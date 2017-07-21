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
    public class CommodityController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/Commodity
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.Commodity.GetCommodity(connectionString);
            List<Commodity> commodities = ConvertToList(ds);
            if (commodities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, commodities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }

        // GET: api/Commodity/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


        private List<Commodity> ConvertToList(DataSet ds)
        {
            List<Commodity> comodities = new List<Commodity>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Commodity commodity = new Commodity();
                commodity.CommodityName = row["CommodityName"].ToString();
                comodities.Add(commodity);
            }

            return comodities;
        }

        // POST: api/Commodity
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Commodity/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Commodity/5
        //public void Delete(int id)
        //{
        //}

        private class Commodity
        {
            public String CommodityName { get; set; }
        }
    }


}
