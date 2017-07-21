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
using CMSVersion2.Report.Operation.Manifest.Reports;
using CMSVersion2.Models;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Booking : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInit();
                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
            }
            
        }

        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadBookingStatus();
        }

        private void LoadBranchCorpOffice()
        {
            rcbBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBco.DataValueField = "BranchCorpOfficeId";
            rcbBco.DataTextField = "BranchCorpOfficeName";
            rcbBco.DataBind();
        }

        private void LoadBookingStatus()
        {
            rcbStatus.DataSource = BLL.BookingStatus.GetBookingStatus(getConstr.ConStrCMS);
            rcbStatus.DataValueField = "BookingStatusId";
            rcbStatus.DataTextField = "BookingStatusName";
            rcbStatus.DataBind();
        }

        public DataTable getBookingData()
        {
            
            Guid? bcoid = new Guid();
            Guid? bookingstatusid = new Guid();
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();

            DateTime? Date1 = new DateTime();
            DateTime? Date2 = new DateTime();


            try
            {
                
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                
                //BCO
                if (rcbBco.SelectedItem.Text == "All")
                {
                    bcoid = null;
                }
                else
                {
                    bcoid = Guid.Parse(rcbBco.SelectedValue.ToString());
                }
                //BOOKING STATUS
                if (rcbStatus.SelectedItem.Text == "All")
                {
                    bookingstatusid = null;
                }
                else
                {
                    bookingstatusid = Guid.Parse(rcbStatus.SelectedValue.ToString());
                }

                  
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            DataSet data = BLL.Report.BookingReport.GetBookingReportData(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid, bookingstatusid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "Booking";
            ReportGlobalModel.Date = DateFromStr.Value.ToShortDateString() + "" + "-" + "" + DateToStr.Value.ToShortDateString();
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = rcbBco.SelectedItem.Text;
            ReportGlobalModel.Notes = rcbStatus.SelectedItem.Text;
            return dt;
        }

        protected void gridBooking_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gridBooking.DataSource = getBookingData();
        }

        protected void gridBooking_PreRender(object sender, EventArgs e)
        {
            //gridPickupCargo.MasterTableView.GetColumn("CREATEDDATE").Visible = false;
            gridBooking.Rebind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridBooking.DataSource = getBookingData();
            gridBooking.Rebind();
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