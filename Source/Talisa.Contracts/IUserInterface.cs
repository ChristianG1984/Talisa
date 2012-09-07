using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts
{
    public interface IUserInterface
    {
        event Action<string> RawFlowCode;
        void ReceiveFlowTokenList(IEnumerable<FlowToken> data);
        void ReceiveFlowAst(FlowAst data);
    }
}
