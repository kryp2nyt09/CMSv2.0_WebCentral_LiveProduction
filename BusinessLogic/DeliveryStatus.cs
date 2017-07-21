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
    public class DeliveryStatus
    {
        public static DataSet GetDeliveryStatus(string conSTR)
        {
            return DAL.DeliveryStatus.GetDeliveryStatus(conSTR);
        }

        public static void DeleteDeliveryStatus(Guid ID, string conSTR)
        {
            DAL.DeliveryStatus.DeleteDeliveryStatus(ID, conSTR);
        }

        public static DataSet GetDeliveryStatusByID(Guid ID, string conSTR)

        {
            return DAL.DeliveryStatus.GetDeliveryStatusByID(ID,conSTR);
        }
        

        public static void UpdateDeliveryStatus(Guid DeliveryStatusID, Guid CreatedBy, string DeliveryStatusName, string conSTR)
        {
            DAL.DeliveryStatus.UpdateDeliveryStatus(DeliveryStatusID, CreatedBy, DeliveryStatusName, conSTR);
        }
        public static void InsertDeliveryStatus( Guid CreatedBy, string DeliveryStatusName, string conSTR)
        {
            DAL.DeliveryStatus.InsertDeliveryStatus(CreatedBy, DeliveryStatusName, conSTR);
        }


    }
}
