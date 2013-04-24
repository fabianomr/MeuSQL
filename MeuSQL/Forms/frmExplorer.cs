using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeuSQL
{
    public partial class frmExplorer : Class.clsBase
    {

        public WeifenLuo.WinFormsUI.Docking.DockPanel objDock;
                
        public frmExplorer(WeifenLuo.WinFormsUI.Docking.DockPanel objDock)
        {
            InitializeComponent();
        }
        
        Class.clsTreeView objTreeview = new Class.clsTreeView();

        private string strTag = "";        
        private string strCode = "";
        private string strDataBase = "";

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

        private void frmExplorer_Load(object sender, EventArgs e)
        {
            this.TabText = "Explorer";
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events


        private void mnuScrCreProcedure_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuScrCreFunction_Click(object sender, EventArgs e)
        {
            NewFunction();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Action();
        }

        private void TreeExplorer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void TreeExplorer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Action();
        }

        private void TreeExplorer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeNode draggedNode = e.Item as TreeNode;
                string strText = "";

                string strTag = draggedNode.Tag.ToString().Substring(0, draggedNode.Tag.ToString().IndexOf("_"));

                if (strTag == "T")
                {
                    strText = draggedNode.Text;
                    strText = "SELECT * FROM " + strText;
                }
                DoDragDrop(strText, DragDropEffects.Move);

            }
            catch (Exception ex)
            {
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            Action();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Drop();
        }

        private void mnuNewTable_Click(object sender, EventArgs e)
        {
            NewTable();
        }

        private void TreeExplorer_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Select the clicked node
                    TreeExplorer.SelectedNode = TreeExplorer.GetNodeAt(e.X, e.Y);

                    if (TreeExplorer.SelectedNode != null)
                    {
                        string strTag = TreeExplorer.SelectedNode.Tag.ToString().Substring(0, TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_"));

                        /*
                            S  = Server
                            B  = Base
                            T  = Tables
                            TC = Columns
                            P  = Procedures
                            F  = Function
                            BT = Folder Table
                            BP = Folder Procedure
                            BF = Folder Function                             
                            TR = Folder Trigger
                        */
                        mnuNewDataBase.Visible = false;
                        mnuLine1.Visible = false;
                        mnuRefresh.Visible = false;
                        mnuLine2.Visible = false;
                        mnuEdit.Visible = false;
                        mnuDelete.Visible = false;
                        
                        mnuNewTable.Visible = false;
                        mnuNewView.Visible = false;
                        mnuNewProcedure.Visible = false;
                        mnuNewFunction.Visible = false;
                        mnuLineUser.Visible=false;
                        mnuAddNewUser.Visible = false;
                        mnuDropUser.Visible = false;
                        mnuChangePassword.Visible = false;
                        
                        mnuRenameTable.Visible = false;
                        mnuLineRenameTable.Visible = false;

                        switch (strTag)
                        {
                            case "S":                                
                                mnuRefresh.Visible = true;
                                break;
                            case "B":
                                mnuRefresh.Visible = true;
                                mnuDelete.Visible = true;                        
                                break;

                            case "T":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuEdit.Visible = true;
                                mnuDelete.Visible = true;                                                      
                                mnuNewTable.Visible = true;                                
                                mnuRenameTable.Visible = true;
                                mnuLineRenameTable.Visible = true;
                                break;


                            case "V":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewView.Visible = true;
                                mnuEdit.Visible = true;
                                mnuDelete.Visible = true;
                                break;

                            case "P":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewProcedure.Visible = true;
                                mnuEdit.Visible = true;
                                mnuDelete.Visible = true;
                                break;

                            case "F":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewFunction.Visible = true;
                                mnuEdit.Visible = true;
                                mnuDelete.Visible = true;
                                break;

                            case "BT":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewTable.Visible = true;
                                break;

                            case "BP":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewProcedure.Visible = true;
                                break;
                            case "PD":
                                mnuNewDataBase.Visible = true;
                                mnuLine1.Visible = true;
                                mnuRefresh.Visible = true;
                                break;
                            case "BF":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewFunction.Visible = true;
                                break;

                            case "PU":
                                mnuRefresh.Visible = true;
                                mnuAddNewUser.Visible = true;
                                break;
                            case "U":                                
                                //mnuLineUser.Visible=true;
                                mnuDropUser.Visible = true;
                                mnuChangePassword.Visible = true;
                                break;
                            case "TG":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuEdit.Visible = true;
                                mnuDelete.Visible = true;
                                break;
                            case "BV":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewView.Visible = true;
                                break;
                            case "TR":
                                mnuRefresh.Visible = true;
                                mnuLine2.Visible = true;
                                mnuNewTrigger.Visible = true;
                                break;
                            default:
                                break;
                        }

                        contextMenuStrip1.Show(TreeExplorer, e.Location);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TreeExplorer_MouseUp: " + ex.Message.ToString());
            }
        }

        private void mnuNewDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmNewDataBase objForm = new Forms.frmNewDataBase();
                objForm.ShowDialog();
                if (objForm.blnCreateNewDataBase == true)
                {
                    objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, objForm.strNewDataBaseName, TreeExplorer.SelectedNode, "B_" + objForm.strNewDataBaseName, 1, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("mnuNewDataBase_Click: " + ex.Message.ToString());
            }
        }

        private void mnuAddNewUser_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void mnuDropUser_Click(object sender, EventArgs e)
        {
            DropUser();
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        #endregion

        private void mnuRenameTable_Click(object sender, EventArgs e)
        {
            BeginRenameTable();
        }

        private void TreeExplorer_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (e.Label != null)
                {
                    EndRenameTable(e.Label);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Rename Table: " + ex.Message);
                e.CancelEdit = true;
            }
        }


        private void btnNewQuery_Click(object sender, EventArgs e)
        {
            NewQuery();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void mnuNewProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                NewProcedure();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewProcedure: " + ex.Message);
            }
        }

        private void mnuNewFunction_Click(object sender, EventArgs e)
        {
            try
            {
                NewFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewProcedure: " + ex.Message);
            }
        }

        private void mnuNewView_Click(object sender, EventArgs e)
        {
            try
            {
                NewView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewProcedure: " + ex.Message);
            }
        }
        
        private void mnuNewTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                NewTrigger();
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewTrigger: " + ex.Message);
            }
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void Connect()
        {
            try
            {
                Forms.frmConnection frm = new Forms.frmConnection();
                frm.ShowDialog();
                
                if (Class.clsMySQL.blnConnected)
                {
                    btnNewQuery.Enabled = true;
                    btnOpen.Enabled = true;
                    ConfigTreeview();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect" + ex.Message);
            }
        }

        private bool ConfigTreeview()
        {
            try
            {
                TreeExplorer.Nodes.Clear();
                TreeNode Node = new TreeNode();
                Node = new TreeNode();

                string strServer = Class.clsMySQL.strServer + " - DataBase Version: " + objDb.GetVersion("");

                Node.Text = strServer;
                Node.Tag = "S_" + Class.clsMySQL.strServer;
                Node.ImageIndex = 0;
                Node.SelectedImageIndex = 0;
                TreeExplorer.Nodes.Add(Node);

                objTreeview.AddNode(TreeExplorer, strServer, "DataBases", Node, "PD_" + "DataBases", 2, true);
                objTreeview.AddNode(TreeExplorer, strServer, "Users", Node, "PU_" + "Users", 2, false);
                
                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable("SHOW DATABASES;");

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "DataBases", Dt.Rows[intI]["Database"].ToString(), Node, "B_" + Dt.Rows[intI]["Database"], 1, true);
                    }
                }

                LoadUsers(Node);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ConfiguraTreeview - " + ex.Message);
            }
            return false;
        }


        private bool LoadTables(string strDataBase)
        {
            try
            {
                TreeExplorer.SelectedNode.Nodes.Clear();

                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable(" SHOW FULL TABLES WHERE Table_type = 'BASE TABLE';", strDataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "Tables", Dt.Rows[intI]["Tables_in_" + strDataBase].ToString(), TreeExplorer.SelectedNode, "T_" + strDataBase, 3);
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadTables - " + ex.Message);
            }
            return false;
        }

        private bool LoadColumns(string strDataBase)
        {
            try
            {
                string strText = "";
                DataTable Dt = new DataTable();

                TreeExplorer.SelectedNode.Nodes.Clear();

                Dt = objDb.GetDataTable(" SHOW COLUMNS FROM " + TreeExplorer.SelectedNode.Parent.Text + ";", strDataBase);

                if (Dt.Rows.Count > 0)
                {

                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {

                        strText = Dt.Rows[intI]["Field"].ToString(); ;

                        if (Dt.Rows[intI]["Type"].ToString() != "")
                        {
                            strText += " - Type: " + Dt.Rows[intI]["Type"];
                        }

                        if (Dt.Rows[intI]["Null"].ToString() != "")
                        {
                            strText += " - Null: " + Dt.Rows[intI]["Null"];
                        }

                        if (Dt.Rows[intI]["Key"].ToString() != "")
                        {
                            strText += " - Key: " + Dt.Rows[intI]["Key"];
                        }

                        if (Dt.Rows[intI]["Default"].ToString() != "")
                        {
                            strText += " - Default: " + Dt.Rows[intI]["Default"];
                        }

                        if (Dt.Rows[intI]["Extra"].ToString() != "")
                        {
                            strText += " - Extra: " + Dt.Rows[intI]["Extra"];
                        }


                        if (Dt.Rows[intI]["Key"].ToString() != "")
                        {
                            objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, strText, TreeExplorer.SelectedNode, "TC_" + strDataBase, 8);
                        }
                        else
                        {
                            objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, strText, TreeExplorer.SelectedNode, "TC_" + strDataBase, 5);
                        }
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadColumns - " + ex.Message);
            }
            return false;
        }

        private bool LoadTrigger(string strDataBase)
        {
            try
            {
                DataTable Dt = new DataTable();

                TreeExplorer.SelectedNode.Nodes.Clear();

                Dt = objDb.GetDataTable(" SHOW TRIGGERS LIKE '" + TreeExplorer.SelectedNode.Parent.Text + "';", strDataBase);
                

                if (Dt.Rows.Count > 0)
                {
                    objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, Dt.Rows[0]["Trigger"].ToString(), TreeExplorer.SelectedNode, "TG_" + strDataBase, 12);                        
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadTrigger - " + ex.Message);
            }
            return false;
        }

        private bool LoadViews(string strDataBase)
        {
            try
            {
                TreeExplorer.SelectedNode.Nodes.Clear();

                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable(" SHOW FULL TABLES WHERE Table_type = 'VIEW';", strDataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "Views", Dt.Rows[intI]["Tables_in_" + strDataBase].ToString(), TreeExplorer.SelectedNode, "V_" + strDataBase, 3);
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadViews - " + ex.Message);
            }
            return false;
        }



        private bool LoadProcedures(string strDataBase)
        {
            try
            {
                TreeExplorer.SelectedNode.Nodes.Clear();

                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable(" SHOW PROCEDURE STATUS;", strDataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "Procedures", Dt.Rows[intI]["Name"].ToString(), TreeExplorer.SelectedNode, "P_" + strDataBase, 4);
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadProcedures - " + ex.Message);
            }
            return false;
        }

        private bool LoadFunction(string strDataBase)
        {
            try
            {
                TreeExplorer.SelectedNode.Nodes.Clear();

                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable(" SHOW FUNCTION STATUS;", strDataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "Functions", Dt.Rows[intI]["Name"].ToString(), TreeExplorer.SelectedNode, "F_" + strDataBase, 10);
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadFunction - " + ex.Message);
            }
            return false;
        }

        private bool LoadView(string strDataBase)
        {
            try
            {
                TreeExplorer.SelectedNode.Nodes.Clear();

                DataTable Dt = new DataTable();

                Dt = objDb.GetDataTable(" SHOW FUNCTION STATUS;", strDataBase);

                if (Dt.Rows.Count > 0)
                {
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        objTreeview.AddNode(TreeExplorer, "Functions", Dt.Rows[intI]["Name"].ToString(), TreeExplorer.SelectedNode, "F_" + strDataBase, 10);
                    }
                }

                TreeExplorer.SelectedNode.ExpandAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadWiew - " + ex.Message);
            }
            return false;
        }

        private bool Action()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);
                string strTag = TreeExplorer.SelectedNode.Tag.ToString().Substring(0, TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_"));


                switch (strTag)
                {
                    case "D":
                        TreeExplorer.SelectedNode.ExpandAll();
                        break;
                    case "U":
                        TreeExplorer.SelectedNode.ExpandAll();
                        break;
                    case "B":
                        TreeExplorer.SelectedNode.Nodes.Clear();
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Tables", TreeExplorer.SelectedNode, "BT_" + strDataBase, 2);                        
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Views", TreeExplorer.SelectedNode, "BV_" + strDataBase, 2);
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Procedures", TreeExplorer.SelectedNode, "BP_" + strDataBase, 2);
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Functions", TreeExplorer.SelectedNode, "BF_" + strDataBase, 2);

                        TreeExplorer.SelectedNode.ExpandAll();
                        break;
                    case "BT":
                        LoadTables(strDataBase);
                        break;
                    case "BV":
                        LoadViews(strDataBase);
                        break;
                    case "T":
                        TreeExplorer.SelectedNode.Nodes.Clear();
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Columns", TreeExplorer.SelectedNode, "CO_" + strDataBase, 2);
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Trigger", TreeExplorer.SelectedNode, "TR_" + strDataBase, 2);
                        break;
                    case "V":
                        TreeExplorer.SelectedNode.Nodes.Clear();
                        objTreeview.AddNode(TreeExplorer, TreeExplorer.SelectedNode.Text, "Columns", TreeExplorer.SelectedNode, "CO_" + strDataBase, 2);
                        break;
                    case "CO":
                        LoadColumns(strDataBase);
                        break;
                    case "TR":
                        LoadTrigger(strDataBase);
                        break;

                    case "BP":
                        LoadProcedures(strDataBase);
                        break;
                    case "BF":
                        LoadFunction(strDataBase);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Action - " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return false;
        }

        private bool Edit()
        {
            try
            {
                string strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);
                string strTag = TreeExplorer.SelectedNode.Tag.ToString().Substring(0, TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_"));

                switch (strTag)
                {
                    case "T":
                        EditTable();
                        break;
                    case "TG":
                        EditTrigger(strDataBase);
                        break;
                    case "P":
                        EditProcedure(strDataBase);
                        break;
                    case "F":
                        EditFunction(strDataBase);
                        break;
                    case "V":
                        EditView(strDataBase);
                        break;

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit - " + ex.Message);
            }
            return false;
        }

        private bool ScriptCreateTable(string strDataBase,string Table)
        {
            try
            { 
                NewQuery(strDataBase, objDb.GetScriptTable(strDataBase,TreeExplorer.SelectedNode.Text));

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ScriptCreateTable - " + ex.Message);
            }
            return false;
        }

        private bool EditTrigger(string strDataBase)
        {
            try
            {
                NewQuery(strDataBase, objDb.GetScriptTrigger(strDataBase, TreeExplorer.SelectedNode.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EditTrigger - " + ex.Message);
            }
            return false;
        }

        private bool EditProcedure(string strDataBase)
        {
            try
            {
                NewQuery(strDataBase, objDb.GetScriptProcedure(strDataBase,TreeExplorer.SelectedNode.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EditProcedure - " + ex.Message);
            }
            return false;
        }

        private bool EditFunction(string strDataBase)
        {
            try
            {
                NewQuery(strDataBase, objDb.GetScriptFunction(strDataBase,TreeExplorer.SelectedNode.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EditFunction - " + ex.Message);
            }
            return false;
        }

        private bool EditView(string strDataBase)
        {
            try
            {
                NewQuery(strDataBase, objDb.GetScriptView(strDataBase, TreeExplorer.SelectedNode.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("EditFunction - " + ex.Message);
            }
            return false;
        }

        public bool Drop()
        {
            try
            {
                string strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);
                string strTag = TreeExplorer.SelectedNode.Tag.ToString().Substring(0, TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_"));

                switch (strTag)
                {
                    case "B":
                        DropDataBase(strDataBase);
                        break;
                    case "T":
                        DropTable(strDataBase);
                        break;
                    case "TG":
                        DropTrigger(strDataBase);
                        break;
                    case "P":
                        DropProcedure(strDataBase);
                        break;
                    case "F":
                        DropFunction(strDataBase);
                        break;
                    case "V":
                        DropView(strDataBase);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drop - " + ex.Message);
            }
            return false;
        }

        private bool DropDataBase(string strDataBase)
        {
            try
            {

                if (MessageBox.Show("Really Drop DataBase '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop DataBase", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    if(objDb.DropDataBase(strDataBase)){
                        TreeExplorer.SelectedNode.Remove();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropDataBase - " + ex.Message);
            }
            return false;
        }

        private bool DropTable(string strDataBase)
        {
            try
            {
                if (MessageBox.Show("Really Drop Table '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop Table", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    objDb.DropTable(strDataBase,TreeExplorer.SelectedNode.Text);
                    TreeExplorer.SelectedNode.Remove();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropTable - " + ex.Message);
            }
            return false;
        }

        private bool DropTrigger(string strDataBase)
        {
            try
            {
                if (MessageBox.Show("Really Drop Trigger '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop Trigger",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    objDb.DropTrigger(strDataBase, TreeExplorer.SelectedNode.Text);
                    TreeExplorer.SelectedNode.Remove();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropTrigger - " + ex.Message);
            }
            return false;
        }

        private bool DropProcedure(string strDataBase)
        {
            try
            {
                if (MessageBox.Show("Really Drop Procedure '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop Procedure", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    objDb.DropProcedure(strDataBase, TreeExplorer.SelectedNode.Text);
                    TreeExplorer.SelectedNode.Remove();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropProcedure - " + ex.Message);
            }
            return false;
        }

        private bool DropFunction(string strDataBase)
        {
            try
            {
                if (MessageBox.Show("Really Drop Function '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop Function", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {                    
                    objDb.DropFunction(strDataBase, TreeExplorer.SelectedNode.Text);
                    TreeExplorer.SelectedNode.Remove();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropFunction - " + ex.Message);
            }
            return false;
        }

        private bool DropView(string strDataBase)
        {
            try
            {
                if (MessageBox.Show("Really Drop View '" + TreeExplorer.SelectedNode.Text + "' ?", "Drop View",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    objDb.DropView(strDataBase, TreeExplorer.SelectedNode.Text);
                    TreeExplorer.SelectedNode.Remove();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropFunction - " + ex.Message);
            }
            return false;
        }

        private bool NewTable()
        {
            try
            {                
                string strDataBase = "";
                strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);

                Forms.frmTable objForm = new Forms.frmTable(objDock);
                objForm.objDock = objDock;
                objForm.strDataBase = strDataBase;
                objForm.TabText = "New Table";

                objForm.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);

                if (objForm.strTable == "")
                {
                    objForm.Close();
                    objForm.Dispose();
                }
                else
                {
                    LoadTables(strDataBase);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewTable - " + ex.Message);
            }
            return false;
        }

        private bool NewProcedure()
        {
            try
            {
                string strDataBase = "";
                strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);

                NewQuery(strDataBase, objDb.GetScriptNewProcedure(strDataBase));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewProcedure - " + ex.Message);
            }
            return false;
        }

        private bool NewFunction()
        {
            try
            {
                string strDataBase = "";
                strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);

                NewQuery(strDataBase, objDb.GetScriptNewFunction(strDataBase));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewFunction - " + ex.Message);
            }
            return false;
        }

        private bool NewView()
        {
            try
            {
                string strDataBase = "";
                strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);

                NewQuery(strDataBase, objDb.GetScriptNewView(strDataBase));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewView - " + ex.Message);
            }
            return false;
        }

        private bool NewTrigger()
        {
            try
            {
                string strDataBase = "";
                strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);

                NewQuery(strDataBase, objDb.GetScriptNewTrigger(strDataBase));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewTrigger - " + ex.Message);
            }
            return false;
        }

        
        private void NewQuery(string strDataBase, string strCode)
        {
            try
            {
                frmQuery objForm = new frmQuery(objDock);
                objForm.objDock = objDock;                
                intQuery += 1;
                objForm.strCode = strCode;

                objForm.strDataBase = strDataBase;
                objForm.LoadDataBases(strDataBase);
                objForm.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                objForm.TabText = "Query " + intQuery;
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewQuery - " + ex.Message);
            }
        }

        private void EditTable()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);
                string strTable = TreeExplorer.SelectedNode.Text;

                Forms.frmTable objForm = new Forms.frmTable(objDock);
                objForm.objDock = objDock;
                objForm.TabText = strTable;
                objForm.strDataBase = strDataBase;
                objForm.strTable = strTable;
                objForm.blnEditing = true;

                objForm.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("EditTable: " + ex.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AddNewUser()
        {
            try
            {
                Forms.frmAddNewUser objForm = new Forms.frmAddNewUser();
                objForm.ShowDialog();
                if (objForm.blnCreated)
                {
                    TreeExplorer.SelectedNode.Nodes.Clear();
                    LoadUsers(TreeExplorer.SelectedNode);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("AddNewUser: " + ex.Message.ToString());
            }
        }

        private void DropUser()
        {
            try
            {
                if (MessageBox.Show("Really Drop Uses " + TreeExplorer.SelectedNode.Text + " ?", "Drop User",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strUser = TreeExplorer.SelectedNode.Text;

                    if (objDb.Execute("DROP USER " + strUser + "; ", "information_schema"))
                    {
                        TreeExplorer.SelectedNode.Remove();                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DropUser: " + ex.Message.ToString());
            }
        }

        private void LoadUsers(TreeNode Node)
        {
            try
            {                
                DataTable Dt = new DataTable();
                Dt = objDb.GetDataTable("SELECT DISTINCT GRANTEE FROM USER_PRIVILEGES", "information_schema");
                if (Dt.Rows.Count > 0)
                {
                    string strUsers = "";
                    for (int intI = 0; intI < Dt.Rows.Count; intI++)
                    {
                        strUsers = Dt.Rows[intI]["GRANTEE"].ToString();
                        if (strUsers.IndexOf("@") > 0)
                        {
                            strUsers = strUsers.Substring(0, strUsers.IndexOf("@")).Replace("'", "");
                        }

                        objTreeview.AddNode(TreeExplorer, "Users", Dt.Rows[intI]["GRANTEE"].ToString(), Node, "U_" + strUsers, 11, false);
                    }
                }

            }
            catch (Exception ex)
            {                
                MessageBox.Show("LoadUsers: " + ex.Message.ToString());
            }
        }

        private void ChangePassword()
        {
            try
            {
                Forms.frmAddNewUser objForm = new Forms.frmAddNewUser();
                objForm.blnChangePassword = true;
                objForm.User = TreeExplorer.SelectedNode.Text;
                objForm.ShowDialog();
            }
            catch (Exception ex)
            {                
                MessageBox.Show("ChangePassword: " + ex.Message.ToString());
            }
        }

        private void BeginRenameTable()
        {
            try
            {
                TreeExplorer.LabelEdit = true;
                TreeExplorer.SelectedNode.BeginEdit();                
            }
            catch (Exception ex)
            {                
                MessageBox.Show("BeginRenameTable: " + ex.Message.ToString());
            }
        }

        private void EndRenameTable(string NewName)
        {
            try
            {
                string strDataBase = TreeExplorer.SelectedNode.Tag.ToString().Substring(TreeExplorer.SelectedNode.Tag.ToString().IndexOf("_") + 1);
                if (objDb.RenameTable(strDataBase, TreeExplorer.SelectedNode.Text, NewName) == true)
                {
                    TreeExplorer.SelectedNode.BeginEdit();
                    TreeExplorer.LabelEdit = false;                
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void NewQuery()
        {
            try
            {
                frmQuery objQuery = new frmQuery(objDock);
                objQuery.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                objQuery.objDock = objDock;
                Class.clsBase.intQuery += 1;
                objQuery.TabText = "Query " + Class.clsBase.intQuery;

                objQuery.LoadDataBases("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("NewQuery - " + ex.Message);
            }
        }

        private void Open()
        {
            try
            {
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.Filter = "All files (*.*)|*.*|SQL files (*.SQL)|*.SQL";
                OpenFileDialog1.FilterIndex = 2;
                OpenFileDialog1.RestoreDirectory = true;

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFile = OpenFileDialog1.FileName.ToString();

                    frmQuery objQuery = new frmQuery(objDock);
                    objQuery.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    objQuery.objDock = objDock;

                    objQuery.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    objQuery.LoadFile(strFile);

                    objQuery.TabText = strFile;
                    objQuery.Tag = "S";

                    objQuery.LoadDataBases("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open: " + ex.Message);
            }
        }

        #endregion







    }
}