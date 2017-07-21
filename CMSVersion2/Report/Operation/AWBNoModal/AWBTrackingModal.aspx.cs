using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.AWBNoModal
{
    public partial class AWBTrackingModal : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //radGridSignature.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {

                }
                else
                {
                    int numberOfRecords = 0;
                    string awbNo = Request.QueryString["Id"].ToString();
                    lblAwbNumber.Value = awbNo;

                    DataTable Data = GetAwbNoInformation(awbNo);
                    numberOfRecords = Data.Rows.Count;

                    if (numberOfRecords > 0)
                    {
                        ReportGlobalModel.Report = "POD";
                        LoadSignature(lblAwbNumber.Value);
                        FillValue(Data);
                    }
                        
                    

                }
            }
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
                        txtCommodity.Text = row["CommodityName"].ToString();

                        txtOrigin.Text = row["Origin"].ToString();
                        txtDestination.Text = row["Destination"].ToString();
                        txtQuantity.Text = row["Quantity"].ToString();

                        ReportGlobalModel.AirwayBillNo = row["AirwayBillNo"].ToString();
                        ReportGlobalModel.ShipperName = row["Shipper"].ToString();
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

        public DataTable GetAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetAwbInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.SignaturePOD(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        private Byte[] DecompressImage(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(new MemoryStream(bytes), CompressionMode.Decompress, true);
            Byte[] buffer = new byte[4095];
            while (true)
            {
                int size = zipStream.Read(buffer, 0, buffer.Length);
                if (size > 0)
                {
                    stream.Write(buffer, 0, size);
                }
                else
                {
                    break;
                }
            }
            zipStream.Close();
            return stream.ToArray();
        }



        public void LoadSignature(string awbNo)
        {
            int count = 0;
            DataTable Data = GetDetailsAwbNoInformation(awbNo);
            count = Data.Rows.Count;
            if(count > 0)
            {
                int counter = 0;
                foreach (DataRow row in Data.Rows)
                {
                    if (counter == 0)
                    {
                        try
                        {
                            string sign = row["Signature"].ToString();
                            string status = row["DeliveryStatusName"].ToString();
                            string date = row["CreatedDate"].ToString();
                            if (!String.IsNullOrEmpty(sign))
                            {
                                byte[] signature = DecompressImage((byte[])row["Signature"]);
                                if (signature != null && signature.Length > 0)
                                {
                                    //byte[] bytes = (byte[])GetDetailsAwbNoInformation(awbNo).Rows[0]["Signature"];
                                    string base64String = Convert.ToBase64String(signature, 0, signature.Length);
                                    Image1.ImageUrl = "data:image/png;base64," + base64String;
                                    string receivedBy = row["ReceivedBy"].ToString();
                                    lblName.Text = receivedBy;
                                    txtDeliveryStatus.Text = status;
                                    txtDatedelivered.Text = date;

                                    ReportGlobalModel.SignedBy = receivedBy;
                                    ReportGlobalModel.DeliveryStatus = status;
                                    ReportGlobalModel.Signature = signature;
                                    ReportGlobalModel.Date = date;


                                }
                            }

                           
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
               

                //string empName = (string)GetDetailsAwbNoInformation(awbNo).Rows[0]["EmployeeName"];
                //lblName.Text = empName;
            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }


        //protected void radGridSignature_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    string awbNo;
        //    awbNo = lblAwbNumber.Value;
        //    if (awbNo != null)
        //    {
        //        try
        //        {
        //            radGridSignature.DataSource = GetDetailsAwbNoInformation(awbNo);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //        }
        //    }
        //}
    }
}