
namespace CMSVersion2.StatementOfAccountPrint
{
    using CMSVersion2.Models;

    /// <summary>
    /// Summary description for SOAReport.
    /// </summary>
    public partial class SOAReport : Telerik.Reporting.Report
    {
        public  StatementOfAccountModelReportModel Model { get; set; }
        public SOAReport(StatementOfAccountModelReportModel reportModel)
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
            this.txtPreviousBillAmount.Value = reportModel.PreviousBillAmount.ToString("0.00");
            this.txtPreviousBillAdjustment.Value = reportModel.PreviousBillAdjustment.ToString("0.00");
            this.txtPreviousBillPayment.Value = reportModel.PreviousBillPayment.ToString("0.00");
            this.txtPreviousBillBalance.Value = reportModel.TotalPreviousBalance.ToString("0.00");

            //Current Charges
            this.txtCurrentCharge.Value = reportModel.CurrentBillAmount.ToString("0.00");
            this.txtSurcharge.Value = reportModel.CurrentSurcharge.ToString("0.00");
            this.txtTotalCurrentCharge.Value = reportModel.TotalCurrentBill.ToString("0.00");

            //Total Amount Due
            this.txtTotalAmountDue.Value = reportModel.TotalAmountDue.ToString("0.00");
            this.txtTotalAmountDue2.Value = reportModel.TotalAmountDue.ToString("0.00");

            //Footer
            this.txtAccountNo.Value = reportModel.AccountNo;
            this.txtCompanyName2.Value = reportModel.CompanyName;
            this.txtCompanyAddress2.Value = reportModel.CompanyAddress;

            this.txtSoaNumber2.Value = reportModel.StatementOfAccountNo;
            this.txtSoaDate2.Value = reportModel.SoaDate;
            this.txtBillPeriod2.Value = reportModel.BillPeriodCovered;
            this.txtSoaDueDate2.Value = reportModel.SoaDueDate;

            //Next Page
            this.txtSoaNumber3.Value = reportModel.StatementOfAccountNo;
            this.txtSoaDate3.Value = reportModel.SoaDate;
            this.txtBillPeriod3.Value = reportModel.BillPeriodCovered;

            //Tables
            this.table1.DataSource = reportModel.CurrentChargesDataTable;
            this.table2.DataSource = reportModel.PreviousBillDataTable;
            this.table3.DataSource = reportModel.PaymentDetailsDataTable;
           

        }
    }
}