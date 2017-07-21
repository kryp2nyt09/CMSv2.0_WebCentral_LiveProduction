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
    public class ServiceType
    {
        public static DataSet GetServiceType(string conSTR)
        {
            return DAL.ServiceType.GetServiceType(conSTR);
        }
        public static void DeleteServiceType(Guid ID, string conSTR)
        {
            DAL.ServiceType.DeleteServiceType(ID, conSTR);

        }

        public static DataSet GetServiceTypeByID(Guid ID, string conSTR)
        {
            return DAL.ServiceType.GetServiceTypeByID(ID, conSTR);
        }

        public static void UpdateServiceType(Guid ID, Guid CreatedBy, string servicename, string conSTR)
        {
            DAL.ServiceType.UpdateServiceType(ID, CreatedBy, servicename, conSTR);
        }
        public static void InsertServiceType( Guid CreatedBy, string servicename, string conSTR)
        {
            DAL.ServiceType.InsertServiceType(CreatedBy, servicename, conSTR);
        }

    }
}
