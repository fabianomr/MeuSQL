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
    public partial class frmNewDataBase : Form
    {
        public frmNewDataBase()
        {
            InitializeComponent();
        }

        Class.clsMySQL objDb = new Class.clsMySQL();

        public string strDataBase = "";
        public string strNewDataBaseName = "";
        public bool blnCreateNewDataBase = false;

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events

            private void frmNewDataBase_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (NewDataBase() == true)
                {
                    this.Close();
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void txtDataBaseName_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (NewDataBase() == true)
                    {
                        this.Close();
                    }
                }
            }


        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Methods

            private bool NewDataBase()
            {
                try
                {
                    if (objDb.Execute(" CREATE DATABASE  " + txtDataBaseName.Text + " ", strDataBase) == true)
                    {
                        strNewDataBaseName = txtDataBaseName.Text;
                        blnCreateNewDataBase = true;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NewDataBase: " + ex.Message.ToString());
                }
                return false;
            }

        #endregion


        
    }
}
