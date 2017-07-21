using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using BAL = BusinessLogic;

namespace CMS2.API.Controllers
{
    public class ShipmentController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Shipment"].ConnectionString;
        public ResponseMessageResult getinvoices([FromUri] DateTime start, [FromUri] DateTime end)
        {
            List<Invoice> result = BAL.Invoice.GetInvoices(start, end, connectionString);

            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<List<Invoice>>(result,
                   new System.Net.Http.Formatting.XmlMediaTypeFormatter
                   {
                       UseXmlSerializer = true
                       
                   })
            });
            //return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/xml") };
        }
        
        public HttpResponseMessage gettonnage(Guid userid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
            return Request.CreateResponse(HttpStatusCode.OK, BAL.Shipment.GetShipmentTonnageByUser(userid, connectionString));
            
            //return new HttpResponseMessage() { Content = new StringContent(result.ToString(), Encoding.UTF8, "application/xml") };
        }

        public HttpResponseMessage gettonnagebyarea(Guid areaid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Cms"].ConnectionString;
            return Request.CreateResponse(HttpStatusCode.OK, BAL.Shipment.GetShipmentTonnageByArea(areaid, connectionString));
            
        }


    }
}
