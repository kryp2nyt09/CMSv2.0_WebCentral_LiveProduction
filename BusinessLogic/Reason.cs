using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
   public class Reason
    {
        public static void InsertReason(Guid statusId, string reasonCode, string reasonName, Guid CreatedBy, int Flag, string conStr)
        {
            DAL.Reason.InsertReason(statusId, reasonCode, reasonName, CreatedBy, Flag, conStr);
        }

        public static void UpdateReason(Guid reasonId, Guid statusId, string reasonName, Guid ModifiedBy, int Flag, string conStr)
        {
            DAL.Reason.UpdateReason(reasonId, statusId, reasonName,ModifiedBy, Flag, conStr);
        }
        public static void DeleteReason(Guid reasonId, int Flag, string conStr)
        {
            DAL.Reason.DeleteReason(reasonId, Flag, conStr);
        }

        public static DataSet GetReasonByReasonId(Guid reasonId, string conSTR)
        {
            return DAL.Reason.GetReasonByReasonId(reasonId, conSTR);
        }


    }
}
