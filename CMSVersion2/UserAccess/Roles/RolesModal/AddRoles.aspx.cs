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

namespace CMSVersion2.UserAccess.Roles.RolesModal
{
    public partial class AddRoles : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            Guid createdBy = new Guid("11111111-1111-1111-1111-111111111111");
            string roleName = "";
            string description = "";

            try
            {
                roleName = txtRoleName.Text;
                description = txtDescription.Text;

                BLL.Role.InsertRoleName(roleName, description, createdBy, getConstr.ConStrCMS);
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