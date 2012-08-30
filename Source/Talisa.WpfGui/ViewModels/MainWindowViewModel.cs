using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using SachsenCoder.Talisa.WpfGui.Interfaces;
using DemoApp.ViewModel;
using Acme.Common.Infrastructure;
using SachsenCoder.Talisa.Contracts;

namespace SachsenCoder.Talisa.WpfGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, /*IUserInterface,*/ IOpenFileGuiRequest
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

        public string FlowCode
        {
            get { return _flowCode; }
            set
            {
                if (_flowCode == value) {
                    return;
                }
                _flowCode = value;
                base.OnPropertyChanged("FlowCode");
            }
        }

        private void OpenFile()
        {
            RequestOpenFileGui(new OpenFileGuiMessage());
        }

        private ICommand _openFile;

        private string _flowCode;
    }
}
