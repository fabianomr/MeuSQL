using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeuSQL.Forms
{
    public partial class frmAlterTable : Class.clsBase
    {

        public string strDataBase = "";
        public string strTable = "";
        public string strColumn = "";

        private bool blnKey = false;
        
        Class.clsTextEditor objTextEditor = new Class.clsTextEditor();

        private bool blnAlterKey = false;
        private bool blnAlterColumn = false;
        private bool blnAlterDataType = false;
        private bool blnAlterNotNull = false;
        private bool blnAlterDefault = false;
        private bool blnAlterComment = false;
        private bool blnAlterAutoincrement = false;
        private bool blnAlterLenght = false;
        private bool blnAlterUnsigned = false;
        private bool blnAlterZerofill = false;
        private bool blnAlterCharacterSet = false;
        private bool blnAlterCollation = false;
        private bool blnAlterBinary = false;
        private bool blnAlterDecimals = false;
        private bool blnAlterValues = false;

        private bool blnOldKey = false;
        private string strOldColumn = "";
        private string strOldDataType = "";
        private bool blnOldNotNull = false;
        private string strOldDefault = "";
        private string strOldComment = "";
        private bool blnOldAutoincrement = false;
        private string strOldLenght = "";
        private bool blnOldUnsigned = false;
        private bool blnOldZerofill = false;
        private bool blnOldCharacterSet = false;
        private string strOldCollation = "";
        private bool blnOldBinary = false;
        private string strOldDecimals = "";
        private string strOldValues = "";        
        
        public frmAlterTable()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmAlterTable_Load(object sender, EventArgs e)
            {
                try
                {
                    txtTableName.Text = strTable;
                    if (txtTableName.Text != "")
                    {
                        txtTableName.Enabled = false;                        
                    }
                    LoadData();
                    objTextEditor.ConfigEditor(txtDDL);
                    AddDataType();
                    this.KeyPreview = true;                    
                }
                catch (Exception ex)
                {   
                 
                }
            }

            private void frmAlterTable_Activated(object sender, EventArgs e)
            {
                if (txtTableName.Enabled == false)
                {
                    txtColumnName.Focus();
                }
            }

            private void frmAlterTable_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Objects Events

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();                
            }

            private void cmbDataType_SelectedValueChanged(object sender, EventArgs e)
            {
                LoadPropertyGrid(propertyGrid1, cmbDataType.Text);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (Validated())
                {
                    Changes();

                    // KEY Verify
                    if (blnAlterKey == true && blnAlterColumn == false && blnAlterDataType == false && blnAlterNotNull == false && blnAlterDefault == false && blnAlterComment == false
                        && blnAlterAutoincrement == false && blnAlterLenght == false && blnAlterUnsigned == false && blnAlterZerofill == false && blnAlterCharacterSet == false
                        && blnAlterCollation == false && blnAlterBinary == false && blnAlterDecimals == false && blnAlterValues == false)
                    {
                        string strQuery = "";
                        string strKey = "";

                        strQuery += "ALTER TABLE `"+ strDataBase  + "`.`"+ strTable +"` " + Environment.NewLine;
                        strQuery += "DROP PRIMARY KEY,";
                        strQuery += "" + Environment.NewLine;

                        strKey = objDb.GetKeys(strDataBase, strTable, txtColumnName.Text);

                        if (strKey != "")
                        {
                            if (strKey.Substring(strKey.Length - 1, 1) == ",")
                            {
                                strKey = strKey.Substring(0, strKey.Length - 1);
                            }
                        }

                        strQuery += "ADD PRIMARY KEY  USING BTREE(" + strKey + ")";

                        
                        if (objDb.Execute(strQuery, strDataBase))
                        {
                            strTable = txtTableName.Text;
                            this.Close();
                        }
                    }

                    
                    Save();
                }
            }

            private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                try
                {
                    Class.DataTypes.clsAuxiliaryCollation.strCharset = "";
                    if (propertyGrid1.SelectedGridItem.Label == "CharacterSet")
                    {
                        SetPropertyGridValue(propertyGrid1, "Collation", "Default");
                        Class.DataTypes.clsAuxiliaryCollation.strCharset = propertyGrid1.SelectedGridItem.Value.ToString();
                    }
                }
                catch (Exception ex)
                {   
                 
                }
            }

            private void tabControl1_SelectionChanged(object sender, EventArgs e)
            {
                ViewDDL();
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Methods

            private void AddDataType()
            {
                try
                {
                    cmbDataType.Items.Clear();
                    cmbDataType.Items.Add("");
                    cmbDataType.Items.Add("BIGINT");
                    cmbDataType.Items.Add("BINARY");
                    cmbDataType.Items.Add("BIT");
                    cmbDataType.Items.Add("BLOB");
                    cmbDataType.Items.Add("BOOL");
                    cmbDataType.Items.Add("CHAR");
                    cmbDataType.Items.Add("DATE");
                    cmbDataType.Items.Add("DATETIME");
                    cmbDataType.Items.Add("DECIMAL");
                    cmbDataType.Items.Add("DOUBLE");
                    cmbDataType.Items.Add("ENUM");
                    cmbDataType.Items.Add("FLOAT");
                    cmbDataType.Items.Add("INT");
                    cmbDataType.Items.Add("LONGBLOB");
                    cmbDataType.Items.Add("LONGTEXT");
                    cmbDataType.Items.Add("MEDIUMBLOB");
                    cmbDataType.Items.Add("MEDIUMINT");
                    cmbDataType.Items.Add("MEDIUMTEXT");
                    cmbDataType.Items.Add("SET");
                    cmbDataType.Items.Add("SMALLINT");
                    cmbDataType.Items.Add("TEXT");
                    cmbDataType.Items.Add("TIME");
                    cmbDataType.Items.Add("TIMESTAMP");
                    cmbDataType.Items.Add("TINYBLOB");
                    cmbDataType.Items.Add("TINYINT");
                    cmbDataType.Items.Add("TINYTEXT");
                    cmbDataType.Items.Add("VARBINARY");
                    cmbDataType.Items.Add("VARCHAR");
                    cmbDataType.Items.Add("YEAR");                                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AddDataType: " + ex.Message.ToString());
                }
            }

            private void Save()
            {
                try
                {
                    if (txtTableName.Text == "")
                    {
                        txtTableName.Focus();
                        MessageBox.Show("Ibform Table Name.");
                    }

                    string strQuery = "";

                    if (strTable == "")
                    {
                        strQuery = GetQueryNewTable();
                    }
                    else if (strColumn == "")
                    {
                        strQuery = GetQueryNewColumn();
                    }
                    else if (strColumn != "")
                    {
                        strQuery = GetQueryChangeColumn();
                    }

                    txtDDL.Text = strQuery;

                    if (objDb.Execute(strQuery, strDataBase))
                    {
                        strTable = txtTableName.Text;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save: " + ex.ToString());
                }
            }
         
            private string GetQueryNewTable(){
                string strQuery = "";
                try
                {                    
                    string strDataType = "";
                    string strSize = "";
                    string strUnsigned = "";
                    string strZerofill = "";
                    string strNotNull = "";
                    string strDefault = "";
                    string strAutoIncrement = "";
                    string strComment = "";

                    if (cmbDataType.Text == "DECIMAL")
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Decimal").ToString();
                    }
                    else
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Lenght").ToString();
                    }
                    strSize = strSize.Replace("(", "");
                    strSize = strSize.Replace(")", "");


                    if (strSize != "")
                    {
                        strDataType = cmbDataType.Text + "(" + strSize + ")";
                    }
                    else
                    {
                        strDataType = cmbDataType.Text;
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Unsigned") != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Unsigned")) == true)
                        {
                            strUnsigned = "UNSIGNED";
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Zerofill") != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Zerofill")) == true)
                        {
                            strZerofill = "zerofill";
                        }
                    }


                    strNotNull = "NULL";
                    if (chkNotNull.Checked)
                    {
                        strNotNull = "NOT NULL";
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Default").ToString() != "")
                    {
                        strDefault = "DEFAULT '" + GetPropertyGridValue(propertyGrid1, "Default") + "'";
                    }

                    strAutoIncrement = "";
                    if (GetPropertyGridValue(propertyGrid1, "Autoincrement") != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Autoincrement")) == true)
                        {
                            strAutoIncrement = "AUTO_INCREMENT";
                        }
                    }

                    if (txtComment.Text != "")
                    {
                        strComment = "COMMENT '" + txtComment.Text + "'";
                    }

                    strQuery = "CREATE TABLE `" + strDataBase + "`.`" + txtTableName.Text + "` (";
                    strQuery += "" + Environment.NewLine;
                    strQuery += "  `" + txtColumnName.Text + "` " + strDataType + " " + strUnsigned + " " + strZerofill + " " + strNotNull + " " + strAutoIncrement + " " + strDefault + " " + strComment + " ";
                    

                    if (chkKey.Checked)
                    {
                        strQuery += ", " + Environment.NewLine;
                        strQuery += " PRIMARY KEY (`" + txtColumnName.Text + "`)";
                    }

                    strQuery += "" + Environment.NewLine;
                    strQuery += ")";
                    
                }
                catch (Exception ex )
                {                    
                    MessageBox.Show("GetQueryNewTable: " + ex.ToString());
                }
                return strQuery;                
            }

            private string GetQueryNewColumn()
            {
                string strQuery = "";
                try
                {
                    string strDataType = "";
                    string strSize = "";
                    string strUnsigned = "";
                    string strZerofill = "";
                    string strNotNull = "";
                    string strDefault = "";
                    string strAutoIncrement = "";
                    string strComment = "";

                    if (cmbDataType.Text == "DECIMAL")
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Decimal").ToString();
                    }
                    else
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Lenght").ToString();
                    }

                    strSize = strSize.Replace("(", "");
                    strSize = strSize.Replace(")", "");

                    if (strSize != "")
                    {
                        strDataType = cmbDataType.Text + "(" + strSize + ")";
                    }
                    else
                    {
                        strDataType = cmbDataType.Text;
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Unsigned").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Unsigned")) == true)
                        {
                            strUnsigned = "UNSIGNED";
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Zerofill").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Zerofill")) == true)
                        {
                            strZerofill = "zerofill";
                        }
                    }

                    strNotNull = "NULL";
                    if (chkNotNull.Checked)
                    {
                        strNotNull = "NOT NULL";
                    }

                    if (txtDefault.Text != "")
                    {
                        strDefault = "DEFAULT '" + txtDefault.Text + "'";
                    }

                    strAutoIncrement = "";
                    if (GetPropertyGridValue(propertyGrid1, "Autoincrement").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Autoincrement")) == true)
                        {
                            strAutoIncrement = "AUTO_INCREMENT";
                        }
                    }

                    if (txtComment.Text != "")
                    {
                        strComment = "COMMENT '" + txtComment.Text + "'";
                    }

                    strQuery = "ALTER TABLE `" +
                                    strDataBase + "`.`" +
                                    txtTableName.Text +
                                    "` ADD COLUMN `" + txtColumnName.Text + "` " +
                                    strDataType + " " +
                                    strUnsigned + " " +
                                    strZerofill + " " +
                                    strNotNull + " " +
                                    strAutoIncrement + " " +
                                    strDefault + " " +
                                    strColumn +
                                    " AFTER `" + objDb.GetLadtColumnName(strDataBase, txtTableName.Text) + "`";

                    if (chkKey.Checked)
                    {
                        strQuery += ",";
                        strQuery += "" + Environment.NewLine;
                        strQuery += "DROP PRIMARY KEY ";
                        strQuery += "" + Environment.NewLine;

                        strQuery += " , ADD PRIMARY KEY  USING BTREE(" + objDb.GetKeys(strDataBase, txtTableName.Text, "") + "`" + txtColumnName.Text + "`)";
                    }

                    strQuery += ";";
                }
                catch (Exception ex)
                {   
                    MessageBox.Show("GetQueryNewColumn: " + ex.ToString());
                }

                return strQuery;
            }

            private string GetQueryChangeColumn()
            {
                string strQuery = "";
                try
                {
                    string strDataType = "";
                    string strSize = "";
                    string strUnsigned = "";
                    string strZerofill = "";
                    string strNotNull = "";
                    string strDefault = "";
                    string strAutoIncrement = "";
                    string strComment = "";
                    string strBinary = "";


                    if (cmbDataType.Text == "DECIMAL")
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Decimal").ToString();
                    }
                    else
                    {
                        strSize = GetPropertyGridValue(propertyGrid1, "Lenght").ToString();
                    }

                        
                    strSize = strSize.Replace("(", "");
                    strSize = strSize.Replace(")", "");
                    

                    if (strSize != "")
                    {
                        strDataType = cmbDataType.Text + "(" + strSize + ")";
                    }
                    else
                    {
                        strDataType = cmbDataType.Text;
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Unsigned").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Unsigned")) == true)
                        {
                            strUnsigned = "UNSIGNED";
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Zerofill").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Zerofill")) == true)
                        {
                            strZerofill = "zerofill";
                        }
                    }

                    strNotNull = "NULL";
                    if (chkNotNull.Checked)
                    {
                        strNotNull = "NOT NULL";
                    }

                    if (txtDefault.Text != "")
                    {
                        strDefault = "DEFAULT '" + txtDefault.Text + "'";
                    }

                    strAutoIncrement = "";
                    if (GetPropertyGridValue(propertyGrid1, "Autoincrement").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Autoincrement")) == true)
                        {
                            strAutoIncrement = "AUTO_INCREMENT";
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Binary").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Binary")) == true)
                        {
                            strBinary = "BINARY";
                        }
                    }

                    if (txtComment.Text != "")
                    {
                        strComment = "COMMENT '" + txtComment.Text + "'";
                    }

                    strQuery = "ALTER TABLE `" +
                                    strDataBase + "`.`" +
                                    txtTableName.Text +
                                    "` CHANGE COLUMN `" + strColumn + "` `" + txtColumnName.Text + "` " +
                                    strDataType + " " +
                                    strBinary + " " +
                                    strUnsigned + " " +
                                    strZerofill + " " +
                                    strNotNull + " " +
                                    strAutoIncrement + " " +
                                    strDefault + " " +
                                    strComment;

                    if (chkKey.Checked && blnKey == false)
                    {

                        string strKey = objDb.GetKeys(strDataBase, txtTableName.Text, strColumn);
                        if (strKey != "")
                        {
                            strQuery += ",";
                            strQuery += "" + Environment.NewLine;
                            strQuery += "DROP PRIMARY KEY ";
                            strQuery += "" + Environment.NewLine;
                        }

                        strQuery += " , ADD PRIMARY KEY  USING BTREE(" + objDb.GetKeys(strDataBase, txtTableName.Text, "") + "`" + txtColumnName.Text + "`)";
                    }

                    if (chkKey.Checked == false && blnKey == true)
                    {

                        strQuery += ",";
                        strQuery += "" + Environment.NewLine;
                        strQuery += "DROP PRIMARY KEY ";
                        strQuery += "" + Environment.NewLine;

                        string strKey = objDb.GetKeys(strDataBase, txtTableName.Text, strColumn);

                        if (strKey != "")
                        {

                            if (strKey.Substring(strKey.Length - 1, 1) == ",")
                            {
                                strKey = strKey.Substring(0, strKey.Length - 1);
                            }

                            strQuery += ", ADD PRIMARY KEY  USING BTREE(" + strKey + ")";
                        }
                    }

                    if (chkKey.Checked == true && blnKey == true)
                    {
                        string strKey = objDb.GetKeys(strDataBase, txtTableName.Text, strColumn);


                        if (strKey != "")
                        {
                            strQuery += ",";
                            strQuery += "" + Environment.NewLine;
                            strQuery += "DROP PRIMARY KEY ";
                            strQuery += "" + Environment.NewLine;

                            if (strKey.Substring(strKey.Length - 1, 1) == ",")
                            {
                                strKey = strKey.Substring(0, strKey.Length - 1);
                            }

                            strQuery += ", ADD PRIMARY KEY  USING BTREE(" + strKey + ")";
                        }
                    }

                    strQuery += ";";
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("GetQueryChangeColumn: " + ex.ToString());
                }

                return strQuery;
            }

            private void LoadData()
            {
                try
                {
                    if (strColumn != "")
                    {

                        string DataType = "";
                        string Size = "";

                        txtColumnName.Text = strColumn;
                        strOldColumn = strColumn;


                        DataTable Dt = new DataTable();

                        Dt = objDb.GetDataTable("show full columns from " + strTable + " like '" + strColumn + "'", strDataBase);
                         if (Dt.Rows.Count > 0)
                        {
                            if (Dt.Rows[0]["Key"].ToString() != "")
                            {
                                chkKey.Checked = true;
                                blnKey = true;
                                blnOldKey = true;
                            }

                            if (Dt.Rows[0]["Null"].ToString() == "NO")
                            {
                                chkNotNull.Checked = true;
                                blnOldNotNull = true;
                            }

                            txtDefault.Text = Dt.Rows[0]["Default"].ToString();
                            strOldDefault = Dt.Rows[0]["Default"].ToString();

                            txtComment.Text = Dt.Rows[0]["Comment"].ToString();
                            strOldComment = Dt.Rows[0]["Comment"].ToString();

                            DataType = Dt.Rows[0]["Type"].ToString();
                            if (DataType.IndexOf("(") > 0)
                            {
                                DataType = DataType.Substring(0, DataType.IndexOf("(")).ToUpper();
                                strOldDataType = DataType;
                                Size = Dt.Rows[0]["Type"].ToString();                                
                            }
                            if (Size.IndexOf("(") > 0)
                            {
                                Size = Size.Substring(Size.IndexOf("("));
                                Size = Size.Substring(0, Size.IndexOf(")"));
                                Size = Size.Replace("(", "");
                                Size = Size.Replace(")", "");                                
                            }
                            cmbDataType.Text = DataType;

                            LoadPropertyGrid(propertyGrid1, DataType);

                            if (DataType == "DECIMAL")
                            {
                                SetPropertyGridValue(propertyGrid1, "Decimal", Size);
                            }
                            else
                            {
                                SetPropertyGridValue(propertyGrid1, "Lenght", Size);
                            }

                            strOldLenght = Size; 
                                                         
                            if (Dt.Rows[0]["Type"].ToString().IndexOf("unsigned") > 0)
                            {
                                SetPropertyGridValue(propertyGrid1, "Unsigned", true);
                                blnOldUnsigned = true;
                            }

                            if (Dt.Rows[0]["Extra"].ToString() != "")
                            {
                                SetPropertyGridValue(propertyGrid1, "Autoincrement", true);
                                blnOldAutoincrement = true;
                            }

                            if (Dt.Rows[0]["Type"].ToString().IndexOf("zerofill") > 0)
                            {
                                SetPropertyGridValue(propertyGrid1, "Zerofill", true);
                                blnOldZerofill = true;
                            }

                            if (Dt.Rows[0]["Collation"].ToString() !="")
                            {
                                SetPropertyGridValue(propertyGrid1, "Collation", Dt.Rows[0]["Collation"].ToString());
                                strOldCollation = Dt.Rows[0]["Collation"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("LoadData: " + ex.Message.ToString());
                }
            }

            private void ViewDDL()
            {
                try
                {
                    if (tabControl1.SelectedTab.Title.ToString() == "DDL")
                    {
                        string strQuery = "";

                        if (strTable == "")
                        {
                            strQuery = GetQueryNewTable();
                        } else if (strColumn == "")
                        {
                            strQuery = GetQueryNewColumn();
                        } else if (strColumn != "")
                        {
                            strQuery = GetQueryChangeColumn();
                        }

                        txtDDL.Text = strQuery;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ViewDDL: " + ex.Message.ToString());
                }
            }

            private bool Validated()
            {
                try
                {
                    if (txtTableName.Text == "")
                    {
                        MessageBox.Show("Enter the table name!");
                        return false;
                    }
                    if (txtColumnName.Text == "")
                    {
                        MessageBox.Show("Enter the column name!");
                        return false;
                    }

                    if (cmbDataType.Text == "")
                    {
                        MessageBox.Show("Enter the DataType!");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Validated: " + ex.Message.ToString());
                }
                return true;
            }

            private void Changes()
            {
                try
                {

                    if (chkKey.Checked != blnOldKey){blnAlterKey = true;}
                    if (txtColumnName.Text != strOldColumn) { blnAlterColumn = true; }
                    if (cmbDataType.Text != strOldDataType) { blnAlterDataType = true; }
                    if (chkNotNull.Checked != blnOldNotNull){ blnAlterNotNull=true;}
                    if (txtDefault.Text  != strOldDefault)  { blnAlterDefault=true;}
                    if (txtComment.Text != strOldComment) { blnAlterComment = true; }

                    if (GetPropertyGridValue(propertyGrid1, "Unsigned") != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Unsigned")) != blnOldUnsigned)
                        {
                            blnAlterUnsigned = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Zerofill") != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Zerofill")) != blnOldZerofill)
                        {
                            blnAlterZerofill = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Autoincrement").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Autoincrement")) != blnOldAutoincrement)
                        {
                            blnAlterAutoincrement = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Binary").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Binary")) != blnOldBinary)
                        {
                            blnAlterBinary = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Lenght").ToString() != "")
                    {
                        if (Convert.ToString(GetPropertyGridValue(propertyGrid1, "Lenght")) != strOldLenght)
                        {
                            blnAlterLenght = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "CharacterSet").ToString() != "")
                    {
                        if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "CharacterSet")) != blnOldCharacterSet)
                        {
                            blnAlterCharacterSet = true;
                        }
                    }

                    if (GetPropertyGridValue(propertyGrid1, "Collation").ToString() != "")
                    {
                        if (Convert.ToString(GetPropertyGridValue(propertyGrid1, "Collation")) != strOldCollation)
                        {
                            blnAlterCollation = true;
                        }
                    }

                    //if (GetPropertyGridValue(propertyGrid1, "Decimals").ToString() != "")
                    //{
                    //    string strDecimals = "";

                    //    if (Convert.ToString(GetPropertyGridValue(propertyGrid1, "Decimals")) != strOldDecimals)
                    //    {
                    //        blnAlterDecimals = true;
                    //    }
                    //}

                    //if (GetPropertyGridValue(propertyGrid1, "Values").ToString() != "")
                    //{
                    //    if (Convert.ToBoolean(GetPropertyGridValue(propertyGrid1, "Values")) != blnOldBinary)
                    //    {
                    //        blnAlterBinary = true;
                    //    }
                    //}
                    
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("Changes: " + ex.Message.ToString());
                }
            }

        #endregion

    }
}
