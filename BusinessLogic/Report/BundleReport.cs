using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class BundleReport
    {
        public static DataSet GetBundle(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? bcoId, Guid? destbcoId, string sackNumber)
        {
            return DAL.Reports.Bundle.GetBundle(conSTR , dateFrom, dateTo, bcoId, destbcoId, sackNumber);
        }

        public static DataSet GetBundleNumber(string conSTR, string date)
        {
            return DAL.Reports.Bundle.GetBundleNumber(conSTR, date);
        }
    }
}
