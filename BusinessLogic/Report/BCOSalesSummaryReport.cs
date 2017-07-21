using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;
namespace BusinessLogic.Report
{
    public class BCOSalesSummaryReport
    {
        public static DataSet GetBCOSalesSummary(string conSTR , string bco , DateTime? date1 ,DateTime? date2)
        {
            return DAL.Reports.BCOSalesSummary.GetBCOSalesSummary(conSTR , bco , date1, date2);
        }
    }
}
