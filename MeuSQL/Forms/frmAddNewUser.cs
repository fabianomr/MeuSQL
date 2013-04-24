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
    public partial class frmAddNewUser : Class.clsBase
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        public bool blnCreated = false;
        public bool blnChangePassword = false;
        public string User = "";

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmAddNewUser_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

        #endregion


        #region Objects Events

            private void frmAddNewUser_Load(object sender, EventArgs e)
            {
                if (blnChangePassword)
                {
                    txtUsername.Text = User;
                    txtUsername.Enabled = false;
                    txtPassword.Focus();
                }
            }

            private void txtUsername_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }

            private void txtPassword_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    txtConfirm.Focus();
                    txtConfirm.SelectAll();
                }
            }

            private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Return)
                {
                    btnSave.Focus();
                }
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (Validated())
                {
                    if (!blnChangePassword)
                    {
                        AddNewUser(txtUsername.Text, txtPassword.Text);
                    }
                    else
                    {
                        ChangePassword(txtUsername.Text, txtPassword.Text);
                    }
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Methods

            private bool Validated()
            {
                try
                {
                    if (txtUsername .Text == "")
                    {
                        MessageBox.Show("Enter the username!");
                        txtUsername.Focus();
                        return false;
                    }

                    if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Enter the password!");
                        txtPassword.Focus();
                        return false;
                    }

                    if (txtConfirm.Text == "")
                    {
                        MessageBox.Show("Enter the confirm!");
                        txtConfirm.Focus();
                        return false;
                    }

                    if (txtPassword.Text != txtConfirm.Text)
                    {
                        MessageBox.Show("The password and confirmation are different!");
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Validated: " + ex.Message.ToString());
                }
                return true;
            }


            private void AddNewUser(string User, string Password)
            {
                try
                {
                    if (objDb.AddNewUser(User, Password, "information_schema"))
                    {
                        MessageBox.Show("User created successfully.");
                        blnCreated = true;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AddNewUser: " + ex.Message.ToString());                 
                }
            }

            private void ChangePassword(string User, string Password)
            {
                try
                {
                    if (objDb.ChangePassword(User, Password, "information_schema"))
                    {
                        MessageBox.Show("Password successfully changed.");                        
                        this.Close();
                    }
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show("AddNewUser: " + ex.Message.ToString());     
                }
            }

        #endregion

    }
}
