using CMSVersion2.Models;
using CMSVersion2.Shipment.AWBTrackingModal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Shipment
{
    public partial class AWBTracking : System.Web.UI.Page
    {
        ViewCargo vcargo = new ViewCargo();

        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

            if (!IsPostBack)
            {


            }
        }

        #region InitLoad

        #endregion

        #region Properties

        List<AwbDetailsModel> listawbDetails = new List<AwbDetailsModel>();
        DataTable awbData = new DataTable();
        #endregion



        #region DataSources
        public DataTable GetAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetAwbInfoByAwbNo(awbNo, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetDetailsAwbNoInformation(string awbNo)
        {
            DataSet data = BLL.AirwayBill.GetDetailsAwbNo(awbNo,2, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            awbData = awbDatatable(convertdata);

            return convertdata;
        }

        public DataTable awbDatatable(DataTable datatable)
        {
            DataTable data = new DataTable();
            data.Columns.AddRange(new DataColumn[8]
                        {
                        new DataColumn("Id", typeof(Guid)),
                        new DataColumn("dateandtime", typeof(DateTime)),
                        new DataColumn("statusofAwb",typeof(string)),
                        new DataColumn("location",typeof(string)),
                        new DataColumn("arrivedPcs", typeof(int)),
                        new DataColumn("cargo", typeof(string)),
                        new DataColumn("receivedBy", typeof(string)),
                        new DataColumn("remarks", typeof(string))
                       });

            foreach (DataRow row in datatable.Rows)
            {
                AwbDetailsModel awbModel = new AwbDetailsModel();
                Guid id = Guid.Parse(row[0].ToString());
                DateTime dateandtime = Convert.ToDateTime(row[1].ToString());
                string statusofAwb = row[2].ToString();
                string location = row[3].ToString();
                int arrivedPcs = Convert.ToInt32(row[4].ToString());
                string cargo = row[5].ToString();
                string receivedBy = row[6].ToString();
                string remarks = row[7].ToString();

                awbModel.Id = id;
                awbModel.dateandtime = dateandtime;
                awbModel.statusofAwb = statusofAwb;
                awbModel.location = location;
                awbModel.arrivedPcs = arrivedPcs;
                awbModel.cargo = cargo;
                awbModel.receivedBy = receivedBy;
                awbModel.remarks = remarks;
                listawbDetails.Add(awbModel);
                awbModel.listawbDetails = listawbDetails;

            }

            vcargo.getAwb(listawbDetails);

            return data;
        }

        public void fillAwbNoInfo(DataTable Data)
        {
            int counter = 0;
            foreach (DataRow row in Data.Rows)
            {
                if (counter == 0)
                {
                    try
                    {
                        txtAwb.Text = row["AirwayBillNo"].ToString();

                        string acceptedDate = row["DateAccepted"].ToString();
                        DateTime dateAccepted = Convert.ToDateTime(acceptedDate);

                        txtDate.Text = dateAccepted.ToShortDateString(); ;

                        txtOrigin.Text = row["Origin"].ToString();
                        txtDestination.Text = row["Destination"].ToString();
                        txtShipper.Text = row["Shipper"].ToString();
                        txtConsignee.Text = row["Consignee"].ToString();

                        txtCommodity.Text = row["CommodityName"].ToString();
                        txtDesc.Text = row["GoodsDescriptionName"].ToString();
                        txtServiceType.Text = row["ServiceTypeName"].ToString();
                        txtShipMode.Text = row["ShipModeName"].ToString();
                        txtAddress1.Text = row["OriginAddress"].ToString();
                        txtAddress2.Text = row["DestinationAddress"].ToString();

                        txtQuantity.Text = row["Quantity"].ToString();
                        txtWeight.Text = row["Weight"].ToString();
                        txtDimension.Text = row["Dimension"].ToString();



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    counter++;
                }
            }
        }
        #endregion


        #region Events
        #region RadGrid Events

        #endregion

        #region Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string awbNo = "";
            if (!String.IsNullOrEmpty(txtAwbNo.Text))
            {
                awbNo = txtAwbNo.Text;
                DataTable Data = GetAwbNoInformation(awbNo);
                //fillAwbNoInfo(Data);
                #region Fill Value
                int counter = 0;
                foreach (DataRow row in Data.Rows)
                {
                    if (counter == 0)
                    {
                        try
                        {
                            txtAwb.Text = row["AirwayBillNo"].ToString();

                            string acceptedDate = row["DateAccepted"].ToString();
                            DateTime dateAccepted = Convert.ToDateTime(acceptedDate);

                            txtDate.Text = dateAccepted.ToShortDateString(); ;

                            txtOrigin.Text = row["Origin"].ToString();
                            txtDestination.Text = row["Destination"].ToString();
                            txtShipper.Text = row["Shipper"].ToString();
                            txtConsignee.Text = row["Consignee"].ToString();

                            txtCommodity.Text = row["CommodityName"].ToString();
                            txtDesc.Text = row["GoodsDescriptionName"].ToString();
                            txtServiceType.Text = row["ServiceTypeName"].ToString();
                            txtShipMode.Text = row["ShipModeName"].ToString();
                            txtAddress1.Text = row["OriginAddress"].ToString();
                            txtAddress2.Text = row["DestinationAddress"].ToString();

                            txtQuantity.Text = row["Quantity"].ToString();
                            txtWeight.Text = row["Weight"].ToString();
                            txtDimension.Text = row["Dimension"].ToString();



                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        counter++;
                    }
                }
                #endregion
                radGridAwbNo.DataSource = GetDetailsAwbNoInformation(awbNo);
                radGridAwbNo.Rebind();
                radGridAwbNo.DataBind();

            }
        }

        //protected void radGridAwbNo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    string awbNo = txtAwbNo.Text;
        //    radGridAwbNo.DataSource = GetDetailsAwbNoInformation(awbNo);
        //}
        #endregion

        protected void radGridAwbNo_ItemCreated(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("viewCargoLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowCargo('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"], e.Item.ItemIndex);
                vcargo.getAwb(listawbDetails);
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                radGridAwbNo.MasterTableView.SortExpressions.Clear();
                radGridAwbNo.MasterTableView.GroupByExpressions.Clear();
                radGridAwbNo.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                radGridAwbNo.MasterTableView.SortExpressions.Clear();
                radGridAwbNo.MasterTableView.GroupByExpressions.Clear();
                radGridAwbNo.MasterTableView.CurrentPageIndex = radGridAwbNo.MasterTableView.PageCount - 1;
                radGridAwbNo.Rebind();
            }
        }
        #endregion

    }
}