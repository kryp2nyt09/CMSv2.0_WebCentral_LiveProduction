using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class CargoMonitoring
    {
        public static DataSet GetCargoMonitoringDelivered(string conSTR, DateTime? date1, DateTime? date2, Guid? bcoid, Guid? revenueunitid, Guid? deliveredbyid, Guid? deliverystatusid)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringDelivered(conSTR, date1, date2, bcoid,revenueunitid, deliveredbyid, deliverystatusid);
        }

        public static DataSet GetCargoMonitoringHold(string conSTR, DateTime? date1, DateTime? date2)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringHold(conSTR, date1, date2);
        }

        public static DataSet GetCargoMonitoringMisrouted(string conSTR, DateTime? date1, DateTime? date2)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringMisrouted(conSTR, date1, date2);
        }
        public static DataSet GetCargoMonitoringOffloaded(string conSTR, DateTime? date1, DateTime? date2)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringOffloaded(conSTR, date1, date2);
        }

        public static DataSet GetCargoMonitoringPending(string conSTR, DateTime? date1, DateTime? date2)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringPending(conSTR, date1, date2);
        }

        public static DataSet GetCargoMonitoringRUD(string conSTR, DateTime? date1, DateTime? date2)
        {
            return DAL.Reports.CargoMonitoring.GetCargoMonitoringRUD(conSTR, date1, date2);
        }

    }
}
