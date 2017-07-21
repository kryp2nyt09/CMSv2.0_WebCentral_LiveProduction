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
    public class BillingPeriod
    {
        public static DataSet GetBillingPeriod(string conSTR)
        {
            return DAL.BillingPeriod.GetBillingPeriod(conSTR);
        }

        public static void Delete(Guid ID, string conSTR)
        {
            DAL.BillingPeriod.Delete(ID, conSTR);
        }

        public static DataSet GetById(Guid ID, string conSTR)
        {
            return DAL.BillingPeriod.GetById(ID, conSTR);
        }

        public static void Update(Guid BillingPeriodID, Guid CreatedBy, string BillingPeriodName, string desc, int noofdays, string conSTR)
        {
            DAL.BillingPeriod.Update(BillingPeriodID, CreatedBy, BillingPeriodName, desc, noofdays, conSTR);
        }

        public static void Insert(Guid CreatedBy, string BillingPeriodName, string desc, int noofdays, string conSTR)
        {
            DAL.BillingPeriod.Insert( CreatedBy, BillingPeriodName, desc, noofdays, conSTR);
        }

        }
}
