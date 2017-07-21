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
    public class ShipmentBasicFee
    {

        public static DataSet GetShipmentBasicFee(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_ShipmentBasicFee", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void DeleteShipmentBasicFee(string conSTR, Guid ShipmentFeeId)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_ShipmentBasicFee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ShipmentFeeId", SqlDbType.UniqueIdentifier).Value = ShipmentFeeId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void InsertShipmentBasicFee(Guid CreatedBy, decimal amount, string ShipmentFeeName, string description, int isvatable, DateTime EffectiveDate, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_ShipmentBasicFee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@ShipmentFeeId", SqlDbType.UniqueIdentifier).Value = ShipmentFeeId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ShipmentFeeName", SqlDbType.VarChar).Value = ShipmentFeeName;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@isVatable", SqlDbType.Int).Value = isvatable;
                    cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = EffectiveDate;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateShipmentBasicFee(Guid ID, Guid CreatedBy, decimal  amount, string ShipmentFeeName, string description, int isvatable, DateTime EffectiveDate, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_ShipmentBasicFee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ShipmentFeeId", SqlDbType.UniqueIdentifier).Value = ID;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ShipmentFeeName", SqlDbType.NVarChar).Value = ShipmentFeeName;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
                    cmd.Parameters.Add("@isVatable", SqlDbType.Int).Value = isvatable;
                    cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = EffectiveDate;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


           


        public static DataSet GetShipmentBasicFeeByID(Guid ID,  string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_view_ShipmentBasicFeeByID", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@ShipmentBasicFeeID", SqlDbType.UniqueIdentifier).Value = ID;
                            DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }


    }
}
