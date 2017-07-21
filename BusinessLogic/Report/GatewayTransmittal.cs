using System;
using System.Data;
using DAL = DataAccess;

namespace BusinessLogic.Report
{
    public class GatewayTransmittal
    {
        public static DataSet GetGWTransmittal(string conSTR,DateTime? dateFrom,DateTime? dateTo, Guid? originbcoId,Guid? destbcoId, Guid? batchid, Guid? commodityTypeId, string driver ,string gateway ,string mawb)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayTransmittal(conSTR, dateFrom, dateTo, originbcoId, destbcoId, batchid,commodityTypeId, driver, gateway, mawb);
        }

        public static DataSet GetGWOutbound(string conSTR,DateTime? dateFrom,DateTime? dateTo,Guid? originbcoId,Guid? destbcoId,string driver,string gateway,Guid? batchid, Guid? commoditytypeid ,string mawb)
        {
            return DAL.Reports.GatewayOutbound.GetGatewayOutbound(conSTR, dateFrom, dateTo, originbcoId, destbcoId, driver, gateway, batchid, commoditytypeid, mawb);
        }

        public static DataSet GetGWInbound(string conSTR, DateTime? dateFrom, DateTime? dateTo,Guid? destbcoid,Guid? originbcoid,string gateway,Guid? commoditytypeid, string flightno,string mawb)
        {
            return DAL.Reports.GatewayInbound.GetGatewayInbound(conSTR, dateFrom, dateTo, destbcoid, originbcoid, gateway, commoditytypeid, flightno, mawb);
        }
        public static DataSet GetCargoTransfer(string conSTR , DateTime? dateFrom,DateTime? dateTo, Guid? originbcoid, Guid? desctbcoid, Guid? revenuetypeid,Guid? revenueunitid,string plateNo, Guid? batchid)
        {
            return DAL.Reports.CargoTransfer.GetCargoTransfer(conSTR , dateFrom, dateTo, originbcoid, desctbcoid, revenuetypeid, revenueunitid, plateNo, batchid);
        }

        public static DataSet GetHoldCargo(string conSTR, DateTime dateFrom, DateTime dateTo, string bco)
        {
            return DAL.Reports.HoldCargo.GetGatewayOutbound(conSTR, dateFrom, dateTo, bco);
        }

        //public static DataSet GetGatewayList(string conSTR , string date)
        //{
        //    return DAL.Reports.GatewayTransmittal.GetGatewayList(conSTR, date);
        //}
        public static DataSet GetGatewayList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayList(conSTR);
        }

        public static DataSet GetGatewayOutBoundList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayOutBoundList(conSTR);
        }
        public static DataSet GetGatewayInBoundList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGatewayInBoundList(conSTR);
        }


        //Driver
        public static DataSet GetGTDriverList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGTDriverList(conSTR);
        }

        //Driver
        public static DataSet GetGODriverList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGODriverList(conSTR);
        }

        //Driver
        public static DataSet GetGIFlightNumberList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetGIFlightNumberList(conSTR);
        }

        //PlateNo
        public static DataSet GetCTPlateNo(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetCTPlateNo(conSTR);
        }

        //PlateNo
        public static DataSet GetSGPlateNo(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetSGPlateNo(conSTR);
        }

        //Driver
        public static DataSet GetSGDriverList(string conSTR)
        {
            return DAL.Reports.GatewayTransmittal.GetSGDriverList(conSTR);
        }
    }
}
