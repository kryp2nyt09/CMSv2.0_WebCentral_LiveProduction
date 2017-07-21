using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Finance.Sales
{
    public partial class SalesPerUserLevel : System.Web.UI.Page
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

        public DataTable getSalesPerClient()
        {
            string bcostr = "All";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            try
            {
                bcostr = BCO.SelectedItem.Text.ToString();
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            DataSet data = BLL.Report.SalesPerUserLevelReport.GetSalesPerUserLevel(getConstr.ConStrCMS, bcostr, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            date1 = (date1 == DateTime.Now.AddYears(-1000)) ? DateTime.Now : date1;
            date2 = (date2 == DateTime.Now.AddYears(1000)) ? DateTime.Now : date2;

            ReportGlobalModel.Report = "SalesPerUserLevel";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = bcostr;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();

            return dt;
        }

        protected void grid_SalesPerUserLevel_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_SalesPerUserLevel.DataSource = getSalesPerClient();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_SalesPerUserLevel.DataSource = getSalesPerClient();
            grid_SalesPerUserLevel.Rebind();
        }

        protected void grid_SalesPerUserLevel_PreRender(object sender, EventArgs e)
        {
            grid_SalesPerUserLevel.Rebind();
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