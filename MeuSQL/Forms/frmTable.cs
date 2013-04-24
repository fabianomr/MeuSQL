using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeuSQL.Forms
{
    public partial class frmTable : Class.clsBase
    {
        public WeifenLuo.WinFormsUI.Docking.DockPanel objDock;

        public string strDataBase = "";
        public string strTable = "";
        public bool blnEditing = false;

        Class.clsTextEditor objTextEditor = new Class.clsTextEditor();
        
        DataTable dtTableView = new DataTable();
        
        public frmTable(WeifenLuo.WinFormsUI.Docking.DockPanel objDock)
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmTable_Load(object sender, EventArgs e)
            {
                try
                {
                    objTextEditor.ConfigEditor(txtDDL);
                    LoadTableView(dtTableView);

                    if (!blnEditing)
                    {
                        grvTable.DataSource = dtTableView;
                        FormatGridView();
                        EnabledButton();
                        btnCreate_Click(sender, e);
                    }
                    else
                    {
                        this.TabText = strDataBase + " - " + strTable;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load: " + ex.Message.ToString());
                }
            }

            private void frmTable_FormClosing(object sender, FormClosingEventArgs e)
            {
                try
                {
                    grvTable.Dispose();
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("Closing: " + ex.Message.ToString());
                }
                
            }
        
        #endregion



        #region Objects Events

            private void tabControl1_SelectionChanged(object sender, EventArgs e)
            {
                ViewDDL();
            }

            private void grvTable_DoubleClick(object sender, EventArgs e)
            {
                Modify();
            }

            private void btnModifyColumn_Click(object sender, EventArgs e)
            {
                Modify();
            }

            private void btnDropColumn_Click(object sender, EventArgs e)
            {
                try
                {
                    if (grvTable.SelectedRows.Count > 0)
                    {
                        if (MessageBox.Show("Confirms drop column '" + grvTable.SelectedCells[1].Value.ToString() + "' ?", "Drop Column", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (grvTable.RowCount > 1)
                            {
                                if (DropColumn(strDataBase, strTable, grvTable.SelectedCells[1].Value.ToString(), Convert.ToBoolean(grvTable.SelectedCells[0].Value)))
                                {
                                    LoadData();
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Attention, removing this column erase the table, confirm?", "Drop Table",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                                {

                                    objDb.DropTable(strDataBase, strTable);
                                    strTable = "";
                                    dtTableView = new DataTable();
                                    LoadTableView(dtTableView);

                                    grvTable.DataSource = dtTableView;
                                    FormatGridView();
                                    EnabledButton();
                                    LoadPropertyGrid(propertyGrid1, "");
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("btnDropColumn_Click: " + ex.Message.ToString());
                }
            }

            private void btnCreate_Click(object sender, EventArgs e)
            {
                CreateColumn();
                if (strTable != "")
                {
                    this.TabText = strDataBase + " - " + strTable;
                    LoadData();

                    if (grvTable.RowCount == 1)
                    {
                        btnModifyColumn.Enabled = true;
                        btnDropColumn.Enabled = true;
                    }
                }
            }

            private void btnUpColumn_Click(object sender, EventArgs e)
            {
                try
                {
                    if (grvTable.SelectedRows.Count > 0)
                    {
                        MoveColumn(strDataBase, strTable, grvTable.SelectedCells[1].Value.ToString(), true);
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("btnUpColumn_Click: " + ex.Message.ToString());
                }                            
            }

            private void btnDownColumn_Click(object sender, EventArgs e)
            {
                MoveColumn(strDataBase, strTable, grvTable.SelectedCells[1].Value.ToString(), false);
            }

            private void grvTable_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    if (grvTable.SelectedRows.Count > 0)
                    {
                        btnModifyColumn.Enabled = true;
                        btnDropColumn.Enabled = true;

                        btnFirst.Enabled = false;
                        btnAfter.Enabled = false;
                        if (e.RowIndex > 0)
                        {
                            btnFirst.Enabled = true;
                        }
                        if (e.RowIndex < grvTable.Rows.Count - 1)
                        {
                            btnAfter.Enabled = true;
                        }
                        LoadColumn(grvTable.SelectedCells[1].Value.ToString());
                    }                    
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("grvTable_CellClick: " + ex.Message.ToString());
                }
            }

        #endregion



        #region Methods

            private void LoadTableView(DataTable dt)
            {
                try
                {                    
                    dt.Columns.Add("Key", System.Type.GetType("System.Boolean"));
                    dt.Columns.Add("Field", System.Type.GetType("System.String"));
                    dt.Columns.Add("Data Type", System.Type.GetType("System.String"));
                    dt.Columns.Add("Size", System.Type.GetType("System.String"));
                    dt.Columns.Add("Not Null", System.Type.GetType("System.Boolean"));
                    dt.Columns.Add("Default", System.Type.GetType("System.String"));
                    dt.Columns.Add("Comment", System.Type.GetType("System.String"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LoadTableView: " + ex.Message.ToString());
                }
            }

            private void FormatGridView()
            {
                try
                {
                    grvTable.Columns[0].Width = 50;
                    grvTable.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grvTable.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("FormatGridView: " + ex.Message.ToString());
                }
            }

            private void CreateColumn()
            {
                try
                {
                    frmAlterTable objForm = new frmAlterTable();
                    objForm.strDataBase = strDataBase;
                    objForm.strTable = strTable;
                    objForm.ShowDialog();
                    strTable = objForm.strTable;
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("CreateColumn: " + ex.Message.ToString());
                }
            }

            private void LoadData()
            {
                try
                {
                    DataTable Dt = new DataTable();

                    bool Key = false;
                    string Field = "";
                    string DataType = "";
                    string Size = "";
                    bool NotNull = false;
                    string Default = "";                    
                    string Comment = "";
                    string Collation = "";

                    Dt = objDb.GetDataTable("SHOW FULL COLUMNS FROM " + strTable, strDataBase);

                    dtTableView.Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        Key = false;
                        Field = "";
                        DataType = "";
                        Size = "";
                        NotNull = false;
                        Default = "";                        
                        Comment = "";
                        Collation = "";

                        if (Dt.Rows[i]["Key"].ToString() != "") { Key = true; }

                        Field = Dt.Rows[i]["Field"].ToString();

                        DataType = Dt.Rows[i]["Type"].ToString();
                        if (DataType.IndexOf("(") > 0)
                        {
                            DataType = DataType.Substring(0, DataType.IndexOf("("));
                            Size = Dt.Rows[i]["Type"].ToString();
                        }
                                                
                        if (Size.IndexOf("(") > 0 && Size.IndexOf("(") > 0)
                        {
                            Size = Size.Substring(Size.IndexOf("(") + 1, Size.IndexOf(")") - Size.IndexOf("(") - 1);
                        }
                        if (Dt.Rows[i]["Null"].ToString() == "NO") { NotNull = true; }

                        Default = Dt.Rows[i]["Default"].ToString();

                        Comment = Dt.Rows[i]["Comment"].ToString();

                        Collation = Dt.Rows[i]["Collation"].ToString();

                        dtTableView.Rows.Add(Key, Field, DataType, Size, NotNull, Default, Comment);
                        grvTable.DataSource = dtTableView;

                        //SetPropertyGridValue(propertyGrid1, "Lenght", Size);
                        //SetPropertyGridValue(propertyGrid1, "Default", Dt.Rows[0]["Type"].ToString());
                    } 
                    
                    if(Dt.Rows.Count == 0){
                        EnabledButton();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LoadData: " + ex.Message.ToString());
                }
            }

            private bool DropColumn(string DataBase, string TableName, string ColumnName, bool Key)
            {
                try
                {
                    string strQuery = "";
                    string strKey = "";
    
                    strQuery = "ALTER TABLE `" + DataBase + "`.`" + TableName + "` DROP COLUMN `" + ColumnName + "`";

                    if (Key)
                    {
                        strQuery += ",";
                        strQuery += "" + Environment.NewLine;
                        strQuery += "DROP PRIMARY KEY,";
                        strQuery += "" + Environment.NewLine;

                        strKey = objDb.GetKeys(DataBase, TableName, ColumnName);

                        if (strKey != "")
                        {
                            if (strKey.Substring(strKey.Length - 1, 1) == ",")
                            {
                                strKey = strKey.Substring(0, strKey.Length - 1);
                            }
                        }

                        strQuery += "ADD PRIMARY KEY  USING BTREE(" + strKey + ")";
                    }
                    strQuery += ";";

                    objDb.Execute(strQuery, DataBase);
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("DropColumn: " + ex.Message.ToString());
                    return false;
                }
                return true;
            }

            private void Modify()
            {
                try
                {
                    if (grvTable.SelectedRows.Count > 0){
                        frmAlterTable objForm = new frmAlterTable();
                        objForm.strDataBase = strDataBase;
                        objForm.strTable = strTable;
                        objForm.strColumn = grvTable.SelectedCells[1].Value.ToString();
                        objForm.ShowDialog();
                    LoadData();
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Modify: " + ex.Message.ToString());
                }
            }

            private void MoveColumn(string DataBase, string Table, string Column, bool blnFirst)
            {
                try
                {
                    DataTable Dt = new DataTable();
                    string OtherColumn = "";
                    string strQuery = "";
                    
                    Dt = objDb.GetDataTable("show full columns from " + Table + "", strDataBase);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        // First
                        if (blnFirst)
                        {
                            
                            if (Column == Dt.Rows[i]["Field"].ToString())
                            {
                                i -= 1;
                                OtherColumn = Dt.Rows[i]["Field"].ToString();
                                strQuery = GetCommandMoveColumn(DataBase, Table, Column, true, OtherColumn);
                                objDb.Execute(strQuery, DataBase);
                                i = Dt.Rows.Count;                                
                            }                           
                        }
                        
                        // After
                        if (!blnFirst)
                        {
                            if (Column == Dt.Rows[i]["Field"].ToString())
                            {
                                i += 1;
                                OtherColumn = Dt.Rows[i]["Field"].ToString();
                                strQuery = GetCommandMoveColumn(DataBase, Table, Column, false, OtherColumn);
                                objDb.Execute(strQuery, DataBase);
                                i = Dt.Rows.Count;
                            }
                        }
                    }
                    LoadData();
                }                    
                catch (Exception ex)
                {
                    MessageBox.Show("MoveColumn: " + ex.Message.ToString());
                }
            }

            private string GetCommandMoveColumn(string DataBase, string Table, string Column, bool blnFirst, string OtherColumn)
            {
                string strQuery = "";
                try
                {                    
                    DataTable Dt = new DataTable();
                    Dt = objDb.GetDataTable("show full columns from " + Table + " like '" + Column + "'", DataBase);

                    if (Dt.Rows.Count > 0)
                    {
                        string strDataType = "";                                                
                        string strZerofill = "";
                        string strNotNull = "NULL";
                        string strDefault = "";
                        string strAutoIncrement = "";
                        string strComment = "";

                        strDataType = Dt.Rows[0]["Type"].ToString();                        
                              
                        if (Dt.Rows[0]["Type"].ToString().IndexOf("zerofill") > 0)
                        {
                            strZerofill = "Zerofill";
                        }

                        if (Dt.Rows[0]["Null"].ToString() == "NO")
                        {
                            strNotNull = "NOT NULL";
                        }

                        if (Dt.Rows[0]["Default"].ToString() != "")
                        {
                            strDefault = "DEFAULT '" + Dt.Rows[0]["Default"].ToString() + "'";
                        }                                               
                                                
                        if (Dt.Rows[0]["Extra"].ToString() != "")
                        {
                            strAutoIncrement = "AUTO_INCREMENT";
                        }

                        if (Dt.Rows[0]["Comment"].ToString() != "")
                        {
                            strComment = "COMMENT '" + Dt.Rows[0]["Comment"].ToString() + "'";
                        }

                        strQuery = "ALTER TABLE `" +
                        strDataBase + "`.`" +
                        Table +
                        "` MODIFY  COLUMN `" + Column + "` " +
                        strDataType + " " +                                                                        
                        strZerofill + " " +
                        strNotNull + " " +
                        strAutoIncrement + " " +
                        strDefault + " " +
                        strComment;
                         
                        if (blnFirst)
                        {
                            strQuery += " FIRST ;";
                        }
                        else
                        {
                            strQuery += " AFTER " + OtherColumn + ";";
                        }
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("MoveColumn: " + ex.Message.ToString());
                }
                return strQuery;
            }

            private void ViewDDL()
            {
                try
                {
                    if (tabControl1.SelectedTab.Title.ToString() == "DDL")
                    {
                        txtDDL.Text = objDb.GetScriptTable(strDataBase,strTable);                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ViewDDL: " + ex.Message.ToString());
                }
            }

            private void LoadColumn(string Columns)
            {
                try
                {
                    string DataType = "";
                    string Size = "";
                                        
                    DataTable Dt = new DataTable();

                    Dt = objDb.GetDataTable("show full columns from " + strTable + " like '" + Columns + "'", strDataBase);
                    if (Dt.Rows.Count > 0)
                    {
                        DataType = Dt.Rows[0]["Type"].ToString();
                        if (DataType.IndexOf("(") > 0)
                        {
                            DataType = DataType.Substring(0, DataType.IndexOf("(")).ToUpper();
                            Size = Dt.Rows[0]["Type"].ToString();

                        }
                        if (Size.IndexOf("(") > 0)
                        {
                            Size = Size.Substring(Size.IndexOf("("));
                            Size = Size.Substring(0, Size.IndexOf(")"));
                            Size = Size.Replace("(", "");
                            Size = Size.Replace(")", "");
                        }

                        LoadPropertyGrid(propertyGrid1, DataType);

                        SetPropertyGridValue(propertyGrid1, "Lenght", Size);
                        
                        if (Dt.Rows[0]["Type"].ToString().IndexOf("unsigned") > 0)
                        {
                            SetPropertyGridValue(propertyGrid1, "Unsigned", true);
                        }

                        if (Dt.Rows[0]["Extra"].ToString() != "")
                        {
                            SetPropertyGridValue(propertyGrid1, "Autoincrement", true);
                        }

                        if (Dt.Rows[0]["Type"].ToString().IndexOf("zerofill") > 0)
                        {
                            SetPropertyGridValue(propertyGrid1, "Zerofill", true);
                        }

                        if (Dt.Rows[0]["Collation"].ToString() !="")
                        {
                            SetPropertyGridValue(propertyGrid1, "Collation", Dt.Rows[0]["Collation"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("LoadColumn: " + ex.Message.ToString());
                }
            }

            private void EnabledButton()
            {
                btnModifyColumn.Enabled = false;
                btnDropColumn.Enabled = false;
                btnFirst.Enabled = false;
                btnAfter.Enabled = false;
            }

        #endregion



    }
}
