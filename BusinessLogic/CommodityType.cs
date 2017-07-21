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
    public class CommodityType
    {
        public static DataSet GetCommodityType(string conSTR)
        {
            return DAL.CommodityType.GetCommodityType(conSTR);
        }
        public static DataSet GetCommodityTypeById(Guid Id, string conSTR)
        {
            return DAL.CommodityType.GetCommodityTypeById(Id, conSTR);
        }

        public static void DeleteCommodityType(Guid CommodityTypeId, int Flag, string conStr)
        {
            DAL.CommodityType.DeleteCommodityType(CommodityTypeId, Flag, conStr);
        }
        public static void UpdateCommodityType(Guid CommodityTypeId, string CommodityTypeCode, string CommodityTypeDesc, string CommodityTypeName, decimal EvmDivisor, Guid CreatedBy, string conStr)
        {
            DAL.CommodityType.UpdateCommodityType(CommodityTypeId, CommodityTypeCode, CommodityTypeDesc, CommodityTypeName, EvmDivisor, CreatedBy, conStr);
        }
        public static void InsertCommodityType(string CommodityTypeCode, string CommodityTypeDesc, string CommodityTypeName, decimal EvmDivisor, Guid CreatedBy, string conStr)
        {
            DAL.CommodityType.InsertCommodityType(CommodityTypeCode, CommodityTypeDesc, CommodityTypeName, EvmDivisor, CreatedBy, conStr);
        }
    }
}
