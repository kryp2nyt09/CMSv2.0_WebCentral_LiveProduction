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
    public class Region
    {
        public static DataSet GetRegion(string conSTR)
        {
            return DAL.Region.GetRegion(conSTR);
        }


        public static DataSet GetRegionById(Guid regiondid, string conSTR)
        {
            return DAL.Region.GetRegionById(regiondid, conSTR);
        }


        public static void DeleteRegion(Guid RegionID, int Flag, string conStr)
        {
            DAL.Region.DeleteRegion(RegionID, Flag, conStr);
        }

        public static void UpdateRegion(Guid RegionId, Guid GroupId, Guid ModifiedBy, string regionName, int Flag, string conStr)
        {
            DAL.Region.UpdateRegion(RegionId, GroupId, ModifiedBy, regionName, Flag, conStr);
        }

        public static void InsertRegion(Guid GroupId, Guid ModifiedBy, string regionName, int Flag, string conStr)
        {
            DAL.Region.InsertRegion( GroupId, ModifiedBy, regionName, Flag, conStr);
        }

    }
}
