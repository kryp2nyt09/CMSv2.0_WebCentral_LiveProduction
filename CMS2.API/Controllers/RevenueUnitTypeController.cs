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
    public class RevenueUnitTypeController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/RevenueUnitType
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.RevenueUnitType.GetRevenueUnitType(connectionString);
            List<RevenueUnitType> revTypes = ConvertToList(ds);
            if (revTypes.Any())
                return Request.CreateResponse(HttpStatusCode.OK, revTypes);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }

        private List<RevenueUnitType> ConvertToList(DataSet ds)
        {
            List<RevenueUnitType> revTypes = new List<RevenueUnitType>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                RevenueUnitType rtype = new RevenueUnitType();
                rtype.RevenueUnitTypeID = Guid.Parse(row["RevenueUnitTypeId"].ToString());
                rtype.RevenueUnitTypeName = row["RevenueUnitTypeName"].ToString();

                revTypes.Add(rtype);
            }

            return revTypes;
        }
    }
    class RevenueUnitType
    {
        public Guid RevenueUnitTypeID { get; set; }
        public string RevenueUnitTypeName { get; set; }
    }
}
