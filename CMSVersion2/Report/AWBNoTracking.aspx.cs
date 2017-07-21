using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report
{
    public partial class AWBNoTracking : System.Web.UI.Page
    {
        #region Properties
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportGlobalModel.Report = "AWBTracking";
        }

        protected void btnSearchAwbNo_Click(object sender, EventArgs e)
        {
            string awbNo = "";
            int numberOfRecords = 0;
            int deliveryDataRecords = 0;
            if (!String.IsNullOrEmpty(txtAwbNo.Text))
            {
                awbNo = txtAwbNo.Text;
                DataTable Data = GetAwbNoInformation(awbNo);
                DataTable deliveryData = GetDeliveryDetailsInfoByAwbNo(awbNo);
                numberOfRecords = Data.Rows.Count;
                deliveryDataRecords = deliveryData.Rows.Count;

                if (numberOfRecords > 0)
                {
                    ReportGlobalModel.Report = "AWBTracking";
                    Print.Visible = true;
                    #region Fill Value
                    FillValue(Data);
                    radGridAwbNoTracking.DataSource = GetDetailsAwbNoInformation(awbNo);
                    radGridAwbNoTracking.Rebind();
                    radGridAwbNoTracking.DataBind();
                    //lblReceivedBy.Visible = true;
                    //podLink.Visible = true;
                    //podLink.Attributes.Add("onclick", "return handleHyperLinkClick(awbNo)");
                    // signLink.Visible = true;

                    if (deliveryDataRecords > 0)
                    {
                        lblReceivedBy.Visible = true;
                        signLink.Visible = true;
                    }
                    else
                    {
                        lblReceivedBy.Visible = false;
                        signLink.Visible = false;
                    }
                    #endregion
                }
                else
                {
                    txtAwb.Text = "";
                    radGridAwbNoTracking.DataSource = null;
                    radGridAwbNoTracking.Rebind();
                    radGridAwbNoTracking.DataBind();
                    lblReceivedBy.Visible = false;
                    signLink.Visible = false;
                }


            }
        }
        #endregion

        #region Methods
        public DataTable GetAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetAwbInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetDetailsAwbNo(awbNo,2,getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            ReportGlobalModel.table1 = convertdata;
            return convertdata;
        }

        public void FillValue(DataTable Data)
        {
            int counter = 0;
            foreach (DataRow row in Data.Rows)
            {
                if (counter == 0)
                {
                    try
                    {
                        txtAwb.Text = row["AirwayBillNo"].ToString();
                        txtShipper.Text = row["Shipper"].ToString();
                        txtConsignee.Text = row["Consignee"].ToString();
                        txtPayMode.Text = row["PaymentModeName"].ToString();
                        txtCommodity.Text = row["CommodityName"].ToString();

                        txtOrigin.Text = row["Origin"].ToString();
                        txtDestination.Text = row["Destination"].ToString();
                        txtQuantity.Text = row["Quantity"].ToString();

                        ReportGlobalModel.AirwayBillNo = row["AirwayBillNo"].ToString();
                        ReportGlobalModel.ShipperName = row["Shipper"].ToString();
                        ReportGlobalModel.Consignee = row["Consignee"].ToString();
                        ReportGlobalModel.PayMode = row["PaymentModeName"].ToString();
                        ReportGlobalModel.CommodityType = row["CommodityName"].ToString();

                        ReportGlobalModel.Origin = row["Origin"].ToString();
                        ReportGlobalModel.Destination = row["Destination"].ToString();
                        ReportGlobalModel.Quantity = row["Quantity"].ToString();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    counter++;
                }
            }
        }

        public DataTable GetDeliveryDetailsInfoByAwbNo(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetDeliveryDetailsInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }


        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        #endregion
    }
}