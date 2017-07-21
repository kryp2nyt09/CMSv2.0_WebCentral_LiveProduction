using CMSVersion2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Tools = utilities;

namespace CMSVersion2.Shipment.AWBTrackingModal
{
    public partial class ViewCargo : System.Web.UI.Page
    {
        List<AwbDetailsModel> listDetails = new List<AwbDetailsModel>();
        static List<AwbDetailsModel> staticlistDetails = new List<AwbDetailsModel>();

        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            rdViewCargo.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {

                }
                else
                {
                    string awbNo = Request.QueryString["Id"].ToString();
                    lblAwbNumber.Value = awbNo;
                }
            }


        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            this.Page.Title = "View Cargo";
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                rdViewCargo.MasterTableView.SortExpressions.Clear();
                rdViewCargo.MasterTableView.GroupByExpressions.Clear();
                rdViewCargo.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                rdViewCargo.MasterTableView.SortExpressions.Clear();
                rdViewCargo.MasterTableView.GroupByExpressions.Clear();
                rdViewCargo.MasterTableView.CurrentPageIndex = rdViewCargo.MasterTableView.PageCount - 1;
                rdViewCargo.Rebind();
            }
        }


        public List<AwbDetailsModel> getAwb(List<AwbDetailsModel> list)
        {
            listDetails = list;
            staticlistDetails = listDetails;
            return list;
        }


        public DataTable GetDetailsAwbNoInformation(Guid id)
        {
            List<AwbDetailsModel> listawbDetails = staticlistDetails;
            var results = listawbDetails.FindAll(r => r.Id == id);
            DataTable convertdata = ConvertToDataTable(results.ToList());
            return convertdata;
        }

        private DataTable ConvertToDataTable(List<AwbDetailsModel> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(Guid)));
            dt.Columns.Add(new DataColumn("dateandtime", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("statusofAwb", typeof(string)));
            dt.Columns.Add(new DataColumn("location", typeof(string)));
            dt.Columns.Add(new DataColumn("arrivedPcs", typeof(int)));
            dt.Columns.Add(new DataColumn("cargo", typeof(string)));
            dt.Columns.Add(new DataColumn("receivedBy", typeof(string)));
            dt.Columns.Add(new DataColumn("remarks", typeof(string)));

            dt.BeginLoadData();

            foreach (AwbDetailsModel item in list)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id.ToString();
                row["dateandtime"] = Convert.ToDateTime(item.dateandtime.ToString());
                row["statusofAwb"] = item.statusofAwb.ToString();
                row["location"] = item.location.ToString();
                row["arrivedPcs"] = Convert.ToInt32(item.arrivedPcs.ToString());
                row["cargo"] = item.cargo.ToString();
                row["receivedBy"] = item.receivedBy.ToString();
                row["remarks"] = item.remarks.ToString();
                dt.Rows.Add(row);
            }
            dt.EndLoadData();
            return dt;
        }


        protected void rdViewCargo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Guid id = new Guid();
            string awbNo = Request.QueryString["Id"].ToString();
            if (awbNo != null)
            {
                try
                {
                    id = Guid.Parse(awbNo);
                    rdViewCargo.DataSource = GetDetailsAwbNoInformation(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}