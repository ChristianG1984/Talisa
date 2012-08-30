using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts
{
    public interface IUserInterface
    {
        event Action<string> RawFlowCode;
    }
}
