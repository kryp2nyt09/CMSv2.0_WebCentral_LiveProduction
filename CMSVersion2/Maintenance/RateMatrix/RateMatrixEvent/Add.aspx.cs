using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;
using System.Data;

namespace CMSVersion2.Maintenance.RateMatrix.RateMatrix
{
    public partial class Add : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //ServiceType();
               // ServiceMode();
                //LoadCommodityType();
                LoadApplicableRate();

                txtAmount.Text = "0";

            }
        }

        //private void ServiceType()
        //{
        //    rdcServicteType.DataSource = BLL.ServiceType.GetServiceType(getConstr.ConStrCMS);
        //    rdcServicteType.DataValueField = "ServiceTypeId";
        //    rdcServicteType.DataTextField = "ServiceTypeName";
        //    rdcServicteType.DataBind();
        //}

        //private void ServiceMode()
        //{
        //    rdcServiceMode.DataSource = BLL.ServiceMode.GetServiceMode(getConstr.ConStrCMS);
        //    rdcServiceMode.DataValueField = "ServiceModeId";
        //    rdcServiceMode.DataTextField = "ServiceModeName";
        //    rdcServiceMode.DataBind();
        //}



        //private void LoadCommodityType()
        //{
        //    rdcCommodityType.DataSource = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS);
        //    rdcCommodityType.DataValueField = "CommodityTypeId";
        //    rdcCommodityType.DataTextField = "CommodityTypeName";
        //    rdcCommodityType.DataBind();
        //}

        private void LoadApplicableRate()
        {
            rdcApplicableRate.DataSource = BLL.ApplicableRate.GetFreeApplicableRate(getConstr.ConStrCMS);
            rdcApplicableRate.DataValueField = "ApplicableRateId";
            rdcApplicableRate.DataTextField = "ApplicableRateName";
            rdcApplicableRate.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Combination";
        }

        public DataTable GetGroupIsland(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.IslandGroup.GetIslandGroupById(getConstr.ConStrCMS, ID);
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

            Guid CreatedBy = new Guid("11111111-1111-1111-1111-111111111111");
            Guid ApplicabbleRateId = new Guid(rdcApplicableRate.SelectedItem.Value.ToString());
           // Guid CommodityType = new Guid(rdcCommodityType.SelectedItem.Value.ToString());
           // Guid ServiceType = new Guid(rdcServicteType.SelectedItem.Value.ToString());
           // Guid ServiceModel = new Guid(rdcServiceMode.SelectedItem.Value.ToString());

            Boolean hasfuelcharge = false;
            Boolean hasinsurance = false;
            Boolean HasAWBFee = false;

            if (chkFuelSurcharge.Checked == true)
            {
                hasfuelcharge = true;
            }

            if (chkhasInsurance.Checked == true)
            {
                hasinsurance = true;
            }

            if (chkhasAWBFee.Checked == true)
            {
                HasAWBFee = true;
            }

            if (chkhasAWBFee.Checked == true)
            {
                HasAWBFee = true;
            }
            Boolean applyevm = false;
            Boolean applyweight = false;


            if (chkApplyEVM.Checked == true)
            {
                applyevm = true;
            }

            if (chkApplyWeight.Checked == true)
            {
                applyweight = true;
            }

            Boolean isvatable = false;

            if (chkIsVatable.Checked == true)
            {
                isvatable = true;

            }

            Boolean hasdeliveryFee = false;

            if (chkHasDeliveryFee.Checked == true)
            {
                hasdeliveryFee = true;
            }

            Boolean hasperishable = false;
            if (chkHasPerishableFee.Checked == true)
            {
                hasperishable = true;
            }
            Boolean hasdangerousfee = false;

            if (chkHasDangerousFee.Checked == true)

            {

                hasdangerousfee = true;

            }
            Boolean valuationcharge = false;

            if (chkHasValuationCharge.Checked == true)
            {
                valuationcharge = true;

            }
            decimal amountno = 0;
            if (txtAmount.Text != "")
            {
                amountno = Convert.ToDecimal(txtAmount.Text);
            }
            DAL.RateMatrix.AddCombinationRateMatrix(ApplicabbleRateId, hasfuelcharge,
                HasAWBFee, hasinsurance, CreatedBy, applyevm, applyweight, isvatable, hasdeliveryFee, hasperishable, hasdangerousfee,
                valuationcharge, amountno, getConstr.ConStrCMS);

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

        //protected void CloseButton_Click1(object sender, EventArgs e)
        //{

        //    Page.ClientScript.RegisterClientScriptBlock(GetType(),
        //        "CloseScript", "Close()", true);

        //}
    }
}