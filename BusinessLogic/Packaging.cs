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
    public class Packaging
    {
        public static DataSet GetPackaging(string conSTR)
        {
            return DAL.Packaging.GetPackaging(conSTR);
        }

        public static DataSet GetPackagingByID(Guid ID, string conSTR)
        {

            return DAL.Packaging.GetPackagingByID(ID, conSTR);
        }
        public static void UpdatePacking(Guid CratingId, string CratingName, decimal Multiplier, int BaseMinimum,
    int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            DAL.Packaging.UpdatePacking(CratingId, CratingName, Multiplier, BaseMinimum,
     BaseMaximum, basefee, excesscoast, CreatedBy, conSTR);
        }

        public static void InsertPacking(string CratingName, decimal Multiplier, int BaseMinimum,
int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            DAL.Packaging.InsertPacking(CratingName, Multiplier, BaseMinimum,
     BaseMaximum, basefee, excesscoast, CreatedBy, conSTR);
        }

        public static void DeletePacking(Guid ID, string conSTR)
        {
            DAL.Packaging.DeletePacking(ID, conSTR);
        }

    }
}
