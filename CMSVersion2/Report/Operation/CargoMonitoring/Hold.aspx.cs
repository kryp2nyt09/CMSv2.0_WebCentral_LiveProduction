﻿using CMSVersion2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.CargoMonitoring
{
    public partial class Hold : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        public static string WebPathName = ConfigurationManager.ConnectionStrings["iiswebname"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable getHold()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;
            try
            {
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;
            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            DataSet data = BLL.Report.CargoMonitoring.GetCargoMonitoringHold(getConstr.ConStrCMS, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            ReportGlobalModel.Report = "HoldReport";
            ReportGlobalModel.table1 = dt;
            ReportGlobalModel.Date = date1.ToShortDateString();
            ReportGlobalModel.Remarks = date2.ToShortDateString();
            return dt;
        }

        protected void grid_Hold_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Hold.DataSource = getHold();
        }

        protected void grid_Hold_PreRender(object sender, EventArgs e)
        {
            grid_Hold.DataSource = getHold();
            grid_Hold.Rebind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            RadWindow1.NavigateUrl = "http://" + host + "/" + WebPathName + "/Report/ReportViewerForm1.aspx";
            string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            RadScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}