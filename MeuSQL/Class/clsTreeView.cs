using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeuSQL.Class
{
    class clsTreeView
    {

        public bool AddNode(TreeView Tree, string strPai, string strTexto, TreeNode Node = null, string strTag = "", int intImageIndex = 0, bool blnExpandir = false)
        {
            try
            {
                for (int intI = 0; intI <= Tree.Nodes.Count - 1; intI++)
                {
                    if ((Node != null))
                    {
                        for (int intY = 0; intY <= Node.Nodes.Count - 1; intY++)
                        {
                            AddNode(Tree, strPai, strTexto, Node.Nodes[intY], strTag, intImageIndex);
                            if (blnExpandir)
                            {
                                Node.Nodes[intY].Expand();
                            }
                        }
                    }
                    if ((Node != null))
                    {
                        if (Node.Text == strPai)
                        {
                            TreeNode catNode = new TreeNode();
                            catNode.Text = strTexto;
                            catNode.Tag = strTag;
                            catNode.ImageIndex = intImageIndex;
                            catNode.SelectedImageIndex = intImageIndex;
                            Node.Nodes.Add(catNode);
                            if (blnExpandir)
                            {
                                Tree.Nodes[intI].Expand();
                            }
                        }

                    }
                    else
                    {
                        if (Tree.Nodes[intI].Text == strPai)
                        {
                            TreeNode catNode = new TreeNode();
                            catNode.Text = strTexto;
                            catNode.Tag = strTag;
                            catNode.ImageIndex = intImageIndex;
                            catNode.SelectedImageIndex = intImageIndex;
                            Tree.Nodes[intI].Nodes.Add(catNode);
                            if (blnExpandir)
                            {
                                Tree.Nodes[intI].Expand();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddNode - " + ex.Message);
                return false;
            }
            return true;
        }

    }
}
