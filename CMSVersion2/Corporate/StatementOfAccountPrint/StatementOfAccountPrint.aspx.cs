using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate.StatementOfAccountDetails
{
    public partial class StatementOfAccountDetail : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        private DataTable StatementOfAccountDataSource;
        private DataTable ShipmentDataSource = new DataTable();
        private DataTable PaymentDataSource = new DataTable();
        private DataTable AdjustmenttDataSource = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StatementOfAccountId"] != null)
            {
                Guid soaid = Guid.Parse(Request.QueryString["StatementOfAccountId"].ToString());
                GetSOADetails(soaid);
                foreach (DataRow row in StatementOfAccountDataSource.Rows)
                {
                    txtAccountNo.Text = row["AccountNo"].ToString();
                    txtCompany.Text = row["CompanyName"].ToString();
                    txtSoaNo.Text = row["StatementOfAccountNo"].ToString();
                    txtBillingPeriod.Text = row["BillingPeriod"].ToString();
                }
                ShipmentGrid.DataSource = ShipmentDataSource;
                PaymentGrid.DataSource = PaymentDataSource;
                AdjustmentGrid.DataSource = AdjustmenttDataSource;
            }

        }

        private void GetSOADetails(Guid SoaId)
        {
            DataSet SoaDetails = BLL.StatementOfAccount.GetSOADetails(SoaId, getConstr.ConStrCMS);
            StatementOfAccountDataSource = SoaDetails.Tables[0];
            ShipmentDataSource = SoaDetails.Tables[1];
            PaymentDataSource = SoaDetails.Tables[2];
            AdjustmenttDataSource = SoaDetails.Tables[3];
        }

        protected void ShipmentGrid_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }
        protected void ShipmentGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }
        protected void ShipmentGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
        protected void PaymentGrid_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }
        protected void PaymentGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {

        }
    }
}