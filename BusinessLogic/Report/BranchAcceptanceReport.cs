using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;
namespace BusinessLogic.Report
{
    public class BranchAcceptanceReport
    {
        public static DataSet GetBranchAcceptance(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? bcoId, Guid? bsoId, string driver, Guid? BatchId)
        {
            return DAL.Reports.BranchAcceptance.GetBranchAcceptance(conSTR , dateFrom, dateTo, bcoId, bsoId, driver, BatchId);
        }
    }
}
