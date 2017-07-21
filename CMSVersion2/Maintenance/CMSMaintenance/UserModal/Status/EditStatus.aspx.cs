using System;
using System.Data;
using System.Web;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.Status
{
	public partial class EditStatus : System.Web.UI.Page
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
                    string statusId = Request.QueryString["ID"].ToString();


                    DataTable GroupInfo = GetStatusById(new Guid(statusId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string x = row["StatusID"].ToString();
                            string y = row["StatusName"].ToString();

                            txtStatusName.Text = y;
                            lblStatusID.Text = x;
                            counter++;
                        }
                    }

                }
            }
        }


        public DataTable GetStatusById(Guid ID)
        {
            DataSet data = BLL.Status.GetStatusByStatusID(getConstr.ConStrCMS, ID);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            BLL.Status.UpdateStatusName(new Guid(lblStatusID.Text), txtStatusName.Text, getConstr.ConStrCMS);

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