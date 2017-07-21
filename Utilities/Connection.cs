using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Configuration;
using System.Data;

using System.Data.SqlClient;
namespace utilities

{
    public class Connection
    {
        /// <summary>
        /// RJCORTEZIII                      ADD                  12/2/2016
        /// REMARKS:    Check SQL server availability.
        /// </summary>
        /// <param name="conSTR"></param>
        /// <returns></returns>
        public static int IsDisconnected(string conSTR)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            
            int returnvalue = 0;

            try
            {
                conn.Open();
                returnvalue = 1;
            }
            catch (Exception er)
            {
                returnvalue = 2;
                Console.WriteLine(er);
            }
            finally
            {
                conn.Close();

            }
            return returnvalue;

        }
    }
}
