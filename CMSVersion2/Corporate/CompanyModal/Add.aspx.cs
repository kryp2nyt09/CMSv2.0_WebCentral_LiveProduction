using CMSVersion2.Models;
using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.CompanyModal
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string urlWithSessionID = Response.ApplyAppPathModifier(Request.Url.PathAndQuery);
            //RadTab tab = RadTabStrip1.FindTabByUrl(urlWithSessionID);
            //if (tab != null)
            //{
            //    tab.SelectParents();
            //    tab.PageView.Selected = true;
            //}


            if (!IsPostBack)
            {
                InitLoad();
                if (Request.QueryString["ClientId"] != null || Request.QueryString["ClientId"].ToString() != "")
                {
                    string clientid = Request.QueryString["ClientId"].ToString();
                    lblClientId.Value = clientid;

                    DataTable Data = GetRepresentativesInfo(Guid.Parse(clientid));
                    int counter = 0;
                    foreach (DataRow row in Data.Rows)
                    {
                        if (counter == 0)
                        {
                            string companyName = row["CompanyName"].ToString();
                            string address1 = row["Address1"].ToString();
                            string address2 = row["Address2"].ToString();
                            string zipcode = row["ZipCode"].ToString();
                            string contactNo = row["ContactNo"].ToString();
                            string email = row["Email"].ToString();

                            if (row["CityId"].ToString() != "")
                            {
                                RadComboBoxItem cityId = rcbCompInfoCity.FindItemByValue(row["CityId"].ToString());
                                cityId.Selected = true;
                            }
                            txtCompInfoCompanyName.Text = companyName;
                            txtCompInfoAddress1.Text = address1;
                            txtCompInfoAdress2.Text = address2;
                            txtCompInfozipCode.Text = zipcode;
                            txtContactNo.Text = contactNo;
                            txtCompInfoEmail.Text = email;
                            counter++;
                        }
                            
                    }
                }
               
            }
        }

        #region
        public DataTable GetRepresentativesInfo(Guid clientid)
        {
            DataSet data = BLL.Representatives.GetRepresentativesByClientId(getConstr.ConStrCMS, clientid);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        #endregion

        #region Properties
        #region Comp Info
        //List<CompanyInformation> companyInfo = new List<CompanyInformation>();
        CompanyInformation compInfo = new CompanyInformation();
        // ContactInformation contactInfo = new ContactInformation();
        #endregion
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Company";
        }

        #region Initialization
        private void InitLoad()
        {
            //CompanyInformation
            LoadCity();
            LoadIndustryType();

            //AccountInformation1
            LoadAccountType();
            LoadAccountStatus();
            LoadOrganizationType();
            LoadBusinessType();
            LoadBillingPeriod();
            LoadPaymentTerm();
            LoadApprovedBy();
            LoadBCO();
            LoadAllRevenueUnit();
            loadDataMotherCompany();
            LoadPaymentMode();
        }
        #endregion

        #region DataSources
        #region CompanyInfo
        private void LoadCity()
        {
            rcbCompInfoCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbCompInfoCity.DataValueField = "CityId";
            rcbCompInfoCity.DataTextField = "CityName";
            rcbCompInfoCity.DataBind();

            rcbBillingInfoCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbBillingInfoCity.DataValueField = "CityId";
            rcbBillingInfoCity.DataTextField = "CityName";
            rcbBillingInfoCity.DataBind();
        }

        private void LoadIndustryType()
        {
            rcbCompInfoIndustry.DataSource = BLL.Industry.GetIndustry(getConstr.ConStrCMS);
            rcbCompInfoIndustry.DataValueField = "IndustryId";
            rcbCompInfoIndustry.DataTextField = "IndustryName";
            rcbCompInfoIndustry.DataBind();
        }
        #endregion

        #region Account Info 1
        private void LoadAccountType()
        {
            rcbAccountType.DataSource = BLL.AccountType.GetAccountType(getConstr.ConStrCMS);
            rcbAccountType.DataValueField = "AccountTypeId";
            rcbAccountType.DataTextField = "AccountTypeName";
            rcbAccountType.DataBind();
        }

        private void LoadAccountStatus()
        {
            rcbAccountStatus.DataSource = BLL.AccountStatus.GetAccountStatus(getConstr.ConStrCMS);
            rcbAccountStatus.DataValueField = "AccountStatusId";
            rcbAccountStatus.DataTextField = "AccountStatusName";
            rcbAccountStatus.DataBind();
        }

        private void LoadOrganizationType()
        {
            rcbAcctInfoOrganizationType.DataSource = BLL.OrganizationType.GetOrganizationType(getConstr.ConStrCMS);
            rcbAcctInfoOrganizationType.DataValueField = "OrganizationTypeId";
            rcbAcctInfoOrganizationType.DataTextField = "OrganizationTypeName";
            rcbAcctInfoOrganizationType.DataBind();
        }

        private void LoadBusinessType()
        {
            rcbBusinessType.DataSource = BLL.BusinessType.GetBusinessType(getConstr.ConStrCMS);
            rcbBusinessType.DataValueField = "BusinessTypeId";
            rcbBusinessType.DataTextField = "BusinessTypeName";
            rcbBusinessType.DataBind();
        }

        private void LoadBillingPeriod()
        {
            rcbBillingPeriod.DataSource = BLL.BillingPeriod.GetBillingPeriod(getConstr.ConStrCMS);
            rcbBillingPeriod.DataValueField = "BillingPeriodId";
            rcbBillingPeriod.DataTextField = "BillingPeriodName";
            rcbBillingPeriod.DataBind();
        }

        private void LoadPaymentTerm()
        {
            rcbPaymentTerm.DataSource = BLL.PaymentTerm.GetPaymentTerm(getConstr.ConStrCMS);
            rcbPaymentTerm.DataValueField = "PaymentTermId";
            rcbPaymentTerm.DataTextField = "PaymentTermName";
            rcbPaymentTerm.DataBind();

        }

        private void LoadApprovedBy()
        {
            rcbApprovedBy.DataSource = BLL.Employee_Info.GetEmployee(getConstr.ConStrCMS);
            rcbApprovedBy.DataValueField = "EmployeeId";
            rcbApprovedBy.DataTextField = "FullName";
            rcbApprovedBy.DataBind();
        }

        private void LoadBCO()
        {
            rcbBCO.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBCO.DataValueField = "BranchCorpOfficeId";
            rcbBCO.DataTextField = "BranchCorpOfficeName";
            rcbBCO.DataBind();
        }

        private void LoadAllRevenueUnit()
        {
            rcbArea.DataSource = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS);
            rcbArea.DataValueField = "RevenueUnitId";
            rcbArea.DataTextField = "RevenueUnitName";
            rcbArea.DataBind();
        }

        private void LoadPaymentMode()
        {
            rcbPaymentMode.DataSource = BLL.PaymentMode.GetPaymentMode(getConstr.ConStrCMS);
            rcbPaymentMode.DataValueField = "PaymentModeId";
            rcbPaymentMode.DataTextField = "PaymentModeName";
            rcbPaymentMode.DataBind();
        }

        private void populateRevenueUnitNameByBCOId()
        {
            DataTable LocationList = BLL.Revenue_Info.getRevenueUnitByBCOId(new Guid(rcbBCO.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
            rcbArea.DataSource = LocationList;
            rcbArea.DataValueField = "RevenueUnitId";
            rcbArea.DataTextField = "RevenueUnitName";
            rcbArea.DataBind();
        }

        private void LoadMotherCompany()
        {
            rcbAcctInfoMotherCompany.DataSource = BLL.Company.GetCompanies(getConstr.ConStrCMS);
            rcbAcctInfoMotherCompany.DataValueField = "CompanyId";
            rcbAcctInfoMotherCompany.DataTextField = "CompanyName";
            rcbAcctInfoMotherCompany.DataBind();
        }

        private void loadDataMotherCompany()
        {
            if (rcbAcctInfoOrganizationType.SelectedIndex >= 0)
            {
                string organizationType = rcbAcctInfoOrganizationType.SelectedItem.Text;
                if (organizationType.Equals("Head Office"))
                {
                    rcbAcctInfoMotherCompany.Enabled = false;
                    rcbAcctInfoMotherCompany.Items.Clear();
                }
                else if (organizationType.Equals("Branch Office"))
                {
                    rcbAcctInfoMotherCompany.Enabled = true;
                    LoadMotherCompany();
                }
            }

        }
        #endregion

        #region Account Info 2
        #endregion


        #endregion

        #region Methods
        #region Comp Info
        private void CompInfo()
        {
            Guid cityId = new Guid();
            Guid? industryId = new Guid();

            try
            {
                cityId = Guid.Parse(rcbCompInfoCity.SelectedValue.ToString());
                industryId = Guid.Parse(rcbCompInfoIndustry.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                industryId = null;
            }


            compInfo.CompanyName = txtCompInfoCompanyName.Text;
            compInfo.Address1 = txtCompInfoAddress1.Text;
            compInfo.Address2 = txtCompInfoAdress2.Text;
            compInfo.CityId = cityId;
            compInfo.CompanyInfoZipCode = txtCompInfozipCode.Text;
            compInfo.IndustryId = industryId;
            compInfo.ContactInfo = txtContactNo.Text;
            compInfo.Tin = txtCompInfoTin.Text;
            compInfo.Website = txtCompInfoWebsite.Text;
            compInfo.Email = txtCompInfoEmail.Text;
            compInfo.President = txtCompInfoPresident.Text;

        }
        #endregion
        #region Contact Info
        private void ContactInfo()
        {
            compInfo.ContactPerson = txtContactInContacPerson.Text;
            compInfo.Position = txtContactInfoPostion.Text;
            compInfo.Department = txtContactInfoDept.Text;
            compInfo.MobileNo = txtContactInfoMobile.Text;
            compInfo.ContactInfoTelNo = txtContactInfoTelNo.Text;
            compInfo.ContactInfoEmail = txtContactInfoEmail.Text;
            compInfo.ContactInfoFax = txtContactInfoFax.Text;
        }
        #endregion

        #region AcctInfo1
        private void AcctInfo1()
        {
            Guid AccttypeId = new Guid();
            Guid acctStatusId = new Guid();
            Guid OrgTypeId = new Guid();

            Guid? MotherCompId = new Guid();
            Guid BusinessTypeId = new Guid();
            Guid BillingPeriodId = new Guid();
            Guid PaymentTermId = new Guid();
            Guid PaymentModeId = new Guid();
            Guid ApproveById = new Guid();
            Guid AreaId = new Guid();
            DateTime dateApprove = dateApproved.SelectedDate.Value;
            decimal Discount = 0;
            decimal CreditLimit = 0;

            if (txtAcctDiscount.Text == null)
            {
                compInfo.Discount = Discount;
            }
            else
            {
                Discount = Convert.ToDecimal(txtAcctDiscount.Text);
            }

            if (txtAcctCreditLimit.Text == null)
            {
                compInfo.CreditLimit = CreditLimit;
            }
            else
            {
                CreditLimit = Convert.ToDecimal(txtAcctCreditLimit.Text);
            }

            if (rcbAcctInfoMotherCompany.Items.Count == 0)
            {
                MotherCompId = null;
                // compInfo.MotherCompId = (MotherCompId == null) ? (Guid?)null : MotherCompId;
            }
            else
            {
                try
                {
                    MotherCompId = Guid.Parse(rcbAcctInfoMotherCompany.SelectedValue.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            try
            {
                AccttypeId = Guid.Parse(rcbAccountType.SelectedValue.ToString());
                acctStatusId = Guid.Parse(rcbAccountStatus.SelectedValue.ToString());
                OrgTypeId = Guid.Parse(rcbAcctInfoOrganizationType.SelectedValue.ToString());
                BusinessTypeId = Guid.Parse(rcbBusinessType.SelectedValue.ToString());
                BillingPeriodId = Guid.Parse(rcbBillingPeriod.SelectedValue.ToString());
                PaymentTermId = Guid.Parse(rcbPaymentTerm.SelectedValue.ToString());
                PaymentModeId = Guid.Parse(rcbPaymentMode.SelectedValue.ToString());
                ApproveById = Guid.Parse(rcbApprovedBy.SelectedValue.ToString());
                AreaId = Guid.Parse(rcbArea.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            compInfo.AccttypeId = AccttypeId;
            compInfo.AcctStatusId = acctStatusId;
            compInfo.OrgTypeId = OrgTypeId;
            compInfo.MotherCompId = MotherCompId;
            compInfo.BusinessTypeId = BusinessTypeId;
            compInfo.BillingPeriodId = BillingPeriodId;
            compInfo.PaymentTermId = PaymentTermId;
            compInfo.PaymentModeId = PaymentModeId;
            compInfo.ApproveById = ApproveById;
            compInfo.AreaId = AreaId;
            compInfo.dateApprove = dateApprove;
            compInfo.Discount = Discount;
            compInfo.CreditLimit = CreditLimit;
        }
        #endregion

        #region AccountInfo2
        private void AccountInfo2()
        {

            if (chkEVM.Checked == true)
            {
                compInfo.appliedEVM = true;
            }
            else
            {
                compInfo.appliedEVM = false;
            }

            if (chkAWBFee.Checked == true)
            {
                compInfo.hasAWBFee = true;
            }
            else
            {
                compInfo.hasAWBFee = false;
            }

            if (chkFC.Checked == true || chkCC.Checked == true)
            {
                compInfo.hasFCFee = true;
            }
            else
            {
                compInfo.hasFCFee = false;
            }

            if (chkHasInsurance.Checked == true)
            {
                compInfo.hasInsurance = true;
            }
            else
            {
                compInfo.hasInsurance = false;
            }

            if (chkHasFuelCharge.Checked == true)
            {
                compInfo.hasFuelCharge = true;
            }
            else
            {
                compInfo.hasFuelCharge = false;
            }

            if (chkhasVat.Checked == true)
            {
                compInfo.hasVatable = true;
            }
            else
            {
                compInfo.hasVatable = false;
            }

            if (chkHasValuationCharge.Checked == true)
            {
                compInfo.hasValuationCharge = true;
            }
            else
            {
                compInfo.hasValuationCharge = false;
            }

            if (chkHasDevFee.Checked == true)
            {
                compInfo.hasDeliveryFee = true;
            }
            else
            {
                compInfo.hasDeliveryFee = false;
            }

            if (chkHasPerishableFee.Checked == true)
            {
                compInfo.hasPerishableFee = true;
            }
            else
            {
                compInfo.hasPerishableFee = false;
            }

            if (chkHasDangerousFee.Checked == true)
            {
                compInfo.hasDangerousFee = true;
            }
            else
            {
                compInfo.hasDangerousFee = false;
            }

            if (chkHasweightCharge.Checked == true)
            {
                compInfo.hasWeightCharge = true;
            }
            else
            {
                compInfo.hasWeightCharge = false;
            }

            if (chkHasChargeInvoice.Checked == true)
            {
                compInfo.hasChargeInvoice = true;
            }
            else
            {
                compInfo.hasChargeInvoice = false;
            }
        }


        #endregion

        #region Billing Info
        private void BillingInfo()
        {
            Guid billInfoCityId = new Guid();
            try
            {
                billInfoCityId = Guid.Parse(rcbBillingInfoCity.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            compInfo.billInfoAddress1 = txtBillingInfoAdd1.Text;
            compInfo.billInfoAddress2 = txtBillingInfoAdd2.Text;
            compInfo.billInfoCityId = billInfoCityId;
            compInfo.billInfozipCode = txtBillingInfoZipCode.Text;
            compInfo.billInfoContactPerson = txtBillingInfoContactPerson.Text;
            compInfo.billInfoPosition = txtBillingInfoPosition.Text;
            compInfo.billInfoDepartment = txtBillingInfoDept.Text;
            compInfo.billInfoContactNo = txtBillingInfoContactNo.Text;
            compInfo.billInfoMobileNo = txtBillingInfoMobileNo.Text;
            compInfo.billInfoEmail = txtBillingInfoEmail.Text;
            compInfo.billInfoFax = txtBillingInfoFax.Text;
        }
        #endregion

        #region Validate Data
        public bool IsDataValid()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtCompInfoCompanyName.Text) || string.IsNullOrEmpty(txtContactNo.Text) || string.IsNullOrEmpty(txtCompInfoAddress1.Text))
            {
                isValid = false;

            }

            return isValid;
        }
        #endregion




        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsDataValid())
            {
                CompInfo();
                ContactInfo();
                AcctInfo1();
                AccountInfo2();
                BillingInfo();

                Guid ID = new Guid("11111111-1111-1111-1111-111111111111");

                BLL.Company.InsertCompanyInfo(compInfo.CompanyName, compInfo.ContactInfo, compInfo.ContactInfoFax, compInfo.Email, compInfo.Address1,
                                        compInfo.Address2, compInfo.CityId, compInfo.CompanyInfoZipCode, compInfo.Website, compInfo.President,
                                        compInfo.Tin, compInfo.MotherCompId, compInfo.ContactPerson, compInfo.Position, compInfo.Department,
                                    compInfo.ContactInfoTelNo, compInfo.MobileNo, compInfo.ContactInfoEmail, "", compInfo.billInfoAddress1,
                                    compInfo.billInfoAddress2, compInfo.billInfoCityId, compInfo.billInfozipCode, compInfo.billInfoContactPerson, compInfo.billInfoPosition,
                                    compInfo.billInfoDepartment, compInfo.billInfoContactNo, compInfo.billInfoMobileNo, compInfo.billInfoEmail, compInfo.billInfoFax,
                                    compInfo.AccttypeId, compInfo.IndustryId, compInfo.BusinessTypeId, compInfo.OrgTypeId, compInfo.AcctStatusId,
                                    compInfo.dateApprove, compInfo.ApproveById, compInfo.PaymentTermId, compInfo.PaymentModeId, compInfo.BillingPeriodId,
                                    compInfo.Discount, compInfo.hasAWBFee, compInfo.hasValuationCharge, compInfo.hasInsurance, compInfo.hasChargeInvoice,
                                    compInfo.hasVatable, compInfo.appliedEVM, compInfo.hasWeightCharge, compInfo.hasFCFee, compInfo.hasFuelCharge,
                                    compInfo.hasDeliveryFee, compInfo.hasPerishableFee, compInfo.hasDangerousFee, compInfo.AreaId,
                                    compInfo.CreditLimit, "", ID, getConstr.ConStrCMS);



                if(lblClientId.Value != null || lblClientId.Value != "")
                {
                    Guid id = new Guid();
                    id = Guid.Parse(lblClientId.Value);
                    BLL.Clients.UpdateClientProfile(id, 3, getConstr.ConStrCMS);
                }

                string script = "<script>CloseOnReload()</" + "script>";
                ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
            }
            else
            {
                //string alert = "<script>alert('Fill out required fields!.)</" + "script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", alert);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill out required fields!')", true);
            }








        }


        #region Account Information 1
        protected void rcbBCO_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCOId();
        }

        protected void rcbOrganizationType_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbAcctInfoOrganizationType.SelectedItem.Text.Equals("Head Office"))
            {
                rcbAcctInfoMotherCompany.Enabled = false;
                rcbAcctInfoMotherCompany.Items.Clear();
            }
            else
            {
                rcbAcctInfoMotherCompany.Enabled = true;
                LoadMotherCompany();
            }
        }
        #endregion
        #endregion


    }
}