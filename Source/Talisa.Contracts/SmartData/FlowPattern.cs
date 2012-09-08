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

        public MatchResult DoesMatch(FlowToken flowToken)
        {
            if (_patternStack.Count > 0) {
                return _patternStack.Pop().DoesMatch(flowToken);
            }
            
            if (_currentStart != null) {
                return handleStartFlowPatternElement(flowToken);
            } else if (_allowAnyBetween == true) {
                if (_currentEnd != null) {
                    var result = handleEndFlowPatternElement(flowToken);
                    if (result.MatchResultType == MatchResultEnum.EndMismatch) {
                        _matchedTokens.Add(flowToken);
                        //_endFlowEnumerator.Reset();
                        return CreateResult(MatchResultEnum.MiddlePartialMatch);
                    } else {
                        return result;
                    }
                } else {
                    return CreateResult(MatchResultEnum.EndFullMatch);
                }
            } else if (_currentEnd != null) {

            }
            return CreateResult(MatchResultEnum.UnknownState);
        }

        public void Reset()
        {
            _currentStart = null;
            _currentMiddle = null;
            _currentEnd = null;
            _startFlowEnumerator = _startFlowTokens.GetEnumerator();
            _middleFlowEnumerator = _middleFlowTokens.GetEnumerator();
            _endFlowEnumerator = _endFlowTokens.GetEnumerator();
            if (_startFlowEnumerator.MoveNext() == true) {
                _currentStart = _startFlowEnumerator.Current;
            }
            if (_middleFlowEnumerator.MoveNext() == true) {
                _currentMiddle = _middleFlowEnumerator.Current;
            }
            if (_endFlowEnumerator.MoveNext() == true) {
                _currentEnd = _endFlowEnumerator.Current;
            }
            _matchedTokens.Clear();
            foreach (var pattern in _patternStack) {
                pattern.Reset();
            }
            _patternStack.Clear();
        }

        public AstElementTypeEnum AstElementType { get; private set; }

        private MatchResult CreateResult(MatchResultEnum matchResultEnum)
        {
            return new MatchResult(AstElementType, matchResultEnum, new List<FlowToken>(_matchedTokens));
        }

        private MatchResult handleStartFlowPatternElement(FlowToken flowToken)
        {
            if (_currentStart.IsFlowTokenTypeEnum &&
                (FlowTokenTypeEnum)_currentStart.Content == flowToken.TokenType) {
                _matchedTokens.Add(flowToken);
                if (_startFlowEnumerator.MoveNext() == true) {
                    _currentStart = _startFlowEnumerator.Current;
                    return CreateResult(MatchResultEnum.StartPartialMatch);
                } else {
                    _currentStart = null;
                    return CreateResult(MatchResultEnum.StartFullMatch);
                }
            } else if (_currentStart.IsFlowPattern) {
                return ((FlowPattern)_currentStart.Content).DoesMatch(flowToken);
            }
            return CreateResult(MatchResultEnum.StartMismatch);
        }

        private MatchResult handleEndFlowPatternElement(FlowToken flowToken)
        {
            if (_currentEnd.IsFlowTokenTypeEnum &&
                (FlowTokenTypeEnum)_currentEnd.Content == flowToken.TokenType) {
                _matchedTokens.Add(flowToken);
                if (_endFlowEnumerator.MoveNext() == true) {
                    _currentEnd = _endFlowEnumerator.Current;
                    return CreateResult(MatchResultEnum.EndPartialMatch);
                } else {
                    return CreateResult(MatchResultEnum.EndFullMatch);
                }
            } else if (_currentEnd.IsFlowPattern) {
                return ((FlowPattern)_currentEnd.Content).DoesMatch(flowToken);
            }
            return CreateResult(MatchResultEnum.EndMismatch);
        }

        private List<FlowPatternElement> _startFlowTokens;
        private List<FlowPatternElement> _middleFlowTokens;
        private List<FlowPatternElement> _endFlowTokens;
        private IEnumerator<FlowPatternElement> _startFlowEnumerator;
        private IEnumerator<FlowPatternElement> _middleFlowEnumerator;
        private IEnumerator<FlowPatternElement> _endFlowEnumerator;
        private FlowPatternElement _currentStart;
        private FlowPatternElement _currentMiddle;
        private FlowPatternElement _currentEnd;
        private Stack<FlowPattern> _patternStack;
        private List<FlowToken> _matchedTokens;
        private bool _allowAnyBetween;
    }
}
