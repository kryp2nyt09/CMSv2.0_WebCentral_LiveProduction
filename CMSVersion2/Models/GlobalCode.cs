using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    /// <summary>
    /// Summary description for Batch
    /// </summary>
    public static class GlobalCode
    {
        public static string globalCode { get; set; }
        public static string userName { get; set; }

        public static int resultValue { get; set; }
        public static Guid userId { get; set; }
        public static string menuName { get; set; }
    }
}