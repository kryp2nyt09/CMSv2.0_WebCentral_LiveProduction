using CMSVersion2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Customer.CustomerModal
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] == null)
                {

                }
                else
                {
                    string userId = Request.QueryString["UserId"].ToString();
                    DataTable UserInfo = GetUsers(new Guid(userId));
                    int counter = 0;
                    foreach (DataRow row in UserInfo.Rows)
                    {
                        if (counter == 0)
                        {

                            txtUsername.Text = row["Username"].ToString();
                            string userName = row["Username"].ToString();
                            getuserName(userName);

                            txtEmployeeName.Text = row["LastName"].ToString() + ", " + row["FirstName"].ToString();
                            byte[] binaryString = (byte[])row["PasswordHash"];
                            byte[] old = (byte[])row["OldPassword"];

                            string decrypt = Tools.Encryption.DecryptPassword(binaryString);
                            string decryptold = Tools.Encryption.DecryptPassword(old);
                            txtDbPassword.Attributes.Add("style", "display:none");

                            txtDbPassword.Text = decrypt;

                            counter++;
                        }
                    }


                }
            }
        } //pageLoad

        private void getuserName(string userName)
        {
            GlobalCode.userName = userName;
        }



        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Page.Title = "Edit User Profile";
        }

        public DataTable GetUsers(Guid Userid)
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Users_Info.GetUserInfo(getConstr.ConStrCMS, Userid);
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

        protected void ddlAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            //populateLocation();
        }

        protected void ddlAssigned_TextChanged(object sender, EventArgs e)
        {

            //ddlLocation.Items.Clear();

            //populateLocation();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (!(txtNewPassword.Text == "") && !(txtConfirmPassword.Text == ""))
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    string userId = Request.QueryString["UserId"].ToString();
                    Guid userid = Guid.Parse(userId);

                    Guid ModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");
                    string host = HttpContext.Current.Request.Url.Authority;
                    string UserName = txtUsername.Text;

                    if (UserName.Equals(GlobalCode.userName))
                    {
                        byte[] oldPassword = Tools.Encryption.EncryptPassword(txtOldPassword.Text);
                        byte[] newPassword = Tools.Encryption.EncryptPassword(txtNewPassword.Text);

                        BLL.Users_Info.UpdateUsers(userid, UserName, oldPassword, newPassword, ModifiedBy, getConstr.ConStrCMS);
                        string script = "<script>CloseOnReload()</" + "script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
                    }
                    else
                    {
                        int count = BLL.Users_Info.isUsernameExist(UserName, getConstr.ConStrCMS);
                        if (count > 0)
                        {
                            string alert = "<script>alert('Username already exist.')</" + "script>";
                            ClientScript.RegisterStartupScript(GetType(), "Alert", alert);
                        }
                        else
                        {
                            byte[] oldPassword = Tools.Encryption.EncryptPassword(txtOldPassword.Text);
                            byte[] newPassword = Tools.Encryption.EncryptPassword(txtNewPassword.Text);

                            BLL.Users_Info.UpdateUsers(userid, UserName, oldPassword, newPassword, ModifiedBy, getConstr.ConStrCMS);
                            string close = "<script>CloseOnReload()</" + "script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", close);
                        }
                    }
                }
                else
                {

                }
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }
    }
}