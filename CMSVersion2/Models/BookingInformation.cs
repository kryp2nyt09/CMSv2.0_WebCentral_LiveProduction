using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class BookingInformation
    {
        public string BookingNo { get; set; }
        public Guid? BookingTypeId { get; set; }
        public DateTime DateBooked { get; set; }
        public Guid BookedById { get; set; }
        public Guid ConsigneeId { get; set; }
        public Guid ShipperId { get; set; }
        public string DestinationAddress1 { get; set; }
        public string Remarks { get; set; }

        public Guid? BookingRemarkId { get; set; }
        public Guid? BookingStatusId { get; set; }
        public bool? HasDailyBooking { get; set; }
        public Guid? PreviousBookingId { get; set; }
        public Guid OriginCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public Guid AssignedToAreaId { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RecordStatus { get; set; }
        public string OriginAddress1 { get; set; }
        public string OriginAddress2 { get; set; }
        public string OriginBarangay { get; set; }
        public string DestinationAddress2 { get; set; }
        public string DestinationBarangay { get; set; }
        public string OriginStreet { get; set; }
        public string DestinationStreet { get; set; }
    }
}