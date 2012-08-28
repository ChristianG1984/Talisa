﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using SachsenCoder.Talisa.WpfGui.ViewModels;

namespace SachsenCoder.Talisa.WpfGui
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.MainWindow = new MainWindow();
            var viewModel = new MainWindowViewModel();

            this.MainWindow.DataContext = viewModel;
            this.MainWindow.Show();
        }
    }
}
