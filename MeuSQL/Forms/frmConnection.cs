using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace MeuSQL.Forms
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
        }

        Class.clsMySQL objDb = new Class.clsMySQL();
        DataSet Ds = new DataSet("Config");
        string strConfig = null;

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmConnection_Load(object sender, EventArgs e)
            {
                try
                {
                    this.KeyPreview = true;
                    this.Text = "Connection";
                    Class.clsMySQL.blnConnected = false;
                    if (LoadConfig())
                    {
                        LoadServers();
                    }
                    txtPassword.Focus();
                }
                catch (Exception ex)
                {
                }
            }

            private void frmConnection_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                try
                {
                    if (MessageBox.Show("Confirms exclusion config connection '" + cmbServer.Text + "' ", "Drop connection",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DeleteConfig())
                        {
                            Clear();
                            LoadServers();
                            MessageBox.Show("Connection successfully excluded!");
                        }
                    }
                }
                catch (Exception ex)
                {   
                 
                }

            }

            private void btnConnect_Click(object sender, EventArgs e)
            {
                Connect();
            }

            private void btnTest_Click(object sender, EventArgs e)
            {
                Test();
            }

            private void btnClear_Click(object sender, EventArgs e)
            {
                Clear();
            }

            private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
            {
                DisplayConfig(cmbServer.Text);
                txtPassword.Focus();
            }

            private void txtPassword_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    Connect();
                }
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------
        
        #region Methods

            private void Clear()
            {
                try
                {
                    cmbServer.Text = "";
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    cmbServer.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void Test()
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Class.clsMySQL.strConnection = "Persist Security Info=False;uid=" + txtUser.Text +
                                                   ";server=" + cmbServer.Text + ";PORT=" + txtPort.Text + ";pwd=" + txtPassword.Text + ";Allow User Variables=true";
                    
                    if (objDb.TestConnection())
                    {
                        MessageBox.Show("Connection successfully established!");
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }

            private void Connect()
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Class.clsMySQL.strConnection = "Persist Security Info=False;uid=" + txtUser.Text +
                                                   ";server=" + cmbServer.Text + ";PORT=" + txtPort.Text + ";pwd=" + txtPassword.Text + ";Allow User Variables=true";

                    if (objDb.TestConnection())
                    {
                        Class.clsMySQL.blnConnected = true;
                        Class.clsMySQL.strServer = cmbServer.Text;
                        AddConfig();
                        this.Cursor = Cursors.Default;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
            }

            private bool LoadConfig()
            {
                try
                {
                    strConfig = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Config.xml";
                    Ds.ReadXml(strConfig);
                    Ds.DataSetName = "Config";
                    Ds.Tables[0].Constraints.Add("pk_servidor", Ds.Tables[0].Columns[0], true);
                    return true;

                }
                catch (Exception ex)
                {
                }
                return false;
            }

            private void LoadServers()
            {
                try
                {
                    cmbServer.Items.Clear();
                    
                    if ((Ds.Tables[0].Rows.Count > 0))
                    {
                        for (int intI = 0; intI <= Ds.Tables[0].Rows.Count - 1; intI++)
                        {
                            cmbServer.Items.Add(Ds.Tables[0].Rows[intI][0].ToString());
                        }
                        cmbServer.Text = Ds.Tables[0].Rows[Ds.Tables[0].Rows.Count - 1][0].ToString();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            private void DisplayConfig(string strServidor)
            {
                try
                {
                    DataRow Dr = null;

                    Dr = Ds.Tables[0].Rows.Find(strServidor);

                    txtUser.Text = "";
                    txtPassword.Text = "";
                    
                    if ((Dr != null))
                    {
                        cmbServer.Text = Dr[0].ToString();
                        txtPort.Text = Dr[1].ToString();
                        txtUser.Text = Dr[2].ToString();
                        string strSenha = Dr[3].ToString();
                        if (!string.IsNullOrEmpty(strSenha))
                        {
                            txtPassword.Text = Class.clsCrypt.Decrypt(strSenha, cmbServer.Text);
                            chkSavePassword.Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            private void AddConfig()
            {
                try
                {
                    if (Ds.Tables.Count < 1)
                    {
                        NewXML();
                    }

                    DeleteConfig();

                    DataRow Dr = null;
                    Dr = Ds.Tables[0].Rows.Find(cmbServer.Text);
                    
                    if (Dr == null)
                    {
                        if (! Class.clsFunctions.IsNumeric(txtPort.Text))
                        {                            
                            txtPort.Text = "3306";                            
                        }
                                                
                        Dr = Ds.Tables[0].NewRow();

                        Dr[0] = cmbServer.Text;
                        Dr[1] = txtPort.Text;
                        Dr[2] = txtUser.Text;
                        if (chkSavePassword.Checked)
                        {
                            Dr[3] = Class.clsCrypt.Encrypt(txtPassword.Text, cmbServer.Text);
                        }
                        Ds.Tables[0].Rows.Add(Dr);
                        Ds.WriteXml(strConfig);
                    }
                    else
                    {
                        Dr[0] = cmbServer.Text;
                        Dr[1] = txtPort.Text;
                        Dr[2] = txtUser.Text;
                        if (chkSavePassword.Checked)
                        {
                            Dr[3] = Class.clsCrypt.Encrypt(txtPassword.Text, cmbServer.Text);
                        }
                        else
                        {
                            Dr[3] = "";
                        }
                        Ds.WriteXml(strConfig);
                    }

                    LoadServers();

                }
                catch (Exception ex)
                {
                }
            }

            private void NewXML()
            {
                try
                {
                    DataTable Dt = new DataTable("Connections");

                    Dt.Columns.Add(AddColuna("Server"));
                    Dt.Columns.Add(AddColuna("Port"));
                    Dt.Columns.Add(AddColuna("User"));
                    Dt.Columns.Add(AddColuna("Pass"));
                    Ds.Tables.Add(Dt);
                    Ds.Tables[0].Constraints.Add("pk_server", Ds.Tables[0].Columns[0], true);
                }
                catch (Exception ex)
                {
                }
            }


            private DataColumn AddColuna(string strColuna)
            {
                try
                {
                    DataColumn Dc = new DataColumn();
                    Dc.ColumnName = strColuna;
                    return Dc;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }


            private bool DeleteConfig()
            {
                try
                {
                    DataRow Dr = null;

                    Dr = Ds.Tables[0].Rows.Find(cmbServer.Text);
                    
                    if ((Dr != null))
                    {
                        Ds.Tables[0].Rows.Remove(Dr);
                        Ds.WriteXml(strConfig);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                }
                return false;
            }

        #endregion
        
    }

    
}
