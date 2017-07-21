using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;

namespace CMSVersion2.Maintenance.FlightInformation.Flight
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranchCorpOffice();
                //LoadCity();
                GetGateway();
                //if (Request.QueryString["ID"] == null)
                //{

                //}
                //else
                //{
                //   string BranchCorpId = Request.QueryString["ID"].ToString();
                //    DataTable GroupInfo = GetBranchCorpById(new Guid(BranchCorpId));
                //    int counter = 0;
                //    foreach (DataRow row in GroupInfo.Rows)
                //    {
                //        if (counter == 0)
                //        {

                //            string Id = row["BranchCorpOfficeId"].ToString();
                //            string BranchCorpOfficeName = row["BranchCorpOfficeName"].ToString();

                //            string ProvinceName = row["ProvinceName"].ToString();
                //            string ContactNo1 = row["ContactNo1"].ToString();
                //            string ContactNo2 = row["ContactNo2"].ToString();
                //            string street = row["StreetAddress"].ToString();
                //            string fax = row["fax"].ToString();
                //            string zipcode = row["ZipCode"].ToString();

                //            RadComboBoxItem item = rcbGroup.FindItemByText(ProvinceName);
                //            item.Selected = true;

                //            txtRegionName.Text = BranchCorpOfficeName; //BCOname
                //            txtContactNo1.Text = ContactNo1;
                //            txtContactNo2.Text = ContactNo2;
                //            txtFax.Text = fax;
                //            txtStreet.Text = street;
                //            txtzipcode.Text = zipcode;

                //            lblGroupID.Text = Id;
                //            counter++;
                //        }
                //    }

                //}
            }
        }

        private void GetGateway()
        {

            rcbGateway.DataSource = BLL.Airlines.GetAllAirlines(getConstr.ConStrCMS);
            rcbGateway.DataValueField = "AirlineID";
            rcbGateway.DataTextField = "AirlineName";
            rcbGateway.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Flight Information";
        }


        private void LoadBranchCorpOffice()
        {
            rcbOrigin.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbOrigin.DataValueField = "BranchCorpOfficeId";
            rcbOrigin.DataTextField = "BranchCorpOfficeName";
            rcbOrigin.DataBind();

            rcbDestination.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbDestination.DataValueField = "BranchCorpOfficeId";
            rcbDestination.DataTextField = "BranchCorpOfficeName";
            rcbDestination.DataBind();
        }



        public DataTable GetBranchCorpById(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOfficeById(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
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

        protected void DetailsView1_ItemCommand1(object sender, DetailsViewCommandEventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating1(object sender, DetailsViewUpdateEventArgs e)
        {

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Guid BCOid = new Guid(rcbBCO.SelectedItem.Value.ToString());
            Guid GatewayId = new Guid();
            Guid OriginCity = new Guid();
            Guid DestinationCity = new Guid();
            DateTime ETD = new DateTime();
            DateTime ETA = new DateTime();
            string FlightNo;

            try
            {
                GatewayId = new Guid(rcbGateway.SelectedItem.Value.ToString());
                OriginCity = new Guid(rcbOrigin.SelectedItem.Value.ToString());
                DestinationCity = new Guid(rcbDestination.SelectedItem.Value.ToString());
                ETD = rdtETD.SelectedDate.Value;
                ETA = rdtETA.SelectedDate.Value;
                FlightNo = txtFlightNo.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            Guid createdBy = new Guid("11111111-1111-1111-1111-111111111111");
            string host = HttpContext.Current.Request.Url.Authority;

            BLL.Flight.InsertFlightInfo(txtFlightNo.Text, ETD, ETA, GatewayId, OriginCity, DestinationCity, createdBy, getConstr.ConStrCMS);

            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);



        }
    }
}