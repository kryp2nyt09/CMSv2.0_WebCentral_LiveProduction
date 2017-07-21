using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.UserAccess.UserRole
{
    public partial class ManageUserRole : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            radSearchUserEmployee.DataSource = GetUserRole();
            radSearchUserEmployee.DataTextField = "FullName";
            radSearchUserEmployee.DataValueField = "UserId";
        }

        #region Datatable
        //public DataTable GetUserbyUserId(Guid userId)
        //{
        //    DataSet data = BLL.Users_Info.GetUserByUserId(userId, getConstr.ConStrCMS);
        //    DataTable convertdata = new DataTable();
        //    convertdata = data.Tables[0];
        //    return convertdata;
        //}
        #endregion




        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink roleslink = (HyperLink)e.Item.FindControl("RolesLink");
                roleslink.Attributes["href"] = "javascript:void(0);";
                roleslink.Attributes["onclick"] = String.Format("return ViewRoles('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"], e.Item.ItemIndex);

                HyperLink manageLink = (HyperLink)e.Item.FindControl("ManageLink");
                manageLink.Attributes["href"] = "javascript:void(0);";
                manageLink.Attributes["onclick"] = String.Format("return ManageMenuAccess('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"], e.Item.ItemIndex);

                HyperLink editlink = (HyperLink)e.Item.FindControl("EditLink");
                editlink.Attributes["href"] = "javascript:void(0);";
                editlink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"], e.Item.ItemIndex);
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.MasterTableView.CurrentPageIndex = RadGrid2.MasterTableView.PageCount - 1;
                RadGrid2.Rebind();
            }
        }

        public DataTable GetUserRole()
        {
            DataSet data = BLL.UserRole.GetAllUserRoles(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetUserRolebyUserId(Guid userId)
        {
            DataSet data = BLL.UserRole.GetUserRolebyUserId(userId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetUserRole();
        }

        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string userid = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"].ToString();
                BLL.Users_Info.UpdateUserProfile(new Guid(userid), 3, getConstr.ConStrCMS);
                //3 for delete flagging
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetUserRole();
            RadGrid2.Rebind();
            
        }

        protected void radSearchUserEmployee_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string employeeId = string.Empty;
            string likeCondition;
            Guid empId = new Guid();

            if (e.DataItem != null)
            {
                employeeId = ((Dictionary<string, object>)e.DataItem)["UserId"].ToString();
                empId = Guid.Parse(employeeId);
                if (!string.IsNullOrEmpty(employeeId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["UserId"].ToString());
                    //gridEmployeeDataSource.SelectCommand = "SELECT [EmployeeId], [FirstName] , [MiddleName], [LastName], [BirthDate], [ContactNo], [Email], [CreatedDate]" + " FROM[Employee] WHERE RecordStatus = 1 AND [" + searchBox.DataValueField + "] LIKE " + likeCondition;
                    //RadGrid2.DataBind();
                    RadGrid2.DataSource = GetUserRolebyUserId(empId);
                    //RadGrid2.DataSource = "SELECT [EmployeeId], [FirstName] , [MiddleName], [LastName], [BirthDate], [ContactNo], [Email], [CreatedDate]" + " FROM [Employee] WHERE RecordStatus = 1 and FirstName = [" + searchBox.Text + "] OR LastName = [" + searchBox.Text + "] or BirthDate = [" + searchBox.Text + "] ";
                    RadGrid2.DataBind();
                    // string search = radSearchEmployee.Text;
                }

            }
            else
            {
                RadGrid2.DataSource = GetUserRole();
                RadGrid2.DataBind();
            }
        }
        #endregion
    }
}