using CMSVersion2.Models;
using System;
using System.Data;
using System.Web;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.Reason
{
    public partial class EditReason : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["StatusCode"] == null)
                {

                }
                else
                {
                    string statusCode = Request.QueryString["StatusCode"].ToString();
                    StatusCode(statusCode);
                    LoadStatusbyStatusCode(statusCode);
                }

                if (Request.QueryString["ID"] == null)
                {

                }
                else
                {

                    string ReasonId = Request.QueryString["ID"].ToString();
                    DataTable GroupInfo = GetReasonDetails(new Guid(ReasonId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string Id = row["ReasonID"].ToString();
                            string ReasonName = row["ReasonName"].ToString();
                            string StatusID = row["StatusID"].ToString();
                            string StatusName = row["StatusName"].ToString();

                            //Use RadComboBoxItem.Selected
                            RadComboBoxItem item = rcbStatus.FindItemByText(StatusName);
                            item.Selected = true;

                            txtReasonName.Text = ReasonName;
                            lblReasonID.Text = Id;


                            counter++;
                        }
                    }

                }
            }
        }


        private void StatusCode(string statusCode)
        {
            GlobalCode.globalCode = statusCode;
        }

        private void LoadStatusbyStatusCode(string statusCode)
        {
            rcbStatus.DataSource = BLL.Status.GetStatusByStatusCode(getConstr.ConStrCMS, statusCode);
            rcbStatus.DataValueField = "StatusID";
            rcbStatus.DataTextField = "StatusName";
            rcbStatus.DataBind();
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Edit Reason";
        }

        public DataTable GetReasonDetails(Guid ID)
        {
            DataSet data = BLL.Reason.GetReasonByReasonId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid statusId = new Guid(rcbStatus.SelectedItem.Value.ToString());
            Guid reasonId = new Guid(lblReasonID.Text);
            Guid ModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
            string host = HttpContext.Current.Request.Url.Authority;
            string reasonName = txtReasonName.Text;


            BLL.Reason.UpdateReason(reasonId, statusId, reasonName, ModifiedBy, 1, getConstr.ConStrCMS);
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