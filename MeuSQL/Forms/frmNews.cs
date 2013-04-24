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
    public partial class frmNews : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmNews()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmNews_Load(object sender, EventArgs e)
            {
                this.TabText = "News";
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion
    }
}
