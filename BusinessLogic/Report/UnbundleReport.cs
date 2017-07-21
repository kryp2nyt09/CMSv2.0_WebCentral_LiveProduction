using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class UnbundleReport
    {
        public static DataSet GetUnBundle(string conSTR , DateTime? dateFrom,DateTime? dateTo,Guid? destbcoId,Guid? originbcoId,string sackNumber)
        {
            return DAL.Reports.Unbundle.GetUnbundle(conSTR , dateFrom, dateTo, destbcoId, originbcoId, sackNumber);
        }
    }
}