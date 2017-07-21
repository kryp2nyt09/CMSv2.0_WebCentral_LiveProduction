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
    public class CommodityType
    {
        public static DataSet GetCommodityType(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_commoditytype", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        public static DataSet GetCommodityTypeById(Guid Id, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_commoditytypeById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = Id;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
        public static void DeleteCommodityType(Guid CommodityTypeId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_commoditytype", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = CommodityTypeId;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InsertCommodityType(string CommodityTypeCode, string CommodityTypeDesc, string CommodityTypeName, decimal EvmDivisor, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_commoditytype", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CommodityTypeCode", SqlDbType.VarChar).Value = CommodityTypeCode;
                    cmd.Parameters.Add("@CommodityTypeName", SqlDbType.VarChar).Value = CommodityTypeName;
                    cmd.Parameters.Add("@CommodityTypeDesc", SqlDbType.VarChar).Value = CommodityTypeDesc;
                    cmd.Parameters.Add("@EvmDivisor", SqlDbType.Decimal).Value = EvmDivisor;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateCommodityType(Guid CommodityTypeId, string CommodityTypeCode, string CommodityTypeDesc, string CommodityTypeName, decimal EvmDivisor, Guid CreatedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_commoditytype", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CommodityTypeId", SqlDbType.UniqueIdentifier).Value = CommodityTypeId;
                    cmd.Parameters.Add("@CommodityTypeCode", SqlDbType.VarChar).Value = CommodityTypeCode;
                    cmd.Parameters.Add("@CommodityTypeName", SqlDbType.VarChar).Value = CommodityTypeName;
                    cmd.Parameters.Add("@CommodityTypeDesc", SqlDbType.VarChar).Value = CommodityTypeDesc;
                    cmd.Parameters.Add("@EvmDivisor", SqlDbType.Decimal).Value = EvmDivisor;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
