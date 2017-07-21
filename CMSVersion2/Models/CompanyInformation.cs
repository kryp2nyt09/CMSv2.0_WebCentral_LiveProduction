using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class CompanyInformation
    {
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Guid CityId { get; set; }
        public string CompanyInfoZipCode { get; set; }
        public Guid? IndustryId { get; set; }
        public string ContactInfo { get; set; }
        public string Tin { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string President { get; set; }

        //ContactInfo
        public string ContactPerson { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string MobileNo { get; set; }
        public string ContactInfoTelNo { get; set; }
        public string ContactInfoEmail { get; set; }
        public string ContactInfoFax { get; set; }

        //AccountInfo1
        public Guid AccttypeId { get; set; }
        public Guid AcctStatusId { get; set; }
        public Guid OrgTypeId { get; set; }

        public Guid? MotherCompId { get; set; }
        public Guid BusinessTypeId { get; set; }
        public Guid BillingPeriodId { get; set; }
        public Guid? PaymentTermId { get; set; }
        public Guid? PaymentModeId { get; set; }

        public DateTime dateApprove { get; set; }
        public Guid ApproveById { get; set; }
        public Guid AreaId { get; set; }
        public decimal Discount { get; set; }

        public decimal CreditLimit { get; set; }

        //AccountInfo 2
        public bool appliedEVM { get; set; }
        public bool hasAWBFee { get; set; }
        public bool hasFCFee { get; set; }
        public bool hasInsurance { get; set; }
        public bool hasFuelCharge { get; set; }
        public bool hasVatable { get; set; }
        public bool hasValuationCharge { get; set; }
        public bool hasDeliveryFee { get; set; }
        public bool hasPerishableFee { get; set; }
        public bool hasDangerousFee { get; set; }
        public bool hasWeightCharge { get; set; }
        public bool hasChargeInvoice { get; set; }

        //BillingInfo
        public string billInfoAddress1 { get; set; }
        public string billInfoAddress2 { get; set; }
        public Guid billInfoCityId { get; set; }
        public string billInfozipCode { get; set; }
        public string billInfoContactPerson { get; set; }
        public string billInfoPosition { get; set; }
        public string billInfoDepartment { get; set; }
        public string billInfoContactNo { get; set; }
        public string billInfoMobileNo { get; set; }
        public string billInfoEmail { get; set; }
        public string billInfoFax { get; set; }
    }
}