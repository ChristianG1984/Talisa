using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class MatchResult
    {
        public MatchResult(AstElementTypeEnum astElementType, MatchResultEnum resultEnum, IEnumerable<FlowToken> flowTokens)
        {
            AstElementType = astElementType;
            MatchResultType = resultEnum;
            FlowTokens = flowTokens;
        }

        public AstElementTypeEnum AstElementType { get; private set; }
        public MatchResultEnum MatchResultType { get; private set; }
        public IEnumerable<FlowToken> FlowTokens { get; private set; }
    }
}
