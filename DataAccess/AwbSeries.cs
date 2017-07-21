using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AwbSeries
    {
        public static DataSet GetAwbIssuedSummary(Guid bcoId, Guid? areaId, DateTime start, DateTime end, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AwbIssuedSummary", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoId;
                da.SelectCommand.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = (object)areaId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@IssuedStartDate", SqlDbType.DateTime).Value = start;
                da.SelectCommand.Parameters.Add("@IssuedEndDate", SqlDbType.DateTime).Value = end;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetAwbSeries(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AwbSeries", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        //public static DataSet GetAwbSeriesbySearch(Guid bcoId, Guid revenueUnitTypeId, Guid revenueUnitId, Guid empId, Guid awbSeriesId, string constr)
        //{
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter("sp_view_SeriesMonitoring", con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoId;
        //        da.SelectCommand.Parameters.Add("@TypeId", SqlDbType.UniqueIdentifier).Value = revenueUnitTypeId;
        //        da.SelectCommand.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = revenueUnitId;
        //        da.SelectCommand.Parameters.Add("@EmpId", SqlDbType.UniqueIdentifier).Value = empId;
        //        da.SelectCommand.Parameters.Add("@AwbSeriesId", SqlDbType.UniqueIdentifier).Value = awbSeriesId;
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;
        //    }
        //}
        public static DataSet GetAwbSeriesbySearch(Guid? bcoId, Guid? revenueUnitTypeId, Guid? revenueUnitId, Guid? empId, Guid? awbSeriesId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_SeriesMonitoring", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@TypeId", SqlDbType.UniqueIdentifier).Value = (object)revenueUnitTypeId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = (object)revenueUnitId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@EmpId", SqlDbType.UniqueIdentifier).Value = (object)empId ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@AwbSeriesId", SqlDbType.UniqueIdentifier).Value = (object)awbSeriesId ?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet GetAllSeriesMonitoring(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_AllSeriesMonitoring", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
