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
    public partial class CargoTransfer : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BCO.DataSource = getBranchCorpOffice();
                //BCO.DataTextField = "BranchCorpOfficeName";
                //BCO.DataValueField = "BranchCorpOfficeCode";
                //BCO.DataBind();

                //Destination.DataSource = getBranchCorpOffice();
                //Destination.DataTextField = "BranchCorpOfficeName";
                //Destination.DataValueField = "BranchCorpOfficeCode";
                //Destination.DataBind();
                LoadInit();
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
            LoadBatch();
            LoadPlateNo();
        }

        private void LoadBranchCorpOffice()
        {
            Origin.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            Origin.DataValueField = "BranchCorpOfficeId";
            Origin.DataTextField = "BranchCorpOfficeName";
            Origin.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            Destination.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            Destination.DataValueField = "BranchCorpOfficeId";
            Destination.DataTextField = "BranchCorpOfficeName";
            Destination.DataBind();
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
            rcbRevenueUnit.DataSource = revenueUnitName;
            rcbRevenueUnit.DataTextField = "RevenueUnitName";
            rcbRevenueUnit.DataValueField = "RevenueUnitId";
            rcbRevenueUnit.DataBind();

            RadComboBoxItem item1 = new RadComboBoxItem();
            item1.Text = "All";
            item1.Value = "All";
            rcbRevenueUnit.Items.Add(item1);
            rcbRevenueUnit.SelectedValue = "All";
        }

        private void LoadBatch()
        {
            rcbBatch.DataSource = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "cargotransfer");
            rcbBatch.DataValueField = "BatchId";
            rcbBatch.DataTextField = "BatchName";
            rcbBatch.DataBind();
        }

        private void LoadPlateNo()
        {
            rcbPlateNo.DataSource = BLL.Report.GatewayTransmittal.GetCTPlateNo(getConstr.ConStrCMS);
            rcbPlateNo.DataValueField = "PlateNo";
            rcbPlateNo.DataTextField = "PlateNo";
            rcbPlateNo.DataBind();
        }

        private void populateRevenueUnitNameByBCOId()
        {
            string type = rcbRevenueUnitType.SelectedItem.Text;
            string bco = Origin.SelectedItem.Text;
            Guid bcoId;
            Guid revenueTypeId;
            if (bco != "All" && type =="All")
            {
                bcoId = Guid.Parse(Origin.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCOId(bcoId, getConstr.ConStrCMS).Tables[0];
                rcbRevenueUnit.DataSource = LocationList;
                rcbRevenueUnit.DataTextField = "RevenueUnitName";
                rcbRevenueUnit.DataValueField = "RevenueUnitId";
                rcbRevenueUnit.DataBind();

                RadComboBoxItem item1 = new RadComboBoxItem();
                item1.Text = "All";
                item1.Value = "All";
                rcbRevenueUnit.Items.Add(item1);
                rcbRevenueUnit.SelectedValue = "All";
            }
            else if (type != "All" && bco != "All")
            {
                revenueTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                bcoId = Guid.Parse(Origin.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
                rcbRevenueUnit.DataSource = LocationList;
                rcbRevenueUnit.DataTextField = "RevenueUnitName";
                rcbRevenueUnit.DataValueField = "RevenueUnitId";
                rcbRevenueUnit.DataBind();

                RadComboBoxItem item1 = new RadComboBoxItem();
                item1.Text = "All";
                item1.Value = "All";
                rcbRevenueUnit.Items.Add(item1);
                rcbRevenueUnit.SelectedValue = "All";
            }
        }

        private void populateRevenueUnitName()
        {
            string type = rcbRevenueUnitType.SelectedItem.Text;
            string bco = Origin.SelectedItem.Text;
            Guid revenueTypeId;
            Guid bcoId;
            if (type != "All" && bco != "All")
            {
                revenueTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                bcoId = Guid.Parse(Origin.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
                rcbRevenueUnit.DataSource = LocationList;
                rcbRevenueUnit.DataTextField = "RevenueUnitName";
                rcbRevenueUnit.DataValueField = "RevenueUnitId";
                rcbRevenueUnit.DataBind();

                RadComboBoxItem item1 = new RadComboBoxItem();
                item1.Text = "All";
                item1.Value = "All";
                rcbRevenueUnit.Items.Add(item1);
                rcbRevenueUnit.SelectedValue = "All";
            }
        }


        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getCargoTransfer()
        {
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();

            DateTime? Date1 = new DateTime();
            DateTime? Date2 = new DateTime();

            Guid? originbcoid = new Guid();
            Guid? destbcoid = new Guid();
            Guid? revenueUnitTypeId = new Guid();
            Guid? revenueUnitId = new Guid();
            Guid? batchid = new Guid();
            string plateNoStr = "";

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;

                Date1 = DateFromStr;
                Date2 = DateToStr;
                plateNoStr = rcbPlateNo.SelectedItem.Text;
                //BCO
                if (Origin.SelectedItem.Text == "All")
                {
                    originbcoid = null;
                }
                else
                {
                    originbcoid = Guid.Parse(Origin.SelectedValue.ToString());
                }
                //DEST BCO
                if (Destination.SelectedItem.Text == "All")
                {
                    destbcoid = null;
                }
                else
                {
                    destbcoid = Guid.Parse(Destination.SelectedValue.ToString());
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
                if (rcbRevenueUnit.SelectedItem.Text == "All")
                {
                    revenueUnitId = null;
                }
                else
                {
                    revenueUnitId = Guid.Parse(rcbRevenueUnit.SelectedValue.ToString());
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

            DataSet data = BLL.Report.GatewayTransmittal.GetCargoTransfer(getConstr.ConStrCMS , DateFromStr , DateToStr , originbcoid, destbcoid, revenueUnitTypeId, revenueUnitId, plateNoStr, batchid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
           

            //PRINTING
            GetColumnDataFromDataTable getColumn = new GetColumnDataFromDataTable();
            ReportGlobalModel.Report = "CargoTransfer";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.Origin = Origin.SelectedItem.Text;
            ReportGlobalModel.Destination = Destination.SelectedItem.Text;

            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getCargoTransfer();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getCargoTransfer();
            gridPickupCargo.Rebind();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            gridPickupCargo.Rebind();
        }

        protected void Origin_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCOId();
        }

        protected void rcbRevenueUnitType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //populateRevenueUnitName();
            populateRevenueUnitNameByBCOId();
        }
    }
}