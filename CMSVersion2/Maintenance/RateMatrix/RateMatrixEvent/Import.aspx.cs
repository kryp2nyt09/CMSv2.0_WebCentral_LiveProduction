using System;
using Telerik.Web.UI;
using Tools = utilities;
using DAL = DataAccess;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace CMSVersion2.Maintenance.RateMatrix.RateMatrix
{
    public partial class Import : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public string ErrorsOnImport = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }
            if (!IsPostBack)
            {
                RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Import Weight Break";
        }

        private DataTable ReadExcelFile(string sheetName, string path)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$] WHERE not ltrim(rtrim(OriginCityName)) = ''";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }


        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            string ID = Request.QueryString["ID"].ToString();
            if (ID != "")
            {
                RadGrid2.DataSource = DAL.RateMatrix.GetWB(new Guid(ID), getConstr.ConStrCMS);
            }
        }

        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            string path = Server.MapPath("~/Upload/");
            e.File.SaveAs(path + e.File.GetName());
        }

        protected void RadButton4_Click(object sender, EventArgs e)
        {
            DataTable dt;

            foreach (UploadedFile f in RadAsyncUpload2.UploadedFiles)
            {
                string path = Server.MapPath("~/Upload/");
                var filename = f.FileName;

                dt = ReadExcelFile("Sheet1", path + filename);

                RadGrid2.DataSource = dt;
                RadGrid2.DataBind();                
            }
        }
        
        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {

        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ID"].ToString();
            if (ID != "")
            {
                RadGrid2.DataSource = DAL.RateMatrix.GetWB(new Guid(ID), getConstr.ConStrCMS);
                RadGrid2.DataBind();
            }

        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {

            string ID = Request.QueryString["ID"].ToString();
            if (ID != "")
            {
               // DAL.RateMatrix.DeleteWB(new Guid(ID), getConstr.ConStrCMS);
                int counter = 1;



                foreach (GridDataItem item in RadGrid2.Items)
                {

                    string OriginCityName = item["OriginCityName"].Text;
                    string DestinationCityName = item["DestinationCityName"].Text;
                    string p1to5Cost = item["1to5Cost"].Text;
                    string p6to49Cost = item["6to49Cost"].Text;
                    string p50to249Cost = item["50to249Cost"].Text;
                    string p250to999Cost = item["250to999Cost"].Text;
                    string p1000to10000Cost = item["1000to10000Cost"].Text;
                    string EffectiveDate = item["EffectiveDate"].Text;

                    string OriginCityId = GetCityId(OriginCityName);
                    string DestinationId = GetCityId(DestinationCityName);
                    if (OriginCityId == "" || DestinationId == "")
                    {
                        ErrorsOnImport = ErrorsOnImport + "Error: Row[" + counter + "]  ";

                    }
                    else
                    {

                        DAL.RateMatrix.InsertWB(new Guid(ID), Convert.ToDecimal(p1to5Cost), Convert.ToDecimal(p6to49Cost),
                            Convert.ToDecimal(p50to249Cost), Convert.ToDecimal(p250to999Cost), Convert.ToDecimal(p1000to10000Cost),
                            Convert.ToDateTime(EffectiveDate), new Guid(OriginCityId), new Guid(DestinationId),
                            new Guid("11111111-1111-1111-1111-111111111111"), getConstr.ConStrCMS);
                    }
                    counter = counter + 1;

                }

                string script = "<script>RefreshParentPage()</" + "script>";
                //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
                ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);

            }
        }

        private string GetCityId(string OriginCityName)
        {
            DataSet ds = DAL.RateMatrix.getCityId(OriginCityName, getConstr.ConStrCMS);

            DataTable dt = ds.Tables[0];
            String OriginCityID = "";
            foreach (DataRow row in dt.Rows)
            {
                OriginCityID = row["CityId"].ToString();
            }

            return OriginCityID;
        }
    }
}