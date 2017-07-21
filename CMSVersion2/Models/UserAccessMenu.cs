using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSVersion2.Models
{
    public class UserAccessMenu
    {
        public string menuAccess { get; set; }

        public List<UserAccessMenu> listuserAccess = new List<UserAccessMenu>();

        public List<UserAccessMenu> GetList()
        {
            return listuserAccess;
        }
    }
}