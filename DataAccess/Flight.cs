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
    public class Flight
    {
        
        public static DataSet GetFlightInformation(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_FlightInformation", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetFlightInformationById(Guid FlightInfoId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_FlightInformationById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@FlightInformationId", SqlDbType.UniqueIdentifier).Value = FlightInfoId;

                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeleteFlightInfo(Guid FlightInfoId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_FlightInformationById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FlightInformationId", SqlDbType.UniqueIdentifier).Value = FlightInfoId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertFlightInfo(
            string flightNo, DateTime ETD, DateTime ETA, Guid GatewayId, Guid OriginCity, Guid DestinationId, Guid CreatedBy,
           string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_FlightInformation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = RevenueUnitId;

                    cmd.Parameters.Add("@FlightNo", SqlDbType.VarChar).Value = flightNo;
                    cmd.Parameters.Add("@ETD", SqlDbType.DateTime).Value = ETD;
                    cmd.Parameters.Add("@ETA", SqlDbType.DateTime).Value = ETA;
                    //cmd.Parameters.Add("@BCOId", SqlDbType.UniqueIdentifier).Value = BCOid;
                    cmd.Parameters.Add("@GatewayId", SqlDbType.UniqueIdentifier).Value = GatewayId;
                    cmd.Parameters.Add("@OriginCity", SqlDbType.UniqueIdentifier).Value = OriginCity;
                    cmd.Parameters.Add("@DestinationId", SqlDbType.UniqueIdentifier).Value = DestinationId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateFlightInfo(Guid FlightInfoId,
            String flightNo, DateTime ETD, DateTime ETA, Guid GatewayId, Guid OriginCity, Guid DestinationId, Guid CreatedBy,
           string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_FlightInformation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FlightId", SqlDbType.UniqueIdentifier).Value = FlightInfoId;
                    cmd.Parameters.Add("@FlightNo", SqlDbType.VarChar).Value = flightNo;
                    cmd.Parameters.Add("@ETD", SqlDbType.DateTime).Value = ETD;
                    cmd.Parameters.Add("@ETA", SqlDbType.DateTime).Value = ETA;
                    //cmd.Parameters.Add("@BCOId", SqlDbType.UniqueIdentifier).Value = BCOid;
                    cmd.Parameters.Add("@GatewayId", SqlDbType.UniqueIdentifier).Value = GatewayId;
                    cmd.Parameters.Add("@OriginCity", SqlDbType.UniqueIdentifier).Value = OriginCity;
                    cmd.Parameters.Add("@DestinationId", SqlDbType.UniqueIdentifier).Value = DestinationId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int checkIfFlightNumberExists(string flightNumber, string conStr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_checkifExists_FlightNumber", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FlightNumber", SqlDbType.VarChar).Value = flightNumber;
                    //rows output
                    cmd.Parameters.Add("@checkIfExists", SqlDbType.Int);
                    cmd.Parameters["@checkIfExists"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@checkIfExists"].Value);
                }
            }

            return countRowsAffected;
        }

        public static int checkIfIdExists(string airlineName, string originCityName, string destinationCityName, string conStr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_checkIfExists_Id", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@airlineName", SqlDbType.VarChar).Value = airlineName;
                    cmd.Parameters.Add("@originCityName", SqlDbType.VarChar).Value = originCityName;
                    cmd.Parameters.Add("@destinationCityName", SqlDbType.VarChar).Value = destinationCityName;

                    //rows output
                    cmd.Parameters.Add("@ifIdExists", SqlDbType.Int);
                    cmd.Parameters["@ifIdExists"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@ifIdExists"].Value);
                }
            }

            return countRowsAffected;
        }




        public static Tuple<Guid, Guid, Guid> GetIds(string airlineName, string originCityName, string destinationCityName, string conStr)
        {
            Guid airlineId = new Guid();
            Guid OriginCityId = new Guid();
            Guid DestinationCityId = new Guid();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_getId_FlightInformation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@airlineName", SqlDbType.VarChar).Value = airlineName;
                    cmd.Parameters.Add("@originCityName", SqlDbType.VarChar).Value = originCityName;
                    cmd.Parameters.Add("@destinationCityName", SqlDbType.VarChar).Value = destinationCityName;
                    //airlineName output
                    cmd.Parameters.Add("@AirlineId", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@AirlineId"].Direction = ParameterDirection.Output;

                    //originCityName output
                    cmd.Parameters.Add("@OriginCityId", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@OriginCityId"].Direction = ParameterDirection.Output;

                    //originCityName output
                    cmd.Parameters.Add("@DestinationCityId", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@DestinationCityId"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    airlineId= Guid.Parse(cmd.Parameters["@AirlineId"].Value.ToString());
                    OriginCityId = Guid.Parse(cmd.Parameters["@OriginCityId"].Value.ToString());
                    DestinationCityId = Guid.Parse(cmd.Parameters["@DestinationCityId"].Value.ToString());
                }
            }

            return new Tuple<Guid, Guid, Guid>(airlineId, OriginCityId, DestinationCityId);
        }

        public static void BulkInsertFlightInfo(DataTable data, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_BulkInsert_FlightInformation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tblFlightInfo", data);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
