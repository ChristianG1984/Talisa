using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;
using SachsenCoder.Talisa.Contracts.SmartData;

namespace SachsenCoder.Talisa.Core
{
    public class Create_Flow_Ast
    {
        public void Process(IEnumerable<FlowToken> data)
        {
            var commentPattern = new FlowPattern(FlowAstElementTypeEnum.Comment);
            commentPattern
                .Has(FlowTokenTypeEnum.HashSign)
                .Then().CanHaveAny()
                .Then().Has(FlowTokenTypeEnum.Linefeed);

            var matcher = new FlowPatternMatcher();
            matcher.Add(commentPattern);

            var tempFlowTokenList = new List<FlowToken>();
            FlowToken currentFlowToken = null;
            FlowToken previousFlowToken = null;

            foreach (var d in data) {

            }
        }

        public event Action<FlowAst> Result;
    }
}
