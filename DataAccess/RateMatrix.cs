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
    public class RateMatrix
    {

        public static DataSet GetRateMatrix(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RateMatrix", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

       
        public static DataSet GetWB(Guid ID, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RateMatrixWB", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RateMatrixId", SqlDbType.UniqueIdentifier).Value = ID;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetRateMatrixById(Guid Ratematrixid, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RateMatrixById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RateMatrixId", SqlDbType.UniqueIdentifier).Value = Ratematrixid;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static DataSet getCityId(String CityName, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Check_CityName", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
//        @RateMatrixID uniqueidentifier,
//@1to5Cost decimal(18, 2),
//@6to49Cost decimal(18, 2),
//@ decimal(18, 2),
//@ decimal(18, 2),
//@ decimal(18, 2),
//@ datetime,
//@ uniqueidentifier,
//@ uniqueidentifier,
//@ uniqueidentifier
        public static void InsertWB(Guid RateMatrixID, decimal p1to5Cost, decimal p6to49Cost,  decimal p50to249Cost,
            decimal p250to999Cost, decimal p1000to10000Cost, DateTime EffectiveDate, Guid OriginCityId, Guid DestinationCityId,
            Guid CreatedBy,
         string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_RateMatrixWB", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RateMatrixID", SqlDbType.UniqueIdentifier).Value = RateMatrixID;
                    cmd.Parameters.Add("@1to5Cost", SqlDbType.Decimal).Value = p1to5Cost;
                    cmd.Parameters.Add("@6to49Cost", SqlDbType.Decimal).Value = p6to49Cost;
                    cmd.Parameters.Add("@50to249Cost", SqlDbType.Decimal).Value = p50to249Cost;
                    cmd.Parameters.Add("@250to999Cost", SqlDbType.Decimal).Value = p250to999Cost;
                    cmd.Parameters.Add("@1000to10000Cost", SqlDbType.Decimal).Value = p1000to10000Cost;
                    cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = EffectiveDate;
                    cmd.Parameters.Add("@OriginCityId", SqlDbType.UniqueIdentifier).Value = OriginCityId;
                    cmd.Parameters.Add("@DestinationCityId", SqlDbType.UniqueIdentifier).Value = DestinationCityId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static void AddCombinationRateMatrix(Guid ApplicableRateId,
            Boolean hasfuelCharge
            , Boolean hasAWBFee, Boolean hasinsurance, Guid CreatedBy, Boolean applyevm,
            Boolean applyweight, Boolean isvatable, Boolean hasdeliveryfee, Boolean hasperishable,
            Boolean hasdangerousFee, Boolean hasValuationcharge, decimal amount,
            string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_RateMatrixCombination", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ApplicabbleRateId", SqlDbType.UniqueIdentifier).Value = ApplicableRateId;
                    //cmd.Parameters.Add("@CommodityType", SqlDbType.UniqueIdentifier).Value = CommodityType;
                    //cmd.Parameters.Add("@ServiceType", SqlDbType.UniqueIdentifier).Value = ServiceType;
                    //cmd.Parameters.Add("@ServiceModel", SqlDbType.UniqueIdentifier).Value = ServiceModel;
                    cmd.Parameters.Add("@hasfuelcharge", SqlDbType.Bit).Value = hasfuelCharge;
                    cmd.Parameters.Add("@HasAWBFee", SqlDbType.Bit).Value = hasAWBFee;
                    cmd.Parameters.Add("@HasInsurance", SqlDbType.Bit).Value = hasinsurance;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ApplyEvm", SqlDbType.Bit).Value = applyevm;
                    cmd.Parameters.Add("@ApplyWeight", SqlDbType.Bit).Value = applyweight;
                    cmd.Parameters.Add("@IsVatable", SqlDbType.Bit).Value = isvatable;
                    cmd.Parameters.Add("@HasDeliveryFee", SqlDbType.Bit).Value = hasdeliveryfee;
                    cmd.Parameters.Add("@hasPerishable", SqlDbType.Bit).Value = hasperishable;
                    cmd.Parameters.Add("@hasDangerousFee", SqlDbType.Bit).Value = hasdangerousFee;
                    cmd.Parameters.Add("@hasValuationcharge", SqlDbType.Bit).Value = hasValuationcharge;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateCombinationRateMatrix(Guid RateMatrixId, Guid ApplicableRateId,
          Boolean hasfuelCharge
         , Boolean hasAWBFee, Boolean hasinsurance, Guid CreatedBy, Boolean applyevm,
         Boolean applyweight, Boolean isvatable, Boolean hasdeliveryfee, Boolean hasperishable,
         Boolean hasdangerousFee, Boolean hasValuationcharge, decimal amount,
         string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_RateMatrixCombination", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RateMatrixId", SqlDbType.UniqueIdentifier).Value = RateMatrixId;
                    cmd.Parameters.Add("@ApplicabbleRateId", SqlDbType.UniqueIdentifier).Value = ApplicableRateId;
                    //cmd.Parameters.Add("@CommodityType", SqlDbType.UniqueIdentifier).Value = CommodityType;
                    //cmd.Parameters.Add("@ServiceType", SqlDbType.UniqueIdentifier).Value = ServiceType;
                    //cmd.Parameters.Add("@ServiceModel", SqlDbType.UniqueIdentifier).Value = ServiceModel;
                    cmd.Parameters.Add("@hasfuelcharge", SqlDbType.Bit).Value = hasfuelCharge;
                    cmd.Parameters.Add("@HasAWBFee", SqlDbType.Bit).Value = hasAWBFee;
                    cmd.Parameters.Add("@HasInsurance", SqlDbType.Bit).Value = hasinsurance;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
                    cmd.Parameters.Add("@ApplyEvm", SqlDbType.Bit).Value = applyevm;
                    cmd.Parameters.Add("@ApplyWeight", SqlDbType.Bit).Value = applyweight;
                    cmd.Parameters.Add("@IsVatable", SqlDbType.Bit).Value = isvatable;
                    cmd.Parameters.Add("@HasDeliveryFee", SqlDbType.Bit).Value = hasdeliveryfee;
                    cmd.Parameters.Add("@hasPerishable", SqlDbType.Bit).Value = hasperishable;
                    cmd.Parameters.Add("@hasDangerousFee", SqlDbType.Bit).Value = hasdangerousFee;
                    cmd.Parameters.Add("@hasValuationcharge", SqlDbType.Bit).Value = hasValuationcharge;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCombinationRateMatrix(Guid RateMatrixId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_RateMatrixCombination", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RateMatrixId", SqlDbType.UniqueIdentifier).Value = RateMatrixId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteWB(Guid RateMatrixId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_RateMatrixWB", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RateMatrixID", SqlDbType.UniqueIdentifier).Value = RateMatrixId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
