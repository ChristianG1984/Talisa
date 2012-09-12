using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPattern
    {
        public FlowPattern(FlowAstElementTypeEnum flowAstElementType)
        {
            _flowAstElementType = flowAstElementType;
            _baseMicroMatcher = new MicroMatcher(_flowAstElementType);
            _currentMicroMatcher = _baseMicroMatcher;
            _matcherToAssignMetaInfo = _currentMicroMatcher;
            _matcherToMatchAgainstNext = _currentMicroMatcher;
        }

        public FlowPatternResult Match(FlowToken d)
        {
            var result = _matcherToMatchAgainstNext.Match(d.TokenType);
            if (result.ContinueInfo == ContinueInfoEnum.TakeMyMatcher && result.HasMatcher) {
                _matcherToMatchAgainstNext = result.MyMatcher;
            } else if (result.ContinueInfo == ContinueInfoEnum.TakeBaseMatcher) {
                _matcherToMatchAgainstNext = _baseMicroMatcher;
            }

            if (result.SuccessInfo == SuccessInfoEnum.FullMatch) {
                
            }
        }

        public FlowPattern Has(params FlowTokenTypeEnum[] startFlowTokens)
        {
            addMultipleTokenTypes(startFlowTokens);
            return this;
        }

        public FlowPattern WithMetaInfos(params MicroMatcherMetaInfoEnum[] metaInfos)
        {
            addMetaInfos(metaInfos);
            return this;
        }

        public FlowPattern Then()
        {
            addNewMatcher();
            return this;
        }

        public FlowPattern CanHaveAnyToken()
        {
            return WithMetaInfos(MicroMatcherMetaInfoEnum.AnyTokenAllowed);
        }

        public FlowPattern WithEndlessCount()
        {
            return WithMetaInfos(MicroMatcherMetaInfoEnum.WithEndlessCount);
        }

        public FlowPattern TerminateEndlessCount()
        {
            return WithMetaInfos(MicroMatcherMetaInfoEnum.TerminateEndlessCount);
        }

        private void addNewMatcher()
        {
            while (_currentMicroMatcher.HasNextMatcher) {
                _currentMicroMatcher = _currentMicroMatcher.Next;
            }
            _currentMicroMatcher = _currentMicroMatcher.CreateNextMatcher();
            _matcherToAssignMetaInfo = _currentMicroMatcher;
        }

        private void addMultipleTokenTypes(IEnumerable<FlowTokenTypeEnum> flowTokens)
        {
            _matcherToAssignMetaInfo = _currentMicroMatcher;
            foreach (var tokenType in flowTokens) {
                if (_currentMicroMatcher.HasTarget) {
                    addNewMatcher();
                }
                _currentMicroMatcher.Target = tokenType;
            }
        }

        private void addMetaInfos(IEnumerable<MicroMatcherMetaInfoEnum> metaInfos)
        {
            var tempMatcher = _matcherToAssignMetaInfo;
            while (true) {
                foreach (var metaInfo in metaInfos) {
                    _matcherToAssignMetaInfo.AddMetaInfo(metaInfo);
                }
                if (_matcherToAssignMetaInfo.HasNextMatcher) {
                    _matcherToAssignMetaInfo = _matcherToAssignMetaInfo.Next;
                    continue;
                }
                break;
            }
            _matcherToAssignMetaInfo = tempMatcher;
        }

        private readonly MicroMatcher _baseMicroMatcher;
        private MicroMatcher _currentMicroMatcher;
        private MicroMatcher _matcherToAssignMetaInfo;
        private MicroMatcher _matcherToMatchAgainstNext;
        private FlowAstElementTypeEnum _flowAstElementType;
        private FlowPatternResult _flowPatternResult;
    }
}
