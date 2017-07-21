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
    public class BranchCorpOffice
    {

        public static DataSet GetBranchCorpOffice(string conSTR)
        {

            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_BranchCorpOffice", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetBranchCorpOfficeById(Guid BranchCorpId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_branchcorpbyId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static DataSet UpdateBranchCorpOfficeById(Guid ProvinceId, Guid BranchCorpId, string BCOName, string bcoCode, Guid modifiedBy, int Flag,string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_update_BranchCorpOfficebyId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ProvinceId", SqlDbType.UniqueIdentifier).Value = ProvinceId;
                da.SelectCommand.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpId;
                da.SelectCommand.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                da.SelectCommand.Parameters.Add("@BCOname", SqlDbType.VarChar).Value = BCOName;
                da.SelectCommand.Parameters.Add("@BCOCode", SqlDbType.VarChar).Value = bcoCode;
                da.SelectCommand.Parameters.Add("@flag", SqlDbType.Int).Value = Flag;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet InsertBranchCorpOffice(Guid ProvinceId, string BCOName, string bcoCode, Guid modifiedBy, int Flag, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_insert_BranchCorpOffice", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ProvinceId", SqlDbType.UniqueIdentifier).Value = ProvinceId;
                da.SelectCommand.Parameters.Add("@modifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                da.SelectCommand.Parameters.Add("@BCOname", SqlDbType.VarChar).Value = BCOName;
                da.SelectCommand.Parameters.Add("@BCOCode", SqlDbType.VarChar).Value = bcoCode;
                da.SelectCommand.Parameters.Add("@flag", SqlDbType.Int).Value = Flag;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


        public static void DeleteBranchCorpOffice(Guid BranchCorpId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_branchcorp", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpId;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
