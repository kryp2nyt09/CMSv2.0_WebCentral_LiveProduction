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
    public class AccountType
    {
        public static DataSet GetAccountType(string conSTR)
        {
            return DAL.AccountType.GetAccountType(conSTR);
        }


        public static void DeleteAccountType(Guid ID, string conSTR)
        {
            DAL.AccountType.DeleteAccountType(ID, conSTR);
        }

        public static DataSet GetAccountTypeById(Guid ID, string conSTR)
        {
            return DAL.AccountType.GetAccountTypeById(ID, conSTR);
        }


        public static void UpdateAccountType(Guid AccountTypeId, Guid CreatedBy, string AccountTypeName, string conSTR)
        {

            DAL.AccountType.UpdateAccountType(AccountTypeId, CreatedBy, AccountTypeName, conSTR);
        }


        public static void InsertAccountType(Guid CreatedBy, string AccountTypeName, string conSTR)
        {
            DAL.AccountType.InsertAccountType( CreatedBy, AccountTypeName, conSTR);
        }

    }
}
