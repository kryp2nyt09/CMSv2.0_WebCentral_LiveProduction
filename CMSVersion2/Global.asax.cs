using CMSVersion2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2
{
    public class Global : HttpApplication
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        void Application_Start(object sender, EventArgs e)
        {
            Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["Username"] = "";
            Application["Count"] = 0;

        }

        void Session_Start(Object sender, EventArgs e)
        {
            if (Session.IsNewSession && Session["UsernameSession"] == null)
            //if (Session.IsNewSession)
            {
                Response.Redirect("~/Login.aspx");
            }
            //else
            //{
            //    Session["FullNameSession"] = true;
            //    Session["UserNameSession"] = true;
            //    Session["UserIdSession"] = true;

            //    Application["Username"] = true;
            //}

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //   EndSession();
        //}

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {
            //EndSession();
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            bool executed = false;
            if (this.Context.Handler is System.Web.UI.Page)
            {
                if (!executed)
                {
                    string username = Application["Username"].ToString();
                    int count = (int)Application["Count"];
                    if (username != "")
                    //if (authCookie != null)
                    {
                        if (HttpContext.Current.User != null &&
                          HttpContext.Current.User.Identity != null &&
                          HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            string currentUrl = "";
                            string name = GlobalCode.menuName;
                            if (name != "" && name != null)
                            {
                                if (name.Equals("Settings")) { }
                                else
                                {
                                    currentUrl = "";
                                    int result = BLL.UserRole.CheckifUserHasAccess(name, currentUrl, GlobalCode.userName, getConstr.ConStrCMS);
                                    if (result == 0)
                                    {
                                        if (!string.IsNullOrEmpty(Request.QueryString["PortalID"]))
                                        {
                                            //HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
                                            //HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
                                            //HttpContext.Current.Response.AddHeader("Expires", "0");
                                            RedirectToLogin();
                                        }
                                    }
                                }

                            }
                            else
                            {
                                name = String.Empty;
                                currentUrl = Request.Url.AbsolutePath;
                                if (currentUrl.EndsWith(".aspx"))
                                {
                                    currentUrl = "~" + currentUrl;
                                }
                                else
                                {
                                    currentUrl = "~" + currentUrl + ".aspx";
                                }

                                int checkResultUrl = BLL.UserRole.CheckIfURLExists(currentUrl, getConstr.ConStrCMS);
                                if (checkResultUrl > 0)
                                {
                                    int result = BLL.UserRole.CheckifUserHasAccess(name, currentUrl, GlobalCode.userName, getConstr.ConStrCMS);
                                    if (result == 0)
                                    {
                                        if (!string.IsNullOrEmpty(Request.QueryString["PortalID"]))
                                        {
                                            RedirectToLogin();
                                        }
                                    }
                                }
                                else
                                {
                                    string[] file = Request.CurrentExecutionFilePath.Split('/');
                                    int fileCount = file.Count();
                                    string fileName;
                                    if (fileCount == 4)
                                    {
                                        fileName = file[file.Length - 2];
                                        int result = BLL.UserRole.CheckifUserHasAccess(fileName, "", GlobalCode.userName, getConstr.ConStrCMS);
                                        if (result == 0)
                                        {
                                            if (!string.IsNullOrEmpty(Request.QueryString["PortalID"]))
                                            {
                                                RedirectToLogin();
                                            }
                                        }

                                    }
                                    if (fileCount == 5)
                                    {
                                        fileName = file[file.Length - 3];
                                        int result = BLL.UserRole.CheckifUserHasAccess(fileName, "", GlobalCode.userName, getConstr.ConStrCMS);
                                        if (result == 0)
                                        {
                                            if (!string.IsNullOrEmpty(Request.QueryString["PortalID"]))
                                            {
                                                RedirectToLogin();
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        //if not authenticated
                        else
                        {
                            if (count == 0)
                            {
                                if (!string.IsNullOrEmpty(Request.QueryString["PortalID"]))
                                {
                                    RedirectToLogin();
                                }

                            }
                        }

                        GlobalCode.menuName = String.Empty;
                    }

                    executed = true;
                }

            }
        }

        protected void Application_End(Object sender, EventArgs e)
        {
            // clear the Application state
            //Application.Clear();
        }

        protected void RedirectToLogin()
        {
            HttpContext.Current.Response.Redirect("~/Login.aspx");
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
    }
}