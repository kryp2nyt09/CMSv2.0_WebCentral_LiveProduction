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
    public partial class GatewayInbound : System.Web.UI.Page
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

                //Gateway.DataSource = getGatewayList();
                //Gateway.DataTextField = "Gateway";
                //Gateway.DataValueField = "Gateway";
                //Gateway.SelectedIndex = 0;
                //Gateway.DataBind();

                //ComType.DataSource = getComType();
                //ComType.DataTextField = "CommodityTypeName";
                //ComType.DataValueField = "CommodityTypeName";
                //ComType.DataBind();

                Date.SelectedDate = DateTime.Now;
                DateTo.SelectedDate = DateTime.Now;
                LoadInit();
            }
        }

        private void LoadInit()
        {
            LoadOriginBranchCorpOffice();
            LoadDestBranchCorpOffice();
            LoadGateway();
            LoadCommodityType();
            LoadFlightNumber();
        }
        private void LoadOriginBranchCorpOffice()
        {
            rcbOrigin.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbOrigin.DataValueField = "BranchCorpOfficeId";
            rcbOrigin.DataTextField = "BranchCorpOfficeName";
            rcbOrigin.DataBind();
        }

        private void LoadDestBranchCorpOffice()
        {
            rcbDestBCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestBCO.DataValueField = "BranchCorpOfficeId";
            rcbDestBCO.DataTextField = "BranchCorpOfficeName";
            rcbDestBCO.DataBind();
        }

        private void LoadGateway()
        {
            Gateway.DataSource = BLL.Report.GatewayTransmittal.GetGatewayInBoundList(getConstr.ConStrCMS);
            Gateway.DataValueField = "Gateway";
            Gateway.DataTextField = "Gateway";
            Gateway.DataBind();
        }

        private void LoadCommodityType()
        {
            ComType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
            ComType.DataValueField = "CommodityTypeId";
            ComType.DataTextField = "CommodityTypeName";
            ComType.DataBind();
        }

        private void LoadFlightNumber()
        {
            rcbFlightNo.DataSource = BLL.Report.GatewayTransmittal.GetGIFlightNumberList(getConstr.ConStrCMS);
            rcbFlightNo.DataValueField = "FlightNumber";
            rcbFlightNo.DataTextField = "FlightNumber";
            rcbFlightNo.DataBind();
        }

        //public DataTable getGatewayList()
        //{
        //    string DateStr = "";
        //    try
        //    {
        //        DateStr = Date.SelectedDate.Value.ToString("dd MMM yyyy");
        //    }
        //    catch (Exception)
        //    {
        //        DateStr = "";
        //    }

        //    DataSet data = BLL.Report.GatewayTransmittal.GetGatewayInBoundList(getConstr.ConStrCMS, DateStr);
        //    DataTable dt = new DataTable();
        //    dt = data.Tables[0];
        //    return dt;
        //}

        public DataTable getComType()
        {
            DataSet data = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
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
            Guid? commoditytypeid = new Guid();
            string gatewayStr = "All";
            string flightNumberStr = "All";
            string mawb = "";

            try
            {
                DateFromStr = Date.SelectedDate.Value;
                DateToStr = DateTo.SelectedDate.Value;

                Date1 = DateFromStr;
                Date2 = DateToStr;
                gatewayStr = Gateway.SelectedItem.Text;
                flightNumberStr = rcbFlightNo.SelectedItem.Text;
                mawb = txtMawb.Text;

                if (mawb != "")
                {
                    DateFromStr = null;
                    DateToStr = null;
                    originbcoid = null;
                    destbcoid = null;
                    commoditytypeid = null;
                    flightNumberStr = "All";
                    gatewayStr = "All";
                }
                else
                {
                    //ORIGIN BCO
                    if (rcbOrigin.SelectedItem.Text == "All")
                    {
                        originbcoid = null;
                    }
                    else
                    {
                        originbcoid = Guid.Parse(rcbOrigin.SelectedValue.ToString());
                    }
                    //DEST BCO
                    if (rcbDestBCO.SelectedItem.Text == "All")
                    {
                        destbcoid = null;
                    }
                    else
                    {
                        destbcoid = Guid.Parse(rcbDestBCO.SelectedValue.ToString());
                    }
                    //CommoditTYpe
                    if (ComType.SelectedItem.Text == "All")
                    {
                        commoditytypeid = null;
                    }
                    else
                    {
                        commoditytypeid = Guid.Parse(ComType.SelectedValue.ToString());
                    }
                }

            }
            catch (Exception)
            {
                
            }

            DataSet data = BLL.Report.GatewayTransmittal.GetGWInbound(getConstr.ConStrCMS, DateFromStr,DateToStr,destbcoid,originbcoid,gatewayStr,commoditytypeid,flightNumberStr,mawb);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            ReportGlobalModel.Report = "GWInbound";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = Date1.Value.ToShortDateString() + "" + "-" + "" + Date2.Value.ToShortDateString();
            ReportGlobalModel.Gateway = Gateway.SelectedItem.Text;
            ReportGlobalModel.CommodityType = ComType.SelectedItem.Text;

            txtMawb.Text = "";
            return dt;
        }

        protected void gridPickupCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
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

        protected void gridPickupCargo_PreRender(object sender, EventArgs e)
        {
            gridPickupCargo.Rebind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            gridPickupCargo.DataSource = getGatewayTranmittal();
            gridPickupCargo.Rebind();
        }
    }
}