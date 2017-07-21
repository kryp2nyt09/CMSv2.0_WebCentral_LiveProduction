using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class MasterSalesReport
    {
        public static DataSet GetMasterSales(string conSTR,DateTime date1,DateTime date2,string BCOShipperStr ,string BCOConsigneeStr,string ShipModeStr, string ComTypeStr,string ServiceModeStr,string PayModeStr,string UserStr)
        {
            return DAL.Reports.MasterSales.GetMasterSales(conSTR, date1, date2, BCOShipperStr, BCOConsigneeStr, ShipModeStr, ComTypeStr, ServiceModeStr, PayModeStr, UserStr);
        }
    }
}
