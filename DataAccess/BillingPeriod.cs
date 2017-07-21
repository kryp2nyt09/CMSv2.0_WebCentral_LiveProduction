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
    public class BillingPeriod
    {

        public static DataSet GetBillingPeriod(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BillingPeriod", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }



        public static void Delete(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_BillingPeriod", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BillingPeriodId", SqlDbType.UniqueIdentifier).Value = ID;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetById(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BillingPeriodByID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BillingPeriodId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void Update(Guid BillingPeriodID, Guid CreatedBy, string BillingPeriodName, string desc, int noofdays, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_BillingPeriod", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BillingPeriodID", SqlDbType.UniqueIdentifier).Value = BillingPeriodID;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@BillingPeriodName", SqlDbType.VarChar).Value = BillingPeriodName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = desc;
                    cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = noofdays;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public static void Insert( Guid CreatedBy, string BillingPeriodName, string desc, int noofdays, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_BillingPeriod", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@BillingPeriodName", SqlDbType.VarChar).Value = BillingPeriodName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = desc;
                    cmd.Parameters.Add("@NoOfDays", SqlDbType.Int).Value = noofdays;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }


    }
}
