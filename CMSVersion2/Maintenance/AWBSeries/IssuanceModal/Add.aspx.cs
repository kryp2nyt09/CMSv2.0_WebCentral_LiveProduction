using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.AWBSeries.InssuanceModal
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadBranchCorpOffice();
                LoadRevenueType();
                LoadArea();
                LoadEmployee();
                rdDateAssigned.SelectedDate = DateTime.Now;

            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Series";
        }

        #region DataSources
        public DataTable GetGroupIsland(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.IslandGroup.GetIslandGroupById(getConstr.ConStrCMS, ID);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        private void LoadBranchCorpOffice()
        {
            rdcBCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rdcBCO.DataValueField = "BranchCorpOfficeId";
            rdcBCO.DataTextField = "BranchCorpOfficeName";
            rdcBCO.DataBind();
        }

        private void LoadArea()
        {
            DataTable area = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS).Tables[0];
            rdcArea.DataSource = area;
            rdcArea.DataValueField = "RevenueUnitId";
            rdcArea.DataTextField = "RevenueUnitName";
            rdcArea.DataBind();
            if (area != null)
            {
                //rdcArea.Items.Insert(0, "None");
                rdcArea.Items.Add("None");
            }
        }

        private void LoadRevenueType()
        {
            rcbRevenueType.DataSource = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS);
            rcbRevenueType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueType.DataBind();
        }

        private void LoadEmployee()
        {
            DataTable employee = BLL.Employee_Info.GetEmployee(getConstr.ConStrCMS).Tables[0];
            rcbName.DataSource = employee;
            rcbName.DataValueField = "EmployeeId";
            rcbName.DataTextField = "FullName";
            rcbName.DataBind();
            if (employee != null)
            {
                //rcbName.Items.Insert(0,"None");
                rcbName.Items.Add("None");
            }

        }

        private void populateRevenueUnitNameByBCO()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(rcbRevenueType.SelectedValue.ToString()), new Guid(rdcBCO.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rdcArea.DataSource = LocationList;
            rdcArea.DataTextField = "RevenueUnitName";
            rdcArea.DataValueField = "RevenueUnitId";
            rdcArea.DataBind();
            if (LocationList != null)
            {
                //rdcArea.Items.Insert(0, "None");
                rdcArea.Items.Add("None");
            }
        }

        private void populateEmployeeByArea()
        {
            DataTable LocationList = BLL.Employee_Info.GetEmployeeBySearch(new Guid(rdcBCO.SelectedValue.ToString()), new Guid(rcbRevenueType.SelectedValue.ToString()), new Guid(rdcArea.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbName.DataSource = LocationList;
            rcbName.DataTextField = "FullName";
            rcbName.DataValueField = "EmployeeId";
            rcbName.DataBind();
            if (LocationList != null)
            {
                //rcbName.Items.Insert(0, "None");
                rcbName.Items.Add("None");
            }
        }
        #endregion

        #region Events
        protected void rdcBCO_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueType_TextChanged(object sender, EventArgs e)
        {
            rdcArea.Items.Clear();
            populateRevenueUnitNameByBCO();
        }

        protected void rdcArea_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateEmployeeByArea();
        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            }
            else if (e.CommandName == "Insert")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //logic to truncate long string to prevent SQL error
            for (int i = 1; i < 4; i++)
            {
                string val = e.NewValues[i - 1].ToString();
                int maxLength = i * 10;
                if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
            }
        }

        protected void DetailsView1_ItemCommand1(object sender, DetailsViewCommandEventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating1(object sender, DetailsViewUpdateEventArgs e)
        {

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid BCOid = new Guid();
            Guid? AreaId = new Guid();
            Guid? empId = new Guid();

            string seriesStart = "";
            string seriesEnd = "";
            DateTime assignedate = new DateTime();

            Guid CreatedBy = new Guid();
            string emp = "";
            string area = "";

            try
            {
                BCOid = new Guid(rdcBCO.SelectedItem.Value.ToString());
                emp = rcbName.SelectedItem.Text;
                area = rdcArea.SelectedItem.Text;
                if (emp.Equals("None"))
                {
                    empId = null;
                }
                else
                {
                    empId = new Guid(rcbName.SelectedItem.Value.ToString());
                }

                if (area.Equals("None"))
                {
                    AreaId = null;
                }
                else
                {
                    AreaId = new Guid(rdcArea.SelectedItem.Value.ToString());
                }

                seriesStart = txtStartSeries.Text;
                seriesEnd = txtEndSeries.Text;
                assignedate = rdDateAssigned.SelectedDate.Value;
                CreatedBy = new Guid("11111111-1111-1111-1111-111111111111");
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            string host = HttpContext.Current.Request.Url.Authority;
            BLL.AwbIssuance.InsertAWBIssuance(seriesStart, seriesEnd, assignedate, AreaId, BCOid, empId, CreatedBy, getConstr.ConStrCMS);
            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        #endregion


    }
}