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
    public class RevenueUnitController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/RevenueUnit
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.Revenue_Info.getAllRevenueUnit(connectionString);
            List<RevenueUnit> revUnits = ConvertToList(ds);
            if (revUnits.Any())            
                return Request.CreateResponse(HttpStatusCode.OK, revUnits);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }

        private List<RevenueUnit> ConvertToList(DataSet ds)
        {
            List<RevenueUnit> revUnits = new List<RevenueUnit>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                RevenueUnit r = new RevenueUnit();
                r.RevenueUnitID = Guid.Parse(row["RevenueUnitId"].ToString());
                r.RevenueUnitName = row["RevenueUnitName"].ToString();
                r.CityId = Guid.Parse(row["CityId"].ToString());
                r.RevenueUnitTypeID = Guid.Parse(row["RevenueUnitTypeID"].ToString());
                revUnits.Add(r);
            }

            return revUnits;
        }

    }

    class RevenueUnit
    {
        public Guid RevenueUnitID { get; set; }
        public string RevenueUnitName { get; set; }
        public Guid CityId { get; set; }
        public Guid RevenueUnitTypeID { get; set; }

    }
}
