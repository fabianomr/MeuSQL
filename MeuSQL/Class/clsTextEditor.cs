using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

using System.Windows.Forms;

namespace MeuSQL.Class
{
    class clsTextEditor
    {

        public void ConfigEditor(TextEditorControl Edit)
        {
            try
            {
                Edit.Text = "";

                Edit.ShowEOLMarkers = false;
                Edit.ShowHRuler = false;
                Edit.ShowInvalidLines = false;
                Edit.ShowMatchingBracket = false;
                Edit.ShowSpaces = false;
                Edit.ShowTabs = false;
                Edit.ShowVRuler = false;
                Edit.AllowDrop = true;
                Edit.AutoScroll = true;
                Edit.ShowHRuler = false;
                //Edit.UseAntiAliasFont = true;

                Edit.AutoScroll = true;
                Edit.Location = new System.Drawing.Point(0, 0);
                Edit.Name = "textEditorControl";
                Edit.ShowInvalidLines = false;
                Edit.Size = new System.Drawing.Size(472, 454);
                Edit.TabIndex = 0;
                Edit.Visible = true;

                string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                HighlightingManager.Manager.AddSyntaxModeFileProvider(new FileSyntaxModeProvider(strPath));
                Edit.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");
                Edit.Encoding = System.Text.Encoding.Default;

                Edit.IsIconBarVisible = false;
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
        }

        public void ConfigEditor(TextEditorControl Edit, bool blnText)
        {
            try
            {
                Edit.Text = "";

                Edit.ShowEOLMarkers = false;
                Edit.ShowHRuler = false;
                Edit.ShowInvalidLines = false;
                Edit.ShowMatchingBracket = false;
                Edit.ShowSpaces = false;
                Edit.ShowTabs = false;
                Edit.ShowVRuler = false;
                Edit.AllowDrop = true;
                Edit.AutoScroll = true;
                Edit.ShowHRuler = false;
                // Edit.UseAntiAliasFont = true;

                Edit.AutoScroll = true;
                Edit.Location = new System.Drawing.Point(0, 0);
                Edit.Name = "textEditorControl";
                Edit.ShowInvalidLines = false;
                Edit.Size = new System.Drawing.Size(472, 454);
                Edit.TabIndex = 0;
                Edit.Visible = true;

                Edit.Encoding = System.Text.Encoding.Default;

                Edit.IsIconBarVisible = false;
            }
            catch (Exception ex)
            {                
                throw(ex);
            }
        }
    }
}
