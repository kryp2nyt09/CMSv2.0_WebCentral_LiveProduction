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
using Telerik.Web.UI.ExportInfrastructure;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class BranchAcceptance : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInit();
                //Date.SelectedDate = DateTime.Now;
                //Batch.DataSource = getBatch();
                //Batch.DataTextField = "BatchName";
                //Batch.DataValueField = "BatchName";
                //Batch.DataBind();

                //BCO.DataSource = getBranchCorpOffice();
                //BCO.DataTextField = "BranchCorpOfficeName";
                //BCO.DataValueField = "BranchCorpOfficeCode";
                //BCO.DataBind();

                //Area.DataSource = getArea();
                //Area.DataTextField = "RevenueUnitName";
                //Area.DataValueField = "RevenueUnitName";
                //Area.DataBind();

                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;


            }
        }

        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadRevenueUnitName();
            LoadBatch();
            LoadDriver();
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

        private void LoadDriver()
        {
            DataTable driver = BLL.Batch.GetBranchAcceptanceDriver(getConstr.ConStrCMS).Tables[0];
            rcbDriver.DataSource = driver;
            rcbDriver.DataTextField = "Driver";
            rcbDriver.DataValueField = "Driver";
            rcbDriver.DataBind();
        }

        private void LoadBatch()
        {
            DataTable batchname = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "branchacceptance").Tables[0];
            Batch.DataSource = batchname;
            Batch.DataTextField = "BatchName";
            Batch.DataValueField = "BatchId";
            Batch.DataBind();
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




        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
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

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "branchacceptance");
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBranchAcceptance()
        {
            Guid? bcoid = new Guid();
            Guid? bsoid = new Guid();
            Guid? batchId = new Guid();
            string driverStr = "";
            DateTime DateFromStr = new DateTime();
            DateTime DateToStr = new DateTime();

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                driverStr = rcbDriver.SelectedItem.Text;

                //BCO
                if (BCO.SelectedItem.Text == "All")
                {
                    bcoid = null;
                }
                else
                {
                    bcoid = Guid.Parse(BCO.SelectedValue.ToString());
                }

                //BSO
                if (Area.SelectedItem.Text == "All")
                {
                    bsoid = null;
                }
                else
                {
                    bsoid = Guid.Parse(Area.SelectedValue.ToString());
                }

                //Batch
                if (Batch.SelectedItem.Text == "All")
                {
                    batchId = null;
                }
                else
                {
                    batchId = Guid.Parse(Batch.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                //DateStr = "";
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.BranchAcceptanceReport.GetBranchAcceptance(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid, bsoid, driverStr, batchId);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            
            //FOR PRINTING     
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
           // DateStr = (DateStr == null) ? "All" : DateStr;
           // AreaStr = (AreaStr == null) ? "All" : AreaStr;

            ReportGlobalModel.Report = "BranchAcceptance";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = DateFromStr.ToShortDateString() + "" + "-" + "" + DateToStr.ToShortDateString();
            ReportGlobalModel.Area = Area.SelectedItem.Text;
            ReportGlobalModel.Batch = Batch.SelectedItem.Text;
            ReportGlobalModel.Driver = getColumn.get_Column_DataView(dt, "DRIVER");
            ReportGlobalModel.Checker = getColumn.get_Column_DataView(dt, "CHECKER");
            ReportGlobalModel.PlateNo = "All";
            ReportGlobalModel.ScannedBy = getColumn.get_Column_DataView(dt, "SCANNEDBY");
            
            return dt;
        }

        protected void grid_BranchAcceptance_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            grid_BranchAcceptance.DataSource = getBranchAcceptance();
            grid_BranchAcceptance.Rebind();
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

        protected void grid_BranchAcceptance_PreRender(object sender, EventArgs e)
        {
            grid_BranchAcceptance.Rebind();
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