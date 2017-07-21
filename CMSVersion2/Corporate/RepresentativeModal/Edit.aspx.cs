using System;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.RepresentativeModal
{
    public partial class Edit : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
                if (Request.QueryString["ClientId"] == null)
                {

                }
                else
                {
                    string clientId = Request.QueryString["ClientId"].ToString();
                    DataTable Data = GetRepresentativesInfo(new Guid(clientId));
                    int counter = 0;
                    foreach (DataRow row in Data.Rows)
                    {
                        if (counter == 0)
                        {
                            lblRepresenatativesID.Text = row["ClientId"].ToString();
                            string comp = row["CompanyId"].ToString();
                            if (row["CityId"].ToString() != "")
                            {
                                RadComboBoxItem cityId = rcbRepCity.FindItemByValue(row["CityId"].ToString());
                                cityId.Selected = true;
                            }

                            
                            if (row["CompanyId"].ToString() != "")
                            {
                                RadComboBoxItem companyId = rcbRepCompany.FindItemByValue(row["CompanyId"].ToString());
                                companyId.Selected = true;
                            }
                            
                            if(row["BranchCorpOfficeId"].ToString() != "")
                            {
                                RadComboBoxItem bcoId = rcbBco.FindItemByValue(row["BranchCorpOfficeId"].ToString());
                                bcoId.Selected = true;
                            }

                            if (row["RevenueUnitTypeId"].ToString() != "")
                            {
                                RadComboBoxItem runitType = rcbRevenueType.FindItemByValue(row["RevenueUnitTypeId"].ToString());
                                runitType.Selected = true;
                            }

                            if (row["AreaId"].ToString() != "")
                            {
                                RadComboBoxItem areaId = rcbRepArea.FindItemByValue(row["AreaId"].ToString());
                                areaId.Selected = true;
                            }
                            

                            txtRepFirstName.Text = row["FirstName"].ToString();
                            txtRepLastName.Text = row["LastName"].ToString();
                            txtRepContactNo.Text = row["ContactNo"].ToString();
                            txtRepMobileNo.Text = row["Mobile"].ToString();
                            txtRepFax.Text = row["Fax"].ToString();
                            txtRepEmail.Text = row["Email"].ToString();
                            txtRepAdress1.Text = row["Address1"].ToString();
                            txtRepAdress2.Text = row["Address2"].ToString();
                            txtRepzipCode.Text = row["ZipCode"].ToString();

                            txtRepTitle.Text = row["Title"].ToString();
                            txtRepDept.Text = row["Department"].ToString();
                            txtRepRemarks.Text = row["Remarks"].ToString();
                            txtRepStreet.Text = row["Street"].ToString();
                            txtRepBarangay.Text = row["Barangay"].ToString();

                            counter++;

                        }
                    }

                }
            }
        }


        public DataTable GetRepresentativesInfo(Guid ID)
        {
            DataSet data = BLL.Representatives.GetRepresentativesByClientId(getConstr.ConStrCMS, ID);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
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
                if (selected == -1 || rcbRepCompany.SelectedItem.Text.ToString().Equals(""))
                {
                    companyId = null;
                }
                else
                {
                    companyId = Guid.Parse(rcbRepCompany.SelectedValue.ToString());
                }


                areaId = Guid.Parse(rcbRepArea.SelectedValue.ToString());

                BLL.Representatives.UpdateRepresentatives(new Guid(lblRepresenatativesID.Text), txtRepFirstName.Text, txtRepLastName.Text, txtRepContactNo.Text, txtRepMobileNo.Text, txtRepFax.Text,
               txtRepEmail.Text, txtRepAdress1.Text, txtRepAdress2.Text, cityId, txtRepzipCode.Text, txtRepTitle.Text,
               txtRepDept.Text, txtRepRemarks.Text, companyId, areaId, txtRepStreet.Text,
               txtRepBarangay.Text, ID, getConstr.ConStrCMS);

                string script = "<script>closeWindow()</" + "script>";
                ClientScript.RegisterStartupScript(this.GetType(), "closeWindow", script);

            }
            catch (Exception)
            {

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