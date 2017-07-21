using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;
namespace BusinessLogic.Report
{
    public class FLM_Qtyby_Commodity
    {
        public static DataSet GetQtybyCommodity(string conSTR, DateTime? dateFrom, DateTime? dateTo, string bcoId)
        {
            return DAL.Reports.FLM_Qtyby_Commodity.GetQtybyCommodity(conSTR, dateFrom, dateTo, bcoId);
        }

        public static DataSet GetQtybyCommodityAll(string conSTR, DateTime? dateFrom, DateTime? dateTo, string BCO)
        {
            return DAL.Reports.FLM_Qtyby_Commodity.GetQtybyCommodityAll(conSTR, dateFrom, dateTo, BCO);
        }

        public static DataSet GetWtbyCommodity(string conSTR, DateTime? dateFrom, DateTime? dateTo, string bcoId)
        {
            return DAL.Reports.FLM_Qtyby_Commodity.GetWtbyCommodity(conSTR, dateFrom, dateTo, bcoId);
        }

        public static DataSet GetWtbyCommodityAll(string conSTR, DateTime? dateFrom, DateTime? dateTo, string BCO)
        {
            return DAL.Reports.FLM_Qtyby_Commodity.GetWtbyCommodityAll(conSTR, dateFrom, dateTo, BCO);
        }
    }
}
