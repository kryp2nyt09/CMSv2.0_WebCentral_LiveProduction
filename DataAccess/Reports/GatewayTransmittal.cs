using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class GatewayTransmittal
    {
        public static DataSet GetGatewayTransmittal(string conSTR, DateTime? dateFrom, DateTime? dateTo, Guid? originbcoId, Guid? destbcoId, Guid? batchid, Guid? commodityTypeId, string driver, string gateway, string mawb)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GatewayTransmittal", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@OriginBcoId", SqlDbType.UniqueIdentifier).Value = (object)originbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DestBcoId", SqlDbType.UniqueIdentifier).Value = (object)destbcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@BatchId", SqlDbType.UniqueIdentifier).Value = (object)batchid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = (object)commodityTypeId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@Driver", SqlDbType.VarChar, 100).Value = driver;
                da.SelectCommand.Parameters.Add("@Gateway", SqlDbType.VarChar, 100).Value = gateway;
                da.SelectCommand.Parameters.Add("@mawb", SqlDbType.VarChar, 100).Value = mawb;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        //public static DataSet GetGatewayList(string conSTR , string date)
        //{
        //    using (SqlConnection con = new SqlConnection(conSTR))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetGatewayList", con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = date;
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }
        //}
        public static DataSet GetGatewayList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetGatewayList", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }




        public static DataSet GetGatewayOutBoundList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetGatewayOutBoundList", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = date;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetGatewayInBoundList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GetGatewayInBoundList", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.VarChar).Value = date;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Driver
        public static DataSet GetGTDriverList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GTDriver", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Driver
        public static DataSet GetGODriverList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GWODriver", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Flight Number
        public static DataSet GetGIFlightNumberList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_GIFlightNumber", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Driver
        public static DataSet GetSGDriverList(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_SGDriver", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Plate No
        public static DataSet GetCTPlateNo(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CTPlateNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //Plate No
        public static DataSet GetSGPlateNo(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_SGPlateNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }



    }
}
