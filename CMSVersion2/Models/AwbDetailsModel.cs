using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class AwbDetailsModel
    {
        public Guid Id { get; set; }
        public DateTime dateandtime { get; set; }
        public string statusofAwb { get; set; }
        public string location { get; set; }
        public int arrivedPcs { get; set; }
        public string cargo { get; set; }
        public string receivedBy { get; set; }
        public string remarks { get; set; }

        public List<AwbDetailsModel> listawbDetails = new List<AwbDetailsModel>();

        public static List<AwbDetailsModel> details = new List<AwbDetailsModel>();


        public List<AwbDetailsModel> GetList()
        {
            return listawbDetails;
        }
    }
}