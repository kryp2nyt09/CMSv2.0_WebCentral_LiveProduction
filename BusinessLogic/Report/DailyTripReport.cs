using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class DailyTripReport
    {
        public static DataSet GetDailyTrip(string conSTR, DateTime? datefrom,DateTime? dateTo, Guid? bcoid,Guid? revenueunitid,Guid? batchid , Guid? paymentmodeid)
        {
            return DAL.Reports.DailyTrip.GetDailyTrip(conSTR, datefrom, dateTo, bcoid, revenueunitid, batchid, paymentmodeid);
        }
    }
}
