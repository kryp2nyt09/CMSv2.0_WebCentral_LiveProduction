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
    public class Crating
    {
        public static DataSet GetCrating(string conSTR)
        {
            return DAL.Crating.GetCrating(conSTR);
        }

        public static DataSet GetCratingByID(Guid ID, string conSTR)
        {

            return DAL.Crating.GetCratingByID(ID, conSTR);
        }

        public static void UpdateCrating(Guid CratingId, string CratingName, decimal Multiplier, int BaseMinimum,
          int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            DAL.Crating.UpdateCrating(CratingId, CratingName, Multiplier, BaseMinimum, BaseMaximum, basefee, excesscoast, CreatedBy, conSTR);

        }

        public static void InsertCrating(string CratingName, decimal Multiplier, int BaseMinimum,
          int BaseMaximum, decimal basefee, decimal excesscoast, Guid CreatedBy, string conSTR)
        {
            DAL.Crating.InsertCrating(CratingName, Multiplier, BaseMinimum, BaseMaximum, basefee, excesscoast, CreatedBy, conSTR);

        }

        public static void DeleteCrating(Guid CratingID, string conSTR)
        {

            DAL.Crating.DeleteCrating(CratingID, conSTR);

        }

    }
}
