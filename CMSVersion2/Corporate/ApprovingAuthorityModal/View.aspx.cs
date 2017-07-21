using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Corporate.ApprovingAuthorityModal
{
    public partial class View : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["CompanyId"] == null)
                {

                }
                else
                {
                    string companyId = Request.QueryString["CompanyId"].ToString();
                    lblCompanyID.Value = companyId;
                }
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            this.Page.Title = "Viewing/Adding Approving Authority";
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


        public DataTable GetApprovingAuthorityById(string CompanyId)
        {

            DataSet data = BLL.ApprovingAuthority.GetApprovingAuthorityById(getConstr.ConStrCMS, new Guid(CompanyId));
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }



        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

            string CompanyId = Request.QueryString["CompanyId"].ToString();
            if (CompanyId != null)
            {

                RadGrid2.DataSource = GetApprovingAuthorityById(CompanyId);
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
                string ClientId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClientId"].ToString();
                BLL.Clients.UpdateClientProfile(new Guid(ClientId), 3, getConstr.ConStrCMS);

                //3 for delete flagging
            }
        }
    }
}