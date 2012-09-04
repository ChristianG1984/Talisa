using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPatternMatcher
    {
        public FlowPatternMatcher()
        {
            _flowPatterns = new List<FlowPattern>();
        }

        public void Add(FlowPattern flowPattern)
        {
            _flowPatterns.Add(flowPattern);
        }

        public bool MatchAgainst(FlowTokenTypeEnum flowTokenType)
        {
            foreach (var pattern in _flowPatterns) {
                if (pattern.DoesMatch(flowTokenType) == true) {

                }
            }
            throw new NotImplementedException();
        }

        private List<FlowPattern> _flowPatterns;
    }
}
