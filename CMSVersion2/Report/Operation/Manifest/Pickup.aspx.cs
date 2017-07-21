using CMSVersion2.Models;
using CMSVersion2.Report.Operation.Manifest.Reports;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class Pickup : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInit();


                //BCO.DataSource = getBranchCorpOffice();
                //BCO.DataTextField = "BranchCorpOfficeName";
                //BCO.DataValueField = "BranchCorpOfficeCode";
                //BCO.DataBind();
                
                //Area.DataSource = getArea();
                //Area.DataTextField = "RevenueUnitName";
                //Area.DataValueField = "RevenueUnitName";
                //Area.DataBind();

                //Checker.DataSource = getEmployee();
                //Checker.DataTextField = "EmployeeName";
                //Checker.DataValueField = "EmployeeName";
                //Checker.DataBind();
                //Checker.SelectedIndex = 0;
                //setAWB();

                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
            }
        }

        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadDestBranchCorpOffice();
            LoadRevenueUnitType();
            LoadRevenueUnitName();
        }

        private void LoadBranchCorpOffice()
        {
            BCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            BCO.DataValueField = "BranchCorpOfficeId";
            BCO.DataTextField = "BranchCorpOfficeName";
            BCO.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            rcbDestBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestBco.DataValueField = "BranchCorpOfficeId";
            rcbDestBco.DataTextField = "BranchCorpOfficeName";
            rcbDestBco.DataBind();
        }

        private void LoadRevenueUnitType()
        {
            rcbRevenueUnitType.DataSource = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS);
            rcbRevenueUnitType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueUnitType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueUnitType.DataBind();
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




        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getEmployee()
        {
            DataSet data = BLL.Employee_Info.GetEmployeeNames(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        private void populateRevenueUnitName()
        {
            string type = rcbRevenueUnitType.SelectedItem.Text;
            string bco = BCO.SelectedItem.Text;
            Guid revenueTypeId;
            Guid bcoId;
            if (type != "All" && bco != "All")
            {
                revenueTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                bcoId = Guid.Parse(BCO.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
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

        private void populateRevenueUnitNameByBCOId()
        {
            string type = rcbRevenueUnitType.SelectedItem.Text;
            string bco = BCO.SelectedItem.Text;
            Guid bcoId;
            Guid revenueTypeId;
            if (bco != "All" && type == "All")
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
            else if (type != "All" && bco != "All")
            {
                revenueTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                bcoId = Guid.Parse(BCO.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
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



        public void setAWB()
        {
            //AWB.DataSource = getPickUpCargoData();
            //AWB.DataTextField = "AWBNO";
            //AWB.DataValueField = "AWBNO";
            //AWB.DataBind();
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


        public DataTable getPickUpCargoData()
        {
            string AreaStr = "All";
            string AWBStr = "";
            string DateStr = "";
            string BCOStr = "All";
            string CheckerStr = "";

            Guid? bcoid = new Guid();
            Guid? destbcoid = new Guid();
            Guid? revenueUnitTypeId = new Guid();
            Guid? revenueUnitId = new Guid();
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();
            

            try
            {

                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
                BCOStr = BCO.SelectedItem.Text;
                AreaStr = Area.SelectedItem.Text.ToString();
                //AWBStr = AWB.Text.ToString();
                // CheckerStr = Checker.SelectedItem.Text.ToString();

                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;
                AWBStr = txtAwbNumber.Text.ToString();

                if(AWBStr != "")
                {
                    DateFromStr = null;
                    DateToStr = null;
                    bcoid = null;
                    destbcoid = null;
                    revenueUnitTypeId = null;
                    revenueUnitId = null;
                }
                else
                {

                    //BCO
                    if (BCO.SelectedItem.Text == "All")
                    {
                        bcoid = null;
                    }
                    else
                    {
                        bcoid = Guid.Parse(BCO.SelectedValue.ToString());
                    }
                    //DEST BCO
                    if (rcbDestBco.SelectedItem.Text == "All")
                    {
                        destbcoid = null;
                    }
                    else
                    {
                        destbcoid = Guid.Parse(rcbDestBco.SelectedValue.ToString());
                    }

                    //REVENUE UNIT TYPE
                    if (rcbRevenueUnitType.SelectedItem.Text == "All")
                    {
                        revenueUnitTypeId = null;
                    }
                    else
                    {
                        revenueUnitTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                    }

                    //REVENUE UNIT
                    if (Area.SelectedItem.Text == "All")
                    {
                        revenueUnitId = null;
                    }
                    else
                    {
                        revenueUnitId = Guid.Parse(Area.SelectedValue.ToString());
                    }
                }


            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                //DateStr = "";
            }

            DataSet data = BLL.Report.PickupCargoManifestReport.GetPickupCargoManifest(getConstr.ConStrCMS, DateFromStr, DateToStr, bcoid, destbcoid, revenueUnitTypeId, revenueUnitId, AWBStr);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            
            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "PickUpCargo";
            ReportGlobalModel.Date = DateStr;
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Branch = BCOStr;
            ReportGlobalModel.Area = AreaStr;
            //ReportGlobalModel.Driver = "All"; //getColumn.get_Column_DataView(dt, "DRIVER");
            ReportGlobalModel.Checker = getColumn.get_Column_DataView(dt, "CHECKER"); ;

            txtAwbNumber.Text = "";
            return dt;
        }


        protected void gridPickupCargo_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getPickUpCargoData();

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("DATE === > " + Date.SelectedDate);
            gridPickupCargo.DataSource = getPickUpCargoData();
            gridPickupCargo.Rebind();
            //setAWB();
        }

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            //gridPickupCargo.MasterTableView.GetColumn("CREATEDDATE").Visible = false;
            gridPickupCargo.Rebind();
        }

        protected void BCO_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //Area.Text = "";
            //Area.Items.Clear();
            //Area.AppendDataBoundItems = true;
            //Area.Items.Add("All");
            //Area.SelectedIndex = 0;
            //Area.DataSource = getArea();
            //Area.DataTextField = "RevenueUnitName";
            //Area.DataValueField = "RevenueUnitId";
            //Area.DataBind();
            populateRevenueUnitNameByBCOId();
        }

        protected void rcbRevenueUnitType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //populateRevenueUnitName();
            populateRevenueUnitNameByBCOId();
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