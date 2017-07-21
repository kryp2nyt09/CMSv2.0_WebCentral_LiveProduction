using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using DAL = DataAccess;
using Tools = utilities;

namespace CMSVersion2.Corporate
{
    public partial class ApprovingAuthority : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

            radSearchApprovingAuthority.DataSource = GetApprovingAutority();
            radSearchApprovingAuthority.DataTextField = "Name";
            radSearchApprovingAuthority.DataValueField = "ApprovingAuthorityId";

            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

        }

        public DataTable GetApprovingAuthorityById(Guid appId)
        {
            DataSet data = DAL.ApprovingAuthority.GetApprovingAuthorityDetailsByID(getConstr.ConStrCMS, appId);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ApprovingAuthorityId"], e.Item.ItemIndex);
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


        public DataTable GetApprovingAutority()
        {

            DataSet data = BLL.ApprovingAuthority.GetApprovingAuthority(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }



        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetApprovingAutority();
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
                string ClientId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ApprovingAuthorityId"].ToString();
                BLL.ApprovingAuthority.DeleteApprovingAuthority(new Guid(ClientId), 3, getConstr.ConStrCMS);

                //3 for delete flagging
            }
        }

        protected void radSearchApprovingAuthority_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string appId = string.Empty;
            string likeCondition;
            Guid id = new Guid();

            if (e.DataItem != null)
            {
                appId = ((Dictionary<string, object>)e.DataItem)["ApprovingAuthorityId"].ToString();
                id = Guid.Parse(appId);
                if (!string.IsNullOrEmpty(appId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["ApprovingAuthorityId"].ToString());
                    RadGrid2.DataSource = GetApprovingAuthorityById(id);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetApprovingAutority();
                RadGrid2.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetApprovingAutority();
            RadGrid2.Rebind();
        }
    }
}