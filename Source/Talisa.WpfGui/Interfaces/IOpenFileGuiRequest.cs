using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.WpfGui.Interfaces
{
    public interface IOpenFileGuiRequest
    {
        event Action<OpenFileGuiMessage> RequestOpenFileGui;
    }
}
