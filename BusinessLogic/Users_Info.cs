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
using Tools = utilities;


namespace BusinessLogic
{
    public class Users_Info
    {

        public static void AddUsers(string username, byte[] password, byte[] salt, Guid employeeId,  Guid createdBy, string conStr)
        {
           // int countRowsAffected =  DAL.Users.AddUsers(username, password, salt, employeeId,createdBy, conStr);
          DAL.Users.AddUsers(username, password, salt, employeeId, createdBy, conStr);
            //return countRowsAffected;

        }
        
        public static void verifyemail(string vcode,  string connectionstring )
        {


            DAL.Users.verifyemail(vcode, connectionstring);
        
        }

        public static DataSet VerifyUser(string uName, string uPass, string conSTR)
        {

            DataSet ds = new DataSet();
            byte[] password = Tools.Encryption.EncryptPassword(uPass);
            ds = DAL.Users.VerifyUser(uName,  password, conSTR);
            return ds;

        }

        public static int isUsernameExist(string useroremail, string conSTR)
        {
            return DAL.Users.isUsernameExist(useroremail, conSTR);
        }
        public static int isEmailExist(string useroremail, string conSTR)
        {
            return DAL.Users.isEmailExist(useroremail, conSTR);
        }

        
   

        public static void AddUserInfo(Guid userid, string firstname, string lastname, string gender, string profileLink, string conStr)
        {

            DAL.Users.AddUserInfo(userid, firstname, lastname, gender, profileLink, conStr);

        }

        public static void UpdateUsers(Guid userId, string username, byte[] oldPassword, byte[] newPassword, Guid modifiedBy, string conStr)
        {

            DAL.Users.UpdateUsers(userId, username, oldPassword, newPassword, modifiedBy, conStr);

        }

        public static Guid GetUserId(string userName, string conStr)
        {
            return DAL.Users.GetUserId(userName, conStr);
        }


        public static DataSet GetUserInfo(string conStr)
        {
            return DAL.Users.GetUserInfo(conStr);
        }

        public static DataSet GetUserInfo(string conStr, Guid userid)
        {
            return DAL.Users.GetUserInfo(conStr, userid);
        }


        public static void UpdateUserProfile(Guid userid,  int flag, string conStr)
        {
            DAL.Users.UpdateUserProfile(userid, flag, conStr);
        }

        public static DataSet GetUserByUserId(Guid userId, string conStr)
        {
            return DAL.Users.GetUserByUserId(userId, conStr);
        }

    }
}
