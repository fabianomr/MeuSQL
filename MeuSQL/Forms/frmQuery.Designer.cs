namespace MeuSQL
{
    partial class frmQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabResultGrid = new Crownwood.Magic.Controls.TabPage();
            this.dtgResult = new System.Windows.Forms.DataGridView();
            this.tabResultText = new Crownwood.Magic.Controls.TabPage();
            this.txtResult = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewQuery = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRendo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExecute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnResultsToGrid = new System.Windows.Forms.ToolStripButton();
            this.btnResultsToText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDataBase = new System.Windows.Forms.ToolStripLabel();
            this.cmbDataBase = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIntellisense = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRendo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScrCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScriCreProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScrCreFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScrCreTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScrCreView = new System.Windows.Forms.ToolStripMenuItem();
            this.lstvIntellisense = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.statusStrip1.SuspendLayout();
            this.tabResultGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.tabResultText.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResult});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // lblResult
            // 
            this.lblResult.Name = "lblResult";
            resources.ApplyResources(this.lblResult, "lblResult");
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabResultGrid;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabResultGrid,
            this.tabResultText});
            // 
            // tabResultGrid
            // 
            this.tabResultGrid.Controls.Add(this.dtgResult);
            resources.ApplyResources(this.tabResultGrid, "tabResultGrid");
            this.tabResultGrid.Name = "tabResultGrid";
            // 
            // dtgResult
            // 
            this.dtgResult.BackgroundColor = System.Drawing.Color.White;
            this.dtgResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgResult, "dtgResult");
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.ShowCellErrors = false;
            this.dtgResult.ShowRowErrors = false;
            // 
            // tabResultText
            // 
            this.tabResultText.Controls.Add(this.txtResult);
            resources.ApplyResources(this.tabResultText, "tabResultText");
            this.tabResultText.Name = "tabResultText";
            this.tabResultText.Selected = false;
            // 
            // txtResult
            // 
            resources.ApplyResources(this.txtResult, "txtResult");
            this.txtResult.IsReadOnly = false;
            this.txtResult.Name = "txtResult";
            this.txtResult.ShowEOLMarkers = true;
            this.txtResult.ShowSpaces = true;
            this.txtResult.ShowTabs = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewQuery,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator4,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator5,
            this.btnUndo,
            this.btnRendo,
            this.toolStripSeparator6,
            this.btnExecute,
            this.toolStripSeparator1,
            this.btnResultsToGrid,
            this.btnResultsToText,
            this.toolStripSeparator2,
            this.lblDataBase,
            this.cmbDataBase,
            this.toolStripSeparator3,
            this.btnRefresh,
            this.toolStripSeparator7,
            this.btnIntellisense});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnNewQuery
            // 
            this.btnNewQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnNewQuery, "btnNewQuery");
            this.btnNewQuery.Name = "btnNewQuery";
            this.btnNewQuery.Click += new System.EventHandler(this.btnNewQuery_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnCut, "btnCut");
            this.btnCut.Name = "btnCut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnPaste, "btnPaste");
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRendo
            // 
            this.btnRendo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRendo, "btnRendo");
            this.btnRendo.Name = "btnRendo";
            this.btnRendo.Click += new System.EventHandler(this.btnRendo_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // btnExecute
            // 
            resources.ApplyResources(this.btnExecute, "btnExecute");
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnResultsToGrid
            // 
            this.btnResultsToGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnResultsToGrid, "btnResultsToGrid");
            this.btnResultsToGrid.Name = "btnResultsToGrid";
            this.btnResultsToGrid.Click += new System.EventHandler(this.btnResultsToGrid_Click);
            // 
            // btnResultsToText
            // 
            this.btnResultsToText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnResultsToText, "btnResultsToText");
            this.btnResultsToText.Name = "btnResultsToText";
            this.btnResultsToText.Click += new System.EventHandler(this.btnResultsToText_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // lblDataBase
            // 
            this.lblDataBase.Name = "lblDataBase";
            resources.ApplyResources(this.lblDataBase, "lblDataBase");
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Name = "cmbDataBase";
            resources.ApplyResources(this.cmbDataBase, "cmbDataBase");
            this.cmbDataBase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDataBase_KeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // btnIntellisense
            // 
            this.btnIntellisense.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnIntellisense, "btnIntellisense");
            this.btnIntellisense.Name = "btnIntellisense";
            this.btnIntellisense.Click += new System.EventHandler(this.btnIntellisense_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExecute,
            this.toolStripMenuItem1,
            this.mnuUndo,
            this.mnuRendo,
            this.toolStripMenuItem2,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.toolStripMenuItem3,
            this.mnuFind,
            this.mnuFindReplace,
            this.toolStripMenuItem4,
            this.mnuSelectAll,
            this.toolStripMenuItem5,
            this.mnuScript});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // mnuExecute
            // 
            resources.ApplyResources(this.mnuExecute, "mnuExecute");
            this.mnuExecute.Name = "mnuExecute";
            this.mnuExecute.Click += new System.EventHandler(this.mnuExecute_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // mnuUndo
            // 
            resources.ApplyResources(this.mnuUndo, "mnuUndo");
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRendo
            // 
            resources.ApplyResources(this.mnuRendo, "mnuRendo");
            this.mnuRendo.Name = "mnuRendo";
            this.mnuRendo.Click += new System.EventHandler(this.mnuRendo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // mnuCut
            // 
            resources.ApplyResources(this.mnuCut, "mnuCut");
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            resources.ApplyResources(this.mnuCopy, "mnuCopy");
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            resources.ApplyResources(this.mnuPaste, "mnuPaste");
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // mnuFind
            // 
            this.mnuFind.Name = "mnuFind";
            resources.ApplyResources(this.mnuFind, "mnuFind");
            this.mnuFind.Click += new System.EventHandler(this.mnuFind_Click);
            // 
            // mnuFindReplace
            // 
            this.mnuFindReplace.Name = "mnuFindReplace";
            resources.ApplyResources(this.mnuFindReplace, "mnuFindReplace");
            this.mnuFindReplace.Click += new System.EventHandler(this.mnuFindReplace_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            resources.ApplyResources(this.mnuSelectAll, "mnuSelectAll");
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // mnuScript
            // 
            this.mnuScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScrCreate});
            this.mnuScript.Name = "mnuScript";
            resources.ApplyResources(this.mnuScript, "mnuScript");
            // 
            // mnuScrCreate
            // 
            this.mnuScrCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScriCreProcedure,
            this.mnuScrCreFunction,
            this.mnuScrCreTrigger,
            this.mnuScrCreView});
            this.mnuScrCreate.Name = "mnuScrCreate";
            resources.ApplyResources(this.mnuScrCreate, "mnuScrCreate");
            // 
            // mnuScriCreProcedure
            // 
            this.mnuScriCreProcedure.Name = "mnuScriCreProcedure";
            resources.ApplyResources(this.mnuScriCreProcedure, "mnuScriCreProcedure");
            this.mnuScriCreProcedure.Click += new System.EventHandler(this.mnuScriCreProcedure_Click);
            // 
            // mnuScrCreFunction
            // 
            this.mnuScrCreFunction.Name = "mnuScrCreFunction";
            resources.ApplyResources(this.mnuScrCreFunction, "mnuScrCreFunction");
            this.mnuScrCreFunction.Click += new System.EventHandler(this.mnuScrCreFunction_Click);
            // 
            // mnuScrCreTrigger
            // 
            this.mnuScrCreTrigger.Name = "mnuScrCreTrigger";
            resources.ApplyResources(this.mnuScrCreTrigger, "mnuScrCreTrigger");
            this.mnuScrCreTrigger.Click += new System.EventHandler(this.mnuScrCreTrigger_Click);
            // 
            // mnuScrCreView
            // 
            this.mnuScrCreView.Name = "mnuScrCreView";
            resources.ApplyResources(this.mnuScrCreView, "mnuScrCreView");
            this.mnuScrCreView.Click += new System.EventHandler(this.mnuScrCreView_Click);
            // 
            // lstvIntellisense
            // 
            this.lstvIntellisense.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstvIntellisense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstvIntellisense.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1});
            this.lstvIntellisense.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstvIntellisense.HideSelection = false;
            resources.ApplyResources(this.lstvIntellisense, "lstvIntellisense");
            this.lstvIntellisense.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items5"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items6"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lstvIntellisense.Items7")))});
            this.lstvIntellisense.MultiSelect = false;
            this.lstvIntellisense.Name = "lstvIntellisense";
            this.lstvIntellisense.ShowGroups = false;
            this.lstvIntellisense.ShowItemToolTips = true;
            this.lstvIntellisense.UseCompatibleStateImageBehavior = false;
            this.lstvIntellisense.View = System.Windows.Forms.View.Details;
            this.lstvIntellisense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvIntellisense_KeyDown);
            // 
            // ColumnHeader1
            // 
            resources.ApplyResources(this.ColumnHeader1, "ColumnHeader1");
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // textEditorControl1
            // 
            resources.ApplyResources(this.textEditorControl1, "textEditorControl1");
            this.textEditorControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.ShowEOLMarkers = true;
            this.textEditorControl1.ShowSpaces = true;
            this.textEditorControl1.ShowTabs = true;
            // 
            // frmQuery
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstvIntellisense);
            this.Controls.Add(this.textEditorControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmQuery";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmQuery_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabResultGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.tabResultText.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabResultGrid;
        private Crownwood.Magic.Controls.TabPage tabResultText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExecute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnResultsToGrid;
        private System.Windows.Forms.ToolStripButton btnResultsToText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblDataBase;
        private System.Windows.Forms.ToolStripComboBox cmbDataBase;
        private ICSharpCode.TextEditor.TextEditorControl txtResult;
        private System.Windows.Forms.ToolStripStatusLabel lblResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuExecute;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRendo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuFindReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRendo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnIntellisense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuScript;
        private System.Windows.Forms.ToolStripMenuItem mnuScrCreate;
        private System.Windows.Forms.ToolStripMenuItem mnuScriCreProcedure;
        private System.Windows.Forms.ToolStripMenuItem mnuScrCreFunction;
        private System.Windows.Forms.DataGridView dtgResult;
        internal System.Windows.Forms.ListView lstvIntellisense;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.Splitter splitter1;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.ToolStripMenuItem mnuScrCreTrigger;
        private System.Windows.Forms.ToolStripButton btnNewQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuScrCreView;
    }
}