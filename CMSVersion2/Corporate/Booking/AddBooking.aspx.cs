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

namespace CMSVersion2.Corporate.Booking
{
    public partial class AddBooking : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        BookingInformation compInfo = new BookingInformation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CompanyId"] == null)
                {

                }
                else
                {
                    string companyId = Request.QueryString["CompanyId"].ToString();
                    lblCompanyID.Value = companyId;
                }

                InitLoad();
            }
        }

       

        #region Methods
        private void InitLoad()
        {
            LoadBranchCorpOffice();
            LoadCity();
            LoadAssignedTo();
            LoadBookingStatus();
            LoadBookingRemarks();
            LoadBookingSched();
            LoadCompany();
            LoadShipper();
        }
        private void LoadShipper()
        {
            Guid companyid = new Guid();
            if(lblCompanyID.Value != null)
            {
                companyid = Guid.Parse(lblCompanyID.Value);
            }

            rcbShipperName.DataSource = BLL.Clients.GetClientsbyCompanyId(companyid, getConstr.ConStrCMS);
            rcbShipperName.DataValueField = "ClientId";
            rcbShipperName.DataTextField = "Name";
            rcbShipperName.DataBind();
        }



        private void LoadBranchCorpOffice()
        {
            rcbBco.DataSource = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            rcbBco.DataValueField = "BranchCorpOfficeId";
            rcbBco.DataTextField = "BranchCorpOfficeName";
            rcbBco.DataBind();
        }

        private void LoadCity()
        {
            rcbCity.DataSource = BLL.City.GetCity(getConstr.ConStrCMS);
            rcbCity.DataValueField = "CityId";
            rcbCity.DataTextField = "CityName";
            rcbCity.DataBind();
        }

        private void LoadAssignedTo()
        {
            rcbAssignedTo.DataSource = BLL.Revenue_Info.getAllRevenueUnit(getConstr.ConStrCMS);
            rcbAssignedTo.DataValueField = "RevenueUnitId";
            rcbAssignedTo.DataTextField = "RevenueUnitName";
            rcbAssignedTo.DataBind();
        }

        private void LoadBookingStatus()
        {
            rcbStatus.DataSource = BLL.BookingStatus.GetBookingStatus(getConstr.ConStrCMS);
            rcbStatus.DataValueField = "BookingStatusId";
            rcbStatus.DataTextField = "BookingStatusName";
            rcbStatus.DataBind();
        }

        private void LoadBookingRemarks()
        {
            rcbRemarks.DataSource = BLL.BookingRemark.GetBookingRemark(getConstr.ConStrCMS);
            rcbRemarks.DataValueField = "BookingRemarkId";
            rcbRemarks.DataTextField = "BookingRemarkName";
            rcbRemarks.DataBind();
        }

        private void LoadCompany()
        {
            rcbCompanyName.DataSource = BLL.Company.GetCompanies(getConstr.ConStrCMS);
            rcbCompanyName.DataValueField = "CompanyId";
            rcbCompanyName.DataTextField = "CompanyName";
            rcbCompanyName.DataBind();
        }
        private void LoadBookingSched()
        {
            rcbSchedule.DataSource = BLL.BookingType.GetBookingType(getConstr.ConStrCMS);
            rcbSchedule.DataValueField = "BookingTypeId";
            rcbSchedule.DataTextField = "BookingTypeName";
            rcbSchedule.DataBind();

            string sched = rcbSchedule.SelectedItem.Text;
            if (sched.Equals("Default"))
            {
                //Pre sched
                lblDateBooked.Visible = false;
                rdDateBooked.Visible = false;

                //Daily Booking
                lblStartDate.Visible = false;
                rdStartDate.Visible = false;

                lblEndDate.Visible = false;
                rdEndDate.Visible = false;

                //By Dates
                lblByDates.Visible = false;
                radcalDates.Visible = false;
            }
        }

        
        private void populateCityByBCOId()
        {
            if(rcbBco.SelectedIndex >= 0)
            {
                DataTable citylist = BLL.City.GetCityByBCOId(new Guid(rcbBco.SelectedValue.ToString()), getConstr.ConStrCMS).Tables[0];
                rcbCity.DataSource = citylist;
                rcbCity.DataValueField = "CityId";
                rcbCity.DataTextField = "CityName";
                rcbCity.DataBind();
            }
            
        }

        private void populateDates()
        {
            string sched = rcbSchedule.SelectedItem.Text;
            if (sched.Equals("Default"))
            {
                //Pre sched
                lblDateBooked.Visible = false;
                rdDateBooked.Visible = false;
                
                //Daily Booking
                lblStartDate.Visible = false;
                rdStartDate.Visible = false;

                lblEndDate.Visible = false;
                rdEndDate.Visible = false;

                //By Dates
                lblByDates.Visible = false;
                radcalDates.Visible = false;
            }else if(sched.Equals("Prescheduled"))
            {
                //Pre sched
                lblDateBooked.Visible = true;
                rdDateBooked.Visible = true;

                //Daily Booking
                lblStartDate.Visible = false;
                rdStartDate.Visible = false;
                
                lblEndDate.Visible = false;
                rdEndDate.Visible = false;

                //By Dates
                lblByDates.Visible = false;
                radcalDates.Visible = false;
            }else if (sched.Equals("Daily"))
            {
                //Pre sched
                lblDateBooked.Visible = false;
                rdDateBooked.Visible = false;
                lblDateBooked.Attributes.Add("class", "disabledtext");
                rdDateBooked.Attributes.Add("class", "disabledtext");

                //Daily Booking
                lblStartDate.Visible = true;
                rdStartDate.Visible = true;

                lblEndDate.Visible = true;
                rdEndDate.Visible = true;

                //By Dates
                lblByDates.Visible = false;
                radcalDates.Visible = false;
            }else if(sched.Equals("By Dates"))
            {
                //Pre sched
                lblDateBooked.Visible = false;
                rdDateBooked.Visible = false;

                //Daily Booking
                lblStartDate.Visible = false;
                rdStartDate.Visible = false;

                lblEndDate.Visible = false;
                rdEndDate.Visible = false;

                //By Dates
                lblByDates.Visible = true;
                radcalDates.Visible = true;
            }
        }

        private void ShipperInfo()
        {
            Guid shipperid;
            try
            {
                if(rcbShipperName.SelectedIndex >=0)
                {
                    shipperid = Guid.Parse(rcbShipperName.SelectedValue.ToString());
                    DataTable ShipperInfo = GetShipperInformation(shipperid);
                    int counter = 0;
                    foreach (DataRow row in ShipperInfo.Rows)
                    {
                        if (counter == 0)
                        {
                            string FirstName = row["FirstName"].ToString();
                            string LastName = row["LastName"].ToString();
                            counter++;
                        }
                    }

                }
                
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
        }

        public DataTable GetShipperInformation(Guid shipperid)
        {
            DataSet data = BLL.Clients.GetClientbyClientId(shipperid, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }


        #endregion

        protected void rcbBco_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateCityByBCOId();
        }

        protected void rcbSchedule_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            populateDates();
        }
    }
}