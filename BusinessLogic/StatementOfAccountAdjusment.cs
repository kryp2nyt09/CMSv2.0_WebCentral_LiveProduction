using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;
namespace BusinessLogic
{
    public class StatementOfAccountAdjusment
    {
        public static void AddStatementOfAccountAdjustment(Guid SoaID, Guid ReasonID, string AirwayBillNo, decimal Amount, Guid AdjustedBy, string conSTR)
        {
            DAL.StatementOfAccountAdjustment.AddStatementOfAccountAdjustment(SoaID, ReasonID, AirwayBillNo, Amount, AdjustedBy, conSTR);
        }
    }
}
