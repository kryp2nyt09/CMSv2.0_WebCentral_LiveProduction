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
    public class DeliveryStatus
    {

        public static DataSet GetDeliveryStatus(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_DeliveryStatus", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeleteDeliveryStatus(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_DeliveryStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DeliveryStatusId ", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetDeliveryStatusByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_DeliveryStatusById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@DeliveryStatusId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void UpdateDeliveryStatus(Guid DeliveryStatusID, Guid CreatedBy, string DeliveryStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_DeliveryStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DeliveryStatusID", SqlDbType.UniqueIdentifier).Value = DeliveryStatusID;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@DeliveryStatusName", SqlDbType.VarChar).Value = DeliveryStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public static void InsertDeliveryStatus( Guid CreatedBy, string DeliveryStatusName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_DeliveryStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@DeliveryStatusName", SqlDbType.VarChar).Value = DeliveryStatusName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }

    }
}
