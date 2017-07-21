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
using Telerik.Web.UI;

namespace CMSVersion2.Maintenance.RateMatrix.RateMatrix
{
    public partial class Edit : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rdcApplicableRate.Enabled = false;

                //ServiceType();
                //ServiceMode();
                //LoadCommodityType();
                LoadApplicableRate();
                if (Request.QueryString["RateMatrixId"] == null)
                {

                }
                else
                {
                    string Id = Request.QueryString["RateMatrixId"].ToString();


                    DataTable rateinfo = GetRateMatrixById(new Guid(Id));
                    int counter = 0;
                    foreach (DataRow row in rateinfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string RateMatrixId = row["RateMatrixId"].ToString();
                            string ApplicabbleRateId = row["ApplicableRateName"].ToString();
                            string CommodityTypeId = row["CommodityTypeName"].ToString();
                            string ServiceTypeId = row["ServiceTypeName"].ToString();
                            string ServiceModeId = row["ServiceModeName"].ToString();

                            string hasFuelCharge = row["HasFuelCharge"].ToString();

                            if (hasFuelCharge == "True")
                            {
                                chkFuelSurcharge.Checked = true;
                            }
                            else
                            {
                                chkFuelSurcharge.Checked = false;

                            }
                            string hasAWBFee = row["HasAwbFee"].ToString();
                            if (hasAWBFee == "True")
                            {
                                chkhasAWBFee.Checked = true;
                            }
                            else
                            {
                                chkhasAWBFee.Checked = false;

                            }

                            string hasApplyEvm = row["ApplyEvm"].ToString();
                            if (hasApplyEvm == "True")
                            {
                                chkApplyEVM.Checked = true;
                            }
                            else
                            {
                                chkApplyEVM.Checked = false;
                            }
                            string ApplyWeight = row["ApplyWeight"].ToString();

                            if (ApplyWeight == "True")
                            {
                                chkApplyWeight.Checked = true;
                            }
                            else
                            {
                                chkApplyWeight.Checked = false;
                            }


                            string IsVatable = row["IsVatable"].ToString();
                            if (IsVatable == "True")

                            {
                                chkIsVatable.Checked = true;

                            }

                            else
                            {

                                chkIsVatable.Checked = false;
                            }

                            string HasDeliveryFee = row["HasDeliveryFee"].ToString();

                            if (HasDeliveryFee == "True")

                            {
                                chkHasDeliveryFee.Checked = true;

                            }

                            else
                            {

                                chkHasDeliveryFee.Checked = false;
                            }
                            string HasPerishableFee = row["HasPerishableFee"].ToString();

                            if (HasPerishableFee == "True")

                            {
                                chkHasPerishableFee.Checked = true;

                            }

                            else
                            {

                                chkHasPerishableFee.Checked = false;
                            }
                            string HasDangerousFee = row["HasDangerousFee"].ToString();

                            if (HasDangerousFee == "True")

                            {
                                chkHasDangerousFee.Checked = true;

                            }

                            else
                            {

                                chkHasDangerousFee.Checked = false;
                            }
                            string HasInsurance = row["HasInsurance"].ToString();

                            if (HasInsurance == "True")

                            {
                                chkhasInsurance.Checked = true;

                            }

                            else
                            {

                                chkhasInsurance.Checked = false;
                            }
                            string HasValuationCharge = row["HasValuationCharge"].ToString();

                            if (HasValuationCharge == "True")

                            {
                                chkHasValuationCharge.Checked = true;

                            }

                            else
                            {

                                chkHasValuationCharge.Checked = false;
                            }

                            if (txtAmount.Text == "")
                            {
                                txtAmount.Text = "0";
                            }
                            lblID.Text = RateMatrixId;
                            txtAmount.Text = row["Amount"].ToString();
                            //Use RadComboBoxItem.Selected
                            RadComboBoxItem item = rdcApplicableRate.FindItemByText(ApplicabbleRateId);
                            item.Selected = true;

                            //RadComboBoxItem item1 = rdcCommodityType.FindItemByText(CommodityTypeId);
                            //item1.Selected = true;


                            //RadComboBoxItem item3 = rdcServicteType.FindItemByText(ServiceTypeId);
                            //item3.Selected = true;

                            //RadComboBoxItem item2 = rdcServiceMode.FindItemByText(ServiceModeId);
                            //item2.Selected = true;
                            //txtIslandGroup.Text = y;
                            //lblGroupID.Text = x;


                            counter++;
                        }
                    }

                }
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
            rdcApplicableRate.DataSource = BLL.ApplicableRate.GetApplicableRate(getConstr.ConStrCMS);
            rdcApplicableRate.DataValueField = "ApplicableRateId";
            rdcApplicableRate.DataTextField = "ApplicableRateName";
            rdcApplicableRate.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Combination";
        }

        public DataTable GetRateMatrixById(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = DAL.RateMatrix.GetRateMatrixById(ID, getConstr.ConStrCMS);
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
            //Guid CommodityType = new Guid(rdcCommodityType.SelectedItem.Value.ToString());
            //Guid ServiceType = new Guid(rdcServicteType.SelectedItem.Value.ToString());
            //Guid ServiceModel = new Guid(rdcServiceMode.SelectedItem.Value.ToString());

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


            DAL.RateMatrix.UpdateCombinationRateMatrix(new Guid(lblID.Text), ApplicabbleRateId, hasfuelcharge,
                HasAWBFee, hasinsurance, CreatedBy, applyevm, applyweight, isvatable, hasdeliveryFee, hasperishable, hasdangerousfee, valuationcharge,
                amountno,
                getConstr.ConStrCMS);

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