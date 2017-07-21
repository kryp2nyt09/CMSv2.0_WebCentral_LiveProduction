﻿using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.BranchGateway
{
    public partial class EditGateway : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadCity();
                LoadCluster();
                if (Request.QueryString["ID"] == null)
                {

                }
                else
                {

                    string AreaID = Request.QueryString["ID"].ToString();
                    DataTable GroupInfo = GetAreaDetails(new Guid(AreaID));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string Id = row["RevenueUnitId"].ToString();
                            string AreaName = row["RevenueUnitName"].ToString();
                            string ClusterId = row["ClusterId"].ToString();
                            string CityName = row["CityName"].ToString();

                            RadComboBoxItem item = rcbCity.FindItemByText(CityName);
                            item.Selected = true;

                            RadComboBoxItem item1 = rcbCluster.FindItemByValue(ClusterId);
                            item1.Selected = true;

                            txtAreaName.Text = AreaName;
                            lblGroupID.Text = Id;


                            counter++;
                        }
                    }

                }
            }
        }



        private void LoadCity()
        {
            rcbCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbCity.DataValueField = "CityId";
            rcbCity.DataTextField = "CityName";
            rcbCity.DataBind();
        }
        private void LoadCluster()
        {
            rcbCluster.DataSource = BLL.Cluster.GetCluster(getConstr.ConStrCMS);
            rcbCluster.DataValueField = "ClusterId";
            rcbCluster.DataTextField = "ClusterName";
            rcbCluster.DataBind();
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Gateway Sat Office";
        }

        public DataTable GetAreaDetails(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Area.GetAreaById(ID, getConstr.ConStrCMS);
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
            Guid CityId = new Guid(rcbCity.SelectedItem.Value.ToString());
            Guid ClusterId = new Guid(rcbCluster.SelectedItem.Value.ToString());

            Guid AreaID = new Guid(lblGroupID.Text);
            Guid ModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
            string host = HttpContext.Current.Request.Url.Authority;
            string AreaName = txtAreaName.Text;
            BLL.Area.UpdateArea(AreaID, new Guid("E4AD3127-EDCE-49C0-858B-A429E20D3D36"), CityId, ClusterId, ModifiedBy, "", "", "", "", AreaName, "", "", getConstr.ConStrCMS);
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