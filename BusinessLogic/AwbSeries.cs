using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class AwbSeries
    {
        public static DataSet GetAwbIssuedSummary(Guid bcoId,Guid? areaId , DateTime start,DateTime end,string conSTR)
        {
            return DAL.AwbSeries.GetAwbIssuedSummary(bcoId, areaId, start, end, conSTR);
        }

        public static DataSet GetAwbSeries(string conSTR)
        {
            return DAL.AwbSeries.GetAwbSeries(conSTR);
        }
        //public static DataSet GetAwbSeriesbySearch(Guid bcoId, Guid revenueUnitTypeId, Guid revenueUnitId, Guid empId, Guid awbSeriesId, string constr)
        //{
        //    return DAL.AwbSeries.GetAwbSeriesbySearch(bcoId, revenueUnitTypeId, revenueUnitId, empId, awbSeriesId, constr);
        //}
        public static DataSet GetAwbSeriesbySearch(Guid? bcoId, Guid? revenueUnitTypeId, Guid? revenueUnitId, Guid? empId, Guid? awbSeriesId, string constr)
        {
            return DAL.AwbSeries.GetAwbSeriesbySearch(bcoId, revenueUnitTypeId, revenueUnitId, empId, awbSeriesId, constr);
        }


        public static DataSet GetAllSeriesMonitoring(string conSTR)
        {
            return DAL.AwbSeries.GetAllSeriesMonitoring(conSTR);
        }

    }
}
