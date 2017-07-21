using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;

namespace CMSVersion2.UserAccess.Roles.RolesModal
{
    public partial class ViewRoles : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] == null)
                {

                }
                else
                {
                    string roleuserid = Request.QueryString["UserId"].ToString();
                    lblRoleUserID.Value = roleuserid;
                }
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            this.Page.Title = "View Roles";
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


        public DataTable GetRolesById(Guid id)
        {

            DataSet data = BLL.UserRole.GetRolesByUserRoleId(id, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }



        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string userRoleId = Request.QueryString["UserId"].ToString();
            Guid id = new Guid();
            if (userRoleId != null)
            {
                try
                {
                    id = Guid.Parse(userRoleId);
                    RadGrid2.DataSource = GetRolesById(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }



        }
    }
}