using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Finance.Sales
{
    public partial class SalesPerBCO : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bco.DataSource = getBCO();
                bco.DataTextField = "BranchCorpOfficeCode";
                bco.DataValueField = "BranchCorpOfficeId";
                bco.DataBind();

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

        public DataTable getBCOSalesSummary()
        {
            string bcostr = "All";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            try
            {
                bcostr = bco.SelectedItem.Text.ToString();
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            DataSet data = BLL.Report.BCOSalesSummaryReport.GetBCOSalesSummary(getConstr.ConStrCMS, bcostr, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            //FOR PRINTING     
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();

            date1 = (date1 == DateTime.Now.AddYears(-1000)) ? DateTime.Now : date1;
            date2 = (date2 == DateTime.Now.AddYears(1000)) ? DateTime.Now : date2;

            ReportGlobalModel.Report = "SalesPerBCO";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = bcostr;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();


            return dt;
        }

        protected void grid_BCOSalesSummary_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_BCOSalesSummary.DataSource = getBCOSalesSummary();
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            grid_BCOSalesSummary.DataSource = getBCOSalesSummary();
            grid_BCOSalesSummary.Rebind();
        }

        protected void grid_BCOSalesSummary_PreRender(object sender, EventArgs e)
        {
            grid_BCOSalesSummary.Rebind();
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