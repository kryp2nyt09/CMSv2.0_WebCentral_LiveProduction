using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
namespace CMSVersion2.Customer
{
    public partial class Customer : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {

            radSearchCustomer.DataSource = GetCustomer();
            radSearchCustomer.DataTextField = "Name";
            radSearchCustomer.DataValueField = "ClientId";

            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

        }

        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClientId"], e.Item.ItemIndex);

                HyperLink addLink = (HyperLink)e.Item.FindControl("AddLink");
                addLink.Attributes["href"] = "javascript:void(0);";
                addLink.Attributes["onclick"] = String.Format("return ShowAddForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClientId"], e.Item.ItemIndex);
            }
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


        public DataTable GetCustomer()
        {

            DataSet data = BLL.Clients.GetClients(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        public void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/Upload/");
                e.File.SaveAs(path + e.File.GetName());
            }
            catch (Exception ex)
            {
                
            }
           

        }

        public DataTable GetRepById(Guid clientId)
        {
            DataSet data = BLL.Representatives.GetRepresentativesByClientId(getConstr.ConStrCMS, clientId);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetCustomer();
        }

        
        protected void radSearchCustomer_Search(object sender, SearchBoxEventArgs e)
        {
            RadSearchBox searchBox = (RadSearchBox)sender;

            string clientId = string.Empty;
            string likeCondition;
            Guid id = new Guid();

            if (e.DataItem != null)
            {
                clientId = ((Dictionary<string, object>)e.DataItem)["ClientId"].ToString();
                id = Guid.Parse(clientId);
                if (!string.IsNullOrEmpty(clientId))
                {
                    likeCondition = string.Format("'{0}{1}%'", searchBox.Filter == SearchBoxFilter.Contains ? "%" : "", ((Dictionary<string, object>)e.DataItem)["ClientId"].ToString());
                    RadGrid2.DataSource = GetRepById(id);
                    RadGrid2.DataBind();
                }

            }
            else
            {
                RadGrid2.DataSource = GetCustomer();
                RadGrid2.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RadGrid2.DataSource = GetCustomer();
            RadGrid2.Rebind();
        }

        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
        }

        protected void RadGrid2_ItemDataBound1(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {

        }

        protected void RadGrid2_ItemCreated1(object sender, GridItemEventArgs e)
        {

        }




        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string ClientId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ClientId"].ToString();
                BLL.Clients.UpdateClientProfile(new Guid(ClientId), 3, getConstr.ConStrCMS);

                //3 for delete flagging
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt;

            foreach (UploadedFile f in RadAsyncUpload1.UploadedFiles)
            {
                string path =  Server.MapPath("~/Upload/");
                var filename = f.FileName;
                //string sheetName = Utilities.ExcelUtililty.GetSheetName(path + filename);
                dt = Utilities.ExcelUtililty.ReadExcelFile("Sheet1", path + filename);
                int count = BLL.Clients.ImportClient(dt, getConstr.ConStrCMS);
                CountUploaded.Text = "No of clients uploaded : " + count + " out of " + dt.Rows.Count;
                RadGrid2.DataSource = GetCustomer();
                RadGrid2.DataBind();
            }
        }

    }
}