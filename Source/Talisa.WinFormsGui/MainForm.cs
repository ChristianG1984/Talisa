using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SachsenCoder.Talisa.Contracts;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.WinFormsGui
{
    public partial class MainForm : Form, IUserInterface
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public event Action<string> RawFlowCode;

        private void txtFlowCode_TextChanged(object sender, EventArgs e)
        {
            RawFlowCode(txtFlowCode.Text);
        }

        public void ReceiveFlowTokenList(IEnumerable<FlowToken> data)
        {
            treeFlowToken.SuspendLayout();
            treeFlowToken.Nodes.Clear();
            foreach (var d in data) {
                var node = new TreeNode();
                node.Text = d.TokenType.ToString();
                node.Nodes.Add(d.Content);
                node.Nodes.Add("Position: " + d.Position.ToString());
                node.Nodes.Add("Length: " + d.Length.ToString());
                node.ExpandAll();
                treeFlowToken.Nodes.Add(node);
            }
            treeFlowToken.ResumeLayout();
        }
    }
}
