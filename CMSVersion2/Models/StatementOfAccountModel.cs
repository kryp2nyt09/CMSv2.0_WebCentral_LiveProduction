using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSVersion2.Models
{
    public class StatementOfAccountModelReportModel
    {
        public string AccountNo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string StatementOfAccountNo { get; set; }
        public string SoaDate { get; set; }
        public string SoaDueDate { get; set; }
        public string BillPeriodCovered { get; set; }
        
        //PreviousBill
        public decimal PreviousBillAmount { get; set; }
        public decimal PreviousBillAdjustment { get; set; }
        public decimal PreviousBillPayment { get; set; }
        public decimal TotalPreviousBalance { get; set; }

        //Current Bill
        public decimal CurrentBillAmount { get; set; }
        public decimal CurrentSurcharge { get; set; }
        public decimal TotalCurrentBill { get; set; }
        
        //Total Amount Due
        public decimal TotalAmountDue { get; set; }

        //DataTables
        public DataTable CurrentChargesDataTable { get; set; }
        public DataTable PreviousBillDataTable { get; set; }
        public DataTable PaymentDetailsDataTable { get; set; }
        
    }
}
