using System;
using System.Data;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.RevenueTypeMaintenance
{
    public partial class EditRUT : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //LoadCluster();
                if (Request.QueryString["ID"] == null)
                {

                }
                else
                {

                    string RUTID = Request.QueryString["ID"].ToString();
                    DataTable GroupInfo = GetRUTbyID(new Guid(RUTID));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {


                            string RevenueUnitTypeId = row["RevenueUnitTypeId"].ToString();
                            string RevenueUnitTypeName = row["RevenueUnitTypeName"].ToString();
                            string Description = row["Description"].ToString();



                            lblGroupID.Text = RevenueUnitTypeId;
                            txtDescription.Text = Description;
                            txtRUT.Text = RevenueUnitTypeName;



                            counter++;
                        }
                    }

                }
            }
        }


        private void LoadCluster()
        {
            //rcbGroup.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            //rcbGroup.DataValueField = "BranchCorpOfficeId";
            //rcbGroup.DataTextField = "BranchCorpOfficeName";
            //rcbGroup.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Revenue Unit Type";
        }

        public DataTable GetRUTbyID(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Revenue_Info.getRevenueTypeById(ID, getConstr.ConStrCMS);
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
            BLL.Revenue_Info.UpdateRevenueType(txtRUT.Text, txtDescription.Text, new Guid(lblGroupID.Text), new Guid("11111111-1111-1111-1111-111111111111"), getConstr.ConStrCMS);
            //BLL.Cluster.UpdateCluster(ClusterID, BranchCorpOfficeId, ModifiedBy,txtRegionName.Text,  getConstr.ConStrCMS);
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