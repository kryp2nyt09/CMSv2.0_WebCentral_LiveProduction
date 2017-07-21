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
    public partial class GrandManifest : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitLoad();
                DateFrom.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
            }
        }

        private void InitLoad()
        {
            LoadBranchCopOffice();
            LoadServiceMode();
            LoadPaymentMode();
            LoadServiceType();
            LoadShipMode();
        }

        private void LoadBranchCopOffice()
        {
            rcbOriginBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbOriginBco.DataValueField = "BranchCorpOfficeId";
            rcbOriginBco.DataTextField = "BranchCorpOfficeName";
            rcbOriginBco.DataBind();

            rcbDestinationBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestinationBco.DataValueField = "BranchCorpOfficeId";
            rcbDestinationBco.DataTextField = "BranchCorpOfficeName";
            rcbDestinationBco.DataBind();
        }

        private void LoadServiceMode()
        {
            rcbServiceMode.DataSource = BLL.ServiceMode.GetServiceMode(getConstr.ConStrCMS);
            rcbServiceMode.DataValueField = "ServiceModeId";
            rcbServiceMode.DataTextField = "ServiceModeName";
            rcbServiceMode.DataBind();
        }

        private void LoadPaymentMode()
        {
            rcbPaymentMode.DataSource = BLL.PaymentMode.GetPaymentMode(getConstr.ConStrCMS);
            rcbPaymentMode.DataValueField = "PaymentModeId";
            rcbPaymentMode.DataTextField = "PaymentModeName";
            rcbPaymentMode.DataBind();
        }

        private void LoadServiceType()
        {
            rcbServiceType.DataSource = BLL.ServiceType.GetServiceType(getConstr.ConStrCMS);
            rcbServiceType.DataValueField = "ServiceTypeId";
            rcbServiceType.DataTextField = "ServiceTypeName";
            rcbServiceType.DataBind();
        }

        private void LoadShipMode()
        {
            rcbShipMode.DataSource = BLL.ShipMode.GetShipMode(getConstr.ConStrCMS);
            rcbShipMode.DataValueField = "ShipModeId";
            rcbShipMode.DataTextField = "ShipModeName";
            rcbShipMode.DataBind();
        }

        public DataTable getGrandManifestData()
        {
            string originbco = "";
            string destbco = "";
            string servicemode = "";
            string paymentmode = "";
            string servicetype = "";
            string shipmode = "";

            DateTime dtDateFrom = new DateTime();
            DateTime dtDateTo = new DateTime();
            DataTable dt = new DataTable();
            try
            {
                dtDateFrom = DateFrom.SelectedDate.Value;
                dtDateTo = DateTo.SelectedDate.Value;
                originbco = rcbOriginBco.SelectedItem.Text;
                destbco = rcbDestinationBco.SelectedItem.Text;
                servicemode = rcbServiceMode.SelectedItem.Text;
                paymentmode = rcbPaymentMode.SelectedItem.Text;
                servicetype = rcbServiceType.SelectedItem.Text;
                shipmode = rcbShipMode.SelectedItem.Text;

                DataSet data = BLL.Report.GrandManifestReport.GetGrandManifestData(getConstr.ConStrCMS, dtDateFrom, dtDateTo, originbco, destbco, servicemode, paymentmode, servicetype, shipmode);
                dt = data.Tables[0];

                ReportGlobalModel.Report = "GrandManifest";
                ReportGlobalModel.Origin = originbco;
                ReportGlobalModel.Destination = destbco;
                ReportGlobalModel.ServiceMode = servicemode;
                ReportGlobalModel.PayMode = paymentmode;
                ReportGlobalModel.ServiceType = servicetype;
                ReportGlobalModel.ShipMode = shipmode;
                ReportGlobalModel.table1 = dt;
            }
            catch(Exception ex)
            {

            }

            return dt;
        }

        protected void radGridGrandManifest_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridGrandManifest.DataSource = getGrandManifestData();
        }

        protected void radGridGrandManifest_PreRender(object sender, EventArgs e)
        {
            radGridGrandManifest.Rebind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            radGridGrandManifest.DataSource = getGrandManifestData();
            radGridGrandManifest.Rebind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void radGridGrandManifest_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName || 
                e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
                e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
            {
                radGridGrandManifest.AllowPaging = false;
                getGrandManifestData(); //contains viewstate of datatable to be binded with grid
                ConfigureExport();
            }
            radGridGrandManifest.AllowPaging = true;
        }

        public void ConfigureExport()
        {
            radGridGrandManifest.ExportSettings.IgnorePaging = true;
            radGridGrandManifest.ExportSettings.ExportOnlyData = true;
            //radGridGrandManifest.ExportSettings.Excel.FileExtension = ".xlsx";
            radGridGrandManifest.ExportSettings.OpenInNewWindow = true;
            radGridGrandManifest.ExportSettings.UseItemStyles = true;
            radGridGrandManifest.ExportSettings.FileName = "GrandManifestReport (" + DateTime.Now + ")";
        }

       
    }
}