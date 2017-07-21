using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL = DataAccess;


namespace BusinessLogic
{
    public class Company
    {
        public static DataSet GetCompanies(string conSTR)
        {
            return DAL.Company.GetCompanies(conSTR);
        }

        public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        {
            DAL.Client.UpdateClientProfile(ClientID, Flag, conStr);
        }

        public static DataSet GetCompanyById(Guid companyId, string conStr)
        {
            return DAL.Company.GetCompanyById(companyId, conStr);
        }

        public static void InsertCompanyInfo(string companyName, string contactNo, string fax, string email, string address1,
                                             string address2, Guid cityId, string zipCode, string website, string president,
                                        string tin, Guid? motherCompanyId, string contactperson, string contactPosition, string contactDept,
                                        string contactTelNo, string contactMobile, string contactEmail, string contactfax, string billAddress1,
                                        string billAddress2, Guid BillingCityId, string billzipCode, string billContactPerson, string billContactPosition,
                                        string billContactDept, string billcontactTelNo, string billContactMobile, string billContactEmail, string billContactFax,
                                        Guid acctTypeId, Guid? IndustryId, Guid BusinessTypeId, Guid OrganizationTypeId, Guid accStatusId, 
                                        DateTime approvedDate, Guid ApprovedById, Guid? paymentTermId, Guid? paymentModeId, Guid billingPeriodId, 
                                        decimal discount, bool hasAwbFee, bool hasvaluationCharge, bool hasInsurance, bool hasChargeinvoice,
                                        bool isVatable, bool applyEvm, bool applyWeight, bool hasfeightCollectCharge, bool hasFuelCharge,
                                        bool hasDeliveryFee, bool hasPerishableFee, bool hasDangerousFee, Guid Areaid, decimal creditLimit, 
                                        string remarks, Guid createdBy, string conStr) 
        {
            DAL.Company.InsertCompanyInfo(companyName, contactNo, fax, email, address1,
                                       address2, cityId, zipCode, website, president,
                                       tin, motherCompanyId, contactperson, contactPosition, contactDept, 
                                       contactTelNo, contactMobile, contactEmail, contactfax, billAddress1,
                                       billAddress2, BillingCityId, billzipCode, billContactPerson, billContactPosition,
                                       billContactDept,billcontactTelNo, billContactMobile, billContactEmail, billContactFax,
                                       acctTypeId, IndustryId, BusinessTypeId, OrganizationTypeId, accStatusId,
                                       approvedDate, ApprovedById, paymentTermId, paymentModeId, billingPeriodId,
                                       discount, hasAwbFee, hasvaluationCharge, hasInsurance, hasChargeinvoice,
                                       isVatable, applyEvm, applyWeight, hasfeightCollectCharge, hasFuelCharge,
                                       hasDeliveryFee, hasPerishableFee, hasDangerousFee, Areaid, creditLimit,
                                       remarks, createdBy, conStr);
        }


        public static void UpdateCompanyInfo(Guid companyId, string companyName, string contactNo, string fax, string email, string address1,
                                           string address2, Guid cityId, string zipCode, string website, string president,
                                      string tin, Guid? motherCompanyId, string contactperson, string contactPosition, string contactDept,
                                      string contactTelNo, string contactMobile, string contactEmail, string contactfax, string billAddress1,
                                      string billAddress2, Guid BillingCityId, string billzipCode, string billContactPerson, string billContactPosition,
                                      string billContactDept, string billcontactTelNo, string billContactMobile, string billContactEmail, string billContactFax,
                                      Guid acctTypeId, Guid? IndustryId, Guid BusinessTypeId, Guid OrganizationTypeId, Guid accStatusId,
                                      DateTime approvedDate, Guid ApprovedById, Guid? paymentTermId, Guid? paymentModeId, Guid billingPeriodId,
                                      decimal discount, bool hasAwbFee, bool hasvaluationCharge, bool hasInsurance, bool hasChargeinvoice,
                                      bool isVatable, bool applyEvm, bool applyWeight, bool hasfeightCollectCharge, bool hasFuelCharge,
                                      bool hasDeliveryFee, bool hasPerishableFee, bool hasDangerousFee, Guid Areaid, decimal creditLimit,
                                      string remarks, Guid createdBy, string conStr)
        {
            DAL.Company.UpdateCompanyInfo(companyId, companyName, contactNo, fax, email, address1,
                                       address2, cityId, zipCode, website, president,
                                       tin, motherCompanyId, contactperson, contactPosition, contactDept,
                                       contactTelNo, contactMobile, contactEmail, contactfax, billAddress1,
                                       billAddress2, BillingCityId, billzipCode, billContactPerson, billContactPosition,
                                       billContactDept, billcontactTelNo, billContactMobile, billContactEmail, billContactFax,
                                       acctTypeId, IndustryId, BusinessTypeId, OrganizationTypeId, accStatusId,
                                       approvedDate, ApprovedById, paymentTermId, paymentModeId, billingPeriodId,
                                       discount, hasAwbFee, hasvaluationCharge, hasInsurance, hasChargeinvoice,
                                       isVatable, applyEvm, applyWeight, hasfeightCollectCharge, hasFuelCharge,
                                       hasDeliveryFee, hasPerishableFee, hasDangerousFee, Areaid, creditLimit,
                                       remarks, createdBy, conStr);
        }

        public static DataSet GetCompanyByCompanyId(Guid companyId, string conStr)
        {
            return DAL.Company.GetCompanyByCompanyId(companyId, conStr);
        }

        public static void DeleteCompany(Guid companyId, int Flag, string conStr)
        {
            DAL.Company.DeleteCompany(companyId, Flag, conStr);
        }

        public static DataSet GetCompanyByBillingPeriodId(Guid BillingPeriodId, string conStr)
        {
            return DAL.Company.GetCompanyByBillingPeriodId(BillingPeriodId, conStr);
        }

    }
}
