using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class AwbIssuance
    {
        public static DataSet GetAwbIssuance(string conSTR)
        {
            return DAL.AwbIssuance.GetAwbIssuance(conSTR);
        }

        public static void InsertAWBIssuance(string seriesStart, string seriesend, DateTime issueddate, Guid? RevenueUnitId, Guid BCOid, Guid? IssuedTold, Guid CreatedBy, string conStr)
        {
            DAL.AwbIssuance.InsertAWBIssuance(seriesStart, seriesend, issueddate, RevenueUnitId, BCOid, IssuedTold, CreatedBy, conStr);
        }

        public static void DeleteAWBIssuanceWB(Guid id, string conSTR)
        {
            DAL.AwbIssuance.DeleteAWBIssuanceWB(id, conSTR);
        }

        public static DataSet GetawbissuanceById(Guid AwbIssuanceId, string conSTR)
        {
            return DAL.AwbIssuance.GetawbissuanceById(AwbIssuanceId, conSTR);
        }

        public static DataSet GetawbissuanceByBCOandAwbId(Guid bcoId, Guid AwbIssuanceId, string conSTR)
        {
            return DAL.AwbIssuance.GetawbissuanceByBCOandAwbId(bcoId, AwbIssuanceId, conSTR);
        }

        public static DataSet GetawbissuanceByBCO(Guid bcoId, Guid RevenueUnitId, string conSTR)
        {
            return DAL.AwbIssuance.GetawbissuanceByBCO(bcoId, RevenueUnitId, conSTR);
        }

        public static void updateAWBIssuanceWB(Guid AwbIssuanceId, string seriesStart, string seriesend, DateTime issueddate, Guid? RevenueUnitId, Guid BCOid, Guid? IssuedTold, Guid ModifiedBy,string conStr)
        {
            DAL.AwbIssuance.updateAWBIssuanceWB(AwbIssuanceId, seriesStart, seriesend, issueddate, RevenueUnitId, BCOid, IssuedTold, ModifiedBy, conStr);
        }
    }
}
