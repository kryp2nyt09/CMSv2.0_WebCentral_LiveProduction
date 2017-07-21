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
    public class Revenue_Info
    {
        public static DataSet getRevenueType(string conSTR)
        {
            return DAL.RevenueInfo.getRevenueType(conSTR);
        }

        public static DataSet getRevenueUnit(Guid RevenueUnit, string conSTR)
        {

            return DAL.RevenueInfo.getRevenueUnit(RevenueUnit, conSTR);
        }
        public static DataSet getRevenueUnitByBCO(Guid RevenueUnit,Guid BCO, string conSTR)
        {

            return DAL.RevenueInfo.getRevenueUnitByBCO(RevenueUnit,BCO, conSTR);
        }

        public static DataSet getRevenueUnitByBCOId(Guid BCOId, string conSTR)
        {

            return DAL.RevenueInfo.getRevenueUnitByBCOId(BCOId, conSTR);
        }

        public static DataSet getAllRevenueUnit(string conSTR)
        {

            return DAL.RevenueInfo.getAllRevenueUnit(conSTR);
        }

        public static DataSet getBranchCorp(string conSTR)
        {
            return DAL.RevenueInfo.getBranchCorp(conSTR);
        }

        public static DataSet getRevenueTypeById(Guid RevenueUnitid, string conSTR)
        {
            return DAL.RevenueInfo.getRevenueTypeById(RevenueUnitid, conSTR);

        }

        public static void UpdateRevenueType(string RevenueName, string description, Guid revenueid, Guid modifiedby, string conStr)
        {
            DAL.RevenueInfo.UpdateRevenueType(RevenueName, revenueid, modifiedby, description, conStr);
        }
        public static void InsertRevenueType(string RevenueName, string description, Guid modifiedby, string conStr)
        {
            DAL.RevenueInfo.InsertRevenueType(RevenueName, modifiedby, description, conStr);
        }

        public static void DeleteRevenueType(Guid revenuetypeid, int Flag, string conStr)
        {
            DAL.RevenueInfo.DeleteRevenueType(revenuetypeid, Flag, conStr);
        }

        public static DataSet GetRevenueByBCOCode( string conStr , string BCOCode)
        {
            return DAL.RevenueInfo.GetRevenueByBCOCode(conStr, BCOCode);
        }
    }
}
