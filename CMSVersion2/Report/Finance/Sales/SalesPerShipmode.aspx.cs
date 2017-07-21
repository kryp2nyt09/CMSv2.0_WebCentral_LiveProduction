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
    public partial class SalesPerShipmode : System.Web.UI.Page
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

        public DataTable getSalesPerShipmode()
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
            DataSet data = BLL.Report.SalesPerShipmodeReport.GetSalesPerShipMode(getConstr.ConStrCMS, bcostr, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            //PRINT
            DataView view = new DataView(dt);

            view.RowFilter = String.Format("ShipModeName = '{0}'", "Direct");
            ReportGlobalModel.table1 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("ShipModeName = '{0}'", "Inter Island");
            ReportGlobalModel.table2 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("ShipModeName = '{0}'", "Transhipment");
            ReportGlobalModel.table3 = view.ToTable();

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            bcostr = (bcostr == null) ? "All" : bcostr;

            date1 = (date1 == DateTime.Now.AddYears(-1000)) ? DateTime.Now : date1;
            date2 = (date2 == DateTime.Now.AddYears(1000)) ? DateTime.Now : date2;
            ReportGlobalModel.Report = "SalesPerShipmode";
            ReportGlobalModel.Branch = bcostr;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();

            return dt;
        }

        protected void grid_SalesPerShipmode_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_SalesPerShipmode.DataSource = getSalesPerShipmode();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_SalesPerShipmode.DataSource = getSalesPerShipmode();
            grid_SalesPerShipmode.Rebind();
        }

        protected void grid_SalesPerShipmode_PreRender(object sender, EventArgs e)
        {
            grid_SalesPerShipmode.Rebind();
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