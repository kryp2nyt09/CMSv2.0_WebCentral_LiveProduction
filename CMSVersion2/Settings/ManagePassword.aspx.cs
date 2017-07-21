using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools = utilities;
using BLL = BusinessLogic;
using CMSVersion2.Models;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

namespace CMSVersion2.Settings
{
    public partial class ManagePassword : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        static List<UserAccessMenu> staticlistDetails = new List<UserAccessMenu>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PortalID"] == null)
                {

                }
                else
                {
                    Guid userId = new Guid();
                    string encryptUserName = Request.QueryString["PortalID"].ToString();
                    // if (!string.IsNullOrEmpty(Session["UserIdSession"] as string))
                    if (Session["UserIdSession"] != null)
                    {
                        string useridsession = Session["UserIdSession"].ToString();
                        userId = Guid.Parse(useridsession);
                        Guid id = GlobalCode.userId;
                        DataTable UserInfo = GetUsers(userId);
                        int counter = 0;
                        foreach (DataRow row in UserInfo.Rows)
                        {
                            if (counter == 0)
                            {

                                byte[] binaryString = (byte[])row["PasswordHash"];
                                byte[] old = (byte[])row["OldPassword"];

                                string decrypt = Tools.Encryption.DecryptPassword(binaryString);
                                string decryptold = Tools.Encryption.DecryptPassword(old);
                                txtDbPassword.Attributes.Add("style", "display:none");

                                txtDbPassword.Text = decrypt;

                                counter++;
                            }
                        }

                        staticlistDetails = AppService.AppServiceMenus;

                        foreach (UserAccessMenu link in staticlistDetails)
                        {
                            HtmlAnchor home = (HtmlAnchor)Page.Master.FindControl(link.menuAccess);
                            string cssToApply = "removeClass";
                            string classAttribute = home.Attributes["class"];
                            if (string.IsNullOrEmpty(classAttribute))
                            {
                                home.Attributes.Add("class", cssToApply);

                            }
                            else
                            {
                                if (classAttribute.Contains(cssToApply))
                                {
                                    home.Attributes.Remove("class");
                                }
                            }
                        }

                    }

                    //byte[] toBytes = Encoding.ASCII.GetBytes(encryptUserName);
                    // string decryptBytes = Tools.Encryption.DecryptPassword(toBytes);

                }
            }
        }

        public DataTable GetUsers(Guid Userid)
        {
            DataSet data = BLL.Users_Info.GetUserInfo(getConstr.ConStrCMS, Userid);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!(txtNewPassword.Text == "") && !(txtConfirmPassword.Text == ""))
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(GlobalCode.userName);
                    Guid ModifiedBy = GlobalCode.userId;
                    string host = HttpContext.Current.Request.Url.Authority;

                    byte[] oldPassword = Tools.Encryption.EncryptPassword(txtOldPassword.Text);
                    byte[] newPassword = Tools.Encryption.EncryptPassword(txtNewPassword.Text);

                    BLL.Users_Info.UpdateUsers(GlobalCode.userId, GlobalCode.userName, oldPassword, newPassword, ModifiedBy, getConstr.ConStrCMS);
                    //string script = "<script>CloseOnReload()</" + "script>";
                    // ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
                    Response.Redirect("~/Default.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                }

            }
        }
    }
}