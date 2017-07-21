using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Administration
{
    public partial class Users : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {


            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            radSearchUser.DataSource = GetUsers();
            radSearchUser.DataTextField = "FullName";
            radSearchUser.DataValueField = "UserId";

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

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




        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserId"], e.Item.ItemIndex);
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

        public DataTable GetUsers()
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Users_Info.GetUserInfo(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetUsers();
        }

        protected void radSearchUser_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string userId = string.Empty;
            string likeCondition;
            Guid userid = new Guid();

            if (e.DataItem != null)
            {
                userId = ((Dictionary<string, object>)e.DataItem)["UserId"].ToString();
                userid = Guid.Parse(userId);
                if (!string.IsNullOrEmpty(userId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["UserId"].ToString());
                    RadGrid2.DataSource = GetUserbyUserId(userid);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetUsers();
                RadGrid2.DataBind();
            }
        }


        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
        }

        protected void RadGrid2_ItemDataBound1(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {

        }

        protected void RadGrid2_ItemCreated1(object sender, GridItemEventArgs e)
        {

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
            RadGrid2.DataSource = GetUsers();
            RadGrid2.Rebind();
        }
        #endregion

    }
}