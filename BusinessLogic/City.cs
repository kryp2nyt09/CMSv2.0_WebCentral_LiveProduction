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
    public class City
    {
        public static DataSet GetCity(string conSTR)
        {
            return DAL.City.GetCity(conSTR);
        }

        public static DataSet GetCityByBCOId(Guid bcoid, string conSTR)
        {
            return DAL.City.GetCityByBCOId(bcoid, conSTR);
        }


        public static DataSet GetCityById(Guid CityId, string conSTR)
        {
            return DAL.City.GetCityByID(CityId, conSTR);
        }

        public static DataSet GetCityByBCO(string conSTR, string BCO)
        {
            return DAL.City.GetCityByBCO(conSTR , BCO);
        }

        public static void InsertCity(Guid BranchCorpOfficeId, Guid ModifiedBy, string CityName, string CityCode, string StreetAddress, string ContactNo1, string ContactNo2, string Fax, string zipcode, string conStr)
        {
            DAL.City.InsertCity(BranchCorpOfficeId, ModifiedBy, CityName, CityCode, StreetAddress, ContactNo1, ContactNo2, Fax, zipcode, conStr);

        }
        public static void UpdateCity(Guid CityId, Guid BcoId, Guid ModifiedBy, string CityName, string CityCode, string StreetAddress, string ContactNo1, string ContactNo2, string Fax, string zipcode, string conStr)
        {
            DAL.City.UpdateCity(CityId, BcoId, ModifiedBy, CityName, CityCode, StreetAddress, ContactNo1, ContactNo2, Fax,zipcode, conStr);
        }

        public static void DeleteCity(Guid CityId,int Flag, string conStr)
        {
            DAL.City.DeleteCity(CityId, Flag, conStr);
        }

    }
}
