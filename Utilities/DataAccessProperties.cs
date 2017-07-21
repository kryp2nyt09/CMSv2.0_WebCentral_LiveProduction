using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace utilities
{
    public class DataAccessProperties
    {


        private static string conStrCMS = ";";

        public string ConStrCMS
        {
            get
            {
                return conStrCMS = ConfigurationManager.ConnectionStrings["cms"].ConnectionString;
            }

        }

        private string reportPath;
        public string SoaReportsPath
        {
            get
            {
                return reportPath = ConfigurationManager.AppSettings["SoaReportPath"].ToString();
            }
        }

        private static string conStrTracking = ";";
        public string ConStrTracking
        {
            get
            {
                return conStrTracking = ConfigurationManager.ConnectionStrings["Tracking"].ConnectionString;
            }

        }


        private static string conStrShipment = ";";
        public string ConStrShipment
        {
            get
            {
                return conStrShipment = ConfigurationManager.ConnectionStrings["Shipment"].ConnectionString;
            }

        }


        //private static string iisWebName = ";";
        //public string IISWebName
        //{
        //    get
        //    {
        //        return iisWebName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        //    }

        //}

        public void CreateTableIfNotExist(string connectionString, string tableName, System.Collections.Generic.IEnumerable<DataColumn> dataColumns)
        {

        }


        public static string addStatus = "";

        public string AddStatus
        {
            get { return addStatus = "Add a New User"; } //1


        }

        public static string editStatus = "";

        public string EditStatus
        {
            get { return editStatus = "Update User Information"; } //1


        }
    }
}
