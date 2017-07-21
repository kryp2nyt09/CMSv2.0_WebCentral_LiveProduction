using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reports
{
    public class CargoMonitoring
    {
        public static DataSet GetCargoMonitoringDelivered(string conSTR, DateTime? date1, DateTime? date2, Guid? bcoid, Guid? revenueunitid, Guid? deliveredbyid, Guid? deliverystatusid)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringDelivered", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = (object)bcoid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = (object)revenueunitid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DeliveredById", SqlDbType.UniqueIdentifier).Value = (object)deliveredbyid ?? DBNull.Value;
                da.SelectCommand.Parameters.Add("@DeliveredStatusId", SqlDbType.UniqueIdentifier).Value = (object)deliverystatusid ?? DBNull.Value;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet GetCargoMonitoringHold(string conSTR, DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringHoldCargo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCargoMonitoringMisrouted(string conSTR, DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringMisrouted", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCargoMonitoringOffloaded(string conSTR, DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringOffloaded", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCargoMonitoringPending(string conSTR, DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringPending", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCargoMonitoringRUD(string conSTR, DateTime? date1, DateTime? date2)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_CargoMonitoringRUD", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DATE1", SqlDbType.Date).Value = date1;
                da.SelectCommand.Parameters.Add("@DATE2", SqlDbType.Date).Value = date2;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}
