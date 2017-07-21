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
    public class GoodsDescription
    {
        public static DataSet GetGoodsDescription(string conSTR)
        {
            return DAL.GoodsDescription.GetGoodsDescription(conSTR);
        }

        public static void UpdateGoodsDesc(Guid GoodDescId, Guid CreatedBy, string GoodDescName, int Flag, string conStr)
        {
            DAL.GoodsDescription.UpdateGoodsDesc(GoodDescId, CreatedBy, GoodDescName, Flag, conStr);
        }

        public static void InsertGoodsDesc(Guid CreatedBy, string GoodDescName, int Flag, string conStr)
        {
            DAL.GoodsDescription.InsertGoodsDesc(CreatedBy, GoodDescName, Flag, conStr);
        }

        public static void DeleteGoodsDesc(Guid GoodDescId, int Flag, string conStr)
        {
            DAL.GoodsDescription.DeleteGoodsDesc(GoodDescId, Flag, conStr);
        }

        public static DataSet GetGoodsDescriptionById(Guid GoodDescId, string conSTR)
        {
            return DAL.GoodsDescription.GetGoodsDescriptionById(GoodDescId, conSTR);
        }
    }
}
