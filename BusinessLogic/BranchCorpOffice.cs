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
    public class BranchCorpOffice
    {
        public static DataSet GetBranchCorpOffice(string conSTR)
        {
            return DAL.BranchCorpOffice.GetBranchCorpOffice(conSTR);
        }

        public static void DeleteBranchCorpOffice(Guid BranchCorpId, int Flag, string conStr)
        {
            DAL.BranchCorpOffice.DeleteBranchCorpOffice(BranchCorpId, Flag, conStr);
        }


        public static void UpdateBranchCorpOfficeById(Guid ProvinceId, Guid BranchCorpId, string BCOName, string bcoCode, Guid modifiedBy, int Flag, string conSTR)
        {
            DAL.BranchCorpOffice.UpdateBranchCorpOfficeById(ProvinceId, BranchCorpId, BCOName, bcoCode, modifiedBy, Flag, conSTR);
        }


        public static void InsertBranchCorpOffice(Guid ProvinceId, string BCOName, string bcoCode,Guid modifiedBy, int Flag, string conSTR)
        {
            DAL.BranchCorpOffice.InsertBranchCorpOffice(ProvinceId,   BCOName, bcoCode, modifiedBy, Flag,conSTR);
        }

        public static DataSet GetBranchCorpOfficeById(Guid BranchCorpId, string conSTR)
        {
            return DAL.BranchCorpOffice.GetBranchCorpOfficeById(BranchCorpId, conSTR);
        }



    }

}
