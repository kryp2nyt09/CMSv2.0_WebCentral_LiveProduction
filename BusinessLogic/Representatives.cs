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
    public class Representatives
    {
        public static DataSet GetRepresentatives(string conSTR)
        {
            return DAL.Representatives.GetRepresentatives(conSTR);
        }


        public static DataSet GetRepresentativesByCompanyId(string conSTR, Guid CompanyId)
        {
            return DAL.Representatives.GetRepresentativesByCompandId(conSTR, CompanyId);
        }

        public static DataSet GetRepresentativesByClientId(string conSTR, Guid clientId)
        {
            return DAL.Representatives.GetRepresentativesByClientId(conSTR, clientId);
        }


        public static void InsertRepresentatives(string firstName, string lastName, string contactNo, string mobile, string fax,
                                                    string email, string address1, string address2, Guid cityId, string zipCode,
                                                    string title, string department, string remarks, Guid? companyId, Guid areaId,
                                                    string street, string barangay, Guid createdBy, string conSTR)
        {
            DAL.Representatives.InsertRepresentatives(firstName, lastName, contactNo, mobile, fax,
                                                    email, address1, address2, cityId, zipCode,
                                                    title, department, remarks, companyId, areaId,
                                                    street, barangay, createdBy, conSTR);
        }

        public static void UpdateRepresentatives(Guid clientId, string firstName, string lastName, string contactNo, string mobile, string fax,
                                                   string email, string address1, string address2, Guid cityId, string zipCode,
                                                   string title, string department, string remarks, Guid? companyId, Guid areaId,
                                                   string street, string barangay, Guid createdBy, string conSTR)
        {
            DAL.Representatives.UpdateRepresentatives(clientId, firstName, lastName, contactNo, mobile, fax,
                                                    email, address1, address2, cityId, zipCode,
                                                    title, department, remarks, companyId, areaId,
                                                    street, barangay, createdBy, conSTR);
        }
    }
}
