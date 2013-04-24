namespace MeuSQL.Forms
{
    partial class frmTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTable));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModifyColumn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDropColumn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAfter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.grvTable = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabColumnsDetails = new Crownwood.Magic.Controls.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dtgResult = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.txtDDL = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTable)).BeginInit();
            this.tabColumnsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreate,
            this.toolStripSeparator1,
            this.btnModifyColumn,
            this.toolStripSeparator2,
            this.btnDropColumn,
            this.toolStripSeparator3,
            this.btnFirst,
            this.toolStripSeparator5,
            this.btnAfter,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(729, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCreate
            // 
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(61, 22);
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModifyColumn
            // 
            this.btnModifyColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyColumn.Image")));
            this.btnModifyColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModifyColumn.Name = "btnModifyColumn";
            this.btnModifyColumn.Size = new System.Drawing.Size(65, 22);
            this.btnModifyColumn.Text = "Modify";
            this.btnModifyColumn.Click += new System.EventHandler(this.btnModifyColumn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDropColumn
            // 
            this.btnDropColumn.Image = ((System.Drawing.Image)(resources.GetObject("btnDropColumn.Image")));
            this.btnDropColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDropColumn.Name = "btnDropColumn";
            this.btnDropColumn.Size = new System.Drawing.Size(53, 22);
            this.btnDropColumn.Text = "Drop";
            this.btnDropColumn.Click += new System.EventHandler(this.btnDropColumn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(49, 22);
            this.btnFirst.Text = "First";
            this.btnFirst.Click += new System.EventHandler(this.btnUpColumn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAfter
            // 
            this.btnAfter.Enabled = false;
            this.btnAfter.Image = ((System.Drawing.Image)(resources.GetObject("btnAfter.Image")));
            this.btnAfter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.Size = new System.Drawing.Size(53, 22);
            this.btnAfter.Text = "After";
            this.btnAfter.Click += new System.EventHandler(this.btnDownColumn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // grvTable
            // 
            this.grvTable.AllowUserToAddRows = false;
            this.grvTable.AllowUserToDeleteRows = false;
            this.grvTable.AllowUserToResizeColumns = false;
            this.grvTable.AllowUserToResizeRows = false;
            this.grvTable.BackgroundColor = System.Drawing.Color.White;
            this.grvTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvTable.Location = new System.Drawing.Point(0, 25);
            this.grvTable.MultiSelect = false;
            this.grvTable.Name = "grvTable";
            this.grvTable.ReadOnly = true;
            this.grvTable.RowHeadersVisible = false;
            this.grvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvTable.Size = new System.Drawing.Size(729, 276);
            this.grvTable.TabIndex = 4;
            this.grvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvTable_CellClick);
            this.grvTable.DoubleClick += new System.EventHandler(this.grvTable_DoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 301);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(729, 5);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.IDEPixelBorder = false;
            this.tabControl1.Location = new System.Drawing.Point(0, 306);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabColumnsDetails;
            this.tabControl1.Size = new System.Drawing.Size(729, 294);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabColumnsDetails,
            this.tabPage1});
            this.tabControl1.SelectionChanged += new System.EventHandler(this.tabControl1_SelectionChanged);
            // 
            // tabColumnsDetails
            // 
            this.tabColumnsDetails.Controls.Add(this.propertyGrid1);
            this.tabColumnsDetails.Controls.Add(this.dtgResult);
            this.tabColumnsDetails.Location = new System.Drawing.Point(0, 0);
            this.tabColumnsDetails.Name = "tabColumnsDetails";
            this.tabColumnsDetails.Size = new System.Drawing.Size(729, 269);
            this.tabColumnsDetails.TabIndex = 8;
            this.tabColumnsDetails.Title = "Columns Details";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(729, 269);
            this.propertyGrid1.TabIndex = 1;
            // 
            // dtgResult
            // 
            this.dtgResult.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResult.Location = new System.Drawing.Point(0, 0);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.Size = new System.Drawing.Size(729, 269);
            this.dtgResult.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDDL);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(729, 269);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Title = "DDL";
            // 
            // txtDDL
            // 
            this.txtDDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDDL.IsReadOnly = false;
            this.txtDDL.Location = new System.Drawing.Point(0, 0);
            this.txtDDL.Name = "txtDDL";
            this.txtDDL.ShowEOLMarkers = true;
            this.txtDDL.ShowSpaces = true;
            this.txtDDL.ShowTabs = true;
            this.txtDDL.Size = new System.Drawing.Size(729, 269);
            this.txtDDL.TabIndex = 0;
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grvTable);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTable";
            this.TabText = "frmTable";
            this.Text = "frmTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTable_FormClosing);
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTable)).EndInit();
            this.tabColumnsDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView grvTable;
        private System.Windows.Forms.Splitter splitter1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabColumnsDetails;
        private System.Windows.Forms.DataGridView dtgResult;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private ICSharpCode.TextEditor.TextEditorControl txtDDL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModifyColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDropColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        
        
        
        

    }
}