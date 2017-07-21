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
    public class ApprovingAuthority
    {
        public static DataSet GetApprovingAuthority(string conSTR)
        {
            return DAL.ApprovingAuthority.GetApprovingAuthority(conSTR);
        }


        public static DataSet GetApprovingAuthorityById(string conSTR, Guid CompanyId)
        {
            return DAL.ApprovingAuthority.GetApprovingAuthorityByID(conSTR, CompanyId);
        }


        public static DataSet GetApprovingAuthorityDetailsById(string conSTR, Guid AuthorityID)
        {
            return DAL.ApprovingAuthority.GetApprovingAuthorityDetailsByID(conSTR, AuthorityID);
        }
        public static void DeleteApprovingAuthority(Guid ApprovingAuthorityId, int Flag, string conStr)
        {
            DAL.ApprovingAuthority.DeleteApprovingAuthority(ApprovingAuthorityId, Flag, conStr);
        }
        public static void UpdateApprovingAuthorityDetails(Guid ApprovingAuthorityId, string FirstName, string Lastname, string title, string position,
            string department, string ContactNo, string Mobile, string Fax, string Email, 
            Guid CompanyId, Guid ModifiedBy, string conStr)
        {
            DAL.ApprovingAuthority.UpdateApprovingAuthorityDetails(ApprovingAuthorityId, FirstName, Lastname, title, position, department, ContactNo, Mobile, Fax, Email, CompanyId, ModifiedBy, conStr);
        }

        public static void  InsertApprovingAuthorityDetails(string FirstName, string Lastname, string title, string position, string department, 
                                        string ContactNo, string Mobile, string Fax, string Email, Guid CompanyId, Guid CreatedBy, string conStr)
        {
            DAL.ApprovingAuthority.InsertApprovingAuthorityDetails(FirstName, Lastname, title, position, department, ContactNo, Mobile, Fax, Email, CompanyId, CreatedBy, conStr);
        }


    }
}
