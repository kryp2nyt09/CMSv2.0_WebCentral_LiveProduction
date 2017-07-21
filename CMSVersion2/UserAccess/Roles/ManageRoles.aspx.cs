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

namespace CMSVersion2.UserAccess.Roles
{
    public partial class ManageRoles : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Datatable
        public DataTable GetUserbyUserId(Guid userId)
        {
            DataSet data = BLL.Users_Info.GetUserByUserId(userId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        #endregion




        protected void radGridRoles_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RoleId"], e.Item.ItemIndex);
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                radGridRoles.MasterTableView.SortExpressions.Clear();
                radGridRoles.MasterTableView.GroupByExpressions.Clear();
                radGridRoles.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                radGridRoles.MasterTableView.SortExpressions.Clear();
                radGridRoles.MasterTableView.GroupByExpressions.Clear();
                radGridRoles.MasterTableView.CurrentPageIndex = radGridRoles.MasterTableView.PageCount - 1;
                radGridRoles.Rebind();
            }
        }

        public DataTable GetRoles()
        {
            DataSet data = BLL.Role.GetAllRoles(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events
        protected void radGridRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridRoles.DataSource = GetRoles();
        }

        protected void radGridRoles_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //if (e.CommandName == "Delete")
            //{
            //    string userid = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"].ToString();
            //    BLL.Users_Info.UpdateUserProfile(new Guid(userid), 3, getConstr.ConStrCMS);
            //    //3 for delete flagging
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            radGridRoles.DataSource = GetRoles();
            radGridRoles.Rebind();
        }
        #endregion
    }
}