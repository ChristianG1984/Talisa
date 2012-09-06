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
            _patternStack = new Stack<FlowPattern>();
        }

        public void Add(FlowPattern flowPattern)
        {
            _flowPatterns.Add(flowPattern);
        }

        public bool MatchAgainst(FlowToken flowToken)
        {
            if (_patternStack.Count > 0) {
            }

            foreach (var pattern in _flowPatterns) {
                if (pattern.DoesMatch(flowToken) == true) {
                    _patternStack.Push(pattern);
                }
            }
        }

        private List<FlowPattern> _flowPatterns;
        private Stack<FlowPattern> _patternStack;
    }
}
