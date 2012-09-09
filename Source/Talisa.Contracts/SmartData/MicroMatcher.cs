using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class MicroMatcher
    {
        public MicroMatcher(FlowAstElementTypeEnum partOfFlowAstElementType)
        {
            _target = null;
            _tokenToTest = null;
            _previousMatcher = null;
            _nextMatcher = null;
            _flowAstElementType = partOfFlowAstElementType;
            _metaInfos = new List<MicroMatcherMetaInfoEnum>();
        }

        public MicroMatcherResult Match(FlowTokenTypeEnum flowTokenType)
        {
            _tokenToTest = flowTokenType;
            return createMicroMatcherResult(_target == _tokenToTest);
        }

        public MicroMatcher CreateNextMatcher()
        {
            if (HasNextMatcher) {
                throw new InvalidOperationException("This MicroMatcher already has a NextMatcher! Try to request that instead.");
            }
            _nextMatcher = new MicroMatcher(_flowAstElementType);
            _nextMatcher._previousMatcher = this;
            return _nextMatcher;
        }

        public void AddMetaInfo(MicroMatcherMetaInfoEnum metaInfo)
        {
            if (_metaInfos.Contains(metaInfo)) {
                throw new InvalidOperationException("This MicroMatcher already has that metaInfo!");
            }
            _metaInfos.Add(metaInfo);
        }

        private MicroMatcherResult createMicroMatcherResult(bool targetHasMatched)
        {
            var targetHasNotMatched = targetHasMatched == false;
            if (targetHasMatched && HasNextMatcher) {
                return targetMatched_hasNext();
            }
            if (targetHasMatched && HasNoNextMatcher) {
                return targetMatched_hasNoNext();
            }
            if (targetHasNotMatched && HasNextMatcher) {
                return targetNotMatched_hasNext();
            }
            return targetNotMatched_hasNoNext();
        }

        private MicroMatcherResult targetMatched_hasNext()
        {
            return new MicroMatcherResult(SuccessInfoEnum.PartialMatch, Next);
        }

        private MicroMatcherResult targetMatched_hasNoNext()
        {
            return new MicroMatcherResult(SuccessInfoEnum.FullMatch, ContinueInfoEnum.TakeBaseMatcher);
        }

        private MicroMatcherResult targetNotMatched_hasNext()
        {
            if (hasMetaInfo(MicroMatcherMetaInfoEnum.AnyTokenAllowed)) {
                return targetMatched_hasNext();
            }
            return new MicroMatcherResult(SuccessInfoEnum.NoMatch, ContinueInfoEnum.TakeBaseMatcher);
        }

        private MicroMatcherResult targetNotMatched_hasNoNext()
        {
            if (hasMetaInfo(MicroMatcherMetaInfoEnum.AnyTokenAllowed)) {
                return targetMatched_hasNoNext();
            }
            if (hasMetaInfo(MicroMatcherMetaInfoEnum.IsSeparator)) {
                if (HasPreviousMatcher && Previous.hasMetaInfo(MicroMatcherMetaInfoEnum.AnyTokenAllowed)) {

                }
            }
            return new MicroMatcherResult(SuccessInfoEnum.NoMatch, ContinueInfoEnum.TakeBaseMatcher);
        }

        private bool hasMetaInfo(MicroMatcherMetaInfoEnum microMatcherMetaInfo)
        {
            return _metaInfos.Contains(microMatcherMetaInfo);
        }

        public FlowTokenTypeEnum Target { set { _target = value; } }

        public MicroMatcher Next
        {
            get
            {
                if (HasNoNextMatcher) {
                    throw new InvalidOperationException("This MicroMatcher has no NextMatcher!");
                }
                return _nextMatcher;
            }
        }

        public MicroMatcher Previous
        {
            get
            {
                if (HasNoPreviousMatcher) {
                    throw new InvalidOperationException("This MicroMatcher has no PreviousMatcher!");
                }
                return _previousMatcher;
            }
        }

        public bool HasTarget { get { return _target.HasValue; } }

        public bool HasPreviousMatcher { get { return _previousMatcher != null; } }

        public bool HasNoPreviousMatcher { get { return HasPreviousMatcher == false; } }

        public bool HasNextMatcher { get { return _nextMatcher != null; } }

        public bool HasNoNextMatcher { get { return HasNextMatcher == false; } }

        private FlowTokenTypeEnum? _target;
        private FlowTokenTypeEnum? _tokenToTest;
        private MicroMatcher _previousMatcher;
        private MicroMatcher _nextMatcher;
        private FlowAstElementTypeEnum _flowAstElementType;
        private List<MicroMatcherMetaInfoEnum> _metaInfos;
    }
}
