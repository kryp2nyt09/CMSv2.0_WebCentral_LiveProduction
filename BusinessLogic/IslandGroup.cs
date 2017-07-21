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
    public class IslandGroup
    {
        public static DataSet GetIslandGroup(string conSTR)
        {
            return DAL.IslandGroup.GetIslandGroup(conSTR);
        }

        public static void DeleteIslandGroup(Guid GroupID, int Flag, string conStr)
        {
            DAL.IslandGroup.DelteGroupIsland(GroupID, Flag, conStr);
        }

        public static void UpdateIslandGroup(Guid GroupID, string GroupName, string conStr)
        {
            DAL.IslandGroup.UpdateGroupIsland(GroupID, GroupName, conStr);
        }

        public static void InsertGroupIsland( string GroupName, Guid CreatedBy , string conStr)
        {
            DAL.IslandGroup.InsertGroupIsland(GroupName, CreatedBy, conStr);
        }

        public static DataSet GetIslandGroupById(string conSTR, Guid ID)
        {
            return DAL.IslandGroup.GetGroupIslandByID(conSTR, ID);
        }
    }
}
