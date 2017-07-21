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

namespace CMSVersion2.Maintenance.AWBSeries
{
    public partial class AWBIssuance : System.Web.UI.Page
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
                InitLoad();
            }

        }

        #region Init
        private void InitLoad()
        {
            LoadBranchCorpOffice();
            LoadRevenueUnitType();
            LoadRevenueUnitName();
        }
        #endregion

        #region Data Sources
        private void LoadBranchCorpOffice()
        {
            rcbBranchCorpOffice.DataSource = DAL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBranchCorpOffice.DataValueField = "BranchCorpOfficeId";
            rcbBranchCorpOffice.DataTextField = "BranchCorpOfficeName";
            rcbBranchCorpOffice.DataBind();
        }

        private void LoadRevenueUnitType()
        {
            rcbRevenueUnitType.DataSource = DAL.RevenueInfo.getRevenueType(getConstr.ConStrCMS);
            rcbRevenueUnitType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueUnitType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueUnitType.DataBind();
        }

        private void LoadRevenueUnitName()
        {
            DataTable revenueUnitName = BLL.Revenue_Info.getRevenueUnit(new Guid(rcbRevenueUnitType.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitName.DataSource = revenueUnitName;
            rcbRevenueUnitName.DataTextField = "RevenueUnitName";
            rcbRevenueUnitName.DataValueField = "RevenueUnitId";
            rcbRevenueUnitName.DataBind();
        }

        private void populateRevenueUnitNameByBCO()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(rcbRevenueUnitType.SelectedValue.ToString()), new Guid(rcbBranchCorpOffice.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitName.DataSource = LocationList;
            rcbRevenueUnitName.DataTextField = "RevenueUnitName";
            rcbRevenueUnitName.DataValueField = "RevenueUnitId";
            rcbRevenueUnitName.DataBind();
        }
        #endregion

        #region Methods
        public DataTable GetAWBIssuance()
        {
            //DataTable data = new DataTable();
            DataSet dt = DAL.AwbIssuance.GetAwbIssuance(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = dt.Tables[0];
            return convertdata;
        }
        public DataTable GetAwbIssuanceBySearch(Guid bcoId, Guid rUnitId)
        {
            DataSet data = BLL.AwbIssuance.GetawbissuanceByBCO(bcoId, rUnitId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        #endregion

        #region Events
        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AwbIssuanceId"], e.Item.ItemIndex);

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


        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetAWBIssuance();
        }


        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string Id = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["AwbIssuanceId"].ToString();

                BLL.AwbIssuance.DeleteAWBIssuanceWB(new Guid(Id), getConstr.ConStrCMS);
                //3 for delete flagging
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetAWBIssuance();
            RadGrid2.Rebind();
        }

        protected void radSearchawbIssuance_DataSourceSelect(object sender, SearchBoxDataSourceSelectEventArgs e)
        {
            SqlDataSource source = (SqlDataSource)e.DataSource;
            RadSearchBox searchBox = (RadSearchBox)sender;

            // string likeCondition = string.Format("'{0}' + @filterString + '%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "");
            string likeCondition = "Arjay De Torres Tabangay";
            string countCondition = e.ShowAllResults ? " " : " TOP " + searchBox.MaxResultCount + 1;
            string condition = "";

            if (e.SelectedContextItem != null)
            {
                condition = string.Format("{0}", e.SelectedContextItem.Key);
            }

            //source.SelectCommand = string.Format("SELECT {0} * FROM [AwbIssuance] WHERE {1}", countCondition, likeCondition);
            source.SelectCommand = string.Format("SELECT  {0} * FROM (SELECT awb.*, bco.BranchCorpOfficeName, ru.RevenueUnitName, emp.FirstName + ' ' + emp.MiddleName + ' ' + emp.LastName AS Name from AwbIssuance awb LEFT join BranchCorpOffice bco on awb.BCOid = bco.BranchCorpOfficeId LEFT join RevenueUnit ru on awb.RevenueUnitId = ru.RevenueUnitId LEFT join Employee emp on awb.IssuedToId = emp.EmployeeId where awb.RecordStatus = 1 and [bco.BranchCorpOfficeId] = '{1}'') AS inner_table WHERE Name LIKE {2}", countCondition, condition, likeCondition);
            source.SelectParameters.Add("filterString", e.FilterString.Replace("%", "[%]").Replace("_", "[_]"));
        }

        protected void radSearchawbIssuance_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string id = string.Empty;
            string likeCondition;
            Guid awbId = new Guid();
            Guid bcoId = new Guid();

            if (e.DataItem != null)
            {
                // id = ((Dictionary<string, object>)e.DataItem)["AwbIssuanceId"].ToString();
                var dataItem = ((Dictionary<string, object>)e.DataItem);
                var awbIssuanceId = dataItem["AwbIssuanceId"].ToString();
                var bco = dataItem["BCOid"].ToString();
                awbId = Guid.Parse(awbIssuanceId);
                bcoId = Guid.Parse(bco);
                if (!string.IsNullOrEmpty(id))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["AwbIssuanceId"].ToString());
                    RadGrid2.DataSource = GetAwbIssuanceById(bcoId, awbId);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetAWBIssuance();
                RadGrid2.DataBind();
            }
        }

        public DataTable GetAwbIssuanceById(Guid bcoId, Guid awbIssuanceId)
        {
            DataSet data = BLL.AwbIssuance.GetawbissuanceByBCOandAwbId(bcoId, awbIssuanceId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void rcbBranchCorpOffice_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueUnitType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueUnitType_TextChanged(object sender, EventArgs e)
        {
            rcbRevenueUnitName.Items.Clear();
            populateRevenueUnitNameByBCO();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Guid bcoId = new Guid();
            Guid revenueUnitTypeId = new Guid();
            Guid rUnitId = new Guid();

            bcoId = Guid.Parse(rcbBranchCorpOffice.SelectedValue.ToString());
            revenueUnitTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
            rUnitId = Guid.Parse(rcbRevenueUnitName.SelectedValue.ToString());

            if (bcoId != null && revenueUnitTypeId != null && rUnitId != null)
            {
                RadGrid2.DataSource = GetAwbIssuanceBySearch(bcoId, rUnitId);
                RadGrid2.DataBind();
            }
        }

        #endregion

    }
}