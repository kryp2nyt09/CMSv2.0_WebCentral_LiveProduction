using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class SalesPerShipmodeReport
    {
        public static DataSet GetSalesPerShipMode(string conSTR, string bcostr ,DateTime? date1 ,DateTime? date2)
        {
            return DAL.Reports.SalesPerShipmode.GetSalesPerShipMode(conSTR, bcostr, date1, date2);
        }
    }
}
