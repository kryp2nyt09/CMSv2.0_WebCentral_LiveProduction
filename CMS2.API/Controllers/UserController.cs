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
    public class UserController : ApiController
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
        // GET: api/User
        public HttpResponseMessage Get()
        {
            DataSet ds = BAL.Users_Info.GetUserInfo(connectionString);
            List<User> users = ConvertToList(ds);
            if (users.Any())
                return Request.CreateResponse(HttpStatusCode.OK, users);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
        }


        private List<User> ConvertToList(DataSet ds)
        {
            List<User> users = new List<User>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                User u =new User();
                u.UserID = Guid.Parse(row["UserID"].ToString());
                u.UserName = row["Username"].ToString();
                u.Password = (byte[])row["Password"];
                u.EmployeeID = Guid.Parse(row["EmployeeID"].ToString());

                users.Add(u);
            }

            return users;
        }
    }

    class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
