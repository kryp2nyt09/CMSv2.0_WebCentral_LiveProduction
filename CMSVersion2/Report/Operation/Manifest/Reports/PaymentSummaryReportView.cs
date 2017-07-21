namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PaymentSummaryReportView.
    /// </summary>
    public partial class PaymentSummaryReportView : Telerik.Reporting.Report
    {
        public PaymentSummaryReportView()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            var objectDataSourcePrepaid = new Telerik.Reporting.ObjectDataSource();
            var objectDataSourceFreight = new Telerik.Reporting.ObjectDataSource();

            List<PaymentSummaryDetails> paymentSummaryDetails = ReportGlobalModel.PaymentSummaryDetails;
            List<PaymentSummaryMainDetails> paymentSummaryMainDetails = ReportGlobalModel.PaymentSummaryMainDetails;

            objectDataSourcePrepaid.DataSource = paymentSummaryDetails.FindAll(x => x.PaymentModeName == "PP-PrePaid");
            objectDataSourceFreight.DataSource = paymentSummaryDetails.FindAll(x => x.PaymentModeName == "FC-Freight Collect");

            tblPrepaid.DataSource = objectDataSourcePrepaid;
            tblFreight.DataSource = objectDataSourceFreight;

            txtBco.Value = ReportGlobalModel.BCO;
            txtArea.Value = ReportGlobalModel.Area;
            txtRemittanceDate.Value = ReportGlobalModel.CollectionDate;
            txtValidatedBy.Value = ReportGlobalModel.ValidatedBy;
            txtTotalCashReceived.Value = ReportGlobalModel.TotalCashReceived.ToString();
            txtTotalCheckReceived.Value = ReportGlobalModel.TotalCheckReceived.ToString();
            txtAmtReceived.Value = ReportGlobalModel.TotalAmountReceived.ToString();
            txttax.Value = ReportGlobalModel.TotalTaxWithheld.ToString();
            txtRemittedBy.Value = ReportGlobalModel.RemittedBy;

            if(ReportGlobalModel.Signature != null)
            {
                pictureBox1.Value = ByteToImage(ReportGlobalModel.Signature);
            }
           

            //foreach (PaymentSummaryMainDetails item in paymentSummaryMainDetails)
            //{
            //    txtRemittedBy.Value = item.RemittedBy;
            //    pictureBox1.Value = ByteToImage(item.Signature);
            //}


        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}