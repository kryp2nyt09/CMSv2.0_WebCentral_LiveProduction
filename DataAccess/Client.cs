using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class Client
    {
    
        public static DataSet GetClients(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_clients", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetClientbyClientId(Guid clientid, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ClientbyClientId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = clientid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        

        public static DataSet GetClientsbyCompanyId(Guid companyId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ClientByCompanyId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.UniqueIdentifier).Value = companyId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        
        public static void UpdateClientProfile(Guid ClientID, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_Client", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClientID", SqlDbType.UniqueIdentifier).Value = ClientID;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static int ImportClient(string AccountNo, string FirstName, string LastName, string ContactNo, string Mobile, 
            string Fax, string Email, string Address1, string Address2, string Barangay, string Street, string CityName,
            string Area,string ZipCode, string Title, string Department, string Remarks, string CompanyName, int Discount,
            bool HasAwbFee, bool HasValuationCharge, bool HasInsurance, bool HasChargeInvoice, bool IsVatable,
             bool ApplyEvm, bool ApplyWeight, bool HasFreightCollectCharge, bool HasFuelCharge, bool HasDeliveryFee,
            bool HasPerishableFee, bool HasDangerousFee, decimal CreditLimit, string conStr)
        {
            int ctr = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Import_Client", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AccountNo", SqlDbType.NVarChar).Value = AccountNo;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
                    cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = ContactNo;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = Mobile;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = Address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = Address2;
                    cmd.Parameters.Add("@Barangay", SqlDbType.VarChar).Value = Barangay;
                    cmd.Parameters.Add("@Street", SqlDbType.VarChar).Value = Street;
                    cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                    cmd.Parameters.Add("@Area", SqlDbType.VarChar).Value = Area;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = ZipCode;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                    cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = Department;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                    cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = CompanyName;
                    cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
                    cmd.Parameters.Add("@HasAwbFee", SqlDbType.Bit).Value = HasAwbFee;
                    cmd.Parameters.Add("@HasValuationCharge", SqlDbType.Bit).Value = HasValuationCharge;
                    cmd.Parameters.Add("@HasInsurance", SqlDbType.Bit).Value = HasInsurance;
                    cmd.Parameters.Add("@HasChargeInvoice", SqlDbType.Bit).Value = HasChargeInvoice;
                    cmd.Parameters.Add("@IsVatable", SqlDbType.Bit).Value = IsVatable;
                    cmd.Parameters.Add("@ApplyEvm", SqlDbType.Bit).Value = ApplyEvm;
                    cmd.Parameters.Add("@ApplyWeight", SqlDbType.Bit).Value = ApplyWeight;
                    cmd.Parameters.Add("@HasFreightCollectCharge", SqlDbType.Bit).Value = HasFreightCollectCharge;
                    cmd.Parameters.Add("@HasFuelCharge", SqlDbType.Bit).Value = HasFuelCharge;
                    cmd.Parameters.Add("@HasDeliveryFee", SqlDbType.Bit).Value = HasDeliveryFee;
                    cmd.Parameters.Add("@HasPerishableFee", SqlDbType.Bit).Value = HasPerishableFee;
                    cmd.Parameters.Add("@HasDangerousFee", SqlDbType.Bit).Value = HasDangerousFee;
                    cmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal).Value = CreditLimit;
                    SqlParameter isSaveParam = new SqlParameter();
                    isSaveParam.ParameterName = "@isSave";
                    isSaveParam.Direction = ParameterDirection.Output;
                    isSaveParam.DbType = DbType.Int32;
                    cmd.Parameters.Add(isSaveParam);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    ctr = Convert.ToInt32( isSaveParam.Value);
                }
            }
            return ctr;
        }

    }
}
