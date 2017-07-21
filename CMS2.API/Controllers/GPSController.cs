using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL = BusinessLogic;

namespace CMS2.API.Controllers
{
    [RoutePrefix("GPS/Trucks")]
    public class GPSController : ApiController
    {
       
        string connectionString = ConfigurationManager.ConnectionStrings["GPS"].ConnectionString;

        
        // GET: api/GPS/5
        public HttpResponseMessage gettrucks()
        {
            var result = BAL.GPS.GetTruckInfo(connectionString);
            if (result.Any())
                return Request.CreateResponse(HttpStatusCode.OK, result );
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"No records found");
        }

        // POST: api/GPS
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/GPS/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/GPS/5
        //public void Delete(int id)
        //{
        //}
    }
}
