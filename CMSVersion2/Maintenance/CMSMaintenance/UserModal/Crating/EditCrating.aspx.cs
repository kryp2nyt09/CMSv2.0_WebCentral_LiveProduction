using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.Crating
{
    public partial class EditCrating : System.Web.UI.Page
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
                    string CratingId = Request.QueryString["ID"].ToString();


                    DataTable GroupInfo = GetCratingInfo(new Guid(CratingId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string CratingName = row["CratingName"].ToString();
                            string Multiplier = row["Multiplier"].ToString();
                            string BaseMinimum = row["BaseMinimum"].ToString();
                            string BaseMaximum = row["BaseMaximum"].ToString();
                            string ExcessCost = row["ExcessCost"].ToString();
                            string Id = row["CratingId"].ToString();
                            string mincost = row["BaseFee"].ToString();

                            txtMinimumCost.Text = mincost;
                            txtCratingName.Text = CratingName;
                            txtFactor.Text = Multiplier;
                            txtMin.Text = BaseMinimum;
                            txtMax.Text = BaseMaximum;
                            txtExcessCost.Text = ExcessCost;
                            lblSBFid.Text = Id;

                            counter++;
                        }
                    }

                }
            }
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Crating";
        }

        public DataTable GetCratingInfo(Guid ID)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Crating.GetCratingByID(ID, getConstr.ConStrCMS);
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
            BLL.Crating.UpdateCrating(new Guid(lblSBFid.Text), txtCratingName.Text, Convert.ToDecimal(txtFactor.Text), Convert.ToInt32(txtMin.Text), Convert.ToInt32(txtMax.Text), Convert.ToDecimal(txtMinimumCost.Text), Convert.ToDecimal(txtExcessCost.Text), ID, getConstr.ConStrCMS);
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