using CMSVersion2.Models;
using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.CompanyModal
{
    public partial class Edit : System.Web.UI.Page
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


                    DataTable Data = GetCompanyInfo(new Guid(companyId));
                    int counter = 0;
                    foreach (DataRow row in Data.Rows)
                    {
                        if (counter == 0)
                        {
                            lblCompanyID.Text = row["CompanyId"].ToString();
                            #region Comp info
                            // Comp info
                            try
                            {
                                RadComboBoxItem compinfoCityId = rcbCompInfoCity.FindItemByValue(row["CityId"].ToString());
                                compinfoCityId.Selected = true;

                                txtCompInfoCompanyName.Text = row["CompanyName"].ToString();
                                txtCompInfoAddress1.Text = row["Address1"].ToString();
                                txtCompInfoAdress2.Text = row["Address2"].ToString();
                                txtCompInfozipCode.Text = row["ZipCode"].ToString();
                                txtContactNo.Text = row["ContactNo"].ToString();
                                txtCompInfoTin.Text = row["TinNo"].ToString();
                                txtCompInfoWebsite.Text = row["Website"].ToString();
                                txtCompInfoEmail.Text = row["Email"].ToString();
                                txtCompInfoPresident.Text = row["President"].ToString();

                                RadComboBoxItem compinfoIndustryId = rcbCompInfoIndustry.FindItemByValue(row["IndustryId"].ToString());
                                compinfoIndustryId.Selected = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            #endregion

                            #region Contact Information
                            //Contact Information
                            try
                            {
                                txtContactInContacPerson.Text = row["ContactPerson"].ToString();
                                txtContactInfoPostion.Text = row["ContactPosition"].ToString();
                                txtContactInfoDept.Text = row["ContactDepartment"].ToString();
                                txtContactInfoMobile.Text = row["ContactMobile"].ToString();
                                txtContactInfoTelNo.Text = row["ContactTelNo"].ToString();
                                txtContactInfoEmail.Text = row["ContactEmail"].ToString();
                                txtContactInfoFax.Text = row["ContactFax"].ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            #endregion



                            #region Account Info 1

                            try
                            {
                                //Account Info 1
                                RadComboBoxItem accttypeId = rcbAccountType.FindItemByValue(row["AccountTypeId"].ToString());
                                accttypeId.Selected = true;
                                RadComboBoxItem acctStatusId = rcbAccountStatus.FindItemByValue(row["AccountStatusId"].ToString());
                                acctStatusId.Selected = true;
                                RadComboBoxItem orgTypeId = rcbAcctInfoOrganizationType.FindItemByValue(row["OrganizationTypeId"].ToString());
                                orgTypeId.Selected = true;

                                RadComboBoxItem bussinessTypeId = rcbBusinessType.FindItemByValue(row["BusinessTypeId"].ToString());
                                bussinessTypeId.Selected = true;
                                RadComboBoxItem billingPeriodId = rcbBillingPeriod.FindItemByValue(row["BillingPeriodId"].ToString());
                                billingPeriodId.Selected = true;
                                RadComboBoxItem paymentTermId = rcbPaymentTerm.FindItemByValue(row["PaymentTermId"].ToString());
                                paymentTermId.Selected = true;

                                RadComboBoxItem paymentModeId = rcbPaymentMode.FindItemByValue(row["PaymentModeId"].ToString());
                                paymentModeId.Selected = true;
                                RadComboBoxItem approvedById = rcbApprovedBy.FindItemByValue(row["ApprovedById"].ToString());
                                approvedById.Selected = true;
                                RadComboBoxItem areaId = rcbArea.FindItemByValue(row["AreaId"].ToString());
                                areaId.Selected = true;

                                string dateApp = row["ApprovedDate"].ToString();
                                dateApproved.SelectedDate = Convert.ToDateTime(dateApp);

                                txtAcctDiscount.Text = row["Discount"].ToString();
                                txtAcctCreditLimit.Text = row["CreditLimit"].ToString();

                                RadComboBoxItem motherCompId = rcbAcctInfoMotherCompany.FindItemByValue(row["MotherCompanyId"].ToString());
                                motherCompId.Selected = true;
                                //DateTime dateApp = Convert.ToDateTime(row["ApprovedDate"].ToString());
                                //dateApproved.SelectedDate = dateApp;



                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            #endregion

                            #region Account Info 2
                            //Account Info 2
                            try
                            {
                                string HasAwbFee = row["HasAwbFee"].ToString();
                                string HasValuationCharge = row["HasValuationCharge"].ToString();
                                string HasInsurance = row["HasInsurance"].ToString();
                                string HasChargeInvoice = row["HasChargeInvoice"].ToString();
                                string IsVatable = row["IsVatable"].ToString();
                                string ApplyEvm = row["ApplyEvm"].ToString();

                                string ApplyWeight = row["ApplyWeight"].ToString();
                                string HasFreightCollectCharge = row["HasFreightCollectCharge"].ToString();
                                string HasFuelCharge = row["HasFuelCharge"].ToString();
                                string HasDeliveryFee = row["HasDeliveryFee"].ToString();
                                string HasPerishableFee = row["HasPerishableFee"].ToString();
                                string HasDangerousFee = row["HasDangerousFee"].ToString();

                                #region Checkboxes - ACCOUNT INFORMATION 2
                                //AWB FEE
                                if (HasAwbFee == "True" || (HasAwbFee == "1"))
                                {
                                    chkAWBFee.Checked = true;
                                }
                                else
                                {
                                    chkAWBFee.Checked = false;
                                }

                                //VALUATION CHARGE
                                if (HasValuationCharge == "True" || (HasValuationCharge == "1"))
                                {
                                    chkHasValuationCharge.Checked = true;
                                }
                                else
                                {
                                    chkHasValuationCharge.Checked = false;
                                }

                                //HAS INSURANCE
                                if (HasInsurance == "True" || (HasInsurance == "1"))
                                {
                                    chkHasInsurance.Checked = true;
                                }
                                else
                                {
                                    chkHasInsurance.Checked = false;
                                }

                                //HAS CHARGE INVOICE
                                if (HasChargeInvoice == "True" || (HasChargeInvoice == "1"))
                                {
                                    chkHasChargeInvoice.Checked = true;
                                }
                                else
                                {
                                    chkHasChargeInvoice.Checked = false;
                                }

                                //IS VATABLE
                                if (IsVatable == "True" || (IsVatable == "1"))
                                {
                                    chkhasVat.Checked = true;
                                }
                                else
                                {
                                    chkhasVat.Checked = false;
                                }

                                //APPLY EVM
                                if (ApplyEvm == "True" || (ApplyEvm == "1"))
                                {
                                    chkEVM.Checked = true;
                                }
                                else
                                {
                                    chkEVM.Checked = false;
                                }

                                //APPLY WEIGHT
                                if (ApplyWeight == "True" || (ApplyWeight == "1"))
                                {
                                    chkHasweightCharge.Checked = true;
                                }
                                else
                                {
                                    chkHasweightCharge.Checked = false;
                                }

                                //HAS FREIGHT COLLECT
                                if (HasFreightCollectCharge == "True" || (HasFreightCollectCharge == "1"))
                                {
                                    chkFC.Checked = true;
                                    chkCC.Checked = true;
                                }
                                else
                                {
                                    chkFC.Checked = false;
                                    chkCC.Checked = false;
                                }

                                //HAS FUEL CHARGE
                                if (HasFuelCharge == "True" || (HasFuelCharge == "1"))
                                {
                                    chkHasFuelCharge.Checked = true;

                                }
                                else
                                {
                                    chkHasFuelCharge.Checked = false;

                                }

                                //HAS DELIVERY FEE
                                if (HasDeliveryFee == "True" || (HasDeliveryFee == "1"))
                                {
                                    chkHasDevFee.Checked = true;

                                }
                                else
                                {
                                    chkHasDevFee.Checked = false;

                                }

                                //HAS PERISHABLE FEE
                                if (HasPerishableFee == "True" || (HasPerishableFee == "1"))
                                {
                                    chkHasPerishableFee.Checked = true;

                                }
                                else
                                {
                                    chkHasPerishableFee.Checked = false;

                                }

                                //HAS DANGEROUS FEE
                                if (HasDangerousFee == "True" || (HasDangerousFee == "1"))
                                {
                                    chkHasDangerousFee.Checked = true;

                                }
                                else
                                {
                                    chkHasDangerousFee.Checked = false;

                                }
                                #endregion

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            #endregion

                            #region BillingInfo
                            //BillingInfo
                            try
                            {
                                RadComboBoxItem billInfoCityId = rcbBillingInfoCity.FindItemByValue(row["BillingCityId"].ToString());
                                billInfoCityId.Selected = true;

                                txtBillingInfoAdd1.Text = row["BillingAddress1"].ToString();
                                txtBillingInfoAdd2.Text = row["BillingAddress2"].ToString();
                                txtBillingInfoZipCode.Text = row["BillingZipCode"].ToString();
                                txtBillingInfoContactPerson.Text = row["BillingContactPerson"].ToString();

                                txtBillingInfoPosition.Text = row["BillingContactPosition"].ToString();
                                txtBillingInfoDept.Text = row["BillingContactDepartment"].ToString();
                                txtBillingInfoContactNo.Text = row["BillingContactTelNo"].ToString();
                                txtBillingInfoMobileNo.Text = row["BillingContactMobile"].ToString();
                                txtBillingInfoEmail.Text = row["BillingContactEmail"].ToString();
                                txtBillingInfoFax.Text = row["BillingContactFax"].ToString();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            #endregion
                            counter++;
                        }
                    }

                }
            }
        }


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
            this.Page.Title = "Edit Company";
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

        public DataTable GetCompanyInfo(Guid ID)
        {
            DataSet data = BLL.Company.GetCompanyByCompanyId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
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
                string organizationType = rcbAcctInfoOrganizationType.SelectedItem.ToString();
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
            //DateTime dateApprove = Convert.ToDateTime(dateApproved.Text);
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
            billInfoCityId = Guid.Parse(rcbBillingInfoCity.SelectedValue.ToString());

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




        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CompInfo();
            ContactInfo();
            AcctInfo1();
            AccountInfo2();
            BillingInfo();

            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");

            BLL.Company.UpdateCompanyInfo(new Guid(lblCompanyID.Text), compInfo.CompanyName, compInfo.ContactInfo, compInfo.ContactInfoFax, compInfo.Email, compInfo.Address1,
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


            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);



        }


        #region Account Information 1
        protected void rcbBCO_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateRevenueUnitNameByBCOId();
        }

        protected void rcbOrganizationType_OnSelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbAcctInfoOrganizationType.Text.Equals("Head Office"))
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