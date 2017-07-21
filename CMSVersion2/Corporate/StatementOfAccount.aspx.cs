using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.Corporate
{
    public partial class StatementOfAccount : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable GetPayment()
        {
            return new DataTable();
        }

        public DataTable GetShipmentByStatementOfAccountId()
        {

            return new DataTable();
        }

        public DataTable GetPreviousBill()
        {

            return new DataTable();
        }

        public DataTable GetStatementOfAccounts()
        {
            DataSet data = BLL.StatementOfAccount.GetAll(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        public DataTable GetStatementOfAccountsByID()
        {
            DataSet data = BLL.StatementOfAccount.GetAll(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        #region Events

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    HyperLink adjustLink = (HyperLink)e.Item.FindControl("PrintLink");
            //    if (adjustLink != null)
            //    {
            //        adjustLink.Attributes["href"] = "javascript:void(0);";
            //        adjustLink.Attributes["onclick"] = String.Format("return PrintPDF('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);

            //    }
            //}

        }
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.MasterTableView.CurrentPageIndex = RadGrid2.MasterTableView.PageCount - 1;
                RadGrid2.Rebind();
            }
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
        }
        protected void radSearchUser_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string SOAnumber = string.Empty;

            if (e.DataItem != null)
            {
                SOAnumber = e.Text;




                //RadGrid2.DataSource = DataSource.AsEnumerable().Where(x => x.Field<String>("StatementOfAccountNo").Contains(SOAnumber));
                //RadGrid2.DataBind();

            }
            else
            {
                //RadGrid2.DataSource = DataSource;
                //RadGrid2.DataBind();
            }
        }
        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }
        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Edit" && e.Item.OwnerTableView.Name == "Shipments")
            {
                (e.Item.OwnerTableView.Columns[0] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[1] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[2] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[3] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[4] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[5] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[6] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[7] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[8] as GridBoundColumn).ReadOnly = false;

                e.Item.OwnerTableView.RetainExpandStateOnRebind = true;
                e.Item.OwnerTableView.Rebind();

            }
            else if (e.CommandName == "Edit" && e.Item.OwnerTableView.Name == "StatementOfAccounts")
            {
                (e.Item.OwnerTableView.Columns[0] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[1] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[2] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[3] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[4] as GridBoundColumn).ReadOnly = true;
                (e.Item.OwnerTableView.Columns[5] as GridBoundColumn).ReadOnly = true;

                e.Item.OwnerTableView.RetainExpandStateOnRebind = true;
                e.Item.OwnerTableView.Rebind();
            }
        }
        protected void RadGrid2_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {
            RadAjaxManager1.Alert("Hello");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //RadGrid2.DataSource = DataSource;
            //RadGrid2.Rebind();
        }
        #endregion        
        protected void RadGrid2_InsertCommand(object sender, GridCommandEventArgs e)
        {

        }

        protected void StatementOfAccountDataSource_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            DbParameterCollection CmdParams = e.Command.Parameters;
            ParameterCollection UpdParams = ((SqlDataSourceView)sender).UpdateParameters;
            Hashtable ht = new Hashtable();
            foreach (Parameter UpdParam in UpdParams)
                ht.Add(UpdParam.Name, true);
            for (int i = 0; i < CmdParams.Count; i++)
            {
                if (!ht.Contains(CmdParams[i].ParameterName.Substring(1)))
                    CmdParams.Remove(CmdParams[i--]);

            }
        }
    }
}