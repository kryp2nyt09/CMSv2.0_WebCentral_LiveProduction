using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class FLM_Qtyby_Commodity
    {
        public static DataSet GetQtybyCommodity(string conSTR, DateTime? dateFrom, DateTime? dateTo, string bcoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_FLM_Qtyby_Commodity", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = bcoId;

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet GetQtybyCommodityAll(string conSTR, DateTime? dateFrom, DateTime? dateTo, string BCO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_FLM_Qtyby_Commodity_All", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = (object)BCO ?? DBNull.Value;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet GetWtbyCommodity(string conSTR, DateTime? dateFrom, DateTime? dateTo, string bcoId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_FLM_Wtby_Commodity", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = bcoId;

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet GetWtbyCommodityAll(string conSTR, DateTime? dateFrom, DateTime? dateTo, string BCO)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conSTR))
                {

                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_FLM_Wtby_Commodity_All", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DateFrom", SqlDbType.Date).Value = (object)dateFrom ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@DateTo", SqlDbType.Date).Value = (object)dateTo ?? DBNull.Value;
                    da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = (object)BCO ?? DBNull.Value;

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
