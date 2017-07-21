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
    public partial class GatewayTransmittal : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
                LoadInit();
            }
        }


        private void LoadInit()
        {
            LoadBranchCorpOffice();
            LoadDestBranchCorpOffice();
            LoadDriver();
            LoadGateway();
            LoadBatch();
            LoadCommodityType();
        }

        private void LoadBranchCorpOffice()
        {
            rcbOriginBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbOriginBco.DataValueField = "BranchCorpOfficeId";
            rcbOriginBco.DataTextField = "BranchCorpOfficeName";
            rcbOriginBco.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            rcbDestBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestBco.DataValueField = "BranchCorpOfficeId";
            rcbDestBco.DataTextField = "BranchCorpOfficeName";
            rcbDestBco.DataBind();
        }

        private void LoadDriver()
        {
            rcbDriver.DataSource = BLL.Report.GatewayTransmittal.GetGTDriverList(getConstr.ConStrCMS);
            rcbDriver.DataValueField = "Driver";
            rcbDriver.DataTextField = "Driver";
            rcbDriver.DataBind();
        }

        private void LoadGateway()
        {
            rcbGateway.DataSource = BLL.Report.GatewayTransmittal.GetGatewayList(getConstr.ConStrCMS);
            rcbGateway.DataValueField = "Gateway";
            rcbGateway.DataTextField = "Gateway";
            rcbGateway.DataBind();
        }

        private void LoadBatch()
        {
            rcbBatch.DataSource = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewaytransmittal");
            rcbBatch.DataValueField = "BatchId";
            rcbBatch.DataTextField = "BatchName";
            rcbBatch.DataBind();
        }

        private void LoadCommodityType()
        {
            rcbCommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbCommodityType.DataValueField = "CommodityTypeId";
            rcbCommodityType.DataTextField = "CommodityTypeName";
            rcbCommodityType.DataBind();
        }
        
        //public DataTable getGatewayList()
        //{
        //    string DateStr = "";
        //    try
        //    {
        //        DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
        //    }
        //    catch (Exception) {
        //        DateStr = "";
        //    }

        //    DataSet data = BLL.Report.GatewayTransmittal.GetGatewayList(getConstr.ConStrCMS , DateStr);
        //    DataTable dt = new DataTable();
        //    dt = data.Tables[0];
        //    return dt;
        //}

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewaytransmittal");
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBranchCorpOffice()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getGatewayTranmittal()
        {
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();

            DateTime? Date1 = new DateTime();
            DateTime? Date2 = new DateTime();

            Guid? originbcoid = new Guid();
            Guid? destbcoid = new Guid();
            Guid? batchid = new Guid();
            Guid? commoditytypeid = new Guid();

            string driverStr = "";
            string gatewayStr = "";
            string mawb = "";

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;

                Date1 = DateFromStr;
                Date2 = DateToStr;

                driverStr = rcbDriver.Text.ToString();
                gatewayStr = rcbGateway.Text.ToString();
                mawb = txtMawb.Text.ToString();

                if(mawb != "")
                {
                    originbcoid = null;
                    destbcoid = null;
                    batchid = null;
                    commoditytypeid = null;
                    driverStr = "All";
                    gatewayStr = "All";
                    DateFromStr = null;
                    DateToStr = null;
                }
                else
                {
                    //BCO
                    if (rcbOriginBco.SelectedItem.Text == "All")
                    {
                        originbcoid = null;
                    }
                    else
                    {
                        originbcoid = Guid.Parse(rcbOriginBco.SelectedValue.ToString());
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
                    //Batch
                    if (rcbBatch.SelectedItem.Text == "All")
                    {
                        batchid = null;
                    }
                    else
                    {
                        batchid = Guid.Parse(rcbBatch.SelectedValue.ToString());
                    }
                    //CommoditTYpe
                    if (rcbCommodityType.SelectedItem.Text == "All")
                    {
                        commoditytypeid = null;
                    }
                    else
                    {
                        commoditytypeid = Guid.Parse(rcbCommodityType.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //DateStr = "";
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGWTransmittal(getConstr.ConStrCMS, DateFromStr , DateToStr, originbcoid, destbcoid, batchid,commoditytypeid, driverStr, gatewayStr, mawb);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "GWTransmittal";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.Gateway = gatewayStr;
            ReportGlobalModel.Branch = rcbOriginBco.SelectedItem.Text;
            ReportGlobalModel.Batch = rcbBatch.SelectedItem.Text;

            txtMawb.Text = "";
            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
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

        protected void Date_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //Gateway.Items.Clear();
            //Gateway.DataSource = getGatewayList();
            //Gateway.DataTextField = "Gateway";
            //Gateway.DataValueField = "Gateway";
            //Gateway.SelectedIndex = 0;
            //Gateway.DataBind();
        }
    }
}