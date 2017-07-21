using CMSVersion2.Models;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.ApplicableRate
{
    public partial class AddApplicableRate : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();

                //if (Request.QueryString["ID"] == null)
                //{

                //}
                //else
                //{
                //    string ApplicableRateId = Request.QueryString["ID"].ToString();


                //    DataTable GroupInfo = GetApplicableRate(new Guid(ApplicableRateId));
                //    int counter = 0;
                //    foreach (DataRow row in GroupInfo.Rows)
                //    {
                //        if (counter == 0)
                //        {
                //            string RateId = row["ApplicableRateId"].ToString();
                //            string ApplicableRateName = row["ApplicableRateName"].ToString();

                //            txtApplicableRateName.Text = ApplicableRateName;
                //            lblGroupID.Text = RateId;
                //            counter++;
                //        }
                //    }

                //}
            }
        }


        private void InitLoad()
        {
            LoadCommodityType();
            ServiceType();
            ServiceMode();
        }

        private void LoadCommodityType()
        {
            DataTable data = BLL.CommodityType.GetCommodityType(getConstr.ConStrCMS).Tables[0];
            rcbCommodityType.DataSource = data;
            rcbCommodityType.DataValueField = "CommodityTypeId";
            rcbCommodityType.DataTextField = "CommodityTypeName";
            rcbCommodityType.DataBind();
            
        }

        private void ServiceType()
        {
            DataTable data = BLL.ServiceType.GetServiceType(getConstr.ConStrCMS).Tables[0];
            rcbServiceType.DataSource = data;
            rcbServiceType.DataValueField = "ServiceTypeId";
            rcbServiceType.DataTextField = "ServiceTypeName";
            rcbServiceType.DataBind();
           
        }

        private void ServiceMode()
        {
            DataTable data = BLL.ServiceMode.GetServiceMode(getConstr.ConStrCMS).Tables[0];
            rcbServiceMode.DataSource = data;
            rcbServiceMode.DataValueField = "ServiceModeId";
            rcbServiceMode.DataTextField = "ServiceModeName";
            rcbServiceMode.DataBind();
           
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Applicable Rate";
        }

        public DataTable GetApplicableRate(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.ApplicableRate.GetApplicableRateID(ID, getConstr.ConStrCMS);
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
            Guid createdBy = new Guid();
            Guid commodiTypeId = new Guid();
            Guid servciceModeId = new Guid();
            Guid serviceTypeId = new Guid();
            string apprateName = "";

            try
            {
                createdBy = GlobalCode.userId;
                commodiTypeId = new Guid(rcbCommodityType.SelectedItem.Value.ToString());
                servciceModeId = new Guid(rcbServiceMode.SelectedItem.Value.ToString());
                serviceTypeId = new Guid(rcbServiceType.SelectedItem.Value.ToString());
                apprateName = txtApplicableRateName.Text;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            
            string host = HttpContext.Current.Request.Url.Authority;
            BLL.ApplicableRate.InsertApplicableRate(createdBy,apprateName,commodiTypeId,servciceModeId,serviceTypeId ,"",1, getConstr.ConStrCMS);

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