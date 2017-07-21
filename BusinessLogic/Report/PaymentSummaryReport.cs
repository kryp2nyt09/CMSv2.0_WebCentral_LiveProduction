using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class PaymentSummaryReport
    {
        public static DataSet GetPaymentSummaryData(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            return DAL.Reports.PaymentSummaryReport.GetPaymentSummaryData(collectiondate, bco, revenuetype, revenueunit, conSTR);
        }

        public static DataSet GetPaymentSummaryPrint(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            return DAL.Reports.PaymentSummaryReport.GetPaymentSummaryPrint(collectiondate, bco, revenuetype, revenueunit, conSTR);
        }

        public static DataSet GetPaymentSummarySignature(DateTime? collectiondate, string bco, string revenuetype, string revenueunit, string conSTR)
        {
            return DAL.Reports.PaymentSummaryReport.GetPaymentSummarySignature(collectiondate, bco, revenuetype, revenueunit, conSTR);
        }
    }
}
