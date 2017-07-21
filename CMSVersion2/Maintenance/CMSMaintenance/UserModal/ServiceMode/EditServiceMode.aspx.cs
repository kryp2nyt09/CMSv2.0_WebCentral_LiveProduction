﻿using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.ServiceMode
{
    public partial class EditServiceMode : System.Web.UI.Page
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
                    string GroupId = Request.QueryString["ID"].ToString();


                    DataTable GroupInfo = GetServiceModeById(new Guid(GroupId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string ServiceModeId = row["ServiceModeId"].ToString();
                            string ServiceModeName = row["ServiceModeName"].ToString();
                            string ServiceModeCode = row["ServiceModeCode"].ToString();

                            txtServiceModeName.Text = ServiceModeName;
                            txtServiceModeCode.Text = ServiceModeCode;
                            lblServiceModeId.Text = ServiceModeId;
                            counter++;
                        }
                    }

                }
            }
        }

        public DataTable GetServiceModeById(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.ServiceMode.GetServiceModeByID(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Service Mode";
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
            string host = HttpContext.Current.Request.Url.Authority;
            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            BLL.ServiceMode.UpdateServiceMode(new Guid(lblServiceModeId.Text), ID, txtServiceModeCode.Text, txtServiceModeName.Text, getConstr.ConStrCMS);
            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }
    }
}