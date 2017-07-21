using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class Company
    {
    
        public static DataSet GetCompanies(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_company", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        #region InsertCompany

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
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Company", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = companyName;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = contactNo;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = address2;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = cityId;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = zipCode;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = website;
                    cmd.Parameters.Add("@President", SqlDbType.NVarChar).Value = president;
                    cmd.Parameters.Add("@Tin", SqlDbType.NVarChar).Value = tin;
                    cmd.Parameters.Add("@MotherCompanyId", SqlDbType.UniqueIdentifier).Value = (object)motherCompanyId ?? DBNull.Value;
                   // cmd.Parameters.AddWithValue("@MotherCompanyId", motherCompanyId == Guid.Empty ?? DBNull.Value : motherCompanyId);
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = contactperson;
                    cmd.Parameters.Add("@ContactPosition", SqlDbType.NVarChar).Value = contactPosition;
                    cmd.Parameters.Add("@ContactDepartment", SqlDbType.NVarChar).Value = contactDept;
                    cmd.Parameters.Add("@ContactTelNo", SqlDbType.NVarChar).Value = contactTelNo;
                    cmd.Parameters.Add("@ContactMobile", SqlDbType.NVarChar).Value = contactMobile;
                    cmd.Parameters.Add("@ContactEmail", SqlDbType.NVarChar).Value = contactEmail;
                    cmd.Parameters.Add("@ContactFax", SqlDbType.NVarChar).Value = contactfax;
                    cmd.Parameters.Add("@BillingAddress1", SqlDbType.NVarChar).Value = billAddress1;
                    cmd.Parameters.Add("@BillingAddress2", SqlDbType.NVarChar).Value = billAddress2;
                    cmd.Parameters.Add("@BillingCityId", SqlDbType.UniqueIdentifier).Value = BillingCityId;
                    cmd.Parameters.Add("@BillingZipCode", SqlDbType.NVarChar).Value = billzipCode;
                    cmd.Parameters.Add("@BillingContactPerson", SqlDbType.NVarChar).Value = billContactPerson;
                    cmd.Parameters.Add("@BillingContactPosition", SqlDbType.NVarChar).Value = billContactPerson;
                    cmd.Parameters.Add("@BillingContactDepartment", SqlDbType.NVarChar).Value = billContactDept;
                    cmd.Parameters.Add("@BillingContactTelNo", SqlDbType.NVarChar).Value = billcontactTelNo;
                    cmd.Parameters.Add("@BillingContactMobile", SqlDbType.NVarChar).Value = billContactMobile;
                    cmd.Parameters.Add("@BillingContactEmail", SqlDbType.NVarChar).Value = billContactEmail;
                    cmd.Parameters.Add("@BillingContactFax", SqlDbType.NVarChar).Value = billContactFax;
                    cmd.Parameters.Add("@AccountTypeId", SqlDbType.UniqueIdentifier).Value = acctTypeId;
                    cmd.Parameters.Add("@IndustryId", SqlDbType.UniqueIdentifier).Value = (object)IndustryId ?? DBNull.Value;
                    cmd.Parameters.Add("@BusinessTypeId", SqlDbType.UniqueIdentifier).Value = BusinessTypeId;
                    cmd.Parameters.Add("@OrganizationTypeId", SqlDbType.UniqueIdentifier).Value = OrganizationTypeId;
                    cmd.Parameters.Add("@AccountStatusId", SqlDbType.UniqueIdentifier).Value = accStatusId;
                    cmd.Parameters.Add("@ApprovedDate", SqlDbType.DateTime).Value = approvedDate;
                    cmd.Parameters.Add("@ApprovedById", SqlDbType.UniqueIdentifier).Value = ApprovedById;
                    cmd.Parameters.Add("@PaymentTermId", SqlDbType.UniqueIdentifier).Value = paymentTermId;
                    cmd.Parameters.Add("@PaymentModeId", SqlDbType.UniqueIdentifier).Value = paymentModeId;
                    cmd.Parameters.Add("@BillingPeriodId", SqlDbType.UniqueIdentifier).Value = billingPeriodId;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = discount;
                    cmd.Parameters.Add("@HasAwbFee", SqlDbType.Bit).Value = hasAwbFee;
                    cmd.Parameters.Add("@HasValuationCharge", SqlDbType.Bit).Value = hasvaluationCharge;
                    cmd.Parameters.Add("@HasInsurance", SqlDbType.Bit).Value = hasInsurance;
                    cmd.Parameters.Add("@HasChargeInvoice", SqlDbType.Bit).Value = hasChargeinvoice;
                    cmd.Parameters.Add("@IsVatable", SqlDbType.Bit).Value = isVatable;
                    cmd.Parameters.Add("@ApplyEvm", SqlDbType.Bit).Value = applyEvm;
                    cmd.Parameters.Add("@ApplyWeight", SqlDbType.Bit).Value = applyWeight;
                    cmd.Parameters.Add("@HasFreightCollectCharge", SqlDbType.Bit).Value = hasfeightCollectCharge;
                    cmd.Parameters.Add("@HasFuelCharge", SqlDbType.Bit).Value = hasFuelCharge;
                    cmd.Parameters.Add("@HasDeliveryFee", SqlDbType.Bit).Value = hasDeliveryFee;
                    cmd.Parameters.Add("@HasPerishableFee", SqlDbType.Bit).Value = hasPerishableFee;
                    cmd.Parameters.Add("@HasDangerousFee", SqlDbType.Bit).Value = hasDangerousFee;
                    cmd.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = Areaid;
                    cmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                    cmd.Parameters.Add("@CreatedModifiedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion


        #region UpdateCompany
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
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_Company", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = companyName;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = contactNo;
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@Address1", SqlDbType.NVarChar).Value = address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.NVarChar).Value = address2;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = cityId;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = zipCode;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = website;
                    cmd.Parameters.Add("@President", SqlDbType.NVarChar).Value = president;
                    cmd.Parameters.Add("@Tin", SqlDbType.NVarChar).Value = tin;
                    cmd.Parameters.Add("@MotherCompanyId", SqlDbType.UniqueIdentifier).Value = (object)motherCompanyId ?? DBNull.Value;
                    cmd.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = contactperson;
                    cmd.Parameters.Add("@ContactPosition", SqlDbType.NVarChar).Value = contactPosition;
                    cmd.Parameters.Add("@ContactDepartment", SqlDbType.NVarChar).Value = contactDept;
                    cmd.Parameters.Add("@ContactTelNo", SqlDbType.NVarChar).Value = contactTelNo;
                    cmd.Parameters.Add("@ContactMobile", SqlDbType.NVarChar).Value = contactMobile;
                    cmd.Parameters.Add("@ContactEmail", SqlDbType.NVarChar).Value = contactEmail;
                    cmd.Parameters.Add("@ContactFax", SqlDbType.NVarChar).Value = contactfax;
                    cmd.Parameters.Add("@BillingAddress1", SqlDbType.NVarChar).Value = billAddress1;
                    cmd.Parameters.Add("@BillingAddress2", SqlDbType.NVarChar).Value = billAddress2;
                    cmd.Parameters.Add("@BillingCityId", SqlDbType.UniqueIdentifier).Value = BillingCityId;
                    cmd.Parameters.Add("@BillingZipCode", SqlDbType.NVarChar).Value = billzipCode;
                    cmd.Parameters.Add("@BillingContactPerson", SqlDbType.NVarChar).Value = billContactPerson;
                    cmd.Parameters.Add("@BillingContactPosition", SqlDbType.NVarChar).Value = billContactPerson;
                    cmd.Parameters.Add("@BillingContactDepartment", SqlDbType.NVarChar).Value = billContactDept;
                    cmd.Parameters.Add("@BillingContactTelNo", SqlDbType.NVarChar).Value = billcontactTelNo;
                    cmd.Parameters.Add("@BillingContactMobile", SqlDbType.NVarChar).Value = billContactMobile;
                    cmd.Parameters.Add("@BillingContactEmail", SqlDbType.NVarChar).Value = billContactEmail;
                    cmd.Parameters.Add("@BillingContactFax", SqlDbType.NVarChar).Value = billContactFax;
                    cmd.Parameters.Add("@AccountTypeId", SqlDbType.UniqueIdentifier).Value = acctTypeId;
                    //cmd.Parameters.Add("@IndustryId", SqlDbType.UniqueIdentifier).Value = IndustryId;
                    cmd.Parameters.Add("@IndustryId", SqlDbType.UniqueIdentifier).Value = (object)IndustryId ?? DBNull.Value;
                    cmd.Parameters.Add("@BusinessTypeId", SqlDbType.UniqueIdentifier).Value = BusinessTypeId;
                    cmd.Parameters.Add("@OrganizationTypeId", SqlDbType.UniqueIdentifier).Value = OrganizationTypeId;
                    cmd.Parameters.Add("@AccountStatusId", SqlDbType.UniqueIdentifier).Value = accStatusId;
                    cmd.Parameters.Add("@ApprovedDate", SqlDbType.DateTime).Value = approvedDate;
                    cmd.Parameters.Add("@ApprovedById", SqlDbType.UniqueIdentifier).Value = ApprovedById;
                    cmd.Parameters.Add("@PaymentTermId", SqlDbType.UniqueIdentifier).Value = paymentTermId;
                    cmd.Parameters.Add("@PaymentModeId", SqlDbType.UniqueIdentifier).Value = paymentModeId;
                    cmd.Parameters.Add("@BillingPeriodId", SqlDbType.UniqueIdentifier).Value = billingPeriodId;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = discount;
                    cmd.Parameters.Add("@HasAwbFee", SqlDbType.Bit).Value = hasAwbFee;
                    cmd.Parameters.Add("@HasValuationCharge", SqlDbType.Bit).Value = hasvaluationCharge;
                    cmd.Parameters.Add("@HasInsurance", SqlDbType.Bit).Value = hasInsurance;
                    cmd.Parameters.Add("@HasChargeInvoice", SqlDbType.Bit).Value = hasChargeinvoice;
                    cmd.Parameters.Add("@IsVatable", SqlDbType.Bit).Value = isVatable;
                    cmd.Parameters.Add("@ApplyEvm", SqlDbType.Bit).Value = applyEvm;
                    cmd.Parameters.Add("@ApplyWeight", SqlDbType.Bit).Value = applyWeight;
                    cmd.Parameters.Add("@HasFreightCollectCharge", SqlDbType.Bit).Value = hasfeightCollectCharge;
                    cmd.Parameters.Add("@HasFuelCharge", SqlDbType.Bit).Value = hasFuelCharge;
                    cmd.Parameters.Add("@HasDeliveryFee", SqlDbType.Bit).Value = hasDeliveryFee;
                    cmd.Parameters.Add("@HasPerishableFee", SqlDbType.Bit).Value = hasPerishableFee;
                    cmd.Parameters.Add("@HasDangerousFee", SqlDbType.Bit).Value = hasDangerousFee;
                    cmd.Parameters.Add("@AreaId", SqlDbType.UniqueIdentifier).Value = Areaid;
                    cmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = remarks;
                    cmd.Parameters.Add("@CreatedModifiedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion


        #region Get Company by Company Id
        public static DataSet GetCompanyByCompanyId(Guid companyId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_CompanyByCompanyId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_CompanyByCompanyId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        #endregion



        public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_Client", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClientID", SqlDbType.UniqueIdentifier).Value = ClientID;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetCompanyById(Guid companyId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_CompanybyId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_CompanybyId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static void DeleteCompany(Guid companyId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Company", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetCompanyByBillingPeriodId(Guid billingPeriodId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand("sp_view_Company_By_BillingPeriodId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Company_By_BillingPeriodId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@billingperiodid", SqlDbType.UniqueIdentifier).Value = billingPeriodId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }

        }

    }
}
