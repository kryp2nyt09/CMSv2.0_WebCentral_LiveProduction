using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class SalesPerClientReport
    {
        public static DataSet GetSalesPerClient(string conSTR, string client ,DateTime? date1,DateTime? date2)
        {
            return DAL.Reports.SalesPerClient.GetSalesPerClient(conSTR, client, date1, date2);
        }
    }
}
