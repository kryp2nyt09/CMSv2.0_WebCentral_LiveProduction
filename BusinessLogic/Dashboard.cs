using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Dashboard
    {
        public static DataSet GetAWBPendingCount(string conSTR)
        {
            return DAL.Dashboard.GetAWBPendingCount(conSTR);
        }

        public static DataSet GetDistributed(string conSTR)
        {
            return DAL.Dashboard.GetDistributed(conSTR);
        }

        public static DataSet GetDelivered(string conSTR)
        {
            return DAL.Dashboard.GetDelivered(conSTR);
        }

        public static DataSet GetPaid(string conSTR)
        {
            return DAL.Dashboard.GetPaid(conSTR);
        }

        public static DataSet GetUnpaid(string conSTR)
        {
            return DAL.Dashboard.GetUnpaid(conSTR);
        }

        public static DataSet GetAWBPickedUp(string conSTR)
        {
            return DAL.Dashboard.GetAWBPickedUp(conSTR);
        }
    }
}
