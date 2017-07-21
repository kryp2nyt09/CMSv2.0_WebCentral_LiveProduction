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
    public partial class DailyTrip : System.Web.UI.Page
    {
        public static int checker = 0;
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
            LoadRevenueUnitName();
            LoadBatch();
            LoadPaymentMode();
        }

        private void LoadBranchCorpOffice()
        {
            BCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            BCO.DataValueField = "BranchCorpOfficeId";
            BCO.DataTextField = "BranchCorpOfficeName";
            BCO.DataBind();
        }

        private void LoadRevenueUnitName()
        {
            DataTable revenueUnitName = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS).Tables[0];
            Area.DataSource = revenueUnitName;
            Area.DataTextField = "RevenueUnitName";
            Area.DataValueField = "RevenueUnitId";
            Area.DataBind();

            RadComboBoxItem item1 = new RadComboBoxItem();
            item1.Text = "All";
            item1.Value = "All";
            Area.Items.Add(item1);
            Area.SelectedValue = "All";
        }
        private void LoadBatch()
        {
            rcbBatch.DataSource = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "distribution");
            rcbBatch.DataValueField = "BatchId";
            rcbBatch.DataTextField = "BatchName";
            rcbBatch.DataBind();
        }

        private void LoadPaymentMode()
        {
            rcbPaymentMode.DataSource = BLL.PaymentMode.GetPaymentMode(getConstr.ConStrCMS);
            rcbPaymentMode.DataValueField = "PaymentModeId";
            rcbPaymentMode.DataTextField = "PaymentModeName";
            rcbPaymentMode.DataBind();
        }


        private void populateRevenueUnitNameByBCOId()
        {
            string bco = BCO.SelectedItem.Text;
            Guid bcoId;
            if (bco != "All")
            {
                bcoId = Guid.Parse(BCO.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCOId(bcoId, getConstr.ConStrCMS).Tables[0];
                Area.DataSource = LocationList;
                Area.DataTextField = "RevenueUnitName";
                Area.DataValueField = "RevenueUnitId";
                Area.DataBind();

                RadComboBoxItem item1 = new RadComboBoxItem();
                item1.Text = "All";
                item1.Value = "All";
                Area.Items.Add(item1);
                Area.SelectedValue = "All";
            }
        }

        public DataTable getArea()
        {
            string bco = "All";
            try
            {
                bco = BCO.SelectedValue;
            }
            catch (Exception) { }
            DataSet data = BLL.Revenue_Info.GetRevenueByBCOCode(getConstr.ConStrCMS, bco);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        //public DataTable getCityBCO()
        //{
        //    string bco = "All";
        //    try
        //    {
        //        bco = BCO.SelectedValue;
        //    }
        //    catch (Exception) { }
        //    DataSet data = BLL.City.GetCityByBCO(getConstr.ConStrCMS, bco);
        //    DataTable dt = new DataTable();
        //    dt = data.Tables[0];
        //    return dt;
        //}

        public DataTable getDailyTripData()
        {
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();
            
            Guid? bcoid = new Guid();
            Guid? revenueUnitId = new Guid();
            Guid? batchid = new Guid();
            Guid? paymentmodeid = new Guid();
            
            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                //BCO
                if (BCO.SelectedItem.Text == "All")
                {
                    bcoid = null;
                }
                else
                {
                    bcoid = Guid.Parse(BCO.SelectedValue.ToString());
                }

                //revenueUnit
                if (Area.SelectedItem.Text == "All")
                {
                    revenueUnitId = null;
                }
                else
                {
                    revenueUnitId = Guid.Parse(Area.SelectedValue.ToString());
                }

                //batch
                if (rcbBatch.SelectedItem.Text == "All")
                {
                    batchid = null;
                }
                else
                {
                    batchid = Guid.Parse(rcbBatch.SelectedValue.ToString());
                }

                //paymentmode
                if (rcbPaymentMode.SelectedItem.Text == "All")
                {
                    paymentmodeid = null;
                }
                else
                {
                    paymentmodeid = Guid.Parse(rcbPaymentMode.SelectedValue.ToString());
                }


            }   
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
            DataSet data = BLL.Report.DailyTripReport.GetDailyTrip(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid,revenueUnitId,batchid,paymentmodeid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            
            //PRINT
            DataView view = new DataView(dt);

            view.RowFilter = String.Format("PaymentModeName = '{0}'", "PP-PrePaid");
            ReportGlobalModel.table1 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "CAS-Coporate Account Shipper");
            ReportGlobalModel.table3 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "FC-Freight Collect");
            ReportGlobalModel.table2 = view.ToTable();

            view = new DataView(dt);
            view.RowFilter = String.Format("PaymentModeName = '{0}'", "CAC-Corporate Account Consignee");
            ReportGlobalModel.table4 = view.ToTable();

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            //DateStr = (DateStr == null) ? "All" : DateStr;
            //AreaStr = (AreaStr == null) ? "All" : AreaStr;

            ReportGlobalModel.Report = "DailyTrip";
            ReportGlobalModel.Date = DateFromStr.Value.ToShortDateString() + "" + "-" + "" + DateToStr.Value.ToShortDateString();
            ReportGlobalModel.Area = Area.SelectedItem.Text;
            ReportGlobalModel.Driver = getColumn.get_Column_DataView(dt, "Driver");
            ReportGlobalModel.Checker = getColumn.get_Column_DataView(dt, "Checker");
            ReportGlobalModel.PlateNo = getColumn.get_Column_DataView(dt, "PlateNo");
            ReportGlobalModel.ScannedBy = getColumn.get_Column_DataView(dt, "SCANNEDBY");

            return dt;
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_DailyTripReport_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_DailyTripReport.DataSource = getDailyTripData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_DailyTripReport.DataSource = getDailyTripData();
            grid_DailyTripReport.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //Area.Text = "";
            //Area.Items.Clear();
            //Area.AppendDataBoundItems = true;
            //Area.Items.Add("All");
            //Area.SelectedIndex = 0;

            //Area.DataSource = getArea();
            //Area.DataTextField = "RevenueUnitName";
            //Area.DataValueField = "RevenueUnitName";
            //Area.DataBind();
            populateRevenueUnitNameByBCOId();
        }

        protected void grid_DailyTripReport_PreRender(object sender, EventArgs e)
        {
            grid_DailyTripReport.Rebind();
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