using System;
using System.Data;
using System.Web;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.RepresentativeModal
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
                if (Request.QueryString["CompanyId"] == null)
                {

                }
                else
                {
                    string companyId = Request.QueryString["CompanyId"].ToString();
                    DataTable GroupInfo = GetCompanyDetails(new Guid(companyId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string company = row["CompanyName"].ToString();
                            rcbRepCompany.SelectedItem.Text = company;
                            rcbRepCompany.SelectedItem.Value = companyId;
                            rcbRepCompany.Enabled = false;
                        }
                    }

                }

            }
        }


        #region InitLoad
        private void InitLoad()
        {
            LoadCity();
            LoadAllRevenueUnit();
            LoadCompany();
            LoadBranchCorporateOffice();
            LoadRevenueUnitType();
            PopulateRevenueUnitName();
        }
        #endregion


        #region Data Sources
        private void LoadCity()
        {
            rcbRepCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbRepCity.DataValueField = "CityId";
            rcbRepCity.DataTextField = "CityName";
            rcbRepCity.DataBind();
        }

        private void LoadAllRevenueUnit()
        {
            rcbRepArea.DataSource = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS);
            rcbRepArea.DataValueField = "RevenueUnitId";
            rcbRepArea.DataTextField = "RevenueUnitName";
            rcbRepArea.DataBind();
        }

        private void LoadCompany()
        {
            rcbRepCompany.DataSource = BLL.Company.GetCompanies(getConstr.ConStrCMS);
            rcbRepCompany.DataValueField = "CompanyId";
            rcbRepCompany.DataTextField = "CompanyName";
            rcbRepCompany.DataBind();
        }

        public DataTable GetCompanyDetails(Guid ID)
        {
            DataSet data = BLL.Company.GetCompanyByCompanyId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        private void LoadBranchCorporateOffice()
        {
            DataTable bcoList = BLL.Revenue_Info.getBranchCorp(getConstr.ConStrCMS).Tables[0];

            rcbBco.DataSource = bcoList;
            rcbBco.DataTextField = "BranchCorpOfficeName";
            rcbBco.DataValueField = "BranchCorpOfficeId";
            rcbBco.DataBind();

        }

        private void LoadRevenueUnitType()
        {
            DataTable revenueUnitTypeList = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS).Tables[0];
            rcbRevenueType.DataSource = revenueUnitTypeList;
            rcbRevenueType.DataTextField = "RevenueUnitTypeName";
            rcbRevenueType.DataValueField = "RevenueUnitTypeId";
            rcbRevenueType.DataBind();
        }

        private void PopulateRevenueUnitName()
        {
            DataTable revenueUnitName = BLL.Revenue_Info.getRevenueUnit(new Guid(rcbRevenueType.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRepArea.DataSource = revenueUnitName;
            rcbRepArea.DataTextField = "RevenueUnitName";
            rcbRepArea.DataValueField = "RevenueUnitId";
            rcbRepArea.DataBind();
        }

        private void populateRevenueUnitNameByBCO()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCO(new Guid(rcbRevenueType.SelectedValue.ToString()), new Guid(rcbBco.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbRepArea.DataSource = LocationList;
            rcbRepArea.DataTextField = "RevenueUnitName";
            rcbRepArea.DataValueField = "RevenueUnitId";
            rcbRepArea.DataBind();
        }
        #endregion


        protected void btnSave_Click(object sender, EventArgs e)
        {

            string host = HttpContext.Current.Request.Url.Authority;
            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            Guid cityId = new Guid();
            Guid? companyId = new Guid();
            Guid areaId = new Guid();

            try
            {
                cityId = Guid.Parse(rcbRepCity.SelectedValue.ToString());
                int selected = rcbRepCompany.SelectedIndex;


                if (selected == -1)
                {
                    companyId = null;
                }
                else
                {
                    companyId = Guid.Parse(rcbRepCompany.SelectedValue.ToString());
                }

                
                areaId = Guid.Parse(rcbRepArea.SelectedValue.ToString());


                BLL.Representatives.InsertRepresentatives(txtRepFirstName.Text, txtRepLastName.Text, txtRepContactNo.Text, txtRepMobileNo.Text, txtRepFax.Text,
              txtRepEmail.Text, txtRepAdress1.Text, txtRepAdress2.Text, cityId, txtRepzipCode.Text, txtRepTitle.Text,
              txtRepDept.Text, txtRepRemarks.Text, companyId, areaId, txtRepStreet.Text,
              txtRepBarangay.Text, ID, getConstr.ConStrCMS);

                string script = "<script>CloseOnReload()</" + "script>";
                ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
          

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void rcbRevenueType_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }

        protected void rcbRevenueType_TextChanged(object sender, EventArgs e)
        {
            rcbRepArea.Items.Clear();
            populateRevenueUnitNameByBCO();
        }

        protected void rcbBco_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCO();
        }
    }
}