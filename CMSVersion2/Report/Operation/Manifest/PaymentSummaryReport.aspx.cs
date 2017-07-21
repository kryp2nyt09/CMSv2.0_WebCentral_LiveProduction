using CMSVersion2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class PaymentSummaryReport : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
                rdpCollectionDate.SelectedDate = DateTime.Now;
            }
        }


        #region Properties
  
        #endregion
        private void InitLoad()
        {
            LoadBranchCorpOffice();
            LoadRevenueUnitType();
            LoadRevenueUnitName();
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
            rcbArea.DataSource = revenueUnitName;
            rcbArea.DataTextField = "RevenueUnitName";
            rcbArea.DataValueField = "RevenueUnitId";
            rcbArea.DataBind();
        }

        public DataTable getPaymentSummaryData()
        {
            string bco = "";
            string revenuetype = "";
            string revenueunit = "";
            DateTime? collectionDate = new DateTime();
            DataTable dt = new DataTable();
            try
            {
                collectionDate = rdpCollectionDate.SelectedDate.Value;
                bco = rcbBco.SelectedItem.Text;
                revenuetype = rcbRevenueUnitType.SelectedItem.Text;
                revenueunit = rcbArea.SelectedItem.Text;

                DataSet data = BLL.Report.PaymentSummaryReport.GetPaymentSummaryData(collectionDate, bco, revenuetype, revenueunit, getConstr.ConStrCMS);
                dt = data.Tables[0];

                
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        protected void radGridPaymentSummary_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridPaymentSummary.DataSource = getPaymentSummaryData();
        }

        protected void radGridPaymentSummary_PreRender(object sender, EventArgs e)
        {
            radGridPaymentSummary.Rebind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            radGridPaymentSummary.DataSource = getPaymentSummaryData();
            radGridPaymentSummary.Rebind();
        }
        
        private void PrintPaymentSummary(DateTime collectiondate, string bco, string revenuetype, string revenueunit)
        {
            ReportGlobalModel.Report = "PaymentSummaryReport";
            DataSet data = BLL.Report.PaymentSummaryReport.GetPaymentSummaryPrint(collectiondate, bco, revenuetype, revenueunit, getConstr.ConStrCMS);
            DataTable dt = data.Tables[0];

            DataSet main = BLL.Report.PaymentSummaryReport.GetPaymentSummarySignature(collectiondate, bco, revenuetype, revenueunit, getConstr.ConStrCMS);
            DataTable mainDt = main.Tables[0];

            List<PaymentSummaryMainDetails> listMainDetails = new List<PaymentSummaryMainDetails>();
            List<PaymentSummaryDetails> listSubDetails = new List<PaymentSummaryDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PaymentSummaryDetails details = new PaymentSummaryDetails();
                details.AirwayBillNo = dt.Rows[i]["AirwayBillNo"].ToString();
                details.Client = dt.Rows[i]["ClientName"].ToString();
                details.PaymentTypeName = dt.Rows[i]["PaymentTypeName"].ToString();
                details.AmountDue = Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString());
                details.AmountPaid = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                details.TaxWithheld = Convert.ToDecimal(dt.Rows[i]["TaxWithheld"].ToString());
                details.OrNo = dt.Rows[i]["OrNo"].ToString();
                details.PrNo = dt.Rows[i]["PrNo"].ToString();
                details.ValidatedBy = dt.Rows[i]["ValidatedBy"].ToString();
                details.PaymentModeName = dt.Rows[i]["PaymentModeName"].ToString();
                listSubDetails.Add(details);
            }
            int count = 0;
            count = mainDt.Rows.Count;
            if (count > 0)
            {
                int counter = 0;
                foreach (DataRow row in mainDt.Rows)
                {
                    if (counter == 0)
                    {
                        try
                        {
                            string sign = row["Signature"].ToString();
                            string remittedBy = row["RemittedBy"].ToString();
                            ReportGlobalModel.RemittedBy = remittedBy;
                            if (!String.IsNullOrEmpty(sign))
                            {
                                //byte[] signature = DecompressImage((byte[])row["Signature"]);
                                byte[] signature = (byte[])row["Signature"];
                                if (signature != null && signature.Length > 0)
                                {
                                    ReportGlobalModel.Signature = signature;
                                }
                            }

                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }

                //for (int i = 0; i < mdainDt.Rows.Count; i++)
                //{
                //    //if(i == 0)
                //    //{
                //    PaymentSummaryMainDetails maindetails = new PaymentSummaryMainDetails();
                //    //maindetails.RemittedBy = dt.Rows[i]["RemittedBy"].ToString();
                //    maindetails.RemittedBy = "Kim";
                //    //maindetails.Signature = dt.Rows[i]["Signature"].
                //    maindetails.Signature = ((byte[])dt.Rows[i]["Signature"]);
                //    listMainDetails.Add(maindetails);
                //    //}

                //}

                ReportGlobalModel.PaymentSummaryDetails = listSubDetails;
            ReportGlobalModel.PaymentSummaryMainDetails = listMainDetails;
            ReportGlobalModel.TotalCashReceived = listSubDetails.Where(i => i.PaymentTypeName == "Cash").Select(x => x.AmountPaid).Sum();
            ReportGlobalModel.TotalCheckReceived = listSubDetails.Where(i => i.PaymentTypeName == "Check").Select(x => x.AmountPaid).Sum();
            ReportGlobalModel.TotalAmountReceived = ReportGlobalModel.TotalCashReceived + ReportGlobalModel.TotalCheckReceived;
            ReportGlobalModel.TotalTaxWithheld = listSubDetails.Select(x => x.TaxWithheld).Sum();
            ReportGlobalModel.BCO = bco;
            ReportGlobalModel.Area = revenueunit;
            ReportGlobalModel.CollectionDate = collectiondate.ToShortDateString();
            ReportGlobalModel.ValidatedBy = listSubDetails.Select(x => x.ValidatedBy).FirstOrDefault();


            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
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

        protected void radGridPaymentSummary_ItemCommand(object sender, GridCommandEventArgs e)
        {
           if (e.CommandName == "PsPrint")
            {
                int rowNo = e.Item.ItemIndex; //to get the row index
                GridDataItem row = radGridPaymentSummary.Items[rowNo];
                string collectiondate = row["CollectionDate"].Text;
                string bco = row["BranchCorpOfficeName"].Text;
                string revenuetype = row["RevenueUnitTypeName"].Text;
                string revenueunit = row["RevenueUnitName"].Text;
                DateTime date = Convert.ToDateTime(collectiondate);
                PrintPaymentSummary(date, bco, revenuetype, revenueunit);
            }
        }
    }
}