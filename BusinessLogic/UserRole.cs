using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic
{
    public class UserRole
    {
        public static DataSet GetAllUserRoles(string constr)
        {
            return DAL.UserRole.GetAllUserRoles(constr);
        }

        public static DataSet GetRolesByUserRoleId(Guid userrolesId, string constr)
        {
            return DAL.UserRole.GetRolesByUserRoleId(userrolesId, constr);
        }

        public static DataSet GetAllRoles(string constr)
        {
            return DAL.UserRole.GetAllRoles(constr);
        }

        public static void InsertUserRole(Guid roleId, Guid userId, bool canLogintoweb, bool canLogintoclient, bool canLogintoTnt, bool canLogintoMobile , Guid createdBy, string constr)
        {
            DAL.UserRole.InsertUserRole(roleId, userId, canLogintoweb, canLogintoclient, canLogintoTnt, canLogintoMobile, createdBy, constr);
        }

        public static DataSet GetMenuByAppTitle(string apptitle, string constr)
        {
            return DAL.UserRole.GetMenuByAppTitle(apptitle, constr);
        }

        public static DataSet GetMenu(string apptitle, string constr)
        {
            return DAL.UserRole.GetMenu(apptitle, constr);
        }

        public static DataSet GetSubMenuByMenuId(Guid menuId, string apptitle, string constr)
        {
            return DAL.UserRole.GetSubMenuByMenuId(menuId, apptitle, constr);
        }

        public static DataSet UpdateLoginDate(string username, string constr)
        {
            return DAL.UserRole.UpdateLoginDate(username, constr);
        }

        //Update CheckLogin
        public static DataSet UpdateLoginDateandCheckLogin(string username, string constr)
        {
            return DAL.UserRole.UpdateLoginDateandCheckLogin(username, constr);
        }


        //Get Menu Access by Username
        public static DataSet GetMenuAccessByUsername(string userName, Guid userId, string constr)
        {
            return DAL.UserRole.GetMenuAccessByUsername(userName, userId, constr);
        }

        public static int CheckifUserHasAccessMenu(string menuName,string userName, string constr)
        {
            return DAL.UserRole.CheckifUserHasAccessMenu(menuName, userName, constr);
        }

        //Check access - combined
        public static int CheckifUserHasAccess(string menuName, string url, string userName, string constr)
        {
            return DAL.UserRole.CheckifUserHasAccess(menuName, url, userName, constr);
        }

        //Count if URl exists
        public static int CheckIfURLExists(string url, string constr)
        {
            return DAL.UserRole.CheckIfURLExists(url, constr);
        }

        public static DataSet GetUserRolebyUserId(Guid userId, string constr)
        {
            return DAL.UserRole.GetUserRolebyUserId(userId, constr);
        }

        //Menu
        public static DataSet GetMenuByUserId(Guid userId, string constr)
        {
            return DAL.UserRole.GetMenuByUserId(userId, constr);
        }

        public static void UpdateUserRole(Guid roleId, Guid userId, bool canLogintoweb, bool canLogintoclient, bool canLogintoTnt, bool canLogintoMobile, Guid modifiedBy, int status, string constr)
        {
            DAL.UserRole.UpdateUserRole(roleId, userId, canLogintoweb, canLogintoclient, canLogintoTnt, canLogintoMobile, modifiedBy, status, constr);
        }

        public static void InsertMenuAccess(Guid menuId, Guid userId, Guid createdBy, string constr)
        {
            DAL.UserRole.InsertMenuAccess(menuId, userId, createdBy, constr);
        }

        public static int checkIfUserIdExists(Guid userId, string conStr)
        {
            return DAL.UserRole.checkIfUserIdExists(userId, conStr);
        }

        public static void UpdateMenuAccess(Guid menuId, Guid userId, Guid modifiedBy, int status, string constr)
        {
            DAL.UserRole.UpdateMenuAccess(menuId, userId, modifiedBy, status, constr);
        }

        //public static int checkIfMenuIdExists(Guid menuId,Guid userId, string conStr)
        //{
        //    return DAL.UserRole.checkIfMenuIdExists(menuId, userId, conStr);
        //}

        public static Tuple<int, int> checkIfMenuIdExists(Guid menuId, Guid userId, string conStr)
        {
            return DAL.UserRole.checkIfMenuIdExists(menuId, userId, conStr);
            
        }

        //SubMenu by MenuId
        public static DataSet SubMenubyMenuId(Guid menuId, string constr)
        {
            return DAL.UserRole.SubMenubyMenuId(menuId, constr);
        }

        public static DataSet MenuAccessByUserId(Guid userId, string constr)
        {
            return DAL.UserRole.MenuAccessByUserId(userId, constr);
        }

        public static string MenuFirstAccess(string access, string conStr)
        {
            return DAL.UserRole.MenuFirstAccess(access, conStr);

        }

    }
}
