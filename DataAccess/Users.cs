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
    public class Users
    {
        /// <summary>
        /// RJCORTEZIII                    ADD                     5.28.2015
        /// REMARKS:      Get user list
        /// </summary>
        /// <param name="conSTR"></param>
        /// <returns></returns>
        public static DataSet GetUsers(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;

                //SqlDataAdapter da = new SqlDataAdapter("spGetUsers", con);

                DataSet ds = new DataSet();
                //da.Fill(ds);
                return ds;

            }
        }

        /// <summary>
        /// RJCORTEZIII                    ADD                     5.28.2015
        /// REMARKS:   Search User by username
        /// </summary>
        /// <param name="conSTR"></param>
        /// <param name="uname"></param>
        /// <returns></returns>
        public static DataSet SearchUser(string conSTR, string uname)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                SqlDataAdapter da = new SqlDataAdapter("spGetUserSearch", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = uname;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        public static DataSet VerifyUser(string uName, byte[] uPass, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Validate_login", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("Username", SqlDbType.VarChar).Value = uName;
                da.SelectCommand.Parameters.Add("PasswordHash", SqlDbType.VarBinary).Value = uPass;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }



        public static int isUsernameExist(string useroremail, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_Verify_Username", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = useroremail;
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public static int isEmailExist(string useroremail, string conSTR)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_Verify_Email", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = useroremail;
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        /// <summary>
        /// RJCORTEZIII                    ADD                     5.28.2015
        /// Remarks:    Add user to user list
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="pass"></param>
        /// <param name="createdBy"></param>
        /// <param name="conStr"></param>
        public static void AddUsers(string username, byte[] password, byte[] salt, Guid employeeId,  Guid createdby, string conStr)
        {
            //int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    //cmd.Parameters.Add("@assignedToAreaId", SqlDbType.UniqueIdentifier).Value = AssignedToAreaid;
                    cmd.Parameters.Add("@pass", SqlDbType.VarBinary).Value = password;
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;
                    cmd.Parameters.Add("@employeeid", SqlDbType.UniqueIdentifier).Value = employeeId;
                    cmd.Parameters.Add("@createdby", SqlDbType.UniqueIdentifier).Value = createdby;
                   // cmd.Parameters.Add("@rowCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("@rowCount", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                   // countRowsAffected = (int)cmd.Parameters["@rowCount"].Value;
                  //  countRowsAffected = Convert.ToInt32(cmd.Parameters["@rowCount"].Value);

                }
            }
            //return countRowsAffected;
        }

     
        public static void UpdateUsers(Guid userId, string username, byte[] oldPassword, byte[] newPassword, Guid modifiedBy, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@OldPassword", SqlDbType.VarBinary).Value = oldPassword;
                    cmd.Parameters.Add("@NewPassword", SqlDbType.VarBinary).Value = newPassword;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }


        public static void UpdateUserProfile(Guid userid, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_user", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userid;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void verifyemail(string vcode, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Verify_Email", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vcode", SqlDbType.VarChar).Value = vcode;
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }


        }

        //public static void UpdateUser(string conStr, string eAdd, DateTime eToday, string currentuser, int userid)
        //{
        //    using (SqlConnection con = new SqlConnection(conStr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("spUpdateUsers", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@userId", SqlDbType.VarChar).Value = userid;
        //            cmd.Parameters.Add("@eadd", SqlDbType.VarChar).Value = eAdd;
        //            cmd.Parameters.Add("@DateModified", SqlDbType.DateTime).Value = eToday;
        //            cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = currentuser;


        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}



        public static void DeleteUSer(int uID, string conStr)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = uID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static Guid GetUserId(string username, string conStr)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_Get_User_Id", conStr);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;

            DataTable dt = new DataTable();
            da.Fill(dt);

            Guid userid = Guid.Parse(dt.Rows[0].ItemArray[0].ToString());

            return userid;


        }

        public static void AddUserInfo(Guid userid, string firstname, string lastname, string gender, string profileLink, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_User_PersonalInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userid;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = firstname;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lastname;
                    //cmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = "";
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
                    //cmd.Parameters.Add("@CellphoneNumber", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@ProfileLink", SqlDbType.VarChar).Value = profileLink;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetUserInfo(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_users", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_users", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userinfo;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetUserInfo(string conStr, Guid userid)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_user", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_user", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userid;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetUserByUserId(Guid userId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_UserbyUserId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_UserbyUserId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }


    }
}
