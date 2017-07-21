using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL = BusinessLogic;

namespace CMS2.API.Controllers
{
    public class CityController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/City
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.City.GetCity(connectionString);
            List<City> cities = ConvertToList(ds);
            if (cities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, cities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }


        private List<City> ConvertToList(DataSet ds)
        {
            List<City> cities = new List<City>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                City c = new City();
                c.CityID = Guid.Parse(row["CityID"].ToString());
                c.CityName = row["CityName"].ToString();
                c.BranchCorpOfficeId = Guid.Parse(row["BranchCorpOfficeID"].ToString());

                cities.Add(c);
            }

            return cities;
        }
    }

    class City
    {
        public Guid CityID { get; set; }
        public string CityName { get; set; }
        public Guid BranchCorpOfficeId { get; set; }
    }
}
