using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class IslandGroup
    {

        public static DataSet GetIslandGroup(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_groupisland", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DelteGroupIsland(Guid GroupIslandId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_groupisland", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GroupId", SqlDbType.UniqueIdentifier).Value = GroupIslandId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGroupIsland(Guid GroupIslandId, string GroupName, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_groupisland", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GroupId", SqlDbType.UniqueIdentifier).Value = GroupIslandId;
                    cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertGroupIsland( string GroupName, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_groupisland", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
                    cmd.Parameters.Add("@Createdby", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static DataSet GetGroupIslandByID(string conStr, Guid Id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_GroupIslandById", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_GroupIslandById", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@GroupId", SqlDbType.UniqueIdentifier).Value = Id;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }



    }
}
