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
    public class Tracking_BatchName
    {
        public static DataSet GetByGroup(string batchCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BatchByBatchCode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BatchCode", SqlDbType.VarChar).Value = batchCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetByRemark(string remarkCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RemarksByRemarkCode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RemarkCode", SqlDbType.VarChar).Value = remarkCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static DataSet Destination(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_branchcorp", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet Airlines(string airlineCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Airline", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AirlineCode", SqlDbType.VarChar).Value = airlineCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet Status(string statusCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Status", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = statusCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        
        public static DataSet GetByReasonCode(string reasonCode, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ReasonByReaasonCode", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ReasonCode", SqlDbType.VarChar).Value = reasonCode;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

    }
}
