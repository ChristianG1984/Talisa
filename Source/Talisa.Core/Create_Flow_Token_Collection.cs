using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Core
{
    public class Create_Flow_Token_Collection
    {
        public void Process(string data)
        {
            
        }

        public event Action<IEnumerable<FlowToken>> Result;
    }
}
