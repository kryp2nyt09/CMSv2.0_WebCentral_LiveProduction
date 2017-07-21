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
    public class Area
    {
        public static DataSet GetArea(string conSTR)
        {
            return DAL.Area.GetArea(conSTR);
        }

        public static DataSet GetAreaById(Guid AreaId, string conSTR)
        {
            return DAL.Area.GetAreaById(AreaId, conSTR);
        }

        public static void DeleteArea(Guid AreaId, int Flag, string conStr)
        {
            DAL.Area.DeleteArea(AreaId, conStr);
        }

        public static void DeleteRUT(Guid AreaId, int Flag, string conStr)
        {
            DAL.Area.DeleteRevenueUnitType(AreaId, conStr);


        }
        public static void UpdateArea(Guid RevenueUnitId, Guid RevenueUnitTypeId, Guid CityId, Guid ClusterId, Guid Createdby,
       string ContactNo1, string ContactNo2, string fax, string zipcode,
       string RevenueUnitName, string StreedAddress, string Description, string conStr)
        {
            DAL.Area.UpdateArea(RevenueUnitId, RevenueUnitTypeId,CityId, ClusterId, Createdby,
        ContactNo1, ContactNo2, fax, zipcode,
        RevenueUnitName, StreedAddress, Description, conStr);
        }

        public static void InsertArea(Guid RevenueUnitTypeId, Guid CityId, Guid ClusterId, Guid Createdby,
        string ContactNo1, string ContactNo2, string fax, string zipcode,
        string RevenueUnitName, string StreedAddress, string Description, string conStr)
        {
            DAL.Area.InsertArea(RevenueUnitTypeId,  CityId, ClusterId, Createdby,
 ContactNo1, ContactNo2, fax, zipcode,
 RevenueUnitName, StreedAddress, Description, conStr);
        }
    }
}
