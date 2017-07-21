using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.Booking
{
    public partial class ViewBooking : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Events
        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
               // string ClientId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClientId"].ToString();
               // BLL.Clients.UpdateClientProfile(new Guid(ClientId), 3, getConstr.ConStrCMS);

                //3 for delete flagging
            }
        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink cancelLink = (HyperLink)e.Item.FindControl("CancelLink");
                cancelLink.Attributes["href"] = "javascript:void(0);";
                cancelLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["BookingId"], e.Item.ItemIndex);
            }
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
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
        #endregion


    }
}