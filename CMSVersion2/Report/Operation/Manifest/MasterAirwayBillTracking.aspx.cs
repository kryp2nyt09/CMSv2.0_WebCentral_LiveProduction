using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Report.Operation.Manifest
{
    public partial class MasterAirwayBillTracking : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable getMasterAirwayBill()
        {
            DataSet data = BLL.MasterAirwayBill.GetMasterAirwayBill(getConstr.ConStrCMS);
            DataTable dt = new DataTable();
            dt = data.Tables[0];

            return dt;
        }

        public DataTable getMasterAirwayBillbySearch(string mawb)
        {
            DataSet data = BLL.MasterAirwayBill.GetMasterAirwayBillBySearch(mawb, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void radGridMawb_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radGridMawb.DataSource = getMasterAirwayBill();
        }

        protected void radGridMawb_PreRender(object sender, EventArgs e)
        {
            radGridMawb.Rebind();
        }

        protected void btnSearchMawb_Click(object sender, EventArgs e)
        {
            string mawb = txtMawb.Text;
            radGridMawb.DataSource = getMasterAirwayBillbySearch(mawb);
        }
    }
}