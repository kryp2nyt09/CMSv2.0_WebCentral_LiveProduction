using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Report.Finance
{
    public partial class Collections1 : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BCO.DataSource = getBCO();
                BCO.DataTextField = "BranchCorpOfficeCode";
                BCO.DataValueField = "BranchCorpOfficeId";
                BCO.DataBind();

                REVENUETYPE.DataSource = getRevenue();
                REVENUETYPE.DataTextField = "RevenueUnitTypeName";
                REVENUETYPE.DataValueField = "RevenueUnitTypeName";
                REVENUETYPE.DataBind();

                Date1.SelectedDate = DateTime.Now;
                Date2.SelectedDate = DateTime.Now;
            }
        }

        public DataTable getBCO()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getRevenue()
        {
            DataSet data = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getCollection()
        {
            string bcostr = "All";
            string type = "All";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            try
            {
                bcostr = BCO.SelectedItem.Text.ToString();
                type = REVENUETYPE.SelectedItem.Text.ToString();
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-100);
                date2 = DateTime.Now.AddYears(100);
            }
            DataSet data = BLL.Report.CollectionReport.GetCollection(getConstr.ConStrCMS, bcostr, type, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            ReportGlobalModel.Report = "Collection";
            ReportGlobalModel.table1 = dt;

            return dt;
        }

        protected void grid_Collection_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Collection.DataSource = getCollection();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Collection.DataSource = getCollection();
            grid_Collection.Rebind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}