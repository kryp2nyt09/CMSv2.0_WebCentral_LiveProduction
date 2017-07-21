using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class StatementOfAccount
    {
        public static DataSet GetAll(string conSTR)
        {
            return DAL.StatementOfAccount.GetAll(conSTR);
        }

        public static DataSet GetSOADetails(Guid SOAID, string conSTR)
        {
            return DAL.StatementOfAccount.GetSOADetails(SOAID, conSTR);
        }

        public static Guid InsertStatementOfAccount(DateTime BillingPeriodFrom, DateTime BillingPeriodUnitl, Guid CompanyId, Guid BillingPeriodId, string SoaNumber, string CiNo, string Remarks, string conStr)
        {
            return DAL.StatementOfAccount.InsertStatementOfAccount(BillingPeriodFrom, BillingPeriodUnitl, CompanyId, BillingPeriodId, SoaNumber, CiNo, Remarks, conStr);
        }

        public static DataSet GetSoaForPrint(Guid SoaId, string conStr)
        {
            return DAL.StatementOfAccount.GetSoaForPrint(SoaId, conStr);
        }

        public static string GetLastStatementOfAccountNo(string conStr)
        {
            return DAL.StatementOfAccount.GetLastStateOfAccountNo(conStr);
        }
    }
}
