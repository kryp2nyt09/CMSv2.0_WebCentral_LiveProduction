using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Bundle : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
                LoadInit();


            }
        }

        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadDestBranchCorpOffice();
           
        }

        private void LoadBranchCorpOffice()
        {
            BCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            BCO.DataValueField = "BranchCorpOfficeId";
            BCO.DataTextField = "BranchCorpOfficeName";
            BCO.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            rcbDestBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestBco.DataValueField = "BranchCorpOfficeId";
            rcbDestBco.DataTextField = "BranchCorpOfficeName";
            rcbDestBco.DataBind();
        }


        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }
        public DataTable getBundleNumber()
        {
            DataSet data = BLL.Report.BundleReport.GetBundleNumber(getConstr.ConStrCMS , Date.SelectedDate.Value.ToString("dd MMM yyyy"));
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getCityBCO()
        {
            string bco = "All";
            try
            {
                bco = BCO.SelectedValue;
            }
            catch (Exception) { }
            DataSet data = BLL.City.GetCityByBCO(getConstr.ConStrCMS, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBundle()
        {
            
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();
            Guid? bcoid = new Guid();
            Guid? destbcoid = new Guid();
            string sackNumber = "";

            DateTime? Date1 = new DateTime();
            DateTime? Date2 = new DateTime();

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                sackNumber = txtSackNumber.Text.ToString();

                Date1 = DateFromStr;
                Date2 = DateToStr;

                if (sackNumber != "")
                {
                    DateFromStr = null;
                    DateToStr = null;
                    bcoid = null;
                    destbcoid = null;
                }
                
                //BCO
                if (BCO.SelectedItem.Text == "All")
                {
                    bcoid = null;
                }
                else
                {
                    bcoid = Guid.Parse(BCO.SelectedValue.ToString());
                }
                //DEST BCO
                if (rcbDestBco.SelectedItem.Text == "All")
                {
                    destbcoid = null;
                }
                else
                {
                    destbcoid = Guid.Parse(rcbDestBco.SelectedValue.ToString());
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                //date = "";
            }

            DataSet data = BLL.Report.BundleReport.GetBundle(getConstr.ConStrCMS, DateFromStr,DateToStr,bcoid,destbcoid, sackNumber);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();

            ReportGlobalModel.Report = "Bundle";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.SackNo = getColumn.get_Column_DataView(dt, "SACKNO");
            ReportGlobalModel.Origin = BCO.SelectedItem.Text;
            ReportGlobalModel.Destination = rcbDestBco.SelectedItem.Text;
            ReportGlobalModel.ScannedBy = getColumn.get_Column_DataView(dt, "SCANNEDBY");

            txtSackNumber.Text = "";
            return dt;
        }

        protected void grid_Bundle_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Bundle.DataSource = getBundle();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Bundle.DataSource = getBundle();
            grid_Bundle.Rebind();
        }

        protected void grid_Bundle_PreRender(object sender, EventArgs e)
        {
            grid_Bundle.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //Destination.Text = "";
            //Destination.Items.Clear();
            //Destination.AppendDataBoundItems = true;
            //Destination.Items.Add("All");
            //Destination.SelectedIndex = 0;
            //Destination.DataSource = getCityBCO();
            //Destination.DataTextField = "CityName";
            //Destination.DataValueField = "CityName";
            //Destination.DataBind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //BundleNumber.Text = "";
            //BundleNumber.Items.Clear();
            //BundleNumber.DataSource = getBundleNumber();
            //BundleNumber.DataTextField = "SackNo";
            //BundleNumber.DataValueField = "SackNo";
            //BundleNumber.DataBind();
            //BundleNumber.SelectedIndex = 0;
        }
    }
}