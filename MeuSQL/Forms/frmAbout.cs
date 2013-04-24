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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events
            private void frmAbout_Load(object sender, EventArgs e)
            {
                lblVersion.Text = "Version " + Application.ProductVersion.ToString() + " Beta";
            }


            private void frmAbout_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events
            private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                System.Diagnostics.Process.Start("http://www.meusql.com.br");
            }
        #endregion


        //------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

    }
}
