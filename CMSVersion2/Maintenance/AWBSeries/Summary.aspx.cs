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
    public partial class Summary : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

            if (!IsPostBack)
            {
                InitLoad();
                startDate.SelectedDate = DateTime.Now;
                endDate.SelectedDate = DateTime.Now;
            }
        }

        #region InitLoad
        public void InitLoad()
        {
            LoadBranchCorporateOffice();
            LoadRevenueUnitType();
        }
        #endregion

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                radGridAwbIssuedSummary.MasterTableView.SortExpressions.Clear();
                radGridAwbIssuedSummary.MasterTableView.GroupByExpressions.Clear();
                radGridAwbIssuedSummary.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                radGridAwbIssuedSummary.MasterTableView.SortExpressions.Clear();
                radGridAwbIssuedSummary.MasterTableView.GroupByExpressions.Clear();
                radGridAwbIssuedSummary.MasterTableView.CurrentPageIndex = radGridAwbIssuedSummary.MasterTableView.PageCount - 1;
                radGridAwbIssuedSummary.Rebind();
            }
        }



        #region DataSources
        public DataTable GetAWBIssuance()
        {
            DataSet data = BLL.AwbIssuance.GetAwbIssuance(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        private void LoadBranchCorporateOffice()
        {
            DataTable bcoList = BLL.Revenue_Info.getBranchCorp(getConstr.ConStrCMS).Tables[0];
            rcbBranchCorpOffice.DataSource = bcoList;
            rcbBranchCorpOffice.DataTextField = "BranchCorpOfficeName";
            rcbBranchCorpOffice.DataValueField = "BranchCorpOfficeId";
            rcbBranchCorpOffice.DataBind();

        }

        private void LoadRevenueUnitType()
        {
            DataTable revenueUnitTypeList = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS).Tables[0];
            rcbRevenueUnitType.DataSource = revenueUnitTypeList;
            rcbRevenueUnitType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueUnitType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueUnitType.DataBind();
            if (revenueUnitTypeList != null)
            {
                rcbRevenueUnitType.Items.Insert(0, "All");
            }
        }

        public DataTable GetAWBIssuedSummarybySearch(Guid bcoId, Guid? revenueUnitTypeId, DateTime start, DateTime end, string constr)
        {
            DataSet data = BLL.AwbSeries.GetAwbIssuedSummary(bcoId, revenueUnitTypeId, start, end, constr);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        #endregion


        #region Events
        #region RadGrid Events
        protected void radGridAwbIssuedSummary_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridAwbIssuedSummary.DataSource = GetAWBIssuance();
        }
        #endregion

        #region Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Guid bcoId = new Guid();
            Guid? revenueUnitTypeId = new Guid();
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            string revenueType = "";

            try
            {
                revenueType = rcbRevenueUnitType.SelectedItem.Text;
                if (revenueType.Equals("All"))
                {
                    revenueUnitTypeId = null;
                }
                else
                {
                    revenueUnitTypeId = Guid.Parse(rcbRevenueUnitType.SelectedValue.ToString());
                }
                bcoId = Guid.Parse(rcbBranchCorpOffice.SelectedValue.ToString());
                start = startDate.SelectedDate.Value;
                end = endDate.SelectedDate.Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (bcoId != null)
            {
                radGridAwbIssuedSummary.DataSource = GetAWBIssuedSummarybySearch(bcoId, revenueUnitTypeId, start, end, getConstr.ConStrCMS);
                radGridAwbIssuedSummary.DataBind();
            }



        }
        #endregion
        #endregion
    }
}