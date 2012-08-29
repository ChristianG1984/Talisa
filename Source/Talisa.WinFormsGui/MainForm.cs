using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SachsenCoder.Talisa.Contracts;

namespace SachsenCoder.Talisa.WinFormsGui
{
    public partial class MainForm : Form, IUserInterface
    {
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
