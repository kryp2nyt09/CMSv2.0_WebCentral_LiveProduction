using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Administration.UserModal
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        //string password = "";
        //string confirmpassword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateEmployeeDDL();
                //PopulateAssignment();
                //populateLocation();
                //populateBranchCorporateOffice();
            }

        }

        //private void populateLocation()
        //{
        //    DataTable LocationList = BLL.Revenue_Info.getRevenueUnit(new Guid(ddlAssigned.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
        //    ddlLocation.DataSource = LocationList;
        //    ddlLocation.DataTextField = "RevenueUnitName";
        //    ddlLocation.DataValueField = "RevenueUnitId";
        //    ddlLocation.DataBind();
        //}

        //private void populateFilteredRevenueUnit()
        //{
        //    DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(ddlAssigned.SelectedValue.ToString()), new Guid(ddlBranchCorpOffice.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
        //    ddlLocation.DataSource = LocationList;
        //    ddlLocation.DataTextField = "RevenueUnitName";
        //    ddlLocation.DataValueField = "RevenueUnitId";
        //    ddlLocation.DataBind();
        //}

        //private void populateBranchCorporateOffice()
        //{
        //    DataTable LocationList = BLL.Revenue_Info.getBranchCorp(getConstr.ConStrCMS).Tables[0];

        //    ddlBranchCorpOffice.DataSource = LocationList;
        //    ddlBranchCorpOffice.DataTextField = "BranchCorpOfficeName";
        //    ddlBranchCorpOffice.DataValueField = "BranchCorpOfficeId";
        //    ddlBranchCorpOffice.DataBind();

        //}
        //private void PopulateAssignment()
        //{
        //    DataTable EmployeeNameList = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS).Tables[0];
        //    ddlAssigned.DataSource = EmployeeNameList;
        //    ddlAssigned.DataTextField = "RevenueUnitTypeName";
        //    ddlAssigned.DataValueField = "RevenueUnitTypeId";
        //    ddlAssigned.DataBind();
        //}


        private void PopulateEmployeeDDL()
        {
            DataTable EmployeeNameList = BLL.Employee_Info.EmployeeNameinUser(getConstr.ConStrCMS).Tables[0];
            ddLEmployee.DataSource = EmployeeNameList;
            ddLEmployee.DataTextField = "EmployeeName";
            ddLEmployee.DataValueField = "EmployeeID";
            ddLEmployee.DataBind();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.QueryString["employeeid"] == null)
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Insert;
            }
            else
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Edit;
            }
            this.Page.Title = "Add New User";
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

        protected void ddlAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populateLocation();
        }

        protected void ddlAssigned_TextChanged(object sender, EventArgs e)
        {

            ///ddlLocation.Items.Clear();

            // populateLocation();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (!(txtPassword.Text == "") && !(txtConfirmPassword.Text == ""))
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    Guid employeeId = new Guid(ddLEmployee.SelectedItem.Value.ToString());
                    // Guid revenueUnitId = new Guid(ddlLocation.SelectedItem.Value.ToString());

                    Guid ModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
                    string host = HttpContext.Current.Request.Url.Authority;
                    string UserName = txtUsername.Text;
                    byte[] Password = Tools.Encryption.EncryptPassword(txtPassword.Text);

                    BLL.Users_Info.AddUsers(UserName, Password, Password, employeeId, new Guid("11111111-1111-1111-1111-111111111111"), getConstr.ConStrCMS);
                    //if(countRowsAffected > 0)
                    //{
                    string script = "<script>CloseOnReload()</" + "script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
                    //}
                    //else
                    //{
                    //    string script = "<script>alert('Already Exists')</" + "script>";
                    //    ClientScript.RegisterStartupScript(GetType(), "Alert", script);
                    //}


                }
                else
                {

                }
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void ddlBranchCorpOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populateFilteredRevenueUnit();
        }
    }
}