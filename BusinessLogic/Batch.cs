using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Batch
    {
        public static void InsertBatchName(string batchName, string batchCode, Guid CreatedBy, string conStr)
        {
            DAL.Batch.InsertBatchName(batchName, batchCode, CreatedBy, conStr);
        }

        public static void UpdateBatchName(Guid batchID, string batchName, string conStr)
        {
            DAL.Batch.UpdateBatchName(batchID, batchName, conStr);
        }

        public static void DeleteBatchName(Guid batchId, int Flag, string conStr)
        {
            DAL.Batch.DeleteBatchName(batchId, Flag, conStr);
        }

        public static DataSet GetBatchByBatchID(string conSTR, Guid ID)
        {
            return DAL.Batch.GetBatchByBatchID(conSTR, ID);
        }

        public static DataSet GetBatchByBatchCode(string conSTR, string code)
        {
            return DAL.Batch.GetBatchByBatchCode(conSTR, code);
        }

        public static DataSet GetBranchAcceptanceDriver(string conSTR)
        {
            return DAL.Batch.GetBranchAcceptanceDriver(conSTR);
        }
    }
}
