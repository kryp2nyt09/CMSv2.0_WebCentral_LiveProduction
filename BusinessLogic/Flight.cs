using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Flight
    {

        public static Tuple<Guid,Guid,Guid> GetIds(string airlineName, string originCityName, string destinationCityName, string conStr)
        {
            var tuple = DAL.Flight.GetIds(airlineName, originCityName, destinationCityName, conStr);
            return tuple;
        }

        public static int checkIfFlightNumberExists(string flightNumber, string conStr)
        {
            return DAL.Flight.checkIfFlightNumberExists(flightNumber, conStr);
        }

        public static int checkIfIdExists(string airlineName, string originCityName, string destinationCityName, string conStr)
        {
            return DAL.Flight.checkIfIdExists(airlineName, originCityName, destinationCityName, conStr);
        }


        public static DataSet GetFlightInformation(string conSTR)
        {
           return DAL.Flight.GetFlightInformation(conSTR);
        }


        public static void InsertFlightInfo(
            string flightNo, DateTime ETD, DateTime ETA, Guid GatewayId, Guid OriginCity, Guid DestinationId, Guid CreatedBy,
           string conStr)
        {
            DAL.Flight.InsertFlightInfo(flightNo, ETD, ETA, GatewayId, OriginCity, DestinationId, CreatedBy,
               conStr);
        }

        public static void UpdateFlightInfo(Guid FlightInfoId,
            String flightNo, DateTime ETD, DateTime ETA, Guid GatewayId, Guid OriginCity, Guid DestinationId, Guid CreatedBy,
           string conStr)
        {
            DAL.Flight.UpdateFlightInfo(FlightInfoId, flightNo, ETD, ETA, GatewayId, OriginCity, DestinationId, CreatedBy,
               conStr);
        }

        public static void BulkInsertFlightInfo(DataTable data, string conStr)
        {
            DAL.Flight.BulkInsertFlightInfo(data, conStr);
        }
    }
}
