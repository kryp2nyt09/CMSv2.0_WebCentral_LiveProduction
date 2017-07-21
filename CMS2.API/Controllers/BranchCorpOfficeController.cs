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
    public class BranchCorpOfficeController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/BranchCorpOffice
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.BranchCorpOffice.GetBranchCorpOffice(connectionString);
            List<BranchCorpOffice> branches = ConvertToList(ds);
            if (branches.Any())
                return Request.CreateResponse(HttpStatusCode.OK, branches);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }

        private List<BranchCorpOffice> ConvertToList(DataSet ds)
        {
            List<BranchCorpOffice> branches = new List<BranchCorpOffice>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                BranchCorpOffice branch = new BranchCorpOffice();
                branch.BranchCorpOfficeID = Guid.Parse(row["BranchCorpOfficeId"].ToString());
                branch.BranchCorpOfficeName = row["BranchCorpOfficeName"].ToString();
                branches.Add(branch);
            }

            return branches;
        }
    }

    class BranchCorpOffice
    {
        public Guid BranchCorpOfficeID { get; set; }
        public string BranchCorpOfficeName { get; set; }
    }
}
