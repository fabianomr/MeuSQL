using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Gui.CompletionWindow;

namespace MeuSQL
{
    public partial class frmQuery : Class.clsBase
    {
        public WeifenLuo.WinFormsUI.Docking.DockPanel objDock;
        
        public frmQuery(WeifenLuo.WinFormsUI.Docking.DockPanel objDock)
        {
            InitializeComponent();
        }

        Class.clsTextEditor objTextEditor = new Class.clsTextEditor();
        public string strCaption = "";
        public string strCode = "";
        public string strDataBase = "";
        private string strKey = "";
        
        DataTable Dt = new DataTable();

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmQuery_Load(object sender, EventArgs e)
            {
                try
                {
                    btnResultsToGrid.Checked = true;

                    this.textEditorControl1.ActiveTextAreaControl.TextArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
                                        
                    textEditorControl1.ActiveTextAreaControl.TextArea.KeyUp += this.textEditorControl1_KeyUp;

                    this.Text = strCaption;
                    this.TabText = strCaption;
                    this.Tag ="";
                    objTextEditor.ConfigEditor(textEditorControl1);
                    objTextEditor.ConfigEditor(txtResult, true);
                    
                    if (!string.IsNullOrEmpty(strCode))
                    {
                        textEditorControl1.Text = strCode;
                        tabControl1.Visible = Convert.ToBoolean(tabControl1.Visible == false);                                               
                    }
                   
                    textEditorControl1.AllowDrop = true;
                    this.AllowDrop = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load: " + ex.Message.ToString());
                }
            }

            private void frmQuery_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == System.Windows.Forms.Keys.F5)
                    {
                        ExecQuery();
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("frmQuery_KeyDown: " + ex.Message.ToString());
                }
            }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events

            private void mnuExecute_Click(object sender, EventArgs e)
            {
                ExecQuery();
            }

            private void mnuUndo_Click(object sender, EventArgs e)
            {
                textEditorControl1.Undo();
            }

            private void mnuRendo_Click(object sender, EventArgs e)
            {
                textEditorControl1.Redo();
            }

            private void mnuCut_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
            }

            private void mnuCopy_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
            }

            private void mnuPaste_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
            }

            private void mnuFind_Click(object sender, EventArgs e)
            {

            }

            private void mnuFindReplace_Click(object sender, EventArgs e)
            {

            }

            private void mnuSelectAll_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e);
            }

            private void textEditorControl1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (strKey == "CTRL+SPACE")
                {
                    e.Handled = true;
                }
            }

            protected override bool ProcessCmdKey(ref Message mg, Keys key)
            {
                try
                {
                    strKey = "";

                    if (key == (Keys.Control | Keys.Space))
                    {
                        strKey = "CTRL+SPACE";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.T))
                    {
                        strKey = "CTRL+T";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.L))
                    {
                        strKey = "CTRL+L";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.H))
                    {
                        strKey = "CTRL+H";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.R))
                    {
                        tabControl1.Visible = Convert.ToBoolean(tabControl1.Visible==false);
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.E))
                    {
                        strKey = "CTRL+E";

                        return false;
                    }
                    else if (key == (Keys.Control | Keys.G))
                    {
                        strKey = "CTRL+G";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.B))
                    {
                        //strKey = "CTRL+B";
                        cmbDataBase.Focus();
                        return false;
                    }

                    else if (key == (Keys.Control | Keys.N))
                    {
                        NewQuery("");
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.O))
                    {
                        strKey = "CTRL+O";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.S))
                    {
                        strKey = "CTRL+S";
                        return false;
                    }
                    else if (key == (Keys.Control | Keys.I))
                    {
                        strKey = "CTRL+I";
                        return false;
                    }

                    else
                        return base.ProcessCmdKey(ref mg, key);
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("ProcessCmdKey: " + ex.Message.ToString());
                }
                return false;
            }

            private void textEditorControl1_KeyUp(object sender, KeyEventArgs e)
            {
                try
                {
                    lstvIntellisense.Visible = false;


                    //Intelisense
                    if (((e.KeyValue == 190) || (strKey == "CTRL+SPACE")) && btnIntellisense.Checked)
                    {

                        lstvIntellisense.Width = 200;

                        Point pt;
                        pt = new Point(textEditorControl1.ActiveTextAreaControl.Caret.ScreenPosition.X, textEditorControl1.ActiveTextAreaControl.Caret.ScreenPosition.Y + 20);

                        lstvIntellisense.Width = 200;

                        pt.Y = (pt.Y + textEditorControl1.Font.Height);

                        if (pt.Y + lstvIntellisense.Height > this.Size.Height)
                        {
                            pt.Y = pt.Y - lstvIntellisense.Height - textEditorControl1.Font.Height;
                        }

                        if (pt.X + lstvIntellisense.Width > this.Size.Width)
                        {
                            pt.X = pt.X - lstvIntellisense.Width;
                        }

                        lstvIntellisense.Location = pt;

                        if (e.KeyValue == 190)
                        {
                            LoadIntelisense(Tipo.Columns);
                        }
                        else
                        {
                            LoadIntelisense(Tipo.Table);
                        }

                        
                        if (lstvIntellisense.Items.Count > 0)
                        {
                            lstvIntellisense.Visible = true;
                            lstvIntellisense.Items[0].Selected = true;
                            lstvIntellisense.Focus();
                        }                        
                    }

                }
                catch (Exception ex)
                {
                    
                }
            }


            private void TextArea_KeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    if ((strKey == "CTRL+SPACE") && btnIntellisense.Checked)
                    {
                        e.Handled = true;
                    }

                    switch (strKey)
                    {

                        case "CTRL+L": 
                            //MessageBox.Show("CTRL+L");
                            break;

                        case "CTRL+H": 
                            //MessageBox.Show("CTRL+H");
                            break;

                        case "CTRL+R":
                            tabControl1.Visible = Convert.ToBoolean(tabControl1.Visible == false);                                               
                            break;

                        case "CTRL+E":                             
                            ExecQuery();
                            break;

                        case "CTRL+O":
                             Open();
                            break;

                        case "CTRL+S":
                            Save();
                            break;

                        case "CTRL+T":
                            btnResultsToText.Checked = true;
                            btnResultsToGrid.Checked = false;
                            break;

                        case "CTRL+G":
                            btnResultsToGrid.Checked = true;
                            btnResultsToText.Checked = false;                            
                            break;
                        case "CTRL+I":
                            if (btnIntellisense.Checked)
                            {
                                btnIntellisense.Checked = false;
                            }
                            else { 
                                btnIntellisense.Checked = true; 
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {                    
                    
                }
            }

            private void btnExecute_Click(object sender, EventArgs e)
            {
                ExecQuery();
            }

            private void btnResultsToGrid_Click(object sender, EventArgs e)
            {
                ResultToGrid();
            }

            private void btnResultsToText_Click(object sender, EventArgs e)
            {
                ResultToText();
            }


            private void lstvIntellisense_KeyDown(object sender, KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        lstvIntellisense.Visible = false;
                        textEditorControl1.Focus();
                    }
                    else if (e.KeyCode == Keys.Back)
                    {
                        lstvIntellisense.Visible = false;
                        textEditorControl1.Focus();
                    }
                    else
                    {
                        Intellisense(e);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            private void btnOpen_Click(object sender, EventArgs e)
            {
                Open();
            }
        
            private void btnSave_Click(object sender, EventArgs e)
            {
                Save();
            }

            private void btnCut_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
            }

            private void btnCopy_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
            }

            private void btnPaste_Click(object sender, EventArgs e)
            {
                textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
            }

            private void btnUndo_Click(object sender, EventArgs e)
            {
                textEditorControl1.Undo();
                textEditorControl1.Update();
            }

            private void btnRendo_Click(object sender, EventArgs e)
            {
                textEditorControl1.Redo();
            }


            private void btnIntellisense_Click(object sender, EventArgs e)
            {
                btnIntellisense.Checked = Convert.ToBoolean(!btnIntellisense.Checked);
            }

            private void btnRefresh_Click(object sender, EventArgs e)
            {
                LoadDataBases("");
            }

            private void mnuScriCreProcedure_Click(object sender, EventArgs e)
            {
                NewQuery(objDb.GetScriptNewProcedure(cmbDataBase.Text));
            }

            private void mnuScrCreFunction_Click(object sender, EventArgs e)
            {
                NewQuery(objDb.GetScriptNewFunction(cmbDataBase.Text));
            }

            private void mnuScrCreTrigger_Click(object sender, EventArgs e)
            {
                NewQuery(objDb.GetScriptNewTrigger(cmbDataBase.Text));
            }

            private void mnuScrCreView_Click(object sender, EventArgs e)
            {
                NewQuery(objDb.GetScriptNewView(cmbDataBase.Text));
            }

            private void btnNewQuery_Click(object sender, EventArgs e)
            {
                NewQuery("");
            }

            private void cmbDataBase_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    textEditorControl1.Focus();
                }
            }




        #endregion
                

        //------------------------------------------------------------------------------------------------------------------


        #region Methods

            private bool ExecQuery()
            {
                this.Cursor = Cursors.WaitCursor;

                bool functionReturnValue = false;
                try
                {
                    string strQuery = null;
                    
                    if (textEditorControl1.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected)
                    {
                        strQuery = textEditorControl1.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
                    }
                    else
                    {
                        strQuery = textEditorControl1.Text;
                    }

                    if (strQuery.Trim().Length == 0)
                    {
                        return functionReturnValue;
                    }

                    if (SetBanco(strQuery))
                    {
                        return functionReturnValue;
                    }

                    dtgResult.DataSource = null;
                    txtResult.Text = "";

                    string[] aComandos = null;


                    if (strQuery.IndexOf("DELIMITER",0) >= 0)
                    {
                        string strDemilitador = GetDelimitador(strQuery).Trim();
                        aComandos = strQuery.Split(strDemilitador.ToCharArray());

                        for (int intI = 0; intI <= aComandos.Length -1 ; intI++)
                        {
                            strQuery = aComandos[intI];
                            if (strQuery.Length > 0)
                            {
                                RunQuery(strQuery);
                            }
                        }
                    }
                    else
                    {
                        RunQuery(strQuery);
                    }

                    splitter1.Visible = true;
                    tabControl1.Visible = true;

                    if (btnResultsToGrid.Checked)
                    {
                        tabControl1.SelectedTab = tabResultGrid;
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabResultText;
                    }
                    textEditorControl1.Focus();

                    return true;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("ExecQry - " + ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                return functionReturnValue;
            }


            private bool SetBanco(string strQuery)
            {
                try
                {
                    int intPos = strQuery.ToUpper().IndexOf("USE ");
                    string strDataBase = "";

                    if (intPos >= 0)
                    {
                        strDataBase = strQuery.Substring(strQuery.ToUpper().IndexOf("USE ") + 4);

                        intPos = strDataBase.IndexOf(" ");
                        if (intPos >= 0)
                        {
                            strDataBase = strDataBase.Substring(0, strDataBase.IndexOf(" ")).Trim();
                        }

                        intPos = strDataBase.IndexOf(";");
                        if (intPos >= 0)
                        {
                            strDataBase = strDataBase.Substring(0, strDataBase.IndexOf(";")).Trim();
                        }

                        for (int inti = 0; inti <= cmbDataBase.Items.Count - 1; inti++)
                        {
                            if (strDataBase.Trim().ToUpper() == Convert.ToString(cmbDataBase.Items[inti].ToString()).ToUpper())
                            {
                                cmbDataBase.Text = strDataBase.Trim();                                
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                return false;
            }

            private string GetDelimitador(string strQuery)
            {
                try
                {
                    int intIni = 0;
                    int intFim = 0;

                    intIni = strQuery.IndexOf("DELIMITER");
                    strQuery = strQuery.Substring(intIni + 9);
                    intFim = strQuery.IndexOf(System.Environment.NewLine);
                    return strQuery.Substring(0, intFim);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }


            private bool RunQuery(string strQuery)
            {
                try
                {
                    this.Cursor = Cursors.Arrow;

                    if (IsQuery(strQuery))
                    {
                        Dt = objDb.GetDataTable(strQuery, cmbDataBase.Text);

                        dtgResult.AutoGenerateColumns = true;
                        if (btnResultsToGrid.Checked)
                        {
                            dtgResult.DataSource = Dt;
                        }
                        else
                        {
                            txtResult.Text = BuildTable(Dt);
                        }

                        lblResult.Text = "  " + Dt.Rows.Count + " Record(s).";
                    }
                    else
                    {
                        if (strQuery.IndexOf("DELIMITER") == -1)
                        {
                            int IntQrdRegistrosAfetados = 0;
                            //strQuery = strQuery.Replace("\r", "");
                            //strQuery = strQuery.Replace("\n", "");
                            //strQuery = strQuery.Replace("\t", "");

                            if (objDb.Execute(strQuery, cmbDataBase.Text, IntQrdRegistrosAfetados))                            
                            {
                                lblResult.Text = "  " + IntQrdRegistrosAfetados + " Record(s).";
                            }
                        }
                    }
                    textEditorControl1.Focus();
                    this.Cursor = Cursors.Default;
                    return true;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("RunQuery - " + ex.Message);
                }
                return false;
            }

            private bool IsQuery(string strQuery)
            {
                try
                {
                    string[] aLine = null;
                    string strLine = "";
                    bool blnComentarioLinhas = false;

                    aLine = strQuery.Split(Convert.ToChar("\n"));

                    for (int intI = 0; intI <= aLine.Length; intI++)
                    {
                        strLine = aLine[intI].Trim();

                        strLine = strLine.Replace("\r", "");


                        if (strLine.Length > 0)
                        {

                            if (strLine.Substring(1, 1) == System.Environment.NewLine)
                            {
                                strLine = strLine.Substring(1);
                            }

                            if (strLine.Substring(1, 2).ToString() == "/*")
                            {
                                blnComentarioLinhas = true;
                            }

                            if (strLine.Substring(0, 2) != "--" & blnComentarioLinhas == false)
                            {
                                if (strLine.Substring(0, 6).ToUpper() == "SELECT" ||
                                    strLine.Substring(0, 4).ToUpper() == "CALL" ||
                                    strLine.Substring(0, 4).ToUpper() == "SHOW" ||
                                    strLine.Substring(0, 3).ToUpper() == "SET" ||
                                    strLine.Substring(0, 7).ToUpper() == "DECLARE")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            if (strLine.Substring(strLine.Length - 2, 2) == "*/")
                            {
                                blnComentarioLinhas = false;
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                }
                return false;
            }


            public string BuildTable(DataTable dt)
            {
                try
                {
                    StringBuilder result = new StringBuilder();
                    List<int> widths = new List<int>();
                    const char ColumnSeparator = '|';
                    const char HeadingUnderline = '-';

                    // determine width of each column based on widest of either column heading or values in that column
                    foreach (DataColumn col in dt.Columns)
                    {
                        int colWidth = int.MinValue;
                        foreach (DataRow row in dt.Rows)
                        {
                            int len = row[col.ColumnName].ToString().Length;
                            if (len > colWidth)
                            {
                                colWidth = len;
                            }
                        }
                        widths.Add(Convert.ToInt32((colWidth < col.ColumnName.Length ? col.ColumnName.Length + 1 : colWidth + 1)));
                    }

                    // write column headers
                    foreach (DataColumn col in dt.Columns)
                    {
                        result.Append(col.ColumnName.PadLeft(widths[col.Ordinal]));
                        result.Append(ColumnSeparator);
                    }
                    result.AppendLine();

                    // write heading underline
                    foreach (DataColumn col in dt.Columns)
                    {
                        string horizontal = new string(HeadingUnderline, widths[col.Ordinal]);
                        result.Append(horizontal.PadLeft(widths[col.Ordinal]));
                        result.Append(ColumnSeparator);
                    }
                    result.AppendLine();

                    // write each row
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            result.Append(row[col.ColumnName].ToString().PadLeft(widths[col.Ordinal]));
                            result.Append(ColumnSeparator);
                        }
                        result.AppendLine();
                    }

                    return result.ToString();

                }
                catch (Exception ex)
                {   
                }
                return "";
            }

            public bool LoadDataBases(string strDataBase)
            {
                try
                {
                    if (Class.clsMySQL.strConnection.ToString() != "")
                    {
                        DataTable Dt = new DataTable();

                        Dt = objDb.GetDataTable("SHOW DATABASES;", "information_schema");

                        if (Dt.Rows.Count > 0)
                        {
                            cmbDataBase.Items.Clear();
                            string strLastDataBase = "";
                            for (int intI = 0; intI <= Dt.Rows.Count - 1; intI++)
                            {
                                this.strDataBase = Convert.ToString(Dt.Rows[intI]["Database"]);
                                if (this.strDataBase != "information_schema" && this.strDataBase != "mysql" && this.strDataBase != "performance_schema" && this.strDataBase != "test")
                                {
                                    strLastDataBase = this.strDataBase;
                                }
                                incluir();
                            }

                            if (strDataBase != "")
                            {
                                cmbDataBase.Text = strDataBase;
                            }
                            else
                            {
                                cmbDataBase.Text = strLastDataBase;
                            }
                        }
                    }
                }               
                catch (Exception ex)
                {
                    MessageBox.Show("LoadDataBases - " + ex.Message);
                }
                return false;
            }


            private void incluir()
            {
                cmbDataBase.Items.Add(strDataBase);
                Application.DoEvents();
                cmbDataBase.Text = strDataBase;
            }

            private void ResultToGrid()
            {
                try
                {
                    btnResultsToGrid.Checked = true;
                    btnResultsToText.Checked = false;
                    tabControl1.TabPages[0].Selected = true;

                    textEditorControl1.Focus();
                }
                catch (Exception ex)
                {
                }
            }

            private void ResultToText()
            {
                try
                {
                    btnResultsToGrid.Checked = false;
                    btnResultsToText.Checked = true;
                    tabControl1.TabPages[1].Selected = true;

                    textEditorControl1.Focus();
                }
                catch (Exception ex)
                {

                }
            }

          
            private void Save()
            {
                 try
                {
                    string strFile = "";
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "All files (*.*)|*.*|SQL files (*.SQL)|*.SQL";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.OverwritePrompt = false;

                    if (this.Tag.ToString() != "S")
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            strFile = saveFileDialog1.FileName.ToString();
                            if (File.Exists(strFile))
                            {
                                if (MessageBox.Show("Já existe um arquivo com esse nome, deseja sobrescrever ?",
                                        "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                {
                                    return;
                                }                                
                            }
                        }
                    }
                    else
                    {
                        strFile = this.TabText;
                    }


                     if(strFile !=""){

                        if (File.Exists(strFile))
                        {
                            File.Delete(strFile);
                        }
                        
                        textEditorControl1.SaveFile(strFile);
                        this.TabText = strFile;
                        this.Tag = "S";
                        lblResult.Text = "Arquivo salvo com sucesso.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save: " + ex.Message);
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

            public void LoadFile(string strFile){
                try 
	            {
                    textEditorControl1.LoadFile(strFile);
	            }
	            catch (Exception ex)
	            {
                    MessageBox.Show("LoadFile: " + ex.Message);
	            }
            }


            private void NewQuery(string strCode)
            {
                try
                {
                    frmQuery objQuery = new frmQuery(objDock);
                    objQuery.strDataBase = cmbDataBase.Text;
                    objQuery.strCode = strCode;
                    objQuery.LoadDataBases(cmbDataBase.Text);

                    objQuery.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    objQuery.objDock = objDock;
                    intQuery += 1;
                    objQuery.TabText = "Query " + intQuery;
                }
                catch (Exception ex)
                {                                        
                }
            }

            public enum Tipo : int
            {
                Table = 0,
                Columns = 1                
            }


            private void LoadIntelisense(Tipo choise)
            {
                try
                {
                    string strField = "";
        
                    int intPFim = textEditorControl1.ActiveTextAreaControl.Caret.Offset;

                    if(choise == Tipo.Columns){
                        strField = "Field";
                    }

                    if(choise == Tipo.Table){                        
                        strField = "Tables_in_" + cmbDataBase.Text.ToString();
                    }

                    lstvIntellisense.Items.Clear();
                    string strTable = textEditorControl1.Text.Substring(0, intPFim);
                    string[] aWord = strTable.Split(' ');
                    // -- Trata Espa�os
                    if ((aWord.Length > 0))
                    {
                        strTable = aWord[(aWord.Length - 1)].ToString().Trim();
                    }
                    
                    // -- Trata Return
                    aWord = strTable.Split(('\r'));

                    if ((aWord.Length > 0))
                    {   
                        strTable = aWord[(aWord.Length - 1)].ToString().Trim();
                    }
                    if ((strTable.Length > 0) || choise == Tipo.Table)
                    {

                        //-- Dot
                        if (strTable.Length > 0)
                        {
                            if (strTable.Substring(strTable.Length - 1, 1) == ".")
                            {
                                strTable = strTable.Substring(0, strTable.Length - 1);
                            }
                        }

                        DataTable Dt = new DataTable();
                        if (choise == Tipo.Columns)
                        {
                            Dt = objDb.GetDataTable((" SHOW COLUMNS FROM " + (strTable + ";")), cmbDataBase.Text);
                        }else if(choise == Tipo.Table)
                        {
                            Dt = objDb.GetDataTable(" SHOW TABLES;", cmbDataBase.Text);
                        }
                        
                        if ((Dt.Rows.Count > 0))
                        {
                            for (int intI = 0; (intI
                                        <= (Dt.Rows.Count - 1)); intI++)
                            {
                                ListViewItem Item = new ListViewItem(Dt.Rows[intI][strField].ToString());
                                if(choise == Tipo.Columns){
                                    if ((Dt.Rows[intI]["Key"].ToString() != ""))
                                    {
                                        Item.ImageIndex = 0;
                                    }
                                    else
                                    {
                                        Item.ImageIndex = 1;
                                    }
                                }
                                lstvIntellisense.Items.Add(Item);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {                    
                    
                }
            }

            private bool Intellisense(System.Windows.Forms.KeyEventArgs e)
            {
                try
                {
                    if (e.KeyCode == System.Windows.Forms.Keys.Return)
                    {                        
                        int offset = textEditorControl1.ActiveTextAreaControl.TextArea.Caret.Offset;
                       
                        if (offset < 0)
                            offset = 0;

                        if (offset > textEditorControl1.Text.Length)
                            offset = textEditorControl1.Text.Length;

                        if (textEditorControl1.Text.Substring(offset - 1, 1) == "(")
                        {
                            offset--;
                            textEditorControl1.Text = textEditorControl1.Text.Remove(offset, 1);
                        }
                        textEditorControl1.Document.Replace(offset, 0, lstvIntellisense.SelectedItems[0].Text.ToString());
                       
                        textEditorControl1.ActiveTextAreaControl.TextArea.Caret.Position = textEditorControl1.Document.OffsetToPosition(offset + lstvIntellisense.SelectedItems[0].Text.Length);
                                                
                        lstvIntellisense.Visible = false;
 
                        textEditorControl1.Focus();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Intellisense - " + ex.Message);
                }
                return false;
            }

        #endregion





     
                        
    }
}
