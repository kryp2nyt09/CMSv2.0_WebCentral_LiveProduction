using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class AirwayBill
    {
        public static DataSet GetAwbInfoByAwbNo(string awbNo, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Search_AwbNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetDetailsAwbNo(string awbNo, int status, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Transaction_AwbNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                da.SelectCommand.Parameters.Add("@status", SqlDbType.Int).Value = status;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet SignaturePOD(string awbNo, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AwbNo_POD", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet GetDeliveryDetailsInfoByAwbNo(string awbNo, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_AwbNo_Delivery", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AwbNo", SqlDbType.NVarChar).Value = awbNo;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


    }
}
