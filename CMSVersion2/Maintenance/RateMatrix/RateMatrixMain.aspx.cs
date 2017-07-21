using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;

namespace CMSVersion2.Maintenance.RateMatrix
{
    public partial class RateMatrixMain : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            radSearchRatematrix.DataSource = GetRateMatrix();
            radSearchRatematrix.DataTextField = "ApplicableRateName";
            radSearchRatematrix.DataValueField = "RateMatrixId";

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
                editLink.Attributes["onclick"] = String.Format("return ShowEditRateForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RateMatrixId"], e.Item.ItemIndex);

                HyperLink WeightBreakLink = (HyperLink)e.Item.FindControl("WeightBreakLink");
                WeightBreakLink.Attributes["href"] = "javascript:void(0);";
                WeightBreakLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RateMatrixId"], e.Item.ItemIndex);
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



        public DataTable GetRateMatrix()
        {

            DataSet data = BLL.RateMatrix.GetrateMatrix(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetRateMatrixById(Guid ratematrixId)
        {
            DataSet data = BLL.RateMatrix.GetRateMatrixById(ratematrixId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void radRateMatrix_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string Id = string.Empty;
            string likeCondition;
            Guid ratematrixid = new Guid();

            if (e.DataItem != null)
            {
                Id = ((Dictionary<string, object>)e.DataItem)["RateMatrixId"].ToString();
                ratematrixid = Guid.Parse(Id);
                if (!string.IsNullOrEmpty(Id))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["RateMatrixId"].ToString());
                    RadGrid2.DataSource = GetRateMatrixById(ratematrixid);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetRateMatrix();
                RadGrid2.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetRateMatrix();
            RadGrid2.Rebind();
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetRateMatrix();
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
                string rateID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RateMatrixId"].ToString();
                DAL.RateMatrix.DeleteCombinationRateMatrix(new Guid(rateID), getConstr.ConStrCMS);



                //3 for delete flagging
            }
        }
    }
}