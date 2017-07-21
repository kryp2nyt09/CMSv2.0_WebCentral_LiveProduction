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
using System.Text;
using System.Web.Security;
using System.Collections;
using System.Security;

namespace CMSVersion2
{
    public partial class Login : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region Global
        List<string> listofMenu = new List<string>();
        List<string> listofMenuAccess = new List<string>();
        List<UserAccessMenu> listDetails = new List<UserAccessMenu>();
        List<string> result = new List<string>();
        string apptitle = "Web";
        #endregion


        #region Events
        protected void btnSubmit_Click(object sender, AuthenticateEventArgs e)
        {

            #region Check if User can login to Web

            // Initialize FormsAuthentication, for what it's worth
            FormsAuthentication.Initialize();
            bool canLogin = false;
            bool firstLogin = false;
            string fullname = "";


            string firstAccess = "";
            Guid userId = new Guid();

            DataTable Data = BLL.Users_Info.VerifyUser(Login1.UserName, Login1.Password, getConstr.ConStrCMS).Tables[0];
            int counter = 0;

            List<string> listofRoles = new List<string>();

            foreach (DataRow row in Data.Rows)
            {
                if (counter == 0)
                {
                    try
                    {

                        string CanLogintoWeb = row["CanLogintoWeb"].ToString();
                        string CheckLogin = row["CheckLogin"].ToString();
                        string roleName = row["RoleName"].ToString();
                        userId = Guid.Parse(row["UserId"].ToString());
                        GlobalCode.userId = userId;
                        GlobalCode.userName = Login1.UserName;
                        fullname = row["FullName"].ToString();
                        listofRoles.Add(roleName);
                        if (CanLogintoWeb == "True" || (CanLogintoWeb == "1"))
                        {
                            canLogin = true;
                        }

                        if (CheckLogin == "True" || (CheckLogin == "1"))
                        {
                            firstLogin = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            #endregion

            if (Data.Rows.Count > 0 && canLogin == true)
            {
                e.Authenticated = true;
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);


                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(Login1.UserName);
                foreach (string item in listofRoles)
                {
                    string roleName = "Administrator";
                    if (item.Contains(roleName))
                    {
                        #region
                        DataList();
                        FormCookies(roleName);
                        foreach (string access in listofMenuAccess)
                        {
                            //if (listofMenuAccess.IndexOf(access) == 0)
                            //if (access.Equals("Dashboard"))
                            // {
                            //     firstAccess = access;
                            // }
                            if (listofMenuAccess.Contains("Dashboard"))
                            {
                                firstAccess = "Dashboard";
                                break;
                            }
                            else
                            {
                                firstAccess = access;
                                break;
                            }
                        }

                        #endregion

                        Session["FullNameSession"] = fullname;
                        Session["UserNameSession"] = Login1.UserName;
                        Session["UserIdSession"] = userId;

                        Application["Username"] = Login1.UserName;
                        ReportGlobalModel.User = fullname;

                        if (firstLogin == true)
                        {
                            BLL.UserRole.UpdateLoginDateandCheckLogin(Login1.UserName, getConstr.ConStrCMS);
                            Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                        }
                        else
                        {

                            BLL.UserRole.UpdateLoginDate(Login1.UserName, getConstr.ConStrCMS);
                            string result = BLL.UserRole.MenuFirstAccess(firstAccess, getConstr.ConStrCMS);
                            if (result.Equals("NONE"))
                            {
                                Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                            }
                            else
                            {
                                string port = result + "?PortalID=";
                                Response.Redirect(port + Encoding.UTF8.GetString(EncryptedUsername));
                            }
                            //Response.Redirect("~/Default.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

                        }
                    }
                    else
                    {
                        #region
                        DataList();
                        FormCookies(item);

                        //foreach (string access in listofMenuAccess)
                        //{
                        //    if (listofMenuAccess.IndexOf(access) == 0)
                        //    {
                        //        firstAccess = access;
                        //    }
                        //}
                        foreach (string access in listofMenuAccess)
                        {
                            //if (listofMenuAccess.IndexOf(access) == 0)
                            //if (access.Equals("Dashboard"))
                            // {
                            //     firstAccess = access;
                            // }
                            if (listofMenuAccess.Contains("Dashboard"))
                            {
                                firstAccess = "Dashboard";
                                break;
                            }
                            else
                            {
                                firstAccess = access;
                                break;
                            }
                        }

                        #endregion

                        Session["FullNameSession"] = fullname;
                        Session["UserNameSession"] = Login1.UserName;
                        Session["UserIdSession"] = userId;
                        Application["Username"] = Login1.UserName;

                        ReportGlobalModel.User = fullname;

                        BLL.UserRole.UpdateLoginDate(Login1.UserName, getConstr.ConStrCMS);
                        foreach (string itemAccess in listofMenuAccess)
                        {
                            if (listofMenuAccess.Contains("Dashboard"))
                            {
                                if (firstLogin == true)
                                {
                                    BLL.UserRole.UpdateLoginDateandCheckLogin(Login1.UserName, getConstr.ConStrCMS);
                                    Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                                }
                                else
                                {

                                    BLL.UserRole.UpdateLoginDate(Login1.UserName, getConstr.ConStrCMS);
                                    Response.Redirect("~/Default.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

                                }
                                // Response.Redirect("~/Maintenance/CMSMaintenance/CMSMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

                            }
                            else
                            {
                                //Response.Redirect("~/Default.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                                //Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                                string result = BLL.UserRole.MenuFirstAccess(firstAccess, getConstr.ConStrCMS);
                                if (result.Equals("NONE"))
                                {
                                    Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                                }
                                else
                                {
                                    string port = result + "?PortalID=";
                                    Response.Redirect(port + Encoding.Unicode.GetString(EncryptedUsername));
                                }

                            }
                        }
                    }


                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You don't have permission to login.!')", true);
            }
        }
        #endregion

        #region Methods
        public List<string> getAllMenu(string apptitle)
        {
            List<string> listofAllMenu = new List<string>();
            DataTable dtMenu = BLL.UserRole.GetMenuByAppTitle(apptitle, getConstr.ConStrCMS).Tables[0];
            foreach (DataRow row in dtMenu.Rows)
            {
                string menuName = row["MenuName"].ToString();
                listofAllMenu.Add(menuName);
            }


            return listofAllMenu;
        }

        public List<string> getAccessMenuByUserName(string username)
        {
            List<string> listofAccessMenu = new List<string>();
            DataTable dtMenuAccess = BLL.UserRole.GetMenuAccessByUsername(username, GlobalCode.userId, getConstr.ConStrCMS).Tables[0];
            foreach (DataRow row in dtMenuAccess.Rows)
            {
                string menuAccessName = row["MenuName"].ToString();
                listofAccessMenu.Add(menuAccessName);
            }


            return listofAccessMenu;
        }

        public void DataList()
        {
            listofMenu = getAllMenu(apptitle);
            listofMenuAccess = getAccessMenuByUserName(Login1.UserName);

            result = listofMenu.Intersect(listofMenuAccess).ToList();

            foreach (string row in result)
            {
                UserAccessMenu useraccessModel = new UserAccessMenu();
                useraccessModel.menuAccess = row;
                listDetails.Add(useraccessModel);
                //useraccessModel.listuserAccess = listDetails;

            }

            AppService.AppServiceMenus = listDetails;
        }

        public void FormCookies(string item)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, // Ticket version
                        Login1.UserName, // Username associated with ticket
                        DateTime.Now, // Date/time issued
                        DateTime.Now.AddMinutes(30), // Date/time to expire
                        true, // "true" for a persistent user cookie
                        item, // User-data, in this case the roles
                        FormsAuthentication.FormsCookiePath);// Path cookie valid for

            // Encrypt the cookie using the machine key for secure transport
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(
               FormsAuthentication.FormsCookieName, // Name of auth cookie
               hash); // Hashed ticket

            // Set the cookie's expiration time to the tickets expiration time
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            // Add the cookie to the list for outgoing response
            Response.Cookies.Add(cookie);
        }
        #endregion
    }
}