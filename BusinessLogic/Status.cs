using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Status
    {
        public static void InsertStatusName(string statusName, string statusCode, Guid CreatedBy, string conStr)
        {
            DAL.Status.InsertStatusName(statusName, statusCode, CreatedBy, conStr);
        }

        public static void UpdateStatusName(Guid statusId, string statusName, string conStr)
        {
            DAL.Status.UpdateStatusName(statusId, statusName, conStr);
        }

        public static int DeleteStatusName(Guid statusId, int Flag, string conStr)
        {
            int countRowsAffected = DAL.Status.DeleteStatusName(statusId, Flag, conStr);
            return countRowsAffected;
        }

        public static DataSet GetStatusByStatusID(string conSTR, Guid ID)
        {
            return DAL.Status.GetStatusByStatusID(conSTR, ID);
        }

        public static DataSet GetStatusByStatusCode(string conSTR, string statusCode)
        {
            return DAL.Status.GetStatusByStatusCode(conSTR, statusCode);
        }
    }
}
