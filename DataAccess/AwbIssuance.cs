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
    public class AwbIssuance
    {

        public static DataSet GetAwbIssuance(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AwbIssuance", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet GetawbissuanceById(Guid AwbIssuanceId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AwbIssuanceById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbIssuanceId", SqlDbType.UniqueIdentifier).Value = AwbIssuanceId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetawbissuanceByBCOandAwbId(Guid bcoId, Guid AwbIssuanceId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AwbIssuance_Search", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoId;
                da.SelectCommand.Parameters.Add("@AwbIssuanceId", SqlDbType.UniqueIdentifier).Value = AwbIssuanceId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetawbissuanceByBCO(Guid bcoId, Guid RevenueUnitId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AwbIssuance_SearchByBCO", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoId;
                da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet getCityId(String CityName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Check_CityName", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static void InsertAWBIssuance(string seriesStart, string seriesend, DateTime issueddate, Guid? RevenueUnitId, Guid BCOid,  Guid? IssuedTold, Guid CreatedBy,string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_AwbIssuanceById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SeriesStart", SqlDbType.NVarChar).Value = seriesStart;
                    cmd.Parameters.Add("@SeriesEnd", SqlDbType.NVarChar).Value = seriesend;
                    cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueddate;
                    cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
                    cmd.Parameters.Add("@BCOid", SqlDbType.UniqueIdentifier).Value = BCOid;
                    cmd.Parameters.Add("@IssuedToId", SqlDbType.UniqueIdentifier).Value = IssuedTold;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void updateAWBIssuanceWB(Guid AwbIssuanceId, string seriesStart, string seriesend, DateTime issueddate, Guid? RevenueUnitId, Guid BCOid, Guid? IssuedTold, Guid CreatedBy,
              string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_AwbIssuanceById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SeriesStart", SqlDbType.NVarChar).Value = seriesStart;
                    cmd.Parameters.Add("@SeriesEnd", SqlDbType.NVarChar).Value = seriesend;
                    cmd.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueddate;
                    cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;
                    cmd.Parameters.Add("@BCOid", SqlDbType.UniqueIdentifier).Value = BCOid;
                    cmd.Parameters.Add("@IssuedToId", SqlDbType.UniqueIdentifier).Value = IssuedTold;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@AwbIssuanceId", SqlDbType.UniqueIdentifier).Value = AwbIssuanceId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static void DeleteAWBIssuanceWB(Guid AwbIssuanceId, 
              string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_AwbIssuance", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                 
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = AwbIssuanceId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
