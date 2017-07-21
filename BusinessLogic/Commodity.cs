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
    public class Commodity
    {
        public static DataSet GetCommodity(string conSTR)
        {
            return DAL.Commodity.GetCommodity(conSTR);
        }
        public static DataSet GetCommodityID(Guid id, string conSTR)
        {
            return DAL.Commodity.GetCommodityID(id, conSTR);
        }

        public static void DeleteCommodity(Guid CommodityId, int Flag, string conStr)
        {
            DAL.Commodity.DeleteCommodity(CommodityId, Flag, conStr);
        }

        public static void InsertCommodity(string CommodityName, Guid CommodityTypeid, Guid CreatedBy, string conStr)
        {
            DAL.Commodity.InsertCommodity(CommodityName, CommodityTypeid, CreatedBy, conStr);
        }

        public static void UpdateCommodity(Guid commodityid, string CommodityName, Guid CommodityTypeid, Guid CreatedBy, string conStr)
        {
            DAL.Commodity.UpdateCommodity(commodityid, CommodityName, CommodityTypeid, CreatedBy, conStr);

        }
    }
}
