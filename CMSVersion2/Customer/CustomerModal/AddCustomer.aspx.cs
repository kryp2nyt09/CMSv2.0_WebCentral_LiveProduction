using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSVersion2.Customer.CustomerModal
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ClientId"] == null)
                {

                }
                else
                {
                    string clientid = Request.QueryString["ClientId"].ToString();
                    lblClientId.Value = clientid;
                }
            }
        }
    }
}