using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SachsenCoder.Talisa.WpfGui.Interfaces;
using Microsoft.Win32;

namespace SachsenCoder.Talisa.WpfGui
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataContext(this.DataContext);
            this.DataContextChanged += (sender, args) =>
            {
                InitializeDataContext(args.NewValue);
            };
        }

        private void InitializeDataContext(object dataCtx)
        {
            _openFileGuiRequester = dataCtx as IOpenFileGuiRequest;
            if (_openFileGuiRequester != null) {
                _openFileGuiRequester.RequestOpenFileGui += new Action<OpenFileGuiMessage>(RequestOpenFileGui);
            }
        }

        private void RequestOpenFileGui(OpenFileGuiMessage obj)
        {
            var ofd = new OpenFileDialog();
            ofd.ShowDialog(this);
        }

        private IOpenFileGuiRequest _openFileGuiRequester;
    }
}
