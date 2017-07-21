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
    public class EmployeeInfo
    {
        public static DataSet GetEmployeeName(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_employeenames", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_get_employeenames", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet EmployeeNameinUser(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_EmployeeNameinUser", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_EmployeeNameinUser", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet EmployeeNameinRoleUser(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_EmployeeNameinRoleUser", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_EmployeeNameinRoleUser", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetEmployeeNameById(Guid EmployeeId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_EmployeebyId", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_EmployeebyId", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@employeeid", SqlDbType.UniqueIdentifier).Value = EmployeeId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetEmployee(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_employee", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_employee", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static DataSet GetEmployeeBySearch(Guid bcoId, Guid revenueUnitTypeId, Guid rUnitId, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_EmployeeByRevenueUnit", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_EmployeeByRevenueUnit", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BcoID", SqlDbType.UniqueIdentifier).Value = bcoId;
                    da.SelectCommand.Parameters.Add("@RevenueUnitTypeId", SqlDbType.UniqueIdentifier).Value = revenueUnitTypeId;
                    da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = rUnitId;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static void InsertEmployee(Guid DepartmentId, Guid PositionId, Guid AssignedToAreaId, string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime? licenseExpiration,Guid createdby, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Insert_Employee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@departmentid", SqlDbType.UniqueIdentifier).Value = DepartmentId;
                    cmd.Parameters.Add("@positionId", SqlDbType.UniqueIdentifier).Value = PositionId;
                    cmd.Parameters.Add("@assignedtoareaid", SqlDbType.UniqueIdentifier).Value = AssignedToAreaId;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstname;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastname;
                    cmd.Parameters.Add("@middlename", SqlDbType.VarChar).Value = middlename;
                    cmd.Parameters.Add("@birthdate", SqlDbType.Date).Value = birthday;
                    cmd.Parameters.Add("@telno", SqlDbType.VarChar).Value = telno;
                    cmd.Parameters.Add("@mobileno", SqlDbType.VarChar).Value = mobileno;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@license", SqlDbType.VarChar).Value = license;
                    //cmd.Parameters.Add("@licenseExpiration", SqlDbType.Date).Value = licenseExpiration;
                    cmd.Parameters.Add("@licenseExpiration", SqlDbType.Date).Value = (object)licenseExpiration ?? DBNull.Value;
                    cmd.Parameters.Add("@createdby", SqlDbType.UniqueIdentifier).Value = createdby;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateEmployee(Guid EmployeeId, Guid departmentId, Guid positionId, string firstname, string lastname, string middlename,
            DateTime birthday, string telno, string mobileno, string email, string license, DateTime? licenseExpiration, 
            Guid createdby, Guid assignedToAreaId, string conStr )
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_Employee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@employeeid", SqlDbType.UniqueIdentifier).Value = EmployeeId;
                    cmd.Parameters.Add("@departmentId", SqlDbType.UniqueIdentifier).Value = departmentId;
                    cmd.Parameters.Add("@positionId", SqlDbType.UniqueIdentifier).Value = positionId;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstname;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastname;
                    cmd.Parameters.Add("@middlename", SqlDbType.VarChar).Value = middlename;
                    cmd.Parameters.Add("@birthdate", SqlDbType.Date).Value = birthday;
                    cmd.Parameters.Add("@telno", SqlDbType.VarChar).Value = telno;
                    cmd.Parameters.Add("@mobileno", SqlDbType.VarChar).Value = mobileno;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@license", SqlDbType.VarChar).Value = license;
                    //cmd.Parameters.Add("@licenseExpiration", SqlDbType.Date).Value = licenseExpiration;
                    cmd.Parameters.Add("@licenseExpiration", SqlDbType.Date).Value = (object)licenseExpiration ?? DBNull.Value;
                    cmd.Parameters.Add("@createdby", SqlDbType.UniqueIdentifier).Value = createdby;
                    cmd.Parameters.Add("@assignedToareaId", SqlDbType.UniqueIdentifier).Value = assignedToAreaId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteEmployee(Guid employeeId, int Flag, string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_delete_Employee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.UniqueIdentifier).Value = employeeId;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetEmployeeNames(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_employeenames", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_get_employeenames", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        //Get all Delivered By
        public static DataSet GetDeliveredBy(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_Reports_DeliveredBy", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_DeliveredBy", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        //Get all Delivered By BCO Id
        public static DataSet GetDeliveredByBcoId(string conStr, Guid bcoid)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_Reports_DeliveredByBCO", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_DeliveredByBCO", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoid;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        //Get all Delivered By RevenueUnit Id and BCo
        public static DataSet GetDeliveredByRevenue(string conStr, Guid bcoid, Guid revenueunitid)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_view_Reports_DeliveredByRevenueUnit", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter("sp_view_Reports_DeliveredByRevenueUnit", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BcoId", SqlDbType.UniqueIdentifier).Value = bcoid;
                    da.SelectCommand.Parameters.Add("@RevenueUnitId", SqlDbType.UniqueIdentifier).Value = revenueunitid;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

    }
}
