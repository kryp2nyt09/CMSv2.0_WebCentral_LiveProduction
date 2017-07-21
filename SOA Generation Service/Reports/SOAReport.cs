
namespace SOA_Generation_Service.Report
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for SOAReport.
    /// </summary>
    public partial class SOAReport : Telerik.Reporting.Report
    {
        public ReportModel.StatementOfAccountModelReportModel Model { get; set; }
        public SOAReport(ReportModel.StatementOfAccountModelReportModel reportModel)
        {
            
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call

            //Barcode

            
            this.barcode1.Value = reportModel.StatementOfAccountNo;
            this.barcode2.Value = reportModel.StatementOfAccountNo;

            this.txtAccountNo.Value = reportModel.AccountNo;
            this.txtCompanyName.Value = reportModel.CompanyName;
            this.txtCompanyAddress.Value = reportModel.CompanyAddress;
            this.txtSoaNumber.Value = reportModel.StatementOfAccountNo;
            this.txtSoaDate.Value = reportModel.SoaDate;
            this.txtBillingPeriod.Value = reportModel.BillPeriodCovered;
            this.txtSoaDue.Value = reportModel.SoaDueDate;

            //Current PreviousBill
            this.txtPreviousBillAmount.Value = reportModel.PreviousBillAmount.ToString("C");
            this.txtPreviousBillAdjustment.Value =  reportModel.PreviousBillAdjustment.ToString("C");
            
            this.txtPreviousBillPayment.Value = reportModel.PreviousBillPayment.ToString("C");
            this.txtPreviousBillBalance.Value = reportModel.TotalPreviousBalance.ToString("C");

            //Current Charges
            this.txtCurrentCharge.Value = reportModel.CurrentBillAmount.ToString("C");
            this.txtSurcharge.Value = reportModel.CurrentSurcharge.ToString("C");
            this.txtTotalCurrentCharge.Value = reportModel.TotalCurrentBill.ToString("C");

            //Total Amount Due
            this.txtTotalAmountDue.Value = reportModel.TotalAmountDue.ToString("C");
            this.txtTotalAmountDue2.Value = reportModel.TotalAmountDue.ToString("C");

            //Footer
            this.txtAccountNo.Value = reportModel.AccountNo;
            this.txtCompanyName2.Value = reportModel.CompanyName;
            this.txtCompanyAddress2.Value = reportModel.CompanyAddress;

            this.txtSoaNumber2.Value = reportModel.StatementOfAccountNo;
            this.txtSoaDate2.Value = reportModel.SoaDate;
            this.txtBillPeriod2.Value = reportModel.BillPeriodCovered;
            this.txtSoaDueDate2.Value = reportModel.SoaDueDate;

            this.txtFooterSoaNumber.Value = reportModel.StatementOfAccountNo;
            this.txtPage.Value = "=PageNumber + ' of ' + PageCount";

            //Next Page
            this.txtSoaNumber3.Value = reportModel.StatementOfAccountNo;
            this.txtSoaDate3.Value = reportModel.SoaDate;
            this.txtBillPeriod3.Value = reportModel.BillPeriodCovered;

            //Tables
            this.table1.DataSource = reportModel.CurrentChargesDataTable;
            this.table2.DataSource = reportModel.PreviousBillDataTable;
            this.table3.DataSource = reportModel.PaymentDetailsDataTable;
            this.table4.DataSource = reportModel.SoaAdjustmentDetailsDataTable;
            this.table5.DataSource = reportModel.AirwayBillAdjustmentDetailsDataTable;

        }
    }
}