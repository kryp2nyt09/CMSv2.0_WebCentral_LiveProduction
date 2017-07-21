using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRole
    {
        public static DataSet GetAllUserRoles(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_UserRole", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static DataSet GetRolesByUserRoleId(Guid userrolesId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RolesByUserRoleId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UserRoleId", SqlDbType.UniqueIdentifier).Value = userrolesId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet GetAllRoles(string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Role", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        public static void InsertUserRole(Guid roleId, Guid userId, bool canLogintoweb, bool canLogintoclient, bool canLogintoTnt, bool canLogintoMobile, Guid createdBy, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_UserRole", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RoleId", SqlDbType.UniqueIdentifier).Value = roleId;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@CanLogintoWeb", SqlDbType.Bit).Value = canLogintoweb;
                    cmd.Parameters.Add("@CanLogintoClient", SqlDbType.Bit).Value = canLogintoclient;
                    cmd.Parameters.Add("@CanLogintoTnT", SqlDbType.Bit).Value = canLogintoTnt;
                    cmd.Parameters.Add("@CanLogintoMobile", SqlDbType.Bit).Value = canLogintoMobile;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateUserRole(Guid roleId, Guid userId, bool canLogintoweb, bool canLogintoclient, bool canLogintoTnt, bool canLogintoMobile, Guid modifiedBy, int status, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_UserRole", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RoleId", SqlDbType.UniqueIdentifier).Value = roleId;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@CanLogintoWeb", SqlDbType.Bit).Value = canLogintoweb;
                    cmd.Parameters.Add("@CanLogintoClient", SqlDbType.Bit).Value = canLogintoclient;
                    cmd.Parameters.Add("@CanLogintoTnT", SqlDbType.Bit).Value = canLogintoTnt;
                    cmd.Parameters.Add("@CanLogintoMobile", SqlDbType.Bit).Value = canLogintoMobile;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                    cmd.Parameters.Add("@RecordStatus", SqlDbType.Int).Value = status;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetMenuByAppTitle(string apptitle, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_MenubyAppTitle", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AppTitle", SqlDbType.NVarChar).Value = apptitle;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet GetMenu(string apptitle, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_Menu", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@AppTitle", SqlDbType.NVarChar).Value = apptitle;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet GetSubMenuByMenuId(Guid menuId, string apptitle, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_SubMenuByMenuId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
                da.SelectCommand.Parameters.Add("@AppTitle", SqlDbType.NVarChar).Value = apptitle;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet UpdateLoginDate(string username, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_update_UserLoginDate", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet UpdateLoginDateandCheckLogin(string username, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_update_UserLoginDateCheckLogin", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }


        //Get menu access by Username
        public static DataSet GetMenuAccessByUsername(string username, Guid userId ,string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_MenuByUsername", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                da.SelectCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

    
        public static int CheckifUserHasAccessMenu(string menuName, string userName, string constr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_check_MenuAccessbyUsername", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = menuName;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = userName;
                    //rows output
                    cmd.Parameters.Add("@result", SqlDbType.Int);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@result"].Value);
                }
            }

            return countRowsAffected;

        }

        //check access -  combined
        public static int CheckifUserHasAccess(string menuName, string url, string userName, string constr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_check_Access", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar).Value = (object)menuName ?? DBNull.Value;
                    cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = (object)url ?? DBNull.Value;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = userName;
                    //rows output
                    cmd.Parameters.Add("@result", SqlDbType.Int);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@result"].Value);
                }
            }

            return countRowsAffected;

        }


        //Check if URL Exist
        public static int CheckIfURLExists(string url, string constr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_check_Url", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = (object)url ?? DBNull.Value;
                    //rows output
                    cmd.Parameters.Add("@result", SqlDbType.Int);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@result"].Value);
                }
            }

            return countRowsAffected;

        }


        public static DataSet GetUserRolebyUserId(Guid userId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_UserRoleByUserId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        //Menu
        public static DataSet GetMenuByUserId(Guid userId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_MenuByUserId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static void InsertMenuAccess(Guid menuId, Guid userId, Guid createdBy, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_MenuAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int checkIfUserIdExists(Guid userId, string conStr)
        {
            int countRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_checkifExists_UserId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    //rows output
                    cmd.Parameters.Add("@checkIfExists", SqlDbType.Int);
                    cmd.Parameters["@checkIfExists"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @rowCount
                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@checkIfExists"].Value);
                }
            }

            return countRowsAffected;
        }

        public static void UpdateMenuAccess(Guid menuId, Guid userId, Guid modifiedBy, int status, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_MenuAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                    cmd.Parameters.Add("@RecordStatus", SqlDbType.Int).Value = status;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public static int checkIfMenuIdExists(Guid menuId, Guid userId, string conStr)
        //{
        //    int countRowsAffected = 0;
        //    using (SqlConnection con = new SqlConnection(conStr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_checkIfExists_MenuIdByUserId", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
        //            cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
        //            //rows output
        //            cmd.Parameters.Add("@checkIfExists", SqlDbType.Int);
        //            cmd.Parameters["@checkIfExists"].Direction = ParameterDirection.Output;
        //            con.Open();
        //            cmd.ExecuteNonQuery();

        //            // read output value from @rowCount
        //            countRowsAffected = Convert.ToInt32(cmd.Parameters["@checkIfExists"].Value);
        //        }
        //    }

        //    return countRowsAffected;
        //}

        public static Tuple<int, int> checkIfMenuIdExists(Guid menuId, Guid userId, string conStr)
        {
            int countRowsAffected = 0;
            int status = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_checkIfExists_MenuIdByUserId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                   // rows output
                    cmd.Parameters.Add("@checkIfExists", SqlDbType.Int);
                    cmd.Parameters["@checkIfExists"].Direction = ParameterDirection.Output;

                    //statusOutput
                    cmd.Parameters.Add("@checkStatus", SqlDbType.Int);
                    cmd.Parameters["@checkStatus"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    countRowsAffected = Convert.ToInt32(cmd.Parameters["@checkIfExists"].Value);
                    status = Convert.ToInt32(cmd.Parameters["@checkStatus"].Value);
                }
            }

            return new Tuple<int, int>(countRowsAffected, status);
        }


        //SubMenuByMenuId
        public static DataSet SubMenubyMenuId(Guid menuId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_check_SubMenuByMenuId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@MenuId", SqlDbType.UniqueIdentifier).Value = menuId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        public static DataSet MenuAccessByUserId(Guid userId, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_check_MenuAccessByUserId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }

        }

        //First Access
        public static string MenuFirstAccess(string access, string conStr)
        {

            string output = "";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_FirstAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@menu", SqlDbType.NVarChar, 500).Value = access;
                    
                    // rows output
                    cmd.Parameters.Add("@result", SqlDbType.NVarChar, 500);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    output = Convert.ToString(cmd.Parameters["@result"].Value);
                   
                }
            }

            return output;
        }



    }
}
