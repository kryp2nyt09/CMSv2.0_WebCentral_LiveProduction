using System;
using System.Data;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.Report.Finance
{
    public partial class Collection : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BCO.DataSource = getBCO();
                BCO.DataTextField = "BranchCorpOfficeCode";
                BCO.DataValueField = "BranchCorpOfficeId";
                BCO.DataBind();

                REVENUETYPE.DataSource = getRevenue();
                REVENUETYPE.DataTextField = "RevenueUnitTypeName";
                REVENUETYPE.DataValueField = "RevenueUnitTypeName";
                REVENUETYPE.DataBind();
            }
        }

        public DataTable getBCO()
        {
            DataSet data = BLL.BranchCorpOffice.GetBranchCorpOffice(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getRevenue()
        {
            DataSet data = BLL.Revenue_Info.getRevenueType(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }


        public DataTable getCollection()
        {
            string bcostr = "All";
            string type = "All";
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Now;

            try
            {
                bcostr = BCO.SelectedItem.Text.ToString();
                type = REVENUETYPE.SelectedItem.Text.ToString();
                date1 = Date1.SelectedDate.Value;
                date2 = Date2.SelectedDate.Value;

            }
            catch (Exception)
            {
                date1 = DateTime.Now.AddYears(-1000);
                date2 = DateTime.Now.AddYears(1000);
            }
            DataSet data = BLL.Report.CollectionReport.GetCollection(getConstr.ConStrCMS, bcostr, type, date1, date2);
            DataTable dt = new DataTable();
            dt = data.Tables[0];
            return dt;
        }

        protected void grid_Collection_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grid_Collection.DataSource = getCollection();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            grid_Collection.DataSource = getCollection();
            grid_Collection.Rebind();
        }
    }
}