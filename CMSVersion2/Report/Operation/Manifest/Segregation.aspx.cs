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
    public partial class Segregation : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //DataView view = new DataView(getSegregationData());
                //DataTable distinctValuesDriver = view.ToTable(true, "Driver");
                //Driver.DataSource = distinctValuesDriver;
                //Driver.DataTextField = "Driver";
                //Driver.DataValueField = "Driver";
                //Driver.DataBind();
                //DataTable distinctValuesChecker = view.ToTable(true, "Checker");
                ////Checker.DataSource = distinctValuesChecker;
                ////Checker.DataTextField = "Checker";
                ////Checker.DataValueField = "Checker";
                ////Checker.DataBind();

                //PlateNo.DataSource = getSegregationData();
                //PlateNo.DataTextField = "PlateNo";
                //PlateNo.DataValueField = "PlateNo";
                //PlateNo.DataBind();

                //BCO.DataSource = getBranchCorpOffice();
                //BCO.DataTextField = "BranchCorpOfficeName";
                //BCO.DataValueField = "BranchCorpOfficeCode";
                //BCO.DataBind();

                //Destination.DataSource = getCityBCO();
                //Destination.DataTextField = "CityName";
                //Destination.DataValueField = "CityName";
                //Destination.DataBind();
                LoadInit();
                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
            }
        }

        private void LoadInit()
        {
            LoadOriginBranchCorpOffice();
            LoadDestBranchCorpOffice();
            LoadPlateNo();
            LoadDriver();
            LoadBatch();
        }

        private void LoadOriginBranchCorpOffice()
        {
            rcbOriginBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbOriginBco.DataValueField = "BranchCorpOfficeId";
            rcbOriginBco.DataTextField = "BranchCorpOfficeName";
            rcbOriginBco.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            rcbDestinationBCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestinationBCO.DataValueField = "BranchCorpOfficeId";
            rcbDestinationBCO.DataTextField = "BranchCorpOfficeName";
            rcbDestinationBCO.DataBind();
        }

        private void LoadDriver()
        {
            Driver.DataSource = BLL.Report.GatewayTransmittal.GetSGDriverList(getConstr.ConStrCMS);
            Driver.DataValueField = "Driver";
            Driver.DataTextField = "Driver";
            Driver.DataBind();
        }

        private void LoadPlateNo()
        {
            PlateNo.DataSource = BLL.Report.GatewayTransmittal.GetCTPlateNo(getConstr.ConStrCMS);
            PlateNo.DataValueField = "PlateNo";
            PlateNo.DataTextField = "PlateNo";
            PlateNo.DataBind();
        }

        private void LoadBatch()
        {
            rcbBatch.DataSource = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "segregation");
            rcbBatch.DataValueField = "BatchId";
            rcbBatch.DataTextField = "BatchName";
            rcbBatch.DataBind();
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

        public DataTable getBranchCorpOffice()
        {

            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getSegregationData()
        {
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();

            DateTime? Date1 = new DateTime();
            DateTime? Date2 = new DateTime();

            Guid? destbcoid = new Guid();
            Guid? originbcoid = new Guid();
            Guid? batchid = new Guid();
            string driverStr = "";
            string plateNoStr = "";
            string CheckerStr = "";
            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;

                Date1 = DateFromStr;
                Date2 = DateToStr;
                driverStr = Driver.SelectedItem.Text;
                plateNoStr = PlateNo.SelectedItem.Text;

                //ORIGIN BCO
                if (rcbOriginBco.SelectedItem.Text == "All")
                {
                    originbcoid = null;
                }
                else
                {
                    originbcoid = Guid.Parse(rcbOriginBco.SelectedValue.ToString());
                }
                //DEST BCO
                if (rcbDestinationBCO.SelectedItem.Text == "All")
                {
                    destbcoid = null;
                }
                else
                {
                    destbcoid = Guid.Parse(rcbDestinationBCO.SelectedValue.ToString());
                }
                //Batch
                if (rcbBatch.SelectedItem.Text == "All")
                {
                    batchid = null;
                }
                else
                {
                    batchid = Guid.Parse(rcbBatch.SelectedValue.ToString());
                }
            }
            catch (Exception)
            {
               
            }
            DataSet data = BLL.Report.SegregationReport.GetSegregation(getConstr.ConStrCMS, DateFromStr, DateToStr, destbcoid, originbcoid, driverStr, plateNoStr, batchid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];


            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();

            //DateStr = (DateStr == null) ? "All" : DateStr;
            //DriverStr = (DriverStr == null) ? "All" : DriverStr;
            //CheckerStr = (CheckerStr == null) ? "All" : CheckerStr;
            //PlateNoStr = (PlateNoStr == null) ? "All" : PlateNoStr;

            ReportGlobalModel.Report = "Segregation";
            ReportGlobalModel.table1 = dt;

            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.Driver = driverStr;
            ReportGlobalModel.Checker = CheckerStr;
            ReportGlobalModel.PlateNo = plateNoStr;


            return dt;
        }

        protected void grid_Segregation_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Segregation.DataSource = getSegregationData();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Segregation.DataSource = getSegregationData();
            grid_Segregation.Rebind();
        }

        protected void grid_Segregation_PreRender(object sender, EventArgs e)
        {
            grid_Segregation.Rebind();
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

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}