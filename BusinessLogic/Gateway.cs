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
    public class Gateway
    {
        public static DataSet GetGateway(string conSTR)
        {
            return DAL.Gateway.GetGateway(conSTR);
        }

        //public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        //{
        //    DAL.Client.UpdateClientProfile(ClientID, Flag, conStr);
        //}

    }
}
