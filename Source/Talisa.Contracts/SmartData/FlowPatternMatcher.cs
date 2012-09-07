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
            _patternQueue = new Queue<FlowPattern>();
        }

        public void Add(FlowPattern flowPattern)
        {
            _flowPatterns.Add(flowPattern);
        }

        public bool MatchAgainst(FlowToken flowToken)
        {
            bool matchSuccess = false;

            while (_patternQueue.Count > 0) {
                var patternQueueElement = _patternQueue.Peek();
                if (patternQueueElement.DoesMatch(flowToken) == true) {
                    MatchResult = patternQueueElement.MatchResult;
                    return true;
                } else {
                    _patternQueue.Dequeue().Reset();
                }
            }

            foreach (var pattern in _flowPatterns) {
                if (pattern.DoesMatch(flowToken) == true) {
                    MatchResult = pattern.MatchResult;
                    _patternQueue.Enqueue(pattern);
                    matchSuccess = true;
                }
            }

            return matchSuccess;
        }

        public MatchResult MatchResult { get; private set; }

        private List<FlowPattern> _flowPatterns;
        private Queue<FlowPattern> _patternQueue;
    }
}
