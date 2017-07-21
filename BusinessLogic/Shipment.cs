using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Shipment
    {

        public static DataSet GetShipmentsAndPaymentsBySOAID(Guid SOAID, string Constr)
        {
            return DAL.Shipment.GetShipmentsAndPaymentsBySoaId(SOAID, Constr);
        }

        public static ShipmentTonnage GetShipmentTonnageByUser(Guid userid, string Constr)
        {
            DataSet ds = DAL.Shipment.GetShipmentTonnageByUser(userid, Constr);
            ShipmentTonnage _tonnage = new ShipmentTonnage();
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];

            _tonnage.AirwayBillCount = (int)dt3.Rows[0][0];
            _tonnage.TotalTonnage =  (decimal)dt1.Rows[0]["Tonnage"];

            List<CommodityTonnage> _tons = new List<CommodityTonnage>();
            foreach (DataRow row in dt2.Rows)
            {   
                _tons.Add(new CommodityTonnage{ Name = row[0].ToString(), Tonnage = (int)row[1] });
            }
            _tonnage.CommodityTonnages = _tons;
            return _tonnage;
        }

        public static ShipmentTonnage GetShipmentTonnageByArea(Guid AreaID, string Constr)
        {
            DataSet ds = DAL.Shipment.GetShipmentTonnageByArea(AreaID, Constr);
            ShipmentTonnage _tonnage = new ShipmentTonnage();
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];
            DataTable dt3 = ds.Tables[2];

            _tonnage.AirwayBillCount = (int)dt3.Rows[0][0];
            _tonnage.TotalTonnage = (decimal)dt1.Rows[0]["Tonnage"];

            List<CommodityTonnage> _tons = new List<CommodityTonnage>();
            foreach (DataRow row in dt2.Rows)
            {
                _tons.Add(new CommodityTonnage { Name = row[0].ToString(), Tonnage = (int)row[1] });
            }
            _tonnage.CommodityTonnages = _tons;
            return _tonnage;
        }
    }

    public class ShipmentTonnage
    {
        public int AirwayBillCount { get; set; }
        public List<CommodityTonnage> CommodityTonnages { get; set; }
        public decimal TotalTonnage { get; set; }
    }

    public class CommodityTonnage
    {
        public string Name { get; set; }
        public decimal Tonnage { get; set; }
    }
}
