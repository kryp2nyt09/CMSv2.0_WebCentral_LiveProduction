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
    public class BusinessType
    {
        public static DataSet GetBusinessType(string conSTR)
        {
            return DAL.BusinessType.GetBusinessType(conSTR);
        }


        public static void DeleteBusinessType(Guid ID, string conSTR)

        {
            DAL.BusinessType.Delete(ID, conSTR);

        }

        public static DataSet GetBusinessTypeById(Guid ID, string conSTR)
        {
           return DAL.BusinessType.GetById(ID, conSTR);
        }


        public static void UpdateBusinesstype(Guid BusinessTypeID, Guid CreatedBy, string BusinessTypeName, string conSTR)
        {
            DAL.BusinessType.Update( BusinessTypeID,  CreatedBy,  BusinessTypeName,  conSTR);

        }


        public static void InsertBusinessType(Guid CreatedBy, string BusinessTypeName, string conSTR)
        {
            DAL.BusinessType.Insert( CreatedBy, BusinessTypeName, conSTR);
        }
       

        }
}
