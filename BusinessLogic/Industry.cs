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
    public class Industry
    {
        public static DataSet GetIndustry(string conSTR)
        {
            return DAL.Industry.GetIndustry(conSTR);
        }

        public static void DeleteIndsutry(Guid ID, string conSTR)
        {
            DAL.Industry.Delete(ID, conSTR);
        }

        public static DataSet GetIndsutryById(Guid ID, string conSTR)
        {
            return DAL.Industry.GetById(ID, conSTR);
        }

        public static void UpdateIndsutry(Guid IndustryID, Guid CreatedBy, string IndustryName, string conSTR)
        {
            DAL.Industry.Update(IndustryID, CreatedBy, IndustryName, conSTR);
        }

        public static void InsertIndsutry(Guid CreatedBy, string IndustryName, string conSTR)
        {
            DAL.Industry.Insert( CreatedBy, IndustryName, conSTR);
        }


        }
}
