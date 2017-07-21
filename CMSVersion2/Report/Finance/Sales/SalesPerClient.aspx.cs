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
    public partial class SalesPerClient : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
                Date1.SelectedDate = DateTime.Now;
                Date2.SelectedDate = DateTime.Now;
                //Client.DataSource = getClient();
                //Client.DataTextField = "Name";
                //Client.DataValueField = "Name";
                //Client.DataBind();
            }
        }

        private void InitLoad()
        {
            LoadClients();
        }

        private void LoadClients()
        {
            rcbClient.DataSource = BLL.Clients.GetClients(getConstr.ConStrCMS);
            rcbClient.DataValueField = "ClientID";
            rcbClient.DataTextField = "Name";
            rcbClient.DataBind();
        }



        public DataTable getClient()
        {
            DataSet data = BLL.Clients.GetClients(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getSalesPerClient()
        {
            string client = "";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;
            try
            {

                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;
            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            try
            {
                client = rcbClient.SelectedItem.Text.ToString();
            }
            catch (Exception)
            {
                client = "";
            }
            DataSet data = BLL.Report.SalesPerClientReport.GetSalesPerClient(getConstr.ConStrCMS, client, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            // FOR PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            client = (client == null) ? "All" : client;
            date1 = (date1 == DateTime.Now.AddYears(-1000)) ? DateTime.Now : date1;
            date2 = (date2 == DateTime.Now.AddYears(1000)) ? DateTime.Now : date2;
            ReportGlobalModel.Report = "SalesPerClient";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Notes = client;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();

            return dt;
        }


        protected void grid_SalesPerClient_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_SalesPerClient.DataSource = getSalesPerClient();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_SalesPerClient.DataSource = getSalesPerClient();
            grid_SalesPerClient.Rebind();
        }

        protected void grid_SalesPerClient_PreRender(object sender, EventArgs e)
        {
            grid_SalesPerClient.Rebind();
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