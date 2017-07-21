using CMSVersion2.Models;
using System;
using System.Web;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.Remarks
{
    public partial class AddRemarks : System.Web.UI.Page
	{
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["remarkCode"] == null)
                {

                }
                else
                {
                    string remarkCode = Request.QueryString["remarkCode"].ToString();
                    RemarkCode(remarkCode);
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.Title = "Add Remarks";
        }

        private void RemarkCode(string remarkCode)
        {
            GlobalCode.globalCode = remarkCode;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            Guid ID = new Guid("11111111-1111-1111-1111-111111111111");
            string remarkCode = GlobalCode.globalCode;
            BLL.Remarks.InsertRemarkName(txtRemarkName.Text, remarkCode, ID, getConstr.ConStrCMS);

            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            //RadScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshParentPage", script, false);
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }
    }
}