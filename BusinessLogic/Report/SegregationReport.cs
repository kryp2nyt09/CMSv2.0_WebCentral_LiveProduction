using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class SegregationReport
    {
        public static DataSet GetSegregation(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? destbcoid, Guid? originbcoid, string driver, string plateno,Guid? batchid)
        {
            return DAL.Reports.Segregation.GetSegregation(conSTR, dateFrom, dateTo, destbcoid, originbcoid, driver, plateno, batchid);
        }
    }
}
