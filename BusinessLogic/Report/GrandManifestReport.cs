using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class GrandManifestReport
    {
        public static DataSet GetGrandManifestData(string conSTR, DateTime dateFrom, DateTime DateTo, string originbco, string destbco, string servicemode, string paymentmode, string servicetype, string shipmode)
        {
            return DAL.Reports.GrandManifestReport.GetGrandManifestData(conSTR, dateFrom, DateTo, originbco, destbco, servicemode, paymentmode, servicetype, shipmode);
        }
    }
}
