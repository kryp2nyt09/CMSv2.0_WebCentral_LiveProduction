using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Airlines
    {
       
        public static void InsertAirlines(string airlineName, string airlineCode, Guid CreatedBy, string conStr)
        {
            DAL.Airlines.InsertAirlines(airlineName, airlineCode, CreatedBy, conStr);
        }

        public static void UpdateAirlines(Guid airlineId, string airlineName, string conStr)
        {
            DAL.Airlines.UpdateAirlines(airlineId, airlineName, conStr);
        }

        public static void DeleteAirlines(Guid airlineId, int Flag, string conStr)
        {
            DAL.Airlines.DeleteAirlines(airlineId, Flag, conStr);
        }


        public static DataSet GetAirlineByAirlineID(string conSTR, Guid ID)
        {
            return DAL.Airlines.GetAirlineByAirlineID(conSTR, ID);
        }

        public static DataSet GetAllAirlines(string conSTR)
        {
            return DAL.Airlines.GetAllAirlines(conSTR);
        }
    }

}

