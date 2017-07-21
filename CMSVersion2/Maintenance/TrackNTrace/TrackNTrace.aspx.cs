using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;
using System.Configuration;
namespace CMSVersion2.Maintenance.TrackNTrace
{
    public partial class TrackNTrace : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //{
            //    string usersession = Session["UsernameSession"].ToString();
            //}
            if (!IsPostBack)
            {
                InitLoad();
            }
        }

        private DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }

        private void InitLoad()
        {
            //BRANCH ACCEPTANCE
            LoadBatchBranchAcceptance();
            LoadRemarkBranchAcceptance();

            //GATEWAY TRANSMITTAL
            LoadBatchGatewayTransmittal();
            LoadDestinationGatewayTransmittal();
            LoadAirlinesGatewayTransmittal();
            LoadCommodityTypeGatewayTransmittal();

            //GATEWAY OUTBOUND
            LoadBatchGatewayOutBound();
            LoadRemarkGatewayOutbound();
            LoadAirlinesGatewayOutbound();
            LoadCommodityTypeGatewayOutbound();
            LoadShipModeGatewayOutbound();

            //GATEWAY INBOUND
            LoadRemarkGatewayInbound();
            LoadCommodityTypeGatewayInbound();
            LoadShipModeGatewayInbound();
            LoadOriginGatewayInbound();

            //CARGO TRANSFER
            LoadBatchCargoTransfer();
            LoadAirlinesCargoTransfer();
            LoadStatusCargoTransfer();
            LoadReasonCargoTransfer();

            //SEGREGATION
            LoadCommodityTypeSegregation();
            LoadBatchSegregation();
            LoadRemarkSegregation();

            //BUNDLING
            LoadDestinationBundling();

            //DISTRIBUTION
            LoadBatchDistribution();

            //HOLD CARGO
            LoadStatusHoldCargo();
            LoadReasonHoldCargo();
        }

        #region Data Sources

        #region BranchAcceptance
        private void LoadBatchBranchAcceptance()
        {
            rcbBA_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("branchacceptance", getConstr.ConStrCMS);
            rcbBA_Batch.DataValueField = "BatchID";
            rcbBA_Batch.DataTextField = "BatchName";
            rcbBA_Batch.DataBind();
        }

        private void LoadRemarkBranchAcceptance()
        {
            rcbBA_Remarks.DataSource = DAL.Tracking_BatchName.GetByRemark("branchacceptance", getConstr.ConStrCMS);
            rcbBA_Remarks.DataValueField = "RemarkID";
            rcbBA_Remarks.DataTextField = "RemarkName";
            rcbBA_Remarks.DataBind();
        }

        #endregion

        #region Gateway Transmittal
        private void LoadBatchGatewayTransmittal()
        {
            rcbGT_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("gatewaytransmittal", getConstr.ConStrCMS);
            rcbGT_Batch.DataValueField = "BatchID";
            rcbGT_Batch.DataTextField = "BatchName";
            rcbGT_Batch.DataBind();
        }

        private void LoadDestinationGatewayTransmittal()
        {
            rcbGT_Destination.DataSource = DAL.Tracking_BatchName.Destination(getConstr.ConStrCMS);
            rcbGT_Destination.DataValueField = "BranchCorpOfficeId";
            rcbGT_Destination.DataTextField = "BranchCorpOfficeName";
            rcbGT_Destination.DataBind();
        }

        private void LoadAirlinesGatewayTransmittal()
        {
            rcbGT_Airlines.DataSource = DAL.Tracking_BatchName.Airlines("gatewaytransmittal", getConstr.ConStrCMS);
            rcbGT_Airlines.DataValueField = "AirlineID";
            rcbGT_Airlines.DataTextField = "AirlineName";
            rcbGT_Airlines.DataBind();
        }

        private void LoadCommodityTypeGatewayTransmittal()
        {
            rcbCommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbCommodityType.DataValueField = "CommodityTypeId";
            rcbCommodityType.DataTextField = "CommodityTypeName";
            rcbCommodityType.DataBind();
        }

        #endregion

        #region Gateway Outbound

        private void LoadBatchGatewayOutBound()
        {
            rcbGO_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("gatewayoutbound", getConstr.ConStrCMS);
            rcbGO_Batch.DataValueField = "BatchID";
            rcbGO_Batch.DataTextField = "BatchName";
            rcbGO_Batch.DataBind();
        }

        private void LoadRemarkGatewayOutbound()
        {
            rcbGO_Remarks.DataSource = DAL.Tracking_BatchName.GetByRemark("gatewayoutbound", getConstr.ConStrCMS);
            rcbGO_Remarks.DataValueField = "RemarkID";
            rcbGO_Remarks.DataTextField = "RemarkName";
            rcbGO_Remarks.DataBind();
        }

        private void LoadAirlinesGatewayOutbound()
        {
            rcbGO_Airlines.DataSource = DAL.Tracking_BatchName.Airlines("gatewayoutbound", getConstr.ConStrCMS);
            rcbGO_Airlines.DataValueField = "AirlineID";
            rcbGO_Airlines.DataTextField = "AirlineName";
            rcbGO_Airlines.DataBind();
        }



        private void LoadCommodityTypeGatewayOutbound()
        {
            rcbGO_CommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbGO_CommodityType.DataValueField = "CommodityTypeId";
            rcbGO_CommodityType.DataTextField = "CommodityTypeName";
            rcbGO_CommodityType.DataBind();
        }


        private void LoadShipModeGatewayOutbound()
        {
            rcbShipMode.DataSource = BLL.ShipMode.GetShipMode(getConstr.ConStrCMS);
            rcbShipMode.DataValueField = "ShipModeId";
            rcbShipMode.DataTextField = "ShipModeName";
            rcbShipMode.DataBind();
        }




        #endregion

        #region Cargo Transfer
        private void LoadBatchCargoTransfer()
        {
            rcbCT_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("cargotransfer", getConstr.ConStrCMS);
            rcbCT_Batch.DataValueField = "BatchID";
            rcbCT_Batch.DataTextField = "BatchName";
            rcbCT_Batch.DataBind();
        }
        private void LoadAirlinesCargoTransfer()
        {
            rcbCT_Airlines.DataSource = DAL.Tracking_BatchName.Airlines("cargotransfer", getConstr.ConStrCMS);
            rcbCT_Airlines.DataValueField = "AirlineID";
            rcbCT_Airlines.DataTextField = "AirlineName";
            rcbCT_Airlines.DataBind();
        }
        private void LoadStatusCargoTransfer()
        {
            rcbCT_Status.DataSource = DAL.Tracking_BatchName.Status("cargotransfer", getConstr.ConStrCMS);
            rcbCT_Status.DataValueField = "StatusID";
            rcbCT_Status.DataTextField = "StatusName";
            rcbCT_Status.DataBind();
        }

        private void LoadReasonCargoTransfer()
        {
            rcbCT_Reason.DataSource = DAL.Tracking_BatchName.GetByReasonCode("cargotransfer", getConstr.ConStrCMS);
            rcbCT_Reason.DataValueField = "ReasonID";
            rcbCT_Reason.DataTextField = "ReasonName";
            rcbCT_Reason.DataBind();
        }

        #endregion

        #region Segregation
        private void LoadBatchSegregation()
        {
            rcbSG_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("segregation", getConstr.ConStrCMS);
            rcbSG_Batch.DataValueField = "BatchID";
            rcbSG_Batch.DataTextField = "BatchName";
            rcbSG_Batch.DataBind();
        }

        private void LoadCommodityTypeSegregation()
        {
            rcbSG_CommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbSG_CommodityType.DataValueField = "CommodityTypeId";
            rcbSG_CommodityType.DataTextField = "CommodityTypeName";
            rcbSG_CommodityType.DataBind();
        }

        private void LoadRemarkSegregation()
        {
            rcbSG_Remarks.DataSource = DAL.Tracking_BatchName.GetByRemark("segregation", getConstr.ConStrCMS);
            rcbSG_Remarks.DataValueField = "RemarkID";
            rcbSG_Remarks.DataTextField = "RemarkName";
            rcbSG_Remarks.DataBind();
        }




        #endregion

        #region Gateway Inbound
        private void LoadRemarkGatewayInbound()
        {
            rcbGI_Remarks.DataSource = DAL.Tracking_BatchName.GetByRemark("gatewayinbound", getConstr.ConStrCMS);
            rcbGI_Remarks.DataValueField = "RemarkID";
            rcbGI_Remarks.DataTextField = "RemarkName";
            rcbGI_Remarks.DataBind();
        }

        private void LoadCommodityTypeGatewayInbound()
        {
            rcbGI_CommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            rcbGI_CommodityType.DataValueField = "CommodityTypeId";
            rcbGI_CommodityType.DataTextField = "CommodityTypeName";
            rcbGI_CommodityType.DataBind();
        }

        private void LoadShipModeGatewayInbound()
        {
            rcbGI_ShipMode.DataSource = BLL.ShipMode.GetShipMode(getConstr.ConStrCMS);
            rcbGI_ShipMode.DataValueField = "ShipModeId";
            rcbGI_ShipMode.DataTextField = "ShipModeName";
            rcbGI_ShipMode.DataBind();
        }

        private void LoadOriginGatewayInbound()
        {
            rcbGI_Origin.DataSource = DAL.Tracking_BatchName.Destination(getConstr.ConStrCMS);
            rcbGI_Origin.DataValueField = "BranchCorpOfficeId";
            rcbGI_Origin.DataTextField = "BranchCorpOfficeName";
            rcbGI_Origin.DataBind();
        }
        #endregion

        #region Bundling
        private void LoadDestinationBundling()
        {
            rcbBund_Destination.DataSource = DAL.Tracking_BatchName.Destination(getConstr.ConStrCMS);
            rcbBund_Destination.DataValueField = "BranchCorpOfficeId";
            rcbBund_Destination.DataTextField = "BranchCorpOfficeName";
            rcbBund_Destination.DataBind();
        }
        #endregion

        #region Distribution
        private void LoadBatchDistribution()
        {
            rcbDIS_Batch.DataSource = DAL.Tracking_BatchName.GetByGroup("distribution", getConstr.ConStrCMS);
            rcbDIS_Batch.DataValueField = "BatchID";
            rcbDIS_Batch.DataTextField = "BatchName";
            rcbDIS_Batch.DataBind();
        }
        #endregion

        #region Hold Cargo
        private void LoadStatusHoldCargo()
        {
            rcbHC_Status.DataSource = DAL.Tracking_BatchName.Status("holdcargo", getConstr.ConStrCMS);
            rcbHC_Status.DataValueField = "StatusID";
            rcbHC_Status.DataTextField = "StatusName";
            rcbHC_Status.DataBind();
        }

        private void LoadReasonHoldCargo()
        {
            rcbHC_Reason.DataSource = DAL.Tracking_BatchName.GetByReasonCode("holdcargo", getConstr.ConStrCMS);
            rcbHC_Reason.DataValueField = "ReasonID";
            rcbHC_Reason.DataTextField = "ReasonName";
            rcbHC_Reason.DataBind();
        }
        #endregion

        #endregion


        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            //RadAsyncUpload2.pat
            //string filepathsetting = "C:\\Users\\Ruben J. Cortez III\\Desktop\\FU\\ExpressRate Special Commodity.xlsx";




        }


        #region BRANCH ACCEPTANCE - BATCH EVENTS
        protected void btnBA_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "branchacceptance";
            rwAdd_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            string script = "function f(){$find(\"" + rwAdd_BA_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnBA_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbBA_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + groupdid;
                rwEdit_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_BA_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnBA_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbBA_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbBA_Batch.Items.Clear();
                LoadBatchBranchAcceptance();
            }
        }
        #endregion

        #region BRANCH ACCEPTANCE - REMARKS EVENTS
        protected void btnBA_Remarks_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarksid = "";
            string remarkCode = "branchacceptance";

            rwAdd_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            //rwAdd_BA_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            string script = "function f(){$find(\"" + rwAdd_BA_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnBA_Remarks_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarkId = this.rcbBA_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {

                // rwEdit_BA_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID= + remarkId;
                rwEdit_BA_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID=" + remarkId;
                string script = "function f(){$find(\"" + rwEdit_BA_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnBA_Remarks_Delete_Click(object sender, EventArgs e)
        {
            string remarkId = this.rcbBA_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {
                BLL.Remarks.DeleteRemarkName(new Guid(remarkId), 3, getConstr.ConStrCMS);
                rcbBA_Remarks.Items.Clear();
                LoadRemarkBranchAcceptance();
            }
        }

        #endregion

        #region GATEWAY TRANSMITTAL - BATCH EVENTS
        protected void btnGT_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "gatewaytransmittal";


            rwAdd_GT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_GT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + groupdid;
            string script = "function f(){$find(\"" + rwAdd_GT_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void btnGT_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbGT_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_GT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + groupdid;
                rwEdit_GT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_GT_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }
        protected void btnGT_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbGT_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbBA_Batch.Items.Clear();
                LoadBatchGatewayTransmittal();
            }
        }

        #endregion

        #region GATEWAY TRANSMITTAL - AIRLINES EVENTS
        protected void btnGT_Airlines_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = "";
            string airlineCode = "gatewaytransmittal";

            rwAdd_GT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            //rwAdd_GT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            string script = "function f(){$find(\"" + rwAdd_GT_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGT_Airlines_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = this.rcbGT_Airlines.SelectedItem.Value.ToString();

            if (airlineid != "")
            {
                // rwEdit_GT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID= + groupdid;
                rwEdit_GT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID=" + airlineid;
                string script = "function f(){$find(\"" + rwEdit_GT_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnGT_Airlines_Delete_Click(object sender, EventArgs e)
        {
            string airlineId = this.rcbGT_Airlines.SelectedItem.Value.ToString();

            if (airlineId != "")
            {
                BLL.Airlines.DeleteAirlines(new Guid(airlineId), 3, getConstr.ConStrCMS);
                rcbGT_Airlines.Items.Clear();
                LoadAirlinesGatewayTransmittal();
            }
        }
        #endregion

        #region GATEWAY OUTBOUND - BATCH EVENTS
        protected void btnGO_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "gatewayoutbound";

            rwAdd_GO_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_GO_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            string script = "function f(){$find(\"" + rwAdd_GO_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGO_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbGO_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_GO_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + batchid;
                rwEdit_GO_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_GO_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnGO_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbGO_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbBA_Batch.Items.Clear();
                LoadBatchGatewayOutBound();
            }
        }

        #endregion

        #region GATEWAY OUTBOUND -  REMARKS EVENTS
        protected void btnGO_Remarks_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarksid = "";
            string remarkCode = "gatewayoutbound";

            rwAdd_GO_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            //rwAdd_GO_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            string script = "function f(){$find(\"" + rwAdd_GO_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGO_Remarks_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarkId = this.rcbGO_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {

                // rwEdit_GO_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID= + remarkId;
                rwEdit_GO_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID=" + remarkId;
                string script = "function f(){$find(\"" + rwEdit_GO_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnGO_Remarks_Delete_Click(object sender, EventArgs e)
        {
            string remarkId = this.rcbGO_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {
                BLL.Remarks.DeleteRemarkName(new Guid(remarkId), 3, getConstr.ConStrCMS);
                rcbGO_Remarks.Items.Clear();
                LoadRemarkGatewayOutbound();
            }
        }
        #endregion

        #region GATEWAY OUTBOUND - ARILINES EVENTS
        protected void btnGO_Airlines_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = "";
            string airlineCode = "gatewayoutbound";

            rwAdd_GO_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            //rwAdd_GO_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            string script = "function f(){$find(\"" + rwAdd_GO_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGO_Airlines_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = this.rcbGO_Airlines.SelectedItem.Value.ToString();

            if (airlineid != "")
            {
                // rwEdit_GO_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID= + groupdid;
                rwEdit_GO_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID=" + airlineid;
                string script = "function f(){$find(\"" + rwEdit_GO_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnGO_Airlines_Delete_Click(object sender, EventArgs e)
        {
            string airlineId = this.rcbGO_Airlines.SelectedItem.Value.ToString();

            if (airlineId != "")
            {
                BLL.Airlines.DeleteAirlines(new Guid(airlineId), 3, getConstr.ConStrCMS);
                rcbGO_Airlines.Items.Clear();
                LoadAirlinesGatewayOutbound();
            }
        }

        #endregion

        #region GATEWAY INBOUND -  REMARKS EVENTS
        protected void btnGI_Remarks_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarksid = "";
            string remarkCode = "gatewayinbound";

            rwAdd_GI_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            //rwAdd_GI_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            string script = "function f(){$find(\"" + rwAdd_GI_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnGI_Remarks_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarkId = this.rcbGI_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {

                // rwEdit_GI_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID= + remarkId;
                rwEdit_GI_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID=" + remarkId;
                string script = "function f(){$find(\"" + rwEdit_GI_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnGI_Remarks_Delete_Click(object sender, EventArgs e)
        {
            string remarkId = this.rcbGI_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {
                BLL.Remarks.DeleteRemarkName(new Guid(remarkId), 3, getConstr.ConStrCMS);
                rcbGI_Remarks.Items.Clear();
                LoadRemarkGatewayInbound();
            }
        }
        #endregion

        #region CARGO TRANSFER - BATCH EVENTS
        protected void btnCT_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "cargotransfer";

            rwAdd_CT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_CT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            string script = "function f(){$find(\"" + rwAdd_CT_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCT_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbCT_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_CT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + groupdid;
                rwEdit_CT_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_CT_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnCT_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbCT_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbCT_Batch.Items.Clear();
                LoadBatchCargoTransfer();
            }
        }
        #endregion

        #region CARGO TRANSFER - AIRLINES EVENTS
        protected void btnCT_Airlines_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = "";
            string airlineCode = "cargotransfer";

            rwAdd_CT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            //rwAdd_CT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/AddAirlines.aspx?ID=" + airlineid + "&airlineCode=" + airlineCode;
            string script = "function f(){$find(\"" + rwAdd_CT_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCT_Airlines_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string airlineid = this.rcbCT_Airlines.SelectedItem.Value.ToString();

            if (airlineid != "")
            {
                // rwEdit_CT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID= + groupdid;
                rwEdit_CT_Airlines.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Airlines/EditAirlines.aspx?ID=" + airlineid;
                string script = "function f(){$find(\"" + rwEdit_CT_Airlines.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnCT_Airlines_Delete_Click(object sender, EventArgs e)
        {
            string airlineId = this.rcbCT_Airlines.SelectedItem.Value.ToString();

            if (airlineId != "")
            {
                BLL.Airlines.DeleteAirlines(new Guid(airlineId), 3, getConstr.ConStrCMS);
                rcbCT_Airlines.Items.Clear();
                LoadAirlinesCargoTransfer();
            }
        }
        #endregion

        #region CARGO TRANSFER - STATUS EVENTS
        protected void btnCT_Status_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string statusId = "";
            string statusCode = "cargotransfer";

            rwAdd_CT_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            //rwAdd_CT_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            string script = "function f(){$find(\"" + rwAdd_CT_Status.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCT_Status_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string statusId = this.rcbCT_Status.SelectedItem.Value.ToString();

            if (statusId != "")
            {
                // rwEdit_CT_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/EditStatus.aspx?ID=" + statusId;
                rwEdit_CT_Status.NavigateUrl = "http://" + host + "/Maintenance/CMSMaintenance/UserModal/Status/EditStatus.aspx?ID=" + statusId;
                string script = "function f(){$find(\"" + rwEdit_CT_Status.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnCT_Status_Delete_Click(object sender, EventArgs e)
        {
            string statusId = this.rcbCT_Status.SelectedItem.Value.ToString();

            if (statusId != "")
            {
                int countRowsAffected = BLL.Status.DeleteStatusName(new Guid(statusId), 3, getConstr.ConStrCMS);
                if (countRowsAffected > 0)
                {
                    rcbCT_Status.Items.Clear();
                    LoadStatusCargoTransfer();
                }
                else
                {
                    // RadScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cannot be deleted! It is reference to another table.');", true);
                    string script = "<script>alert('Cannot be deleted! It is reference to another table.')</" + "script>";
                    //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
                    ClientScript.RegisterStartupScript(GetType(), "Alert", script);

                }

            }
        }
        #endregion


        #region CARGO TRANSFER - REASON EVENTS
        protected void btnCT_Reason_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string reasonId = "";
            string statusCode = "cargotransfer";

            rwAdd_CT_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/AddReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
            //rwAdd_CT_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            string script = "function f(){$find(\"" + rwAdd_CT_Reason.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCT_Reason_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string reasonId = this.rcbCT_Reason.SelectedItem.Value.ToString();
            string statusCode = "cargotransfer";
            if (reasonId != "")
            {
                // rwEdit_CT_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/EditReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
                rwEdit_CT_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/EditReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
                string script = "function f(){$find(\"" + rwEdit_CT_Reason.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnCT_Reason_Delete_Click(object sender, EventArgs e)
        {
            string reasonId = this.rcbCT_Reason.SelectedItem.Value.ToString();

            if (reasonId != "")
            {
                BLL.Reason.DeleteReason(new Guid(reasonId), 3, getConstr.ConStrCMS);
                rcbCT_Reason.Items.Clear();
                LoadReasonCargoTransfer();
            }
        }
        #endregion


        #region SEGREGATION - BATCH EVENTS
        protected void btnSG_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "segregation";

            rwAdd_SG_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_SG_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            string script = "function f(){$find(\"" + rwAdd_SG_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnSG_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbSG_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_SG_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + groupdid;
                rwEdit_SG_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_SG_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnSG_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbSG_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbSG_Batch.Items.Clear();
                LoadBatchSegregation();
            }
        }
        #endregion

        #region SEGREGATION -  REMARKS EVENTS
        protected void btnSG_Remarks_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarksid = "";
            string remarkCode = "segregation";

            rwAdd_SG_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            //rwAdd_SG_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/AddRemarks.aspx?ID=" + remarksid + "&remarkCode=" + remarkCode;
            string script = "function f(){$find(\"" + rwAdd_SG_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnSG_Remarks_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string remarkId = this.rcbSG_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {

                // rwEdit_SG_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID= + remarkId;
                rwEdit_SG_Remarks.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Remarks/EditRemarks.aspx?ID=" + remarkId;
                string script = "function f(){$find(\"" + rwEdit_SG_Remarks.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnSG_Remarks_Delete_Click(object sender, EventArgs e)
        {
            string remarkId = this.rcbSG_Remarks.SelectedItem.Value.ToString();

            if (remarkId != "")
            {
                BLL.Remarks.DeleteRemarkName(new Guid(remarkId), 3, getConstr.ConStrCMS);
                rcbSG_Remarks.Items.Clear();
                LoadRemarkSegregation();
            }
        }
        #endregion

        #region DISTRIBUTION - BATCH EVENTS
        protected void btnDIS_Batch_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = "";
            string batchCode = "distribution";

            rwAdd_DIS_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Add.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            //rwAdd_DIS_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/AddBatch.aspx?ID=" + batchid + "&batchCode=" + batchCode;
            string script = "function f(){$find(\"" + rwAdd_DIS_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnDIS_Batch_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string batchid = this.rcbDIS_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {

                // rwEdit_DIS_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/EditBatch.aspx?ID= + groupdid;
                rwEdit_DIS_Batch.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Batch/Edit.aspx?ID=" + batchid;
                string script = "function f(){$find(\"" + rwEdit_DIS_Batch.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnDIS_Batch_Delete_Click(object sender, EventArgs e)
        {
            string batchid = this.rcbDIS_Batch.SelectedItem.Value.ToString();

            if (batchid != "")
            {
                BLL.Batch.DeleteBatchName(new Guid(batchid), 3, getConstr.ConStrCMS);
                rcbDIS_Batch.Items.Clear();
                LoadBatchDistribution();
            }
        }
        #endregion

        #region HOLD CARGO - STATUS EVENTS
        protected void btnHC_Status_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string statusId = "";
            string statusCode = "holdcargo";

            rwAdd_HC_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            //rwAdd_HC_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            string script = "function f(){$find(\"" + rwAdd_HC_Status.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnHC_Status_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string statusId = this.rcbHC_Status.SelectedItem.Value.ToString();

            if (statusId != "")
            {
                // rwEdit_HC_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/EditStatus.aspx?ID=" + statusId;
                rwEdit_HC_Status.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/EditStatus.aspx?ID=" + statusId;
                string script = "function f(){$find(\"" + rwEdit_HC_Status.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnHC_Status_Delete_Click(object sender, EventArgs e)
        {
            string statusId = this.rcbHC_Status.SelectedItem.Value.ToString();

            if (statusId != "")
            {
                int countRowsAffected = BLL.Status.DeleteStatusName(new Guid(statusId), 3, getConstr.ConStrCMS);
                if (countRowsAffected > 0)
                {
                    rcbHC_Status.Items.Clear();
                    LoadStatusHoldCargo();
                }
                else
                {
                    string script = "<script>alert('Cannot be deleted! It is reference to another table.')</" + "script>";
                    ClientScript.RegisterStartupScript(GetType(), "Alert", script);

                }
            }
        }
        #endregion

        #region HOLD CARGO - REASON EVENTS
        protected void btnHC_Reason_Add_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string reasonId = "";
            string statusCode = "holdcargo";

            rwAdd_HC_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/AddReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
            //rwAdd_HC_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Status/AddStatus.aspx?ID=" + statusId + "&statusCode=" + statusCode;
            string script = "function f(){$find(\"" + rwAdd_HC_Reason.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnHC_Reason_Edit_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string reasonId = this.rcbHC_Reason.SelectedItem.Value.ToString();
            string statusCode = "holdcargo";
            if (reasonId != "")
            {
                // rwEdit_HC_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/EditReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
                rwEdit_HC_Reason.NavigateUrl = "http://" + host + "/" + WebPathName + "/Maintenance/CMSMaintenance/UserModal/Reason/EditReason.aspx?ID=" + reasonId + "&StatusCode=" + statusCode;
                string script = "function f(){$find(\"" + rwEdit_HC_Reason.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

            }
        }

        protected void btnHC_Reason_Delete_Click(object sender, EventArgs e)
        {
            string reasonId = this.rcbHC_Reason.SelectedItem.Value.ToString();

            if (reasonId != "")
            {
                BLL.Reason.DeleteReason(new Guid(reasonId), 3, getConstr.ConStrCMS);
                rcbHC_Reason.Items.Clear();
                LoadReasonHoldCargo();
            }
        }
        #endregion
    }
}