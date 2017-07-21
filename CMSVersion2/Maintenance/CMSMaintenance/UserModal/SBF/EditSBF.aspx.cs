﻿using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.SBF
{
    public partial class EditSBF : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString["ID"] == null)
                {

                }
                else
                {
                    string SBFid = Request.QueryString["ID"].ToString();


                    DataTable SBFinfo = GetShipmentFeeDetailsById(new Guid(SBFid));
                    int counter = 0;
                    foreach (DataRow row in SBFinfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string shipmentBasicFeeId = row["shipmentBasicFeeId"].ToString();
                            string shipmentBasicFeeName = row["shipmentFeeName"].ToString();
                            decimal amount = Convert.ToDecimal(row["Amount"].ToString());
                            string EffectivityDate = row["EffectiveDate"].ToString();
                            string desc = row["Description"].ToString();
                            bool isvatable = Convert.ToBoolean(row["IsVatable"].ToString());


                            DateTime dt = Convert.ToDateTime(EffectivityDate);
                            //string temp = dt.ToShortDateString();


                            txtEffectivityDate1.SelectedDate = dt;


                            txtShipmentFee.Text = shipmentBasicFeeName;
                            txtAmount.Text = Convert.ToString(amount);



                            
                            txtDescription.Text = desc;
                            //if (isvatable == 1)
                            //{
                            chkVatable.Checked = isvatable;
                            //}
                            lblSBFid.Text = shipmentBasicFeeId;
                            counter++;
                        }
                    }

                }
            }
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Shipment Basic Fee";
        }

        public DataTable GetShipmentFeeDetailsById(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.ShipmentBasicFee.GetShipmentBasicFeeByID(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }


        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            }
            else if (e.CommandName == "Insert")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //logic to truncate long string to prevent SQL error
            for (int i = 1; i < 4; i++)
            {
                string val = e.NewValues[i - 1].ToString();
                int maxLength = i * 10;
                if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
            }
        }

        protected void DetailsView1_ItemCommand1(object sender, DetailsViewCommandEventArgs e)
        {

        }

        protected void DetailsView1_ItemUpdating1(object sender, DetailsViewUpdateEventArgs e)
        {

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            int chk = 0;
            if (chkVatable.Checked == true)
            {
                chk = 1;
            }

            DateTime DT1 = txtEffectivityDate1.SelectedDate.Value;
            BLL.ShipmentBasicFee.UpdateShipmentBasicFee(new Guid(lblSBFid.Text), ID, Convert.ToDecimal(txtAmount.Text), txtShipmentFee.Text, txtDescription.Text, chk, DT1, getConstr.ConStrCMS);

            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);



        }
    }
}