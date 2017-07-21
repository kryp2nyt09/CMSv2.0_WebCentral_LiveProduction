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
    public class OrganizationType
    {
        public static DataSet GetOrganizationType(string conSTR)
        {
            return DAL.OrganizationType.GetOrganizationType(conSTR);
        }

        public static void DeleteOrganizationType(Guid ID, string conSTR)
        {
            DAL.OrganizationType.Delete(ID, conSTR);

        }


        public static DataSet GetOrganizationTypeById(Guid ID, string conSTR)
        {
            return DAL.OrganizationType.GetById(ID, conSTR);
        }

        public static void UpdateOrganizationType(Guid OrganizationTypeID, Guid CreatedBy, string OrganizationTypeName, string conSTR)
        {
            DAL.OrganizationType.Update(OrganizationTypeID, CreatedBy, OrganizationTypeName, conSTR);
        }

        public static void InsertOrganizationType(Guid CreatedBy, string OrganizationTypeName, string conSTR)
        {
            DAL.OrganizationType.Insert(CreatedBy, OrganizationTypeName, conSTR);
        }
    }
}
