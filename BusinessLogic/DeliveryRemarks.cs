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
    public class DeliveryRemarks
    {
        public static DataSet GetDeliveryRemarks(string conSTR)
        {
            return DAL.DeliveryRemarks.GetRemarks(conSTR);
        }

        public static void DeleteDeliveryRemarks(Guid ID, string conSTR)
        {
            DAL.DeliveryRemarks.DeleteDeliveryRemarks(ID, conSTR);
        }

        public static DataSet GetDeliveryRemarkByID(Guid ID, string conSTR)
        {
            return DAL.DeliveryRemarks.GetDeliveryRemarkByID(ID, conSTR);
        }

        public static void UpdateDeliveryRemarks(Guid DeliveryRemarkID, Guid CreatedBy, string DeliveryRemarkName, string conSTR)
        {
             DAL.DeliveryRemarks.UpdateDeliveryStatus(DeliveryRemarkID, CreatedBy, DeliveryRemarkName, conSTR);
        }


        public static void InsertDeliveryRemarks(Guid CreatedBy, string DeliveryRemarkName, string conSTR)
        {
            DAL.DeliveryRemarks.InsertDeliveryStatus(CreatedBy, DeliveryRemarkName, conSTR);
        }


        }
}
