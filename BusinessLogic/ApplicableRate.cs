using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL = DataAccess;


namespace BusinessLogic
{
    public class ApplicableRate
    {
        public static DataSet GetApplicableRate(string conSTR)
        {
            return DAL.ApplicableRate.GetApplicableRate(conSTR);
        }


        public static DataSet GetFreeApplicableRate(string conSTR)
        {
            return DAL.ApplicableRate.GetFreeApplicableRate(conSTR);
        }


        public static void UpdateApplicableRate(Guid ApplicableRateId, string applicableratename, Guid commodityTypeId, Guid serviceModeId, Guid serviceTypeId, Guid Createdby, string description, string conStr)
        {
            DAL.ApplicableRate.UpdateApplicableRate(ApplicableRateId, applicableratename, commodityTypeId, serviceModeId, serviceTypeId, Createdby, description, conStr);

        }
        public static void InsertApplicableRate(Guid Createdby, string applicableratename, Guid commodityTypeId, Guid serviceModeId, Guid serviceTypeId, string description, int Flag, string conStr)
        {
            DAL.ApplicableRate.InsertApplicableRate(Createdby, applicableratename, commodityTypeId, serviceModeId, serviceTypeId, description, Flag, conStr);

        }

        public static void DeleteApplicableRate(Guid ApplicableRateId, int Flag, string conStr)
        {
            DAL.ApplicableRate.DeleteApplicableRate(ApplicableRateId, Flag, conStr);
        }
        public static DataSet GetApplicableRateID(Guid ApplicableRateID, string conSTR)
        {
            return DAL.ApplicableRate.GetApplicableRateID(ApplicableRateID, conSTR);

        }
    }
}
