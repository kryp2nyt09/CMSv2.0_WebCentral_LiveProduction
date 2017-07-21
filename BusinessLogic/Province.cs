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
    public class Province
    {
        public static DataSet GetProvince(string conSTR)
        {
            return DAL.Province.GetProvince(conSTR);
        }


        public static DataSet GetProvinceById(Guid ProvinceId, string conSTR)
        {
            return DAL.Province.GetProvinceById(ProvinceId, conSTR);
        }


        public static void DeleteProvince(Guid RegionID, int Flag, string conStr)
        {
            DAL.Province.DeleteProvince(RegionID, Flag, conStr);
        }

        public static void UpdateProvince(Guid ProvinceId, Guid RegionId, Guid ModifiedBy, string ProvinceName, int Flag, string conStr)
        {
            DAL.Province.UpdateProvince(ProvinceId, RegionId, ModifiedBy, ProvinceName, Flag, conStr);
        }

        public static void InsertProvince( Guid RegionId, Guid ModifiedBy, string ProvinceName, int Flag, string conStr)
        {
            DAL.Province.InsertProvince(RegionId, ModifiedBy, ProvinceName, Flag, conStr);
        }

    }
}
