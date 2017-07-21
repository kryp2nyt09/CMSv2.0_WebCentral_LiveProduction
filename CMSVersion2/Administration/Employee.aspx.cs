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
namespace CMSVersion2.Administration
{
    public partial class Employee : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            radSearchEmployee.DataSource = GetEmployee();
            radSearchEmployee.DataTextField = "FullName";
            radSearchEmployee.DataValueField = "EmployeeId";



            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }
            if (!IsPostBack)
            {
                InitLoad();
            }

        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["EmployeeId"], e.Item.ItemIndex);
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

        #region Datatable

        public DataTable GetEmployee()
        {
            DataSet data = BLL.Employee_Info.GetEmployee(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            //convertdata.Columns.Add("FullName", typeof(string), "FirstName + ' ' + MiddleName + ' ' +LastName");
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetEmployeebyEmployeeId(Guid employeeId)
        {
            DataSet data = BLL.Employee_Info.GetEmployeeById(employeeId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetEmployeebySearch(Guid bcoId, Guid revenueUnitTypeId, Guid rUnitId)
        {
            DataSet data = BLL.Employee_Info.GetEmployeeBySearch(bcoId, revenueUnitTypeId, rUnitId, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #endregion

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

        #region Events

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

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetEmployee();
        }

        protected void radSearchEmployee_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string employeeId = string.Empty;
            string likeCondition;
            Guid empId = new Guid();

            if (e.DataItem != null)
            {
                employeeId = ((Dictionary<string, object>)e.DataItem)["EmployeeId"].ToString();
                empId = Guid.Parse(employeeId);
                if (!string.IsNullOrEmpty(employeeId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["EmployeeId"].ToString());
                    //gridEmployeeDataSource.SelectCommand = "SELECT [EmployeeId], [FirstName] , [MiddleName], [LastName], [BirthDate], [ContactNo], [Email], [CreatedDate]" + " FROM[Employee] WHERE RecordStatus = 1 AND [" + searchBox.DataValueField + "] LIKE " + likeCondition;
                    //RadGrid2.DataBind();
                    RadGrid2.DataSource = GetEmployeebyEmployeeId(empId);
                    //RadGrid2.DataSource = "SELECT [EmployeeId], [FirstName] , [MiddleName], [LastName], [BirthDate], [ContactNo], [Email], [CreatedDate]" + " FROM [Employee] WHERE RecordStatus = 1 and FirstName = [" + searchBox.Text + "] OR LastName = [" + searchBox.Text + "] or BirthDate = [" + searchBox.Text + "] ";
                    RadGrid2.DataBind();
                    // string search = radSearchEmployee.Text;
                }

            }
            else
            {
                RadGrid2.DataSource = GetEmployee();
                RadGrid2.DataBind();
            }
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
                RadGrid2.DataSource = GetEmployeebySearch(bcoId, revenueUnitTypeId, rUnitId);
                RadGrid2.DataBind();
            }

            //radSearchEmployee.Text = "";
            //string host = HttpContext.Current.Request.Url.Authority;
            //Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            //string batchCode = GlobalCode.globalCode;
            //BLL.Batch.InsertBatchName(txtBatchName.Text, batchCode, ID, getConstr.ConStrCMS);

            //string script = "<script>CloseOnReload()</" + "script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

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
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["EmployeeId"], e.Item.ItemIndex);
            }
        }

        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string employeeId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["EmployeeId"].ToString();
                BLL.Employee_Info.DeleteEmployee(new Guid(employeeId), 3, getConstr.ConStrCMS);
                //3 for delete flagging
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetEmployee();
            RadGrid2.Rebind();
        }
        #endregion
    }
}