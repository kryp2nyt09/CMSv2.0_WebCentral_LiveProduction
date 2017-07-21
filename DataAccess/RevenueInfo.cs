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
    public class RevenueInfo
    {
        public static DataSet getRevenueType(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_revenuetype", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet getRevenueUnit(Guid RevenueUnit, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_revenueunit", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RUnit", SqlDbType.UniqueIdentifier).Value = RevenueUnit;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }


        public static DataSet GetRevenueByBCOCode(string conSTR, string BCOCode)
        {
            
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RevenueUnitByBCOCode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BCOCODE", SqlDbType.VarChar).Value = BCOCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet getRevenueUnitByBCO(Guid RevenueUnitType, Guid BCO, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_revenueunitbyBCO", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add("@RUnit", SqlDbType.UniqueIdentifier).Value = RevenueUnitType;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.UniqueIdentifier).Value = BCO;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        public static DataSet getRevenueUnitByBCOId(Guid BCOId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RevenueUnitByBCOId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BCOId", SqlDbType.UniqueIdentifier).Value = BCOId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        public static DataSet getAllRevenueUnit(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AllRevenueUnit", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet getRevenueTypeById(Guid RevenueUnitid, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_revenuetypeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@revenueid", SqlDbType.UniqueIdentifier).Value = RevenueUnitid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet getBranchCorp(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_branchcorp", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.Add("@RUnit", SqlDbType.UniqueIdentifier).Value = RevenueUnit;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }


        public static void DeleteRevenueType(Guid revenuetypeid, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_RevenueTypeId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenueUnitTypeId", SqlDbType.UniqueIdentifier).Value = revenuetypeid;
                    //cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertRevenueType(string RevenueName, Guid modifiedby, string description, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_RevenueTypeId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenuTypeName", SqlDbType.VarChar).Value = RevenueName;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedby;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRevenueType(string RevenueName, Guid revenueid, Guid modifiedby, string description, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_RevenueTypeId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RevenuTypeId", SqlDbType.UniqueIdentifier).Value = revenueid;
                    cmd.Parameters.Add("@RevenuTypeName", SqlDbType.VarChar).Value = RevenueName;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedby;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
