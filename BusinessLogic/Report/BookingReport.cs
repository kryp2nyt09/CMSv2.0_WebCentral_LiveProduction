using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class BookingReport
    {
        public static DataSet GetBookingReportData(string conSTR, DateTime? dateFrom, DateTime? DateTo, Guid? bcoId, Guid? bookungstatusid)
        {
            return DAL.Reports.BookingReport.GetBookingReportData(conSTR, dateFrom, DateTo, bcoId, bookungstatusid);
        }
    }
}
