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
    public class Clients
    {
        public static DataSet GetClients(string conSTR)
        {
            return DAL.Client.GetClients(conSTR);
        }

        public static DataSet GetClientbyClientId(Guid clientid, string conSTR)
        {
            return DAL.Client.GetClientbyClientId(clientid,conSTR);
        }

        public static DataSet GetClientsbyCompanyId(Guid companyId, string conSTR)
        {
            return DAL.Client.GetClientsbyCompanyId(companyId, conSTR);
        }

        public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        {
            DAL.Client.UpdateClientProfile(ClientID, Flag, conStr);
        }

        public static int ImportClient(DataTable clientTable, string conStr)
        {
            int ctr = 0;
            foreach (DataRow row in clientTable.Rows)
            {
                try
                {
                   ctr +=  DAL.Client.ImportClient(
                        row["AccountNo"].ToString().Trim()
                        , row["FirstName"].ToString().Trim()
                        , row["LastName"].ToString().Trim()
                        , row["ContactNo"].ToString().Trim()
                        , row["Mobile"].ToString().Trim()
                        , row["Fax"].ToString().Trim()
                        , row["Email"].ToString().Trim()
                        , row["Address1"].ToString().Trim()
                        , row["Address2"].ToString().Trim()
                        , row["Barangay"].ToString().Trim()
                        , row["Street"].ToString().Trim()
                        , row["CityName"].ToString().Trim()
                        , row["Area"].ToString().Trim()
                        , row["ZipCode"].ToString().Trim()
                        , row["Title"].ToString().Trim()
                        , row["Department"].ToString().Trim()
                        , row["Remarks"].ToString().Trim()
                        , row["CompanyName"].ToString().Trim()
                        , Convert.ToInt32(row["Discount"])
                        , Convert.ToBoolean(row["HasAwbFee"])
                        , Convert.ToBoolean(row["HasValuationCharge"])
                        , Convert.ToBoolean(row["HasInsurance"])
                        , Convert.ToBoolean(row["HasChargeInvoice"])
                        , Convert.ToBoolean(row["IsVatable"])
                        , Convert.ToBoolean(row["ApplyEvm"])
                        , Convert.ToBoolean(row["ApplyWeight"])
                        , Convert.ToBoolean(row["HasFreightCollectCharge"])
                        , Convert.ToBoolean(row["HasFuelCharge"])
                        , Convert.ToBoolean(row["HasDeliveryFee"])
                        , Convert.ToBoolean(row["HasPerishableFee"])
                         , Convert.ToBoolean(row["HasDangerousFee"])
                        , Convert.ToDecimal(row["CreditLimit"])
                        , conStr);
                }
                catch (Exception ex)
                {

                }               
            }
            return ctr;
        }
    }
}
