using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Acme.Common.Infrastructure;
using System.Windows;
using SachsenCoder.Talisa.WpfGui.Interfaces;

namespace SachsenCoder.Talisa.WpfGui.ViewModels
{
    public class MainWindowViewModel : IOpenFileGuiRequest
    {
        public event Action<OpenFileGuiMessage> RequestOpenFileGui;

        public ICommand OpenFileCommand
        {
            get
            {
                if (_openFile == null) {
                    _openFile = new RelayCommand(OpenFile);
                }
                return _openFile;
            }
        }

        private void OpenFile()
        {
            RequestOpenFileGui(new OpenFileGuiMessage());
        }

        private ICommand _openFile;
    }
}
