using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.SmartData;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Core.Leafs
{
    public class Create_Flow_Ast
    {
        public void Process(FlowPatternResult data)
        {
            var flowAst = new FlowAst();

            foreach (var content in data.Content) {
                flowAst.Add(content);
            }

            Result(flowAst);
        }

        public event Action<FlowAst> Result;
    }
}
