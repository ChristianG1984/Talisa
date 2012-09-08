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
            _defaultResult = new MatchResult(AstElementTypeEnum.Unknown, MatchResultEnum.UnknownState, null);
        }

        public void Add(FlowPattern flowPattern)
        {
            _flowPatterns.Add(flowPattern);
        }

        public MatchResult MatchAgainst(FlowToken flowToken)
        {
            MatchResult result = _defaultResult;

            while (_patternQueue.Count > 0) {
                var patternQueueElement = _patternQueue.Peek();
                result = patternQueueElement.DoesMatch(flowToken);
                if (result.MatchResultType == MatchResultEnum.EndFullMatch) {
                    _patternQueue.Dequeue().Reset();
                }
                return result;
            }

            MatchResult firstMatch = null;

            foreach (var pattern in _flowPatterns) {
                result = pattern.DoesMatch(flowToken);
                if (result.MatchResultType == MatchResultEnum.StartPartialMatch ||
                    result.MatchResultType == MatchResultEnum.StartFullMatch) {
                    _patternQueue.Enqueue(pattern);
                    if (firstMatch == null) {
                        firstMatch = result;
                    }
                }
            }

            if (firstMatch != null) {
                return firstMatch;
            }
            return result;
        }

        private List<FlowPattern> _flowPatterns;
        private Queue<FlowPattern> _patternQueue;
        private MatchResult _defaultResult;
    }
}
