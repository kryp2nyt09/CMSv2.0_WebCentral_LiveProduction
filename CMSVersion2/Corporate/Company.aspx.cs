using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate
{
    public partial class Company : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            radSearchCompany.DataSource = GetCompany();
            radSearchCompany.DataTextField = "CompanyName";
            radSearchCompany.DataValueField = "CompanyId";


            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }


        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);

                HyperLink ViewReps = (HyperLink)e.Item.FindControl("ViewRepsLink");
                ViewReps.Attributes["href"] = "javascript:void(0);";
                ViewReps.Attributes["onclick"] = String.Format("return ViewRep('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);


                HyperLink ViewApprovingLink = (HyperLink)e.Item.FindControl("ViewApprovingLink");
                ViewApprovingLink.Attributes["href"] = "javascript:void(0);";
                ViewApprovingLink.Attributes["onclick"] = String.Format("return ViewApprovingAuthority('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);

                //HyperLink ViewBookingLink = (HyperLink)e.Item.FindControl("ViewBookingLink");
                //ViewBookingLink.Attributes["href"] = "javascript:void(0);";
                //ViewBookingLink.Attributes["onclick"] = String.Format("return ViewBooking('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);

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


        public DataTable GetCompany()
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Company.GetCompanies(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetCompanyById(Guid companyId)
        {
            DataSet data = BLL.Company.GetCompanyById(companyId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }


        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetCompany();
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

        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string companyId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"].ToString();
                BLL.Company.DeleteCompany(new Guid(companyId), 3, getConstr.ConStrCMS);
                //3 for delete flagging
            }
        }

        protected void radCompany_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string companyId = string.Empty;
            string likeCondition;
            Guid compId = new Guid();

            if (e.DataItem != null)
            {
                companyId = ((Dictionary<string, object>)e.DataItem)["CompanyId"].ToString();
                compId = Guid.Parse(companyId);
                if (!string.IsNullOrEmpty(companyId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["CompanyId"].ToString());
                    RadGrid2.DataSource = GetCompanyById(compId);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetCompany();
                RadGrid2.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetCompany();
            RadGrid2.Rebind();
        }
    }
}