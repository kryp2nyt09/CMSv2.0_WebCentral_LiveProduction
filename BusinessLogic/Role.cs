using System;
using System.Data;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class Role
    {
        public static DataSet GetAllRoles(string constr)
        {
            return DAL.Role.GetAllRoles(constr);
        }

        public static DataSet GetRoleByRoleId(Guid roleId, string constr)
        {
            return DAL.Role.GetRoleByRoleId(roleId, constr);
        }

        public static void InsertRoleName(string roleName, string description, Guid createdBy, string constr)
        {
            DAL.Role.InsertRoleName(roleName, description, createdBy, constr);
        }

        public static void UpdateRoleName(Guid roleId, string roleName, string description, Guid modifiedBy, string constr)
        {
            DAL.Role.UpdateRoleName(roleId, roleName, description, modifiedBy, constr);
        }
    }
}
