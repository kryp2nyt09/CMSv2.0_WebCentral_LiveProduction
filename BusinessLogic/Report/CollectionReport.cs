using System;
using System.Data;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class CollectionReport
    {
        public static DataSet GetCollection(string conSTR, string bcostr ,string type,DateTime? date1,DateTime? date2)
        {
            return DAL.Reports.CollectionReport.GetCollection(conSTR, bcostr, type, date1, date2);
        }
    }
}
