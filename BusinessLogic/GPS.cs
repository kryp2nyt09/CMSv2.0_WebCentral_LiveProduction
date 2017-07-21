using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class GPS
    {


        public static List<Car> GetTruckInfo(string constr)
        {
            DataSet ds = DAL.GPS.GetAllTrackInfo(constr);
            DataTable dt = ds.Tables[0];
            List<Car> cars = new List<Car>();
            foreach (DataRow row in dt.Rows)
            {
                Car c = new Car();
                c.TruckId = row["strTEId"].ToString();
                c.Truckname = row["strCarNum"].ToString();
                cars.Add(c);
            }
            return cars;
        }

    }

    public class Car
    {
        public string TruckId { get; set; }
        public string Truckname { get; set; }

    }
}
