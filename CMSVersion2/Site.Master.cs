using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Tools = utilities;
using System.Text;
using CMSVersion2.Models;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.Configuration;

namespace CMSVersion2
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        static List<UserAccessMenu> staticlistDetails = new List<UserAccessMenu>();
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string UserName = Request.QueryString["PortalID"];
            if (UserName != null)
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
                //{
                if (!string.IsNullOrEmpty(Session["FullNameSession"] as string))
                {
                    string fullnamesession = Session["FullNameSession"].ToString();
                    lblUserName.Text = fullnamesession;

                    string[] file = Request.CurrentExecutionFilePath.Split('/');
                    string fileName = file[file.Length - 1];
                    string path = Server.MapPath(fileName);


                    staticlistDetails = AppService.AppServiceMenus;

                    foreach (UserAccessMenu link in staticlistDetails)
                    {
                        HtmlAnchor home = (HtmlAnchor)Page.Master.FindControl(link.menuAccess);
                        string cssToApply = "removeClass";
                        string classAttribute = home.Attributes["class"];
                        if (!string.IsNullOrEmpty(classAttribute))
                        {
                            if (classAttribute.Contains(cssToApply))
                            {
                                home.Attributes.Remove("class");
                            }
                        }
                        //if (string.IsNullOrEmpty(classAttribute))
                        //{
                        //    home.Attributes.Add("class", cssToApply);

                        //}
                        //else
                        //{
                        //    if (classAttribute.Contains(cssToApply))
                        //    {
                        //        home.Attributes.Remove("class");
                        //    }
                        //}
                    }

                }
                //}


            }
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        #region Methods
        public string GetUsername
        {
            get
            {
                return lblUserName.Text;
            }
            set
            {
                string UserName = Request.QueryString["PortalID"];
                if (UserName != null)
                {
                    if (!string.IsNullOrEmpty(Session["FullNameSession"] as string))
                    {
                        string fullnamesession = Session["FullNameSession"].ToString();
                        lblUserName.Text = "Welcome " + fullnamesession;

                    }
                }
                else
                {
                    lblUserName.Text = "Guest";
                }

            }
        }

        #endregion

        #region Modules

        #region Dashboard
        protected void clickDashboard(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //if (Session["UsernameSession"] != null)
            {
                string usersession = Session["UsernameSession"].ToString();
                //string session = (string)(Session["UsernameSession"]);
                //string usersession = GlobalCode.userName;
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Dashboard");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                //anchor.Attributes.Add("onclick", "~/Portal/ManageUsers.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Default.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        #endregion

        #region Maintenance
        //CMS Maintenance
        protected void clickmainMaintenance(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("CMSMaintenance");
                //var anchor = (HtmlAnchor)Master.FindControl("CMSMaintenance");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                // MainMaintenance.Attributes.Add("onclick", "~/Portal/MainMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/CMSMaintenance/CMSMaintenance.aspx");

            }
            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Hello" + "')", true);

        }

        //Flight Information
        protected void clickFlightInformation(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("FlightInformation");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/FlightInformation/FlightInformation.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Rate Matrix
        protected void clickRateMatrix(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("RateMatrix");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/RateMatrix/RateMatrixMain.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Track and Trace
        protected void clickTrackNTrace(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("TrackNTrace");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/TrackNTrace/TrackNTrace.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        protected void clickTruckAreaAssignment(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("TruckAreaAssignment");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Error/UnderMaintenancePage.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Awb Series -  AwbIssuance
        protected void clickAwbIssuance(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("AWBIssuance");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "AWB Series";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/AWBSeries/Issuance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        //Awb Series -  AwbIssued Summary
        protected void clickAwbIssuedSummary(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("AWBIssuedSummary");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "AWB Series";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/AWBSeries/Summary.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Awb Series -  Awb Series Monitoring
        protected void clickAwbSeriesMonitoring(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("SeriesMonitoring");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "AWB Series";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Maintenance/AWBSeries/Monitoring.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        #endregion

        #region Customer
        protected void clickCustomers(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("SeriesMonitoring");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Customer";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Customer/Customer.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        #region Corporate
        protected void clickCompany(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Company");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Corporate/Company.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickRepresentatives(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Representatives");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Corporate/Representative.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickApprovingAuth(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("ApprovingAuthority");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Corporate/ApprovingAuthority.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickStatementOfAccount(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("StatementofAccount");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Corporate/StatementOfAccount.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        #region Report
        #region Operation - Manifest
        protected void clickBookingReport(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/Booking.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
            }
        }

        //Pickup Cargo
        protected void clickPickUpCargo(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("PickupCargo");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/Pickup.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Branch Acceptance
        protected void clickBranchAcceptance(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("BranchAcceptance");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/BranchAcceptance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Bundle
        protected void clickBundle(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Bundle");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/Bundle.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Unbundle
        protected void clickUnbundle(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Unbundle");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/Unbundle.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Segregation
        protected void clickSegregation(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Segregation");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/Segregation.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Daily Trip
        protected void clickDailyTrip(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/DailyTrip.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Gateway Transmittal
        protected void clickGatewayTransmittal(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/GatewayTransmittal.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Gateway Outbound
        protected void clickGatewayOutbound(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/GatewayOutbound.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Gateway Inbound
        protected void clickGatewayInbound(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/GatewayInbound.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }


        //Cargo Transfer
        protected void clickCargoTransfer(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/CargoTransfer.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }


        //Hold Cargo
        protected void clickHoldCargo(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/HoldCargo.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Payment Summary
        protected void clickPaymentSummary(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/PaymentSummaryReport.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //MAWB Tracking
        protected void clickMawbTracking(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/MasterAirwayBillTracking.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //MAWB Tracking
        protected void clickGrandManifest(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("DailyTrip");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/Manifest/GrandManifest.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }



        #endregion

        #region Operation - Cargo Monitoring
        //Pickup Cargo
        protected void clickDelivered(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Delivered");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/Delivered.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Hold
        protected void clickHold(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Hold");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/Hold.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Misrouted
        protected void clickMisrouted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Misrouted");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/Misrouted.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Offloaded
        protected void clickOffloaded(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Offloaded");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/Offloaded.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Pending
        protected void clickPending(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Pending");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/Pending.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //RUD
        protected void clickRUD(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("RUD");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Operation";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Operation/CargoMonitoring/RUD.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        #region Finance - Sales
        //master sales
        protected void clickMasterSales(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/MasterSales.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Sales per BCO
        protected void clickSalesPerBCO(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("SalesPerBCO");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/SalesPerBCO.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Sales per Shipmode
        protected void clickSalesperShipMode(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/SalesPerShipMode.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Sales per CLient
        protected void clickSalesperClient(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/SalesPerClient.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickSalesperRevenueUnit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/SalesPerRevenueUnit.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickSalesperUserLevel(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Sales/SalesPerUserLevel.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        #region Finance - Collection
        protected void clickCollection(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("MasterSales");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Finance";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/Finance/Collections1.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        protected void clickawbDetailedTracking(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("AWBDetailedTracking");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/AWBDetailedTracking.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickawbTracking(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("AWBTracking");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/AWBNoTracking.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }



        //Marketing
        protected void clickMarketing(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Marketing");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Error/UnderMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Courier
        protected void clickCourier(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Courier");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Error/UnderMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //OR Series
        protected void clickORSeries(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("ORSeries");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Error/UnderMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        //Booking
        protected void clickBooking(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Booking");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Error/UnderMaintenance.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }


        #endregion

        #region Administration

        protected void clickManageUsers(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("ManageUsers");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Administration/Users.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickManageEmployee(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("ManageEmployee");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Administration/Employee.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion

        #region UserAccess
        #region Roles
        //protected void clickManageRoles(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
        //    {
        //        string usersession = Session["UsernameSession"].ToString();
        //        byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
        //        HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Roles");
        //        string text = anchor.InnerText;
        //        GlobalCode.menuName = text;
        //        Session["UserNameSession"] = usersession;
        //        Response.Redirect("~/Portal/ManageRoles.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

        //    }

        //}

        #endregion

        #region User Roles
        protected void clickManageUserRole(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("UserRoles");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/UserAccess/UserRole/ManageUserRole.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickManageRole(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Roles");
                string text = anchor.InnerText;
                GlobalCode.menuName = text;
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/UserAccess/Roles/ManageRoles.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }
        #endregion
        #endregion

        #region Logout
        protected void clickLogout(object sender, EventArgs e)
        {

            //Application["Count"] = 0;
            //Application.Clear();
            string UserName = Request.QueryString["PortalID"];
            if (UserName != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();


                // clear authentication cookie
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie1.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie1);

                // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
                SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
                HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
                cookie2.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie2);

                Response.Redirect("~/Login.aspx", true);
            }
            //if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            //{

            // }

        }
        #endregion

        #region Settings
        protected void clickSettings(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("Settings");
                //string text = anchor.InnerText;
                GlobalCode.menuName = "Settings";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Settings/ManagePassword.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));

            }

        }

        protected void clickQtybyCommodity(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("FLM");
                //string text = anchor.InnerText;
                //GlobalCode.menuName = text;
                GlobalCode.menuName = "FLM";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/FLM/FLM_Qtyby_Commodity.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
            }
        }

        protected void clickWtbyCommodity(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
                byte[] EncryptedUsername = Tools.Encryption.EncryptPassword(usersession);
                //HtmlAnchor anchor = (HtmlAnchor)Page.Master.FindControl("FLM");
                //string text = anchor.InnerText;
                //GlobalCode.menuName = text;
                GlobalCode.menuName = "FLM";
                Session["UserNameSession"] = usersession;
                Response.Redirect("~/Report/FLM/FLM_Wtby_Commodity.aspx?PortalID=" + Encoding.Unicode.GetString(EncryptedUsername));
            }
        }
        #endregion



        #endregion
    }

}