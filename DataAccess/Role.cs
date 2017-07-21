using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class Role
    {
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

        public static DataSet GetRoleByRoleId(Guid roleId, string conSTR)
        {
            using (SqlConnection con = new SqlConnection(conSTR))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_view_RoleByRoleId", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.UniqueIdentifier).Value = roleId;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public static void InsertRoleName(string roleName, string description, Guid createdBy, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Role", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = roleName;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateRoleName(Guid roleId, string roleName, string description, Guid modifiedBy, string constr)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_Role", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RoleId", SqlDbType.UniqueIdentifier).Value = roleId;
                    cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = roleName;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                    cmd.Parameters.Add("@ModifiedBy", SqlDbType.UniqueIdentifier).Value = modifiedBy;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
