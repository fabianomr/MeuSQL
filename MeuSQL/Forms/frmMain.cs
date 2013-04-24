using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Resources;
using System.Globalization;
using System.Threading;


namespace MeuSQL
{
    public partial class frmMain : Form
    {          

        frmExplorer objExplorer;
        
        public frmMain()
        {
            InitializeComponent();
            objExplorer = new frmExplorer(objDock);   
        }

        //------------------------------------------------------------------------------------------------------------------

        #region Form Events

            private void frmMain_Load(object sender, EventArgs e)
            {
                try
                {
                    this.IsMdiContainer = true;
                    ShowExplorer();

                    this.Height = Convert.ToInt16(Convert.ToDouble(Screen.PrimaryScreen.WorkingArea.Height) / 1.2);
                    this.Width = Convert.ToInt16(Convert.ToDouble(Screen.PrimaryScreen.WorkingArea.Width) / 1.2);

                    this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
                        
                    #if DEBUG
                        this.Text = "MeuSQL";
                    #else
                        this.Text = "MeuSQL - version " + Application.ProductVersion.ToString() + " Beta";
                    #endif
                }
                catch (Exception ex)
                {   
                 
                }        
            }

        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Object Events

            private void mnuFilExit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
   
            private void mnuAbout_Click(object sender, EventArgs e)
            {
                ShowAbou();
            }

            private void mnuViewExplorer_Click(object sender, EventArgs e)
            {
                objExplorer = new frmExplorer(objDock);   
                ShowExplorer();
            }
        #endregion

        //------------------------------------------------------------------------------------------------------------------

        #region Methods
        
            public void ShowExplorer(){
                try 
	            {                    
                    objExplorer.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
                    objExplorer.objDock = objDock;
                    objExplorer.TabText = "Explorer";
	            }
	            catch (Exception ex)
	            {		
		            MessageBox.Show("ShowExplorer: " + ex.Message.ToString());
	            }
            }

            public void ShowNews()
            {
                try
                {
                    Forms.frmNews objNews = new Forms.frmNews();                    
                    objNews.Show(objDock, WeifenLuo.WinFormsUI.Docking.DockState.Document);
                    objNews.TabText = "News";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ShowNews: " + ex.Message.ToString());
                }
            }


            public void ShowAbou()
            {
                try
                {
                    Forms.frmAbout objAbou = new Forms.frmAbout();
                    objAbou.ShowDialog();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ShowAbou: " + ex.Message.ToString());
                }
            }
        
        #endregion
    }
}
