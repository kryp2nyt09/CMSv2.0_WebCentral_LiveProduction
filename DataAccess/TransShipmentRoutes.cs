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
    public class TransShipmentRoutes
    {

        public static DataSet GetTransShipmentRoutes(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_TransShipmentRoute", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteTransShipmentRoutes(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_TransShipmentRoute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TransShipmentRouteId", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetTransShipmentRoutesByID(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_TransShipmentRouteById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@TransShipmentRouteId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }





        public static void UpdateTransShipmentRoutes(Guid TransShipmentRouteId, Guid OriginCityId, Guid DestinationCityId, Guid CreatedBy, DateTime CreatedDate,  string TransShipmentRouteName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_TransShipmentRoute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TransShipmentRouteId ", SqlDbType.UniqueIdentifier).Value = TransShipmentRouteId;
                    cmd.Parameters.Add("@OriginCityId ", SqlDbType.UniqueIdentifier).Value = OriginCityId;
                    cmd.Parameters.Add("@DestinationCityId ", SqlDbType.UniqueIdentifier).Value = DestinationCityId;
                    cmd.Parameters.Add("@CreatedBy ", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@CreatedDate ", SqlDbType.DateTime).Value = CreatedDate;
                    cmd.Parameters.Add("@TransShipmentRouteName ", SqlDbType.VarChar).Value = CreatedDate;
                    

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static void InsertTransShipmentRoutes( Guid OriginCityId, Guid DestinationCityId, Guid CreatedBy, DateTime CreatedDate, string TransShipmentRouteName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_TransShipmentRoute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@OriginCityId ", SqlDbType.UniqueIdentifier).Value = OriginCityId;
                    cmd.Parameters.Add("@DestinationCityId ", SqlDbType.UniqueIdentifier).Value = DestinationCityId;
                    cmd.Parameters.Add("@CreatedBy ", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@CreatedDate ", SqlDbType.DateTime).Value = CreatedDate;
                    cmd.Parameters.Add("@TransShipmentRouteName ", SqlDbType.VarChar).Value = CreatedDate;


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
