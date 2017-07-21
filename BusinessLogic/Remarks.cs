using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Remarks
    {
        public static void InsertRemarkName(string remarkName, string remarkCode, Guid CreatedBy, string conStr)
        {
            DAL.Remarks.InsertRemarkName(remarkName, remarkCode, CreatedBy, conStr);
        }

        public static void UpdateRemarkName(Guid remarkID, string remarkName, string conStr)
        {
            DAL.Remarks.UpdateRemarkName(remarkID, remarkName, conStr);
        }

        public static void DeleteRemarkName(Guid remarkId, int Flag, string conStr)
        {
            DAL.Remarks.DeleteRemarkName(remarkId, Flag, conStr);
        }

        public static DataSet GetRemarkByRemarkID(string conSTR, Guid ID)
        {
            return DAL.Remarks.GetRemarkByRemarkID(conSTR, ID);
        }
    }
}
