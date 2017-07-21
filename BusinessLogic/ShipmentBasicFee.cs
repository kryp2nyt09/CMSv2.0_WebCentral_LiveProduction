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
    public class ShipmentBasicFee
    {
        public static DataSet GetShipmentBasicFee(string conSTR)
        {
            return DAL.ShipmentBasicFee.GetShipmentBasicFee(conSTR);
        }

        public static DataSet GetShipmentBasicFeeByID(Guid ID, string conSTR)


        {
            return DAL.ShipmentBasicFee.GetShipmentBasicFeeByID(ID, conSTR);
        }

        public static void UpdateShipmentBasicFee(Guid ID, Guid CreatedBy, decimal amount, string ShipmentFeeName, string description, int isvatable, DateTime EffectiveDate, string conSTR)
        {
            DAL.ShipmentBasicFee.UpdateShipmentBasicFee(ID, CreatedBy, amount, ShipmentFeeName, description, isvatable, EffectiveDate, conSTR);
        }

        public static void InsertShipmentBasicFee(Guid CreatedBy, decimal amount, string ShipmentFeeName, string description, int isvatable, DateTime EffectiveDate, string conSTR)
        {
            DAL.ShipmentBasicFee.InsertShipmentBasicFee( CreatedBy, amount, ShipmentFeeName, description, isvatable, EffectiveDate, conSTR);
        }
        public static void DeleteShipmentBasicFee(string conSTR, Guid ShipmentFeeId)
        {
            DAL.ShipmentBasicFee.DeleteShipmentBasicFee(conSTR, ShipmentFeeId);
        }

        //public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        //{
        //    DAL.Client.UpdateClientProfile(ClientID, Flag, conStr);
        //}

    }
}
