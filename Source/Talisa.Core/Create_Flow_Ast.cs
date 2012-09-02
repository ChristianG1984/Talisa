using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Core
{
    public class Create_Flow_Ast
    {
        public void Process(IEnumerable<FlowToken> data)
        {
            var tempFlowTokenList = new List<FlowToken>();
            FlowToken currentFlowToken = null;
            FlowToken previousFlowToken = null;

            foreach (var d in data) {

            }
        }

        public event Action<FlowAst> Result;
    }
}
