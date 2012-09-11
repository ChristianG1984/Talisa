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
                .Then().CanHaveAnyToken().WithEndlessCount()
                .Then().Has(FlowTokenTypeEnum.Linefeed).TerminateEndlessCount();

            FlowPatternResult result;

            foreach (var d in data) {
                result = commentPattern.Match(d);
            }
        }

        public event Action<FlowAst> Result;
    }
}
