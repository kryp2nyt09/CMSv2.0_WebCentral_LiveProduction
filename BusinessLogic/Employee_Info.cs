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
    public class Employee_Info
    {
        //UserRole
        public static DataSet GetEmployeeNames(string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeNames(conStr);
        }

        //DeliveredBy
        public static DataSet GetDeliveredBy(string conStr)
        {
            return DAL.EmployeeInfo.GetDeliveredBy(conStr);
        }

        //DeliveredBy bco id
        public static DataSet GetDeliveredByBcoId(string conStr, Guid bcoid)
        {
            return DAL.EmployeeInfo.GetDeliveredByBcoId(conStr, bcoid);
        }

        //DeliveredBy bco id and revenueunitid
        public static DataSet GetDeliveredByRevenue(string conStr, Guid bcoid, Guid revenueunitid)
        {
            return DAL.EmployeeInfo.GetDeliveredByRevenue(conStr, bcoid, revenueunitid);
        }

        public static DataSet GetEmployeeName(string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeName(conStr);
        }

        public static DataSet EmployeeNameinUser(string conStr)
        {
            return DAL.EmployeeInfo.EmployeeNameinUser(conStr);
        }

        public static DataSet EmployeeNameinRoleUser(string conStr)
        {
            return DAL.EmployeeInfo.EmployeeNameinRoleUser(conStr);
        }

        public static DataSet GetEmployeeById(Guid EmployeeId, string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeNameById(EmployeeId,conStr);
        }

        public static DataSet GetEmployee(string conStr)
        {
            return DAL.EmployeeInfo.GetEmployee(conStr);
        }

        public static DataSet GetEmployeeBySearch(Guid bcoId, Guid revenueUnitTypeId, Guid rUnitId, string conStr)
        {
            return DAL.EmployeeInfo.GetEmployeeBySearch(bcoId, revenueUnitTypeId, rUnitId, conStr);
        }


        public static void InsertEmployee(Guid Departmentid, Guid PositionId, Guid AssignedToAreaId , string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime? licenseExpiration,Guid createdby, string conStr)
        {
             DAL.EmployeeInfo.InsertEmployee(Departmentid, PositionId, AssignedToAreaId, firstname, lastname, middlename,
                birthday, telno, mobileno, email, license, licenseExpiration, createdby, conStr);
        }

        public static void UpdateEmployee(Guid EmployeeId, Guid departmentId, Guid positionId, string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime? licenseExpiration, Guid createdby, 
            Guid assignedToAreaId, string conStr)
        {
            DAL.EmployeeInfo.UpdateEmployee(EmployeeId, departmentId, positionId, firstname, lastname, middlename,
               birthday, telno, mobileno, email, license, licenseExpiration, createdby, assignedToAreaId, conStr);
        }

        public static void DeleteEmployee(Guid employeeId, int Flag, string conStr)
        {
            DAL.EmployeeInfo.DeleteEmployee(employeeId, Flag, conStr);
        }
    }
}
