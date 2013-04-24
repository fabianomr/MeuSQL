namespace MeuSQL
{
    partial class frmExplorer 

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExplorer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLineUser = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDropUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLineRenameTable = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameTable = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeExplorer = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Server.gif");
            this.imageList1.Images.SetKeyName(1, "DataBase.gif");
            this.imageList1.Images.SetKeyName(2, "Folder.gif");
            this.imageList1.Images.SetKeyName(3, "Table.gif");
            this.imageList1.Images.SetKeyName(4, "procedure.gif");
            this.imageList1.Images.SetKeyName(5, "Column.gif");
            this.imageList1.Images.SetKeyName(6, "Parameter.gif");
            this.imageList1.Images.SetKeyName(7, "disconect.gif");
            this.imageList1.Images.SetKeyName(8, "PrimaryKey.gif");
            this.imageList1.Images.SetKeyName(9, "Refresh.gif");
            this.imageList1.Images.SetKeyName(10, "function.gif");
            this.imageList1.Images.SetKeyName(11, "User.gif");
            this.imageList1.Images.SetKeyName(12, "trigger.gif");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewDataBase,
            this.mnuLine1,
            this.mnuRefresh,
            this.mnuLine2,
            this.mnuNewTable,
            this.mnuNewTrigger,
            this.mnuNewView,
            this.mnuNewProcedure,
            this.mnuNewFunction,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuLineUser,
            this.mnuAddNewUser,
            this.mnuDropUser,
            this.mnuChangePassword,
            this.mnuLineRenameTable,
            this.mnuRenameTable});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 336);
            // 
            // mnuNewDataBase
            // 
            this.mnuNewDataBase.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewDataBase.Image")));
            this.mnuNewDataBase.Name = "mnuNewDataBase";
            this.mnuNewDataBase.Size = new System.Drawing.Size(168, 22);
            this.mnuNewDataBase.Text = "New DataBase";
            this.mnuNewDataBase.Click += new System.EventHandler(this.mnuNewDataBase_Click);
            // 
            // mnuLine1
            // 
            this.mnuLine1.Name = "mnuLine1";
            this.mnuLine1.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuRefresh.Image")));
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(168, 22);
            this.mnuRefresh.Text = "Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuLine2
            // 
            this.mnuLine2.Name = "mnuLine2";
            this.mnuLine2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuNewTable
            // 
            this.mnuNewTable.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewTable.Image")));
            this.mnuNewTable.Name = "mnuNewTable";
            this.mnuNewTable.Size = new System.Drawing.Size(168, 22);
            this.mnuNewTable.Text = "New Table";
            this.mnuNewTable.Click += new System.EventHandler(this.mnuNewTable_Click);
            // 
            // mnuNewView
            // 
            this.mnuNewView.Name = "mnuNewView";
            this.mnuNewView.Size = new System.Drawing.Size(168, 22);
            this.mnuNewView.Text = "New View";
            this.mnuNewView.Click += new System.EventHandler(this.mnuNewView_Click);
            // 
            // mnuNewProcedure
            // 
            this.mnuNewProcedure.Name = "mnuNewProcedure";
            this.mnuNewProcedure.Size = new System.Drawing.Size(168, 22);
            this.mnuNewProcedure.Text = "New Procedure";
            this.mnuNewProcedure.Click += new System.EventHandler(this.mnuNewProcedure_Click);
            // 
            // mnuNewFunction
            // 
            this.mnuNewFunction.Name = "mnuNewFunction";
            this.mnuNewFunction.Size = new System.Drawing.Size(168, 22);
            this.mnuNewFunction.Text = "New Function";
            this.mnuNewFunction.Click += new System.EventHandler(this.mnuNewFunction_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(168, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(168, 22);
            this.mnuDelete.Text = "Drop";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuLineUser
            // 
            this.mnuLineUser.Name = "mnuLineUser";
            this.mnuLineUser.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuAddNewUser
            // 
            this.mnuAddNewUser.Name = "mnuAddNewUser";
            this.mnuAddNewUser.Size = new System.Drawing.Size(168, 22);
            this.mnuAddNewUser.Text = "Add New User";
            this.mnuAddNewUser.Click += new System.EventHandler(this.mnuAddNewUser_Click);
            // 
            // mnuDropUser
            // 
            this.mnuDropUser.Name = "mnuDropUser";
            this.mnuDropUser.Size = new System.Drawing.Size(168, 22);
            this.mnuDropUser.Text = "Drop User";
            this.mnuDropUser.Click += new System.EventHandler(this.mnuDropUser_Click);
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(168, 22);
            this.mnuChangePassword.Text = "Change Password";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
            // 
            // mnuLineRenameTable
            // 
            this.mnuLineRenameTable.Name = "mnuLineRenameTable";
            this.mnuLineRenameTable.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuRenameTable
            // 
            this.mnuRenameTable.Name = "mnuRenameTable";
            this.mnuRenameTable.Size = new System.Drawing.Size(168, 22);
            this.mnuRenameTable.Text = "Rename Table";
            this.mnuRenameTable.Click += new System.EventHandler(this.mnuRenameTable_Click);
            // 
            // TreeExplorer
            // 
            this.TreeExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeExplorer.ImageIndex = 0;
            this.TreeExplorer.ImageList = this.imageList1;
            this.TreeExplorer.Location = new System.Drawing.Point(0, 25);
            this.TreeExplorer.Name = "TreeExplorer";
            this.TreeExplorer.SelectedImageIndex = 0;
            this.TreeExplorer.Size = new System.Drawing.Size(283, 269);
            this.TreeExplorer.TabIndex = 2;
            this.TreeExplorer.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeExplorer_AfterLabelEdit);
            this.TreeExplorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeExplorer_ItemDrag);
            this.TreeExplorer.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeExplorer_DragEnter);
            this.TreeExplorer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeExplorer_MouseDoubleClick);
            this.TreeExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeExplorer_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(283, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 269);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.toolStripSeparator1,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnNewQuery,
            this.toolStripSeparator3,
            this.btnOpen,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "toolStripButton2";
            this.btnRefresh.ToolTipText = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNewQuery
            // 
            this.btnNewQuery.Enabled = false;
            this.btnNewQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnNewQuery.Image")));
            this.btnNewQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewQuery.Name = "btnNewQuery";
            this.btnNewQuery.Size = new System.Drawing.Size(86, 22);
            this.btnNewQuery.Text = "New Query";
            this.btnNewQuery.Click += new System.EventHandler(this.btnNewQuery_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.ToolTipText = "Open Script";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuNewTrigger
            // 
            this.mnuNewTrigger.Name = "mnuNewTrigger";
            this.mnuNewTrigger.Size = new System.Drawing.Size(168, 22);
            this.mnuNewTrigger.Text = "New Trigger";
            this.mnuNewTrigger.Click += new System.EventHandler(this.mnuNewTrigger_Click);
            // 
            // frmExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 294);
            this.Controls.Add(this.TreeExplorer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExplorer";
            this.TabText = "frmExplorer";
            this.Load += new System.EventHandler(this.frmExplorer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView TreeExplorer;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripSeparator mnuLine2;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTable;
        private System.Windows.Forms.ToolStripMenuItem mnuNewDataBase;
        private System.Windows.Forms.ToolStripSeparator mnuLine1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator mnuLineUser;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDropUser;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameTable;
        private System.Windows.Forms.ToolStripSeparator mnuLineRenameTable;
        private System.Windows.Forms.ToolStripButton btnNewQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuNewView;
        private System.Windows.Forms.ToolStripMenuItem mnuNewProcedure;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFunction;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTrigger;
    }
}