using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SachsenCoder.Talisa.Core;

namespace SachsenCoder.Talisa.WinFormsGui
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            var mainFlow = new CoreEntry(mainForm);
            
            Application.Run(mainForm);
        }
    }
}
