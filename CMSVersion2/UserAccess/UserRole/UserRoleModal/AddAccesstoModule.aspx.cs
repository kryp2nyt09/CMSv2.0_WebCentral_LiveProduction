using CMSVersion2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;


namespace CMSVersion2.UserAccess.UserRole.UserRoleModal
{
    public partial class AddAccesstoModule : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        //string password = "";
        //string confirmpassword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateRadTreeViewWeb();
            treeViewWeb.SelectedNodeStyle.ForeColor = Color.Black;


            if (!IsPostBack)
            {
                InitLoad();
                #region QueryString
                if (Request.QueryString["UserId"] == null)
                {

                }
                else
                {
                    string userid = Request.QueryString["UserId"].ToString();
                    lblUserID.Value = userid;
                    //int countChild = 0;
                    //int checkCountChild = 0;

                    int result = BLL.UserRole.checkIfUserIdExists(new Guid(userid), getConstr.ConStrCMS);
                    if (result > 0) // UserId exists in MenuAccess
                    {
                        #region UserId exists in MenuAccess
                        GlobalCode.resultValue = 1; // 1 for Update
                        DataTable Data = GetMenuInfo(new Guid(userid));
                        int counter = 0;
                        foreach (DataRow row in Data.Rows)
                        {
                            #region Load Data

                            if (counter == 0)
                            {
                                try
                                {

                                    string menuId = row["MenuId"].ToString();
                                    string empName = row["FullName"].ToString();
                                    string CanLogintoWeb = row["CanLogintoWeb"].ToString();
                                    string CanLogintoClient = row["CanLogintoClient"].ToString();
                                    string CanLogintoTnT = row["CanLogintoTnT"].ToString();
                                    string CanLogintoMobile = row["CanLogintoMobile"].ToString();
                                    string canLogin = "";
                                    //txtLoginLabel.Enabled = false;
                                    txtFullName.Text = empName;
                                    if (CanLogintoWeb == "False" || (CanLogintoWeb == "0"))
                                    {
                                        //chklistWeb.Enabled = false;
                                        treeViewWeb.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Web\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoClient == "False" || (CanLogintoClient == "0"))
                                    {
                                        chklistClient.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Client\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoTnT == "False" || (CanLogintoTnT == "0"))
                                    {
                                        chklistTnt.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS TracknTrace\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoMobile == "False" || (CanLogintoMobile == "0"))
                                    {
                                        chklistMobile.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Mobile\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }

                                    #endregion

                            #region CheckBoxlist
                                    //Web
                                    //if (chklistWeb.Enabled == true)
                                    //{
                                    //    for (int i = 0; i < chklistWeb.Items.Count; i++)
                                    //    {
                                    //        string val = chklistWeb.Items[i].Value;
                                    //        if (menuId == val)
                                    //        {
                                    //            chklistWeb.Items[i].Selected = true;
                                    //        }

                                    //    }
                                    //}


                                    //Client
                                    if (chklistClient.Enabled == true)
                                    {
                                        for (int i = 0; i < chklistClient.Items.Count; i++)
                                        {
                                            string val = chklistClient.Items[i].Value;
                                            if (menuId == val)
                                            {
                                                chklistClient.Items[i].Selected = true;
                                            }

                                        }
                                    }

                                    //TNT
                                    if (chklistTnt.Enabled == true)
                                    {
                                        for (int i = 0; i < chklistTnt.Items.Count; i++)
                                        {
                                            string val = chklistTnt.Items[i].Value;
                                            if (menuId == val)
                                            {
                                                chklistTnt.Items[i].Selected = true;
                                            }

                                        }
                                    }

                                    //Mobile
                                    if (chklistMobile.Enabled == true)
                                    {
                                        for (int i = 0; i < chklistMobile.Items.Count; i++)
                                        {
                                            string val = chklistMobile.Items[i].Value;
                                            if (menuId == val)
                                            {
                                                chklistMobile.Items[i].Selected = true;
                                            }

                                        }
                                    }

                                    #endregion

                            #region TreeView
                                    foreach (TreeNode node in treeViewWeb.Nodes)
                                    {
                                        string subMenuId;
                                        string MenuId;
                                        List<string> subMenuList = new List<string>();
                                        List<string> MenuList = new List<string>();
                                        List<string> accessResult = new List<string>();
                                        if (node.Value == menuId)
                                        {
                                            if (node.ChildNodes.Count > 0)
                                            {
                                                int countChildNodes = node.ChildNodes.Count;
                                                DataTable SubMenuData = BLL.UserRole.SubMenubyMenuId(Guid.Parse(menuId), getConstr.ConStrCMS).Tables[0];
                                                foreach (DataRow rows in SubMenuData.Rows)
                                                {
                                                    subMenuId = row["SubMenuId"].ToString();
                                                    subMenuList.Add(subMenuId);
                                                }

                                                DataTable MenuAccessData = BLL.UserRole.MenuAccessByUserId(Guid.Parse(userid), getConstr.ConStrCMS).Tables[0];
                                                foreach (DataRow rows in MenuAccessData.Rows)
                                                {
                                                    MenuId = row["MenuId"].ToString();
                                                    MenuList.Add(MenuId);
                                                }


                                                accessResult = MenuList.Intersect(subMenuList).ToList();
                                                int countResult = accessResult.Count;

                                                if (countChildNodes == countResult)
                                                {
                                                    node.Checked = true;
                                                    if (node.ChildNodes.Count > 0)
                                                        checkChildNode(node);
                                                }

                                                //checkCountChild += 1;

                                            }
                                            else
                                            {
                                                node.Checked = true;
                                                
                                            }
    
                                        }
                                        else
                                        {
                                            if (node.ChildNodes.Count > 0)
                                            {
                                                foreach (TreeNode chNode in node.ChildNodes)
                                                {
                                                    if(chNode.Value == menuId)
                                                    {
                                                        chNode.Checked = true;
                                                        //checkCountChild += 1;
                                                    }
                                                    
                                                }
                                            }
                                        }
                                       
                                       
                                    }

                                    #endregion


                                    //foreach (TreeNode treenode in treeViewWeb.Nodes)
                                    //{
                                    //    if (treenode.ChildNodes.Count > 0)
                                    //    {
                                    //        countChild += 1;
                                    //    }
                                    //}

                                    //if(countChild == checkCountChild)
                                    //{
                                    //   foreach (TreeNode treenode in treeViewWeb.Nodes)
                                    //    {
                                    //        treenode.Checked = true;
                                    //    }
                                    //}


                                }
                        catch (Exception ex)
                        {
                            //string error = ex.ToString();
                            Console.WriteLine(ex);
                           // ClientScript.RegisterStartupScript(typeof(Page), "SymbolError", "<script type='text/javascript'>alert(error);</script>", false);
                         }

                                //counter++;
                        }
                        }
                        #endregion
                    }
                    else
                    {
                        #region UserId Not exists in MenuAccess
                        GlobalCode.resultValue = 0; // 0 for Save
                        DataTable Data = GetModuleInfo(new Guid(userid));
                        int counter = 0;
                        foreach (DataRow row in Data.Rows)
                        {
                            if (counter == 0)
                            {
                                try
                                {
                                    string empName = row["FullName"].ToString();
                                    string CanLogintoWeb = row["CanLogintoWeb"].ToString();
                                    string CanLogintoClient = row["CanLogintoClient"].ToString();
                                    string CanLogintoTnT = row["CanLogintoTnT"].ToString();
                                    string CanLogintoMobile = row["CanLogintoMobile"].ToString();
                                    string canLogin = "";
                                    // txtLoginLabel.Enabled = false;
                                    txtFullName.Text = empName;
                                    if (CanLogintoWeb == "False" || (CanLogintoWeb == "0"))
                                    {
                                        treeViewWeb.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Web\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoClient == "False" || (CanLogintoClient == "0"))
                                    {
                                        chklistClient.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Client\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoTnT == "False" || (CanLogintoTnT == "0"))
                                    {
                                        chklistTnt.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS TracknTrace\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                    if (CanLogintoMobile == "False" || (CanLogintoMobile == "0"))
                                    {
                                        chklistMobile.Enabled = false;
                                    }
                                    else
                                    {
                                        canLogin += "CMS Mobile\n".Replace("\n", Environment.NewLine);
                                        txtLoginLabel.Text = canLogin;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }

                                //counter++;
                            }
                        }
                        #endregion
                    }

                }
                #endregion

            }

        }

        private void checkChildNode(TreeNode node)
        {
            foreach (TreeNode chNode in node.ChildNodes)
            {
                chNode.Checked = true;
                if (chNode.ChildNodes.Count > 0)
                    checkChildNode(chNode);
            }
        }

        #region InitLoad
        public void InitLoad()
        {
            //PopulateWeb();
            PopulateClient();
            PopulateTnT();
            PopulateMobile();
        }

        #endregion
        
        #region DataSources
        private void PopulateRadTreeViewWeb()
        {
            string apptitle = "Web";
            DataTable dt = BLL.UserRole.GetMenu(apptitle, getConstr.ConStrCMS).Tables[0];
            //treeViewWeb.Nodes.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode tnParent = new TreeNode();
                   // tnParent.CollapseAll();
                    tnParent.Text = dr["MenuName"].ToString();
                    tnParent.Value = dr["MenuId"].ToString();
                    //tnParent.SelectAction = TreeNodeSelectAction.None;
                    treeViewWeb.Nodes.Add(tnParent);
                    PopulateTreeViewChild(Guid.Parse(tnParent.Value), tnParent);
                }
            }



        }

        private void PopulateTreeViewChild(Guid parentId, TreeNode parentNode)
        {
            string apptitle = "Web";
            DataTable dtChild = BLL.UserRole.GetSubMenuByMenuId(parentId, apptitle, getConstr.ConStrCMS).Tables[0];
            if (dtChild.Rows.Count > 0)
            {
                foreach (DataRow dr in dtChild.Rows)
                {
                    if(dr["SubMenuId"].ToString() !=null)
                    {
                        TreeNode child = new TreeNode();
                        child.Text = dr["DisplaySubMenuName"].ToString().Trim();
                        child.Value = dr["SubMenuId"].ToString().Trim();
                        //child.SelectAction = TreeNodeSelectAction.None;
                        parentNode.ChildNodes.Add(child);
                    }
                }
            }

        }

        //private void ColorNode(TreeView nodes, System.Drawing.Color Color)
        //{

        //    foreach (TreeNode child in nodes)
        //    {
        //        child.ForeColor = Color;
        //        if (child.Nodes != null && child.Nodes.Count > 0)
        //            ColorNode(child.Nodes, Color);
        //    }
        //}

        private void PopulateClient()
        {
            string apptitle = "Client";
            DataTable dt = BLL.UserRole.GetMenuByAppTitle(apptitle, getConstr.ConStrCMS).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    ButtonListItem item = new ButtonListItem();
                    item.Text = dtRow["MenuName"].ToString();
                    item.Value = dtRow["MenuId"].ToString();
                    chklistClient.Items.Add(item);
                }

            }
        }

        private void PopulateTnT()
        {
            string apptitle = "TnT";
            DataTable dt = BLL.UserRole.GetMenuByAppTitle(apptitle, getConstr.ConStrCMS).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    ButtonListItem item = new ButtonListItem();
                    item.Text = dtRow["MenuName"].ToString();
                    item.Value = dtRow["MenuId"].ToString();
                    chklistTnt.Items.Add(item);
                }

            }
        }

        private void PopulateMobile()
        {
            string apptitle = "Mobile";
            DataTable dt = BLL.UserRole.GetMenuByAppTitle(apptitle, getConstr.ConStrCMS).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    ButtonListItem item = new ButtonListItem();
                    item.Text = dtRow["MenuName"].ToString();
                    item.Value = dtRow["MenuId"].ToString();
                    chklistMobile.Items.Add(item);
                }

            }
        }

        //If user Id not exist in Menu Access
        public DataTable GetModuleInfo(Guid ID)
        {
            DataSet data = BLL.UserRole.GetRolesByUserRoleId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }

        //If user Id exist in Menu Access
        public DataTable GetMenuInfo(Guid ID)
        {
            DataSet data = BLL.UserRole.GetMenuByUserId(ID, getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.QueryString["employeeid"] == null)
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Insert;
            }
            else
            {
                //DetailsView1.DefaultMode = DetailsViewMode.Edit;
            }
            this.Page.Title = "Add User Access";
        }

        protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            }
            else if (e.CommandName == "Insert")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //logic to truncate long string to prevent SQL error
            for (int i = 1; i < 4; i++)
            {
                string val = e.NewValues[i - 1].ToString();
                int maxLength = i * 10;
                if (val.Length > maxLength) e.NewValues[i - 1] = val.Substring(0, maxLength);
            }
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = "<script>RefreshParentPage()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", script);
        }

        private void UpdateChildNode(TreeNode node, Guid userId, Guid createdBy)
        {
            Guid menuChildId = new Guid();
            int status = 1;
            if (node.ChildNodes.Count > 0)
            {
                foreach (TreeNode chNode in node.ChildNodes)
                {
                    menuChildId = Guid.Parse(chNode.Value);
                    var checkNode = BLL.UserRole.checkIfMenuIdExists(menuChildId, userId, getConstr.ConStrCMS);
                    int childcountExist = checkNode.Item1;
                    int childcheckStatus = checkNode.Item2;
                    if(childcountExist == 0)
                    {
                        BLL.UserRole.InsertMenuAccess(menuChildId, userId, createdBy, getConstr.ConStrCMS);
                    }
                    if (childcountExist > 0 && childcheckStatus == 3)
                    {
                        BLL.UserRole.UpdateMenuAccess(menuChildId, userId, createdBy, status, getConstr.ConStrCMS);
                    }
                }
            }
        }

        private void CheckChildNode(TreeNode node, Guid userId, Guid createdBy, Guid menuId)
        {
            Guid menuChildId = new Guid();
            int status = 1;
            int countCheckNode = 0; // To check if Parent Node status should be updated to 1 or 3
            if (node.ChildNodes.Count > 0)
            {
                foreach (TreeNode chNode in node.ChildNodes)
                {
                    if (chNode.Checked == true)
                    {
                        countCheckNode += 1;
                        menuChildId = Guid.Parse(chNode.Value);
                        var checkNode = BLL.UserRole.checkIfMenuIdExists(menuChildId, userId, getConstr.ConStrCMS);
                        int childcountExist = checkNode.Item1;
                        int childcheckStatus = checkNode.Item2;
                        if (childcountExist == 0)
                        {
                            BLL.UserRole.InsertMenuAccess(menuChildId, userId, createdBy, getConstr.ConStrCMS);
                        }
                        if (childcountExist > 0 && childcheckStatus == 3)
                        {
                            BLL.UserRole.UpdateMenuAccess(menuChildId, userId, createdBy, status, getConstr.ConStrCMS);
                        }
                    }
                    else
                    {
                        menuChildId = Guid.Parse(chNode.Value);
                        var checkNode = BLL.UserRole.checkIfMenuIdExists(menuChildId, userId, getConstr.ConStrCMS);
                        int childcountExist = checkNode.Item1;
                        int childcheckStatus = checkNode.Item2;
                        if (childcountExist > 0 && childcheckStatus == 3)
                        {
                           // BLL.UserRole.UpdateMenuAccess(menuChildId, userId, createdBy, status, getConstr.ConStrCMS);
                        }
                        if (childcountExist > 0 && childcheckStatus == 1)
                        {
                            BLL.UserRole.UpdateMenuAccess(menuChildId, userId, createdBy, 3, getConstr.ConStrCMS);
                        }
                    }
                }

                if (countCheckNode > 0)
                {
                    var checkNode = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                    int childcountExist = checkNode.Item1;
                    int childcheckStatus = checkNode.Item2;
                    if (childcountExist == 0)
                    {
                        BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                    }
                    if (childcountExist > 0 && childcheckStatus == 3)
                    {
                        BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, status, getConstr.ConStrCMS);
                    }
                }
                if(countCheckNode == 0)
                {
                    var checkNode = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                    int childcountExist = checkNode.Item1;
                    if(childcountExist == 1)
                    {
                        BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 3, getConstr.ConStrCMS);
                    }
                    
                }
            }
        }



        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Guid userId = new Guid();
            Guid menuId = new Guid();
            Guid createdBy = new Guid("11111111-1111-1111-1111-111111111111");

           // Guid menuChildId = new Guid();

            int resultValue = GlobalCode.resultValue;
            int status = 1;
            #region Save
            if (resultValue == 0)//Save
            {
                List<string> result = GetAllCheckedAccess();
                try
                {
                    userId = Guid.Parse(lblUserID.Value);
                    #region
                    foreach (string access in result)
                    {
                        menuId = Guid.Parse(access);
                        BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                    }

                    //Client
                    if (chklistClient.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistClient.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                            }
                        }
                    }
                    //TNT
                    if (chklistTnt.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistTnt.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                            }
                        }
                    }

                    //Mobile
                    if (chklistMobile.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistMobile.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                            }
                        }
                    }

                    #endregion




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            #endregion

            #region Update
            if (resultValue == 1)
            {
                try
                {
                    userId = Guid.Parse(lblUserID.Value);

                    #region Update Treeview
                    int countTreeWeb = 0;
                    foreach (TreeNode node in treeViewWeb.Nodes)
                    {
                        int countTreeViewweb = treeViewWeb.Nodes.Count;
                        countTreeViewweb = countTreeViewweb / 2;
                        if(countTreeWeb < countTreeViewweb)
                        {
                            if (node.Checked == true)
                            {
                                menuId = Guid.Parse(node.Value);
                                //Added
                                int countChild = 0;
                                countChild = node.ChildNodes.Count;

                                if (countChild == 0)
                                {
                                    var checkNode = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                    int childcountExist = checkNode.Item1;
                                    if (childcountExist == 1)
                                    {
                                        BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 1, getConstr.ConStrCMS);
                                    }//Added
                                    if(childcountExist == 0)
                                    {
                                        BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                                    }
                                }

                                //---------------
                                if(countChild > 0)
                                {
                                    var check = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                    int countExists = check.Item1;
                                    int checkStatus = check.Item2;
                                    //Save
                                    if (countExists == 0)
                                    {
                                        BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                                        UpdateChildNode(node, userId, createdBy);

                                    }
                                    //Update
                                    if (countExists > 0 && checkStatus == 3)
                                    {
                                        BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, status, getConstr.ConStrCMS);
                                        UpdateChildNode(node, userId, createdBy);
                                    }
                                    if (countExists > 0 && checkStatus == 1)
                                    {
                                        UpdateChildNode(node, userId, createdBy);
                                    }
                                }
                                

                            }
                            else
                            {
                                menuId = Guid.Parse(node.Value);
                                int countChild = 0;
                                countChild = node.ChildNodes.Count;
                                if(countChild == 0)
                                {
                                    var checkNode = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                    int childcountExist = checkNode.Item1;
                                    if (childcountExist == 1)
                                    {
                                        BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 3, getConstr.ConStrCMS);
                                    }
                                }

                                if(countChild > 0)
                                {
                                    CheckChildNode(node, userId, createdBy, menuId);
                                }
                               

                            }
                        }


                        countTreeWeb++;

                    }
                    #endregion

                    #region Client
                    if (chklistClient.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistClient.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                var check = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int countExists = check.Item1;
                                int checkStatus = check.Item2;
                                if (countExists == 0)
                                {
                                    BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                                }
                                if (countExists > 0 && checkStatus == 3)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, status, getConstr.ConStrCMS);
                                }

                            }
                            else
                            {

                                menuId = Guid.Parse(item.Value);
                                var checkExist = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int count = checkExist.Item1;
                                int recordStatus = checkExist.Item2;
                                if (count > 0 && recordStatus == 1)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 3, getConstr.ConStrCMS);
                                }

                            }
                        }
                    }
                    #endregion

                    #region TNT
                    if (chklistTnt.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistTnt.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                var check = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int countExists = check.Item1;
                                int checkStatus = check.Item2;
                                if (countExists == 0)
                                {
                                    BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                                }
                                if (countExists > 0 && checkStatus == 3)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, status, getConstr.ConStrCMS);
                                }

                            }
                            else
                            {

                                menuId = Guid.Parse(item.Value);
                                var checkExist = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int count = checkExist.Item1;
                                int recordStatus = checkExist.Item2;
                                if (count > 0 && recordStatus == 1)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 3, getConstr.ConStrCMS);
                                }

                            }
                        }
                    }

                    #endregion

                    #region Mobile
                    if (chklistMobile.Enabled == true)
                    {
                        foreach (ButtonListItem item in chklistMobile.Items)
                        {
                            if (item.Selected)
                            {
                                menuId = Guid.Parse(item.Value);
                                var check = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int countExists = check.Item1;
                                int checkStatus = check.Item2;
                                if (countExists == 0)
                                {
                                    BLL.UserRole.InsertMenuAccess(menuId, userId, createdBy, getConstr.ConStrCMS);
                                }
                                if (countExists > 0 && checkStatus == 3)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, status, getConstr.ConStrCMS);
                                }

                            }
                            else
                            {

                                menuId = Guid.Parse(item.Value);
                                var checkExist = BLL.UserRole.checkIfMenuIdExists(menuId, userId, getConstr.ConStrCMS);
                                int count = checkExist.Item1;
                                int recordStatus = checkExist.Item2;
                                if (count > 0 && recordStatus == 1)
                                {
                                    BLL.UserRole.UpdateMenuAccess(menuId, userId, createdBy, 3, getConstr.ConStrCMS);
                                }

                            }
                        }
                    }
                    #endregion

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            #endregion

            string script = "<script>CloseOnReload()</" + "script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);
        }

        private List<string> GetAllCheckedAccess()
        {
            List<string> aResult = new List<string>();
            string val = "";
            int i = treeViewWeb.CheckedNodes.Count;
            if (i > 0)
            {
                foreach (TreeNode node in treeViewWeb.CheckedNodes)
                {
                    if (node.ChildNodes.Count != 0)
                    {
                        val = node.Value;
                        if (!aResult.Contains(val))
                        {
                            aResult.Add(val);
                        }
                        foreach (TreeNode childNode in node.ChildNodes)
                        {
                            val = childNode.Value;
                            if (!aResult.Contains(val))
                            {
                                aResult.Add(val);
                            }
                        }
                    }
                    else
                    {
                        val = node.Value;
                    }
                    if (!aResult.Contains(val))
                    {
                        aResult.Add(val);
                    }

                }
            }

            return aResult;
        }


        private List<TreeNode> AllCheckedNodes = new List<TreeNode>();

        private void GetAllCheckedNodes()
        {
            //for (int i = 0; i < treeViewWeb.CheckedNodes.Count; i++)
            //{
            //    AllCheckedNodes.Add(treeViewWeb.CheckedNodes[i]);
            //}
            List<string> arrayName = new List<string>();
            foreach (TreeNode tn in treeViewWeb.CheckedNodes)
            {
                // Implement Your Code Here.
                //string ar = tn.ChildNodes.
                //arrayName.add

            }
        }

        private void GetNodeRecursive(TreeNode treeNode)
        {
            if (treeNode.Checked == true)
            {
                Response.Write("<br/>" + treeNode.Text + "<br/>");
                //Your Code Goes Here to perform any action on checked node
            }
            foreach (TreeNode tn in treeNode.ChildNodes)
            {
                GetNodeRecursive(tn);
            }

        }

        protected void treeViewWeb_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
           
        }

        private void CheckTreeNodeRecursive(TreeNode parent, bool fCheck)
        {
            foreach (TreeNode child in parent.ChildNodes)
            {
                if (child.Checked != fCheck)
                {
                    child.Checked = fCheck;
                }

                if (child.ChildNodes.Count > 0)
                {
                    CheckTreeNodeRecursive(child, fCheck);
                }
            }
        }

       
        #endregion
    }
}