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
    public class RateMatrix
    {
        public static DataSet GetrateMatrix(string conSTR)
        {
            return DAL.RateMatrix.GetRateMatrix(conSTR);
        }

        public static DataSet GetRateMatrixById(Guid ratematrixId, string conStr)
        {
            return DAL.RateMatrix.GetRateMatrixById(ratematrixId, conStr);
        }

        //public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        //{
        //    DAL.Client.UpdateClientProfile(ClientID, Flag, conStr);
        //}

    }
}
