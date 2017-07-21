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
    public class AccountStatus
    {
        public static DataSet GetAccountStatus(string conSTR)
        {
            return DAL.AccountStatus.GetAccountStatus(conSTR);
        }

        public static void DeleteAccountStatus(Guid ID, string conSTR)
        {
            DAL.AccountStatus.DeleteAccountStatuse(ID,conSTR);
        }

        public static DataSet GetAccountStatusById(Guid ID, string conSTR)
        {
            return DAL.AccountStatus.GetAccountStatusById(ID, conSTR);
        }

        public static void UpdateAccountStatus(Guid AccountStatusID, Guid CreatedBy, string AccountStatusName, string conSTR)
        {
             DAL.AccountStatus.UpdateAccountStatus(AccountStatusID, CreatedBy, AccountStatusName, conSTR);

        }

        public static void InsertAccountStatus(Guid CreatedBy, string AccountStatusName, string conSTR)
        {
             DAL.AccountStatus.InsertAccountStatus( CreatedBy, AccountStatusName, conSTR);
        }

        }
}
