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
    public class ServiceMode
    {
        public static DataSet GetServiceMode(string conSTR)
        {
            return DAL.ServiceMode.GetServiceMode(conSTR);
        }

        public static DataSet GetServiceModeByID(Guid ID, string conSTR)
        {
            return DAL.ServiceMode.GetServiceModeID( ID, conSTR);
        }
        public static void DeleteServiceMode(Guid ID, string conSTR)
        {
            DAL.ServiceMode.DeleteServiceMode(ID, conSTR);
        }

        public static void UpdateServiceMode(Guid @ServiceModeId, Guid CreatedBy, string servicemodecode, string servicename, string conSTR)
        {
            DAL.ServiceMode.UpdateServiceMode(@ServiceModeId, CreatedBy, servicemodecode, servicename, conSTR);
        
            }
        public static void InsertServiceMode( Guid CreatedBy, string servicemodecode, string servicename, string conSTR)
        {
            DAL.ServiceMode.InsertServiceMode( CreatedBy, servicemodecode, servicename, conSTR);

        }


    }
}
