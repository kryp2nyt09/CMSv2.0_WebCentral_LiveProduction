using System;
using System.Data;
using System.Web;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Maintenance.CMSMaintenance.UserModal.Remarks
{
    public partial class EditRemarks : System.Web.UI.Page
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
                    string remarkId = Request.QueryString["ID"].ToString();


                    DataTable GroupInfo = GetRemarks(new Guid(remarkId));
                    int counter = 0;
                    foreach (DataRow row in GroupInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string x = row["RemarkID"].ToString();
                            string y = row["RemarkName"].ToString();

                            txtRemarkName.Text = y;
                            lblRemarkID.Text = x;
                            counter++;
                        }
                    }

                }
            }
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Title = "Edit Remarks";
        }

        public DataTable GetRemarks(Guid ID)
        {
            DataSet data = BLL.Remarks.GetRemarkByRemarkID(getConstr.ConStrCMS, ID);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }


        //protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Update")
        //    {
        //        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        //    }
        //    else if (e.CommandName == "Insert")
        //    {
        //        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        //    }
        //    else
        //    {
        //        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
        //    }
        //}

        //protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        //{
        //    //logic to truncate long string to prevent SQL error
        //    for (int i = 1; i < 4; i++)
        //    {
        //        string val = e.NewValues[i - 1].ToString();
        //        int maxLength = i * 10;
        //        if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            BLL.Remarks.UpdateRemarkName(new Guid(lblRemarkID.Text), txtRemarkName.Text, getConstr.ConStrCMS);

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