using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools = utilities;
using BLL = BusinessLogic;
using System.Data;
using Telerik.Web.UI;

namespace CMSVersion2.UserAccess.UserRole.UserRoleModal
{
    public partial class AddUserRole : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
            }
        }

        #region InitLoad
        public void InitLoad()
        {
            PopulateEmployeeDDL();
            PopulateRoles();
        }
        #endregion

        #region DataSources
        private void PopulateEmployeeDDL()
        {
            //DataTable EmployeeNameList = BLL.Employee_Info.GetEmployeeNames(getConstr.ConStrCMS).Tables[0];
            rcbEmployee.DataSource = BLL.Employee_Info.EmployeeNameinRoleUser(getConstr.ConStrCMS);
            rcbEmployee.DataTextField = "EmployeeName";
            rcbEmployee.DataValueField = "UserId";
            rcbEmployee.DataBind();

        }
       
        private void PopulateRoles()
        {
            DataTable dt = BLL.UserRole.GetAllRoles(getConstr.ConStrCMS).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //chkListRoles.DataSource = dt;
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

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid();
            Guid roleId = new Guid();
            bool canLogintoweb = false;
            bool canLogintoclient = false;
            bool canLogintoTnt = false;
            bool canLogintoMobile = false;
            Guid createdBy = new Guid("11111111-1111-1111-1111-111111111111");

            try
            {
                userId = Guid.Parse(rcbEmployee.SelectedValue.ToString());
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
                        roleId = Guid.Parse(item.Value);
                        BLL.UserRole.InsertUserRole(roleId, userId, canLogintoweb, canLogintoclient, canLogintoTnt, canLogintoMobile, createdBy, getConstr.ConStrCMS);
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
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }
        #endregion
    }
}