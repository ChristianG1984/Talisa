using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPattern
    {
        public FlowPattern(AstElementTypeEnum astElementType)
        {
            AstElementType = astElementType;
            _startFlowTokens = new List<FlowPatternElement>();
            _middleFlowTokens = new List<FlowPatternElement>();
            _endFlowTokens = new List<FlowPatternElement>();
            _patternStack = new Stack<FlowPattern>();
            _matchedTokens = new List<FlowToken>();
            _allowAnyBetween = false;
        }

        public FlowPattern StartsWith(params FlowPatternElement[] startFlowTokens)
        {
            _startFlowTokens.Clear();
            _startFlowTokens.AddRange(startFlowTokens);
            return this;
        }

        public FlowPattern Then()
        {
            return this;
        }

        public FlowPattern CanHaveAny()
        {
            _allowAnyBetween = true;
            _middleFlowTokens.Clear();
            return this;
        }

        public void EndsWith(params FlowPatternElement[] endFlowTokens)
        {
            _endFlowTokens.Clear();
            _endFlowTokens.AddRange(endFlowTokens);
            Reset();
        }

        public bool DoesMatch(FlowToken flowToken)
        {
            if (_patternStack.Count > 0) {
                return _patternStack.Pop().DoesMatch(flowToken);
            }

            if (_startFlowEnumerator.MoveNext() == true) {
                if (_startFlowEnumerator.Current.IsFlowTokenTypeEnum &&
                    (FlowTokenTypeEnum)_startFlowEnumerator.Current.Content == flowToken.TokenType) {
                        _matchedTokens.Add(flowToken);
                        CreateResult(MatchResultEnum.Partial);
                        return true;
                } else if (_startFlowEnumerator.Current.IsFlowPattern) {
                    return ((FlowPattern)_startFlowEnumerator.Current.Content).DoesMatch(flowToken);
                }
            } else if (_allowAnyBetween == true) {
                if (_endFlowEnumerator.MoveNext() == true) {
                    if (HandleEndFlowPatternElement(_endFlowEnumerator.Current, flowToken) == false) {
                        _matchedTokens.Add(flowToken);
                        _endFlowEnumerator.Reset();
                    }
                }
            } else if (_endFlowEnumerator.MoveNext() == true) {

            }
            return false;
        }

        public void Reset()
        {
            _startFlowEnumerator = _startFlowTokens.GetEnumerator();
            _middleFlowEnumerator = _middleFlowTokens.GetEnumerator();
            _endFlowEnumerator = _endFlowTokens.GetEnumerator();
            _matchedTokens.Clear();
            MatchResult = null;
            foreach (var pattern in _patternStack) {
                pattern.Reset();
            }
            _patternStack.Clear();
        }

        public AstElementTypeEnum AstElementType { get; private set; }
        public MatchResult MatchResult { get; private set; }

        private void CreateResult(MatchResultEnum matchResultEnum)
        {
            MatchResult = new MatchResult(AstElementType, matchResultEnum, _matchedTokens);
        }

        private bool HandleEndFlowPatternElement(FlowPatternElement flowPatternElement, FlowToken flowToken)
        {
            if (flowPatternElement.IsFlowTokenTypeEnum &&
                (FlowTokenTypeEnum)flowPatternElement.Content == flowToken.TokenType) {
                _matchedTokens.Add(flowToken);
                CreateResult(MatchResultEnum.Partial);
                return true;
            } else if (flowPatternElement.IsFlowPattern) {
                return ((FlowPattern)flowPatternElement.Content).DoesMatch(flowToken);
            }
            return false;
        }

        private List<FlowPatternElement> _startFlowTokens;
        private List<FlowPatternElement> _middleFlowTokens;
        private List<FlowPatternElement> _endFlowTokens;
        private IEnumerator<FlowPatternElement> _startFlowEnumerator;
        private IEnumerator<FlowPatternElement> _middleFlowEnumerator;
        private IEnumerator<FlowPatternElement> _endFlowEnumerator;
        private Stack<FlowPattern> _patternStack;
        private List<FlowToken> _matchedTokens;
        private bool _allowAnyBetween;
    }
}
