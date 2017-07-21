using CMSVersion2.Models;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.Reports
{
    public partial class CompanyExportPreview : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        public DataTable Sellers
        {
            get
            {
                DataTable data = Session["CompanyData"] as DataTable;

                if (data == null)
                {
                    data = GetUsers();
                    Session["CompanyData"] = data;
                }

                return data;
            }
        }

        public DataTable GetUsers()
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Company.GetCompanies(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected override void OnInit(EventArgs e)
        {


            base.OnInit(e);

            if (Request.QueryString["CompanyId"] == null)
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Insert;
            }
            else
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Edit;
            }
            this.Page.Title = "Print Preview";
        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            }
            else if (e.CommandName == "Insert")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //logic to truncate long string to prevent SQL error
            for (int i = 1; i < 4; i++)
            {
                string val = e.NewValues[i - 1].ToString();
                int maxLength = i * 10;
                if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
            }
        }

        protected void rdPreview_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rdPreview.DataSource = this.GetUsers();
        }

        protected void rdPreview_ItemCommand(object sender, GridCommandEventArgs e)
        {

        }
    }
}