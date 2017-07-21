using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.CargoMonitoring
{
    public partial class Offloaded : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Date1.SelectedDate = DateTime.Now;
                Date2.SelectedDate = DateTime.Now;
            }

        }
        public DataTable getDelivered()
        {
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
            DataSet data = BLL.Report.CargoMonitoring.GetCargoMonitoringOffloaded(getConstr.ConStrCMS, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            ReportGlobalModel.Report = "Offloaded";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();
            return dt;
        }


        protected void grid_Delivered_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Delivered.DataSource = getDelivered();
        }

        protected void grid_Delivered_PreRender(object sender, EventArgs e)
        {
            grid_Delivered.DataSource = getDelivered();
            grid_Delivered.Rebind();
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