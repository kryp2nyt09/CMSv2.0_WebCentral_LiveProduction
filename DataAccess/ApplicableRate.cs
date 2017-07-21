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
    public class ApplicableRate
    {

        public static DataSet GetApplicableRate(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_applicablerate", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetFreeApplicableRate(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_View_FreeApplicableRate", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetApplicableRateID(Guid ApplicableRateID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_applicablerateById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ApplicableRateId", SqlDbType.UniqueIdentifier).Value = ApplicableRateID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeleteApplicableRate(Guid ApplicableRateId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_ApplicableRate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ApplicableRateId", SqlDbType.UniqueIdentifier).Value = ApplicableRateId;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertApplicableRate(Guid Createdby, string applicableratename, Guid commodityTypeId, Guid serviceModeId, Guid serviceTypeId, string description, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_applicablerateById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ApplicableRateName", SqlDbType.VarChar).Value = applicableratename;
                    cmd.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = commodityTypeId;
                    cmd.Parameters.Add("@ServiceModeId", SqlDbType.UniqueIdentifier).Value = serviceModeId;
                    cmd.Parameters.Add("@ServiceTypeId", SqlDbType.UniqueIdentifier).Value = serviceTypeId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = Createdby;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

      
        public static void UpdateApplicableRate(Guid ApplicableRateId, string applicableratename, Guid commodityTypeId, Guid serviceModeId, Guid serviceTypeId, Guid Createdby, string description, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_applicablerateById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ApplicableRateId", SqlDbType.UniqueIdentifier).Value = ApplicableRateId;
                    cmd.Parameters.Add("@ApplicableRateName", SqlDbType.VarChar).Value = applicableratename;
                    cmd.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = commodityTypeId;
                    cmd.Parameters.Add("@ServiceModeId", SqlDbType.UniqueIdentifier).Value = serviceModeId;
                    cmd.Parameters.Add("@ServiceTypeId", SqlDbType.UniqueIdentifier).Value = serviceTypeId;
                    cmd.Parameters.Add("@Createdby", SqlDbType.UniqueIdentifier).Value = Createdby;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}

