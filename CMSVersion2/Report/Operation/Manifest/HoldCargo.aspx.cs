using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class HoldCargo : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BCO.DataSource = getBranchCorpOffice();
                BCO.DataTextField = "BranchCorpOfficeName";
                BCO.DataValueField = "BranchCorpOfficeCode";
                BCO.DataBind();

                Date.SelectedDate = DateTime.Now;
                Date1.SelectedDate = DateTime.Now;
            }
           
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getHoldCargoData()
        {
            DateTime DateFromStr = new DateTime();
            DateTime DateToStr = new DateTime();
            string BCOStr = "All";
            try
            {
                BCOStr = BCO.SelectedItem.Text;
                //string DateFrom = Date.SelectedDate.Value.ToString("yyyy/MM/dd");
                //string DateTo = Date1.SelectedDate.Value.ToString("yyyy/MM/dd");
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = Date1.SelectedDate.Value;
                //DateFromStr = DateTime.ParseExact(DateFrom, "yyyy/MM/dd", CultureInfo.InvariantCulture);
               // DateToStr = DateTime.ParseExact(DateTo, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               // DateFromStr = "";
               // DateToStr = "";
            }
            DataSet data = BLL.Report.GatewayTransmittal.GetHoldCargo(getConstr.ConStrCMS, DateFromStr, DateToStr, BCOStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "HoldCargo";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = BCOStr;
            ReportGlobalModel.Date = DateFromStr.ToShortDateString() + "" + "-" +"" + DateToStr.ToShortDateString();

            return dt;
        }



        //public DataTable getGatewayTranmittal()
        //{
        //    DataSet data = BLL.Report.GatewayTransmittal.GetHoldCargo(getConstr.ConStrCMS);
        //    DataTable dt = new DataTable();
        //    dt = data.Tables[0];
        //    return dt;

        //}

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getHoldCargoData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("DATE === > " + Date.SelectedDate);
            gridPickupCargo.DataSource = getHoldCargoData();
            gridPickupCargo.Rebind();
            //setAWB();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}