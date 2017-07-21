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
    public partial class Delivered : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Date1.SelectedDate = DateTime.Now;
                Date2.SelectedDate = DateTime.Now;
                LoadInit();
            }
        }

        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadRevenueUnitType();
            LoadRevenueUnitName();
            LoadDeliveryStatus();
            LoadDeliveryBy();
        }

        private void LoadBranchCorpOffice()
        {
            rcbBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBco.DataValueField = "BranchCorpOfficeId";
            rcbBco.DataTextField = "BranchCorpOfficeName";
            rcbBco.DataBind();
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

        private void LoadDeliveryStatus()
        {
            DataTable devStatus = BLL.DeliveryStatus.GetDeliveryStatus(getConstr.ConStrCMS).Tables[0];
            rcbStatus.DataSource = devStatus;
            rcbStatus.DataTextField = "DeliveryStatusName";
            rcbStatus.DataValueField = "DeliveryStatusId";
            rcbStatus.DataBind();
        }

        private void LoadDeliveryBy()
        {
            DataTable deliveredBy = BLL.Employee_Info.GetDeliveredBy(getConstr.ConStrCMS).Tables[0];
            rcbDeliveredBy.DataSource = deliveredBy;
            rcbDeliveredBy.DataTextField = "Name";
            rcbDeliveredBy.DataValueField = "DeliveredById";
            rcbDeliveredBy.DataBind();
        }

        private void populateRevenueUnitNameByBCOId()
        {
            string bco = rcbBco.SelectedItem.Text;
            string type = rcbRevenueUnitType.SelectedItem.Text;
            Guid bcoId;
            Guid revenueTypeId;
            if (bco != "All" && type == "All")
            {
                bcoId = Guid.Parse(rcbBco.SelectedValue.ToString());

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
                bcoId = Guid.Parse(rcbBco.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
                rcbRevenueUnit.DataSource = LocationList;
                rcbRevenueUnit.DataTextField = "RevenueUnitName";
                rcbRevenueUnit.DataValueField = "RevenueUnitId";
                rcbRevenueUnit.DataBind();
            }
        }

        private void populateDeliveredyBCOId()
        {
            string bco = rcbBco.SelectedItem.Text;
            Guid bcoId;
            if (bco != "All")
            {
                bcoId = Guid.Parse(rcbBco.SelectedValue.ToString());

                DataTable deliveredBy = BLL.Employee_Info.GetDeliveredByBcoId(getConstr.ConStrCMS, bcoId).Tables[0];
                rcbDeliveredBy.DataSource = deliveredBy;
                rcbDeliveredBy.DataTextField = "Name";
                rcbDeliveredBy.DataValueField = "DeliveredById";
                rcbDeliveredBy.DataBind();
            }
        }

        private void populateRevenueUnitName()
        {
            string type = rcbRevenueUnitType.SelectedItem.Text;
            string bco = rcbBco.SelectedItem.Text;
            Guid revenueTypeId;
            Guid bcoId;
            if (type != "All" && bco != "All")
            {
                revenueTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                bcoId = Guid.Parse(rcbBco.SelectedValue.ToString());

                DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(revenueTypeId, bcoId, getConstr.ConStrCMS).Tables[0];
                rcbRevenueUnit.DataSource = LocationList;
                rcbRevenueUnit.DataTextField = "RevenueUnitName";
                rcbRevenueUnit.DataValueField = "RevenueUnitId";
                rcbRevenueUnit.DataBind();
            }
        }

        public DataTable getDelivered()
        {
            DateTime? date1 = DateTime.Now;
            DateTime? date2 = DateTime.Now;

            Guid? bcoid = new Guid();
            Guid? revenueunitid = new Guid();
            Guid? deliveredbyid = new Guid();
            Guid? deliverystatusid = new Guid();
            try
            {
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

                //BCO
                if (rcbBco.SelectedItem.Text == "All")
                {
                    bcoid = null;
                }
                else
                {
                    bcoid = Guid.Parse(rcbBco.SelectedValue.ToString());
                }

                //Revenue unit
                if (rcbRevenueUnit.SelectedItem.Text == "All")
                {
                    revenueunitid = null;
                }
                else
                {
                    revenueunitid = Guid.Parse(rcbRevenueUnit.SelectedValue.ToString());
                }

                //Delivered By
                if (rcbDeliveredBy.SelectedItem.Text == "All")
                {
                    deliveredbyid = null;
                }
                else
                {
                    deliveredbyid = Guid.Parse(rcbDeliveredBy.SelectedValue.ToString());
                }

                //Delivery Status
                if (rcbStatus.SelectedItem.Text == "All")
                {
                    deliverystatusid = null;
                }
                else
                {
                    deliverystatusid = Guid.Parse(rcbStatus.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                //date1 = DateTime.Now.AddYears(-1000);
                //date2 = DateTime.Now.AddYears(1000);
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.CargoMonitoring.GetCargoMonitoringDelivered(getConstr.ConStrCMS, date1, date2, bcoid, revenueunitid, deliveredbyid, deliverystatusid);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "Delivered";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = date1.Value.ToShortDateString() + "" + "-" + "" + date2.Value.ToShortDateString();
            ReportGlobalModel.Remarks = "";

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

        protected void rcbBco_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCOId();
            populateDeliveredyBCOId();
        }

        protected void rcbRevenueUnitType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //populateRevenueUnitName();
            populateRevenueUnitNameByBCOId();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Delivered.DataSource = getDelivered();
            grid_Delivered.Rebind();
        }

    }
}