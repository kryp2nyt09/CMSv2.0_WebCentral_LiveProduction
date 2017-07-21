﻿using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.ProvinceMaintenance
{
    public partial class EditProvince : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["ID"] == null)
                {

                }
                else
                {
                    string ID = Request.QueryString["ID"].ToString();

                    LoadRegion();
                    DataTable Province = GetProvince(new Guid(ID));
                    int counter = 0;
                    foreach (DataRow row in Province.Rows)
                    {
                        if (counter == 0)
                        {
                            string x = row["ProvinceId"].ToString();
                            string y = row["RegionName"].ToString();
                            string z = row["ProvinceName"].ToString();

                            RadComboBoxItem item = rcbRegion.FindItemByText(y);
                            item.Selected = true;

                            txtProvince.Text = z;
                            lblGroupID.Text = x;
                            counter++;
                        }
                    }

                }

            }
        }

        private DataTable GetProvince(Guid ID)
        {
            DataSet data = BLL.Province.GetProvinceById(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Province";
        }

        private void LoadRegion()
        {
            rcbRegion.DataSource = BLL.Region.GetRegion(getConstr.ConStrCMS);
            rcbRegion.DataValueField = "RegionId";
            rcbRegion.DataTextField = "RegionName";
            rcbRegion.DataBind();
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
            Guid RegionId = new Guid(rcbRegion.SelectedItem.Value.ToString());
            Guid ProvinceID = new Guid(lblGroupID.Text);
            Guid ModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
            string host = HttpContext.Current.Request.Url.Authority;
            string RegionName = txtProvince.Text;
            BLL.Province.UpdateProvince(ProvinceID, RegionId, ModifiedBy, RegionName, 1, getConstr.ConStrCMS);
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