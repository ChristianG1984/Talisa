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
            var commentPattern = new FlowPattern(AstElementTypeEnum.Comment);
            commentPattern
                .StartsWith(new FlowPatternElement(FlowTokenTypeEnum.HashSign))
                .Then().CanHaveAny()
                .EndsWith(new FlowPatternElement(FlowTokenTypeEnum.Linefeed));

            var matcher = new FlowPatternMatcher();
            matcher.Add(commentPattern);

            //var tempFlowTokenList = new List<FlowToken>();
            //FlowToken currentFlowToken = null;
            //FlowToken previousFlowToken = null;
            var flowAst = new FlowAst();
            MatchResult result = null;

            foreach (var d in data) {
                result = matcher.MatchAgainst(d);

                if (result.MatchResultType == MatchResultEnum.EndFullMatch &&
                    result.AstElementType == AstElementTypeEnum.Comment) {
                        flowAst.Add(new FlowAstElement(new AstComment(result.FlowTokens), AstElementTypeEnum.Comment));
                }
            }

            //if (result != null) {

            //}
            Result(flowAst);
        }

        public event Action<FlowAst> Result;
    }
}
