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
    public class ShipMode
    {
        public static DataSet GetShipMode(string conSTR)
        {
            return DAL.ShipMode.GetShipMode(conSTR);
        }

        public static void DeleteShipMode(Guid ID, string conSTR)
        {
            DAL.ShipMode.DeleteShipMode(ID, conSTR);
        }


        public static DataSet GetShipModeByID(Guid ID, string conSTR)
        {

            return DAL.ShipMode.GetShipModeByID(ID, conSTR);

        }
        public static void UpdateShipMode(Guid ShipModeId, Guid CreatedBy, string ShipModeName, string conSTR)
        {
            DAL.ShipMode.UpdateShipMode(ShipModeId, CreatedBy, ShipModeName, conSTR);

        }
        public static void InsertShipMode(Guid CreatedBy, string ShipModeName, string conSTR)

        { 
             DAL.ShipMode.InsertShipMode( CreatedBy, ShipModeName, conSTR);
        }
    }
}
