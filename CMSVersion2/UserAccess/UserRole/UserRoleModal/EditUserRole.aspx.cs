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


namespace CMSVersion2.UserAccess.UserRole.UserRoleModal
{
    public partial class EditUserRole : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
                if (Request.QueryString["UserId"] == null)
                {

                }
                else
                {
                    string userid = Request.QueryString["UserId"].ToString();
                    DataTable Data = GetUserRoleInfo(new Guid(userid));
                    int counter = 0;
                    foreach (DataRow row in Data.Rows)
                    {
                        if (counter == 0)
                        {
                            try
                            {
                                lblUserID.Text = row["User_UserId"].ToString();
                                string fullName = row["FullName"].ToString();
                                string roleId = row["Role_RoleId"].ToString();
                                string CanLogintoWeb = row["CanLogintoWeb"].ToString();
                                string CanLogintoClient = row["CanLogintoClient"].ToString();
                                string CanLogintoTnT = row["CanLogintoTnT"].ToString();
                                string CanLogintoMobile = row["CanLogintoMobile"].ToString();

                                if (CanLogintoWeb == "True" || (CanLogintoWeb == "1"))
                                {
                                    chkWeb.Checked = true;
                                }
                                if (CanLogintoClient == "True" || (CanLogintoClient == "1"))
                                {
                                    chkClient.Checked = true;
                                }
                                if (CanLogintoTnT == "True" || (CanLogintoTnT == "1"))
                                {
                                    chkTnt.Checked = true;
                                }
                                if (CanLogintoMobile == "True" || (CanLogintoMobile == "1"))
                                {
                                    chkMobile.Checked = true;
                                }

                                for (int i = 0; i < chkListRoles.Items.Count; i++)
                                {
                                    string val = chkListRoles.Items[i].Value;
                                    if (roleId == val)
                                    {
                                        chkListRoles.Items[i].Selected = true;
                                    }

                                }

                                txtEmpName.Text = fullName;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }

                    }

                }
            }
        }

        #region InitLoad
        public void InitLoad()
        {
            PopulateRoles();
        }
        #endregion

        #region DataSources
        private void PopulateRoles()
        {
            DataTable dt = BLL.UserRole.GetAllRoles(getConstr.ConStrCMS).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    ButtonListItem item = new ButtonListItem();
                    item.Text = dtRow["RoleName"].ToString();
                    item.Value = dtRow["RoleId"].ToString();
                    chkListRoles.Items.Add(item);
                }

            }
        }

        #endregion

        public DataTable GetUserRoleInfo(Guid ID)
        {
            DataSet data = BLL.UserRole.GetUserRolebyUserId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid();
            Guid roleId = new Guid();
            bool canLogintoweb = false;
            bool canLogintoclient = false;
            bool canLogintoTnt = false;
            bool canLogintoMobile = false;
            Guid modifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
            int status = 1;

            try
            {
                userId = Guid.Parse(lblUserID.Text);
                if (chkWeb.Checked == true)
                {
                    canLogintoweb = true;
                }
                if (chkClient.Checked == true)
                {
                    canLogintoclient = true;
                }
                if (chkTnt.Checked == true)
                {
                    canLogintoTnt = true;
                }
                if (chkMobile.Checked == true)
                {
                    canLogintoMobile = true;
                }

                foreach (ButtonListItem item in chkListRoles.Items)
                {
                    if (item.Selected)
                    {
                        status = 1;
                        roleId = Guid.Parse(item.Value);
                        BLL.UserRole.UpdateUserRole(roleId, userId, canLogintoweb, canLogintoclient, canLogintoTnt, canLogintoMobile, modifiedBy, status, getConstr.ConStrCMS);
                    }
                    else
                    {
                        status = 3;
                        roleId = Guid.Parse(item.Value);
                        BLL.UserRole.UpdateUserRole(roleId, userId, canLogintoweb, canLogintoclient, canLogintoTnt, canLogintoMobile, modifiedBy, status, getConstr.ConStrCMS);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }
        #endregion
    }
}