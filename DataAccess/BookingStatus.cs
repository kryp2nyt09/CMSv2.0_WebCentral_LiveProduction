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
    public class BookingStatus
    {
    
        public static DataSet GetBookingStatus(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BookingStatus", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteBookingStatus(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_BookingStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BookingStatusId", SqlDbType.UniqueIdentifier).Value = ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetBookingStatusByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BookingStatusById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BookingStatusId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        
        public static void UpdateBookingStatus(Guid BookingStatusId, Guid CreatedBy, string BookingStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_BookingStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BookingStatusId", SqlDbType.UniqueIdentifier).Value = BookingStatusId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@BookingStatusName", SqlDbType.VarChar).Value = BookingStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void InsertBookingStatus( Guid CreatedBy, string BookingStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_BookingStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@BookingStatusName", SqlDbType.VarChar).Value = BookingStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
