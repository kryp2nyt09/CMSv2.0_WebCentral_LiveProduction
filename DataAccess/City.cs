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
    public class City
    {

        public static DataSet GetCity(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_City", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCityByBCO(string conSTR , string BCO)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_CityByBCO", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BCO", SqlDbType.VarChar).Value = BCO;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCityByID(Guid CityId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_CityById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = CityId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetCityByBCOId(Guid bcoid, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_CitybyBCOId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteCity(Guid CityID, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_City", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CityID", SqlDbType.UniqueIdentifier).Value = CityID;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertCity(Guid BranchCorpOfficeId, Guid ModifiedBy, string CityName, string CityCode,
            string StreetAddress, string ContactNo1, string ContactNo2, string Fax, string zipcode, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_City", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpOfficeId;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                    cmd.Parameters.Add("@CityCode", SqlDbType.VarChar).Value = CityCode;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = StreetAddress;
                    cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = ContactNo1;
                    cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = ContactNo2;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax;
                    cmd.Parameters.Add("@Zipcode", SqlDbType.VarChar).Value = zipcode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateCity(Guid CityId, Guid BranchCorpOfficeId, Guid ModifiedBy, string CityName, string Citycode,
            string StreetAddress, string ContactNo1, string ContactNo2, string Fax, string zipcode, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_City", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CityId", SqlDbType.UniqueIdentifier).Value = CityId;
                    cmd.Parameters.Add("@BranchCorpOfficeId", SqlDbType.UniqueIdentifier).Value = BranchCorpOfficeId;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = ModifiedBy;
                    cmd.Parameters.Add("@CityCode", SqlDbType.VarChar).Value = Citycode;
                    cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.VarChar).Value = StreetAddress;
                    cmd.Parameters.Add("@ContactNo1", SqlDbType.VarChar).Value = ContactNo1;
                    cmd.Parameters.Add("@ContactNo2", SqlDbType.VarChar).Value = ContactNo2;
                    cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax;
                    cmd.Parameters.Add("@Zipcode", SqlDbType.VarChar).Value = zipcode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
