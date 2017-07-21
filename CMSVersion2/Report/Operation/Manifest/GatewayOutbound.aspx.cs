using CMSVersion2.Models;
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
    public partial class GatewayOutbound : System.Web.UI.Page
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

                //Batch.DataSource = getBatch();
                //Batch.DataTextField = "BatchName";
                //Batch.DataValueField = "BatchName";
                //Batch.DataBind();

                //Gateway.DataSource = getGatewayList();
                //Gateway.DataTextField = "Gateway";
                //Gateway.DataValueField = "Gateway";
                //Gateway.SelectedIndex = 0;
                //Gateway.DataBind();
                LoadInit();
                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;

            }

        }

        private void LoadInit()
        {
            LoadOriginBranchCorpOffice();
            LoadDestBranchCorpOffice();
            LoadDriver();
            LoadGateway();
            LoadBatch();
            LoadCommodityType();
        }

        private void LoadOriginBranchCorpOffice()
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

        private void LoadDriver()
        {
            rcbDriver.DataSource = BLL.Report.GatewayTransmittal.GetGODriverList(getConstr.ConStrCMS);
            rcbDriver.DataValueField = "Driver";
            rcbDriver.DataTextField = "Driver";
            rcbDriver.DataBind();
        }

        private void LoadGateway()
        {
            Gateway.DataSource = BLL.Report.GatewayTransmittal.GetGatewayOutBoundList(getConstr.ConStrCMS);
            Gateway.DataValueField = "Gateway";
            Gateway.DataTextField = "Gateway";
            Gateway.DataBind();
        }

        private void LoadBatch()
        {
            Batch.DataSource = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewayoutbound");
            Batch.DataValueField = "BatchId";
            Batch.DataTextField = "BatchName";
            Batch.DataBind();
        }

        private void LoadCommodityType()
        {
            rcbCommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbCommodityType.DataValueField = "CommodityTypeId";
            rcbCommodityType.DataTextField = "CommodityTypeName";
            rcbCommodityType.DataBind();
        }

        public DataTable getGatewayList()
        {
            string DateStr = "";
            try
            {
                DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
            }
            catch (Exception)
            {
                DateStr = "";
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGatewayOutBoundList(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        public DataTable getBatch()
        {
            DataSet data = BLL.Batch.GetBatchByBatchCode(getConstr.ConStrCMS, "gatewayoutbound");
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

        public DataTable getGatewayOutbound()
        {
            DateTime? DateFromStr = new DateTime();
            DateTime? DateToStr = new DateTime();

            DateTime? Date1 = new DateTime();
            DateTime? Date2= new DateTime();

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

                driverStr = rcbDriver.SelectedItem.Text;
                gatewayStr = Gateway.SelectedItem.Text;
                mawb = txtMawb.Text;

                if(mawb != "")
                {
                    DateFromStr = null;
                    DateToStr = null;
                    originbcoid = null;
                    destbcoid = null;
                    batchid = null;
                    commoditytypeid = null;
                    driverStr = "All";
                    gatewayStr = "All";
                }
                else
                {
                    //ORIGIN BCO
                    if (BCO.SelectedItem.Text == "All")
                    {
                        originbcoid = null;
                    }
                    else
                    {
                        originbcoid = Guid.Parse(BCO.SelectedValue.ToString());
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
                    if (Batch.SelectedItem.Text == "All")
                    {
                        batchid = null;
                    }
                    else
                    {
                        batchid = Guid.Parse(Batch.SelectedValue.ToString());
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
                Console.WriteLine(ex.ToString());
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGWOutbound(getConstr.ConStrCMS, DateFromStr,DateToStr,originbcoid,destbcoid,driverStr,gatewayStr,batchid,commoditytypeid,mawb);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "GWOutbound";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.Gateway = Gateway.SelectedItem.Text;
            //ReportGlobalModel.Branch = BCOStr;
            //ReportGlobalModel.Batch = BatchStr;

            txtMawb.Text = "";
            return dt;

        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //gridPickupCargo.DataSource = getGatewayTranmittal();
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
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

        protected void Search_Click(object sender, EventArgs e)
        {
            gridGatewayOutbound.DataSource = getGatewayOutbound();
            gridGatewayOutbound.Rebind();
        }

        protected void Print_Click1(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void gridGatewayOutbound_PreRender(object sender, EventArgs e)
        {
            gridGatewayOutbound.Rebind();
        }

        protected void gridGatewayOutbound_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
        {
            gridGatewayOutbound.DataSource = getGatewayOutbound();
        }
    }
}