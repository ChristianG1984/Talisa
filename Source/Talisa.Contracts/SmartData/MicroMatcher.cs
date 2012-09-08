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
            _previousMatcher = null;
            _nextMatcher = null;
            _flowAstElementType = partOfFlowAstElementType;
            _metaInfos = new List<MicroMatcherMetaInfoEnum>();
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

        public FlowTokenTypeEnum Target { set { _target = value; } }

        public MicroMatcher Next
        {
            get
            {
                if (HasNextMatcher == false) {
                    throw new InvalidOperationException("This MicroMatcher has no NextMatcher!");
                }
                return _nextMatcher;
            }
        }

        public bool HasTarget { get { return _target.HasValue; } }

        public bool HasPreviousMatcher { get { return _previousMatcher != null; } }

        public bool HasNextMatcher { get { return _nextMatcher != null; } }

        private FlowTokenTypeEnum? _target;
        private MicroMatcher _previousMatcher;
        private MicroMatcher _nextMatcher;
        private FlowAstElementTypeEnum _flowAstElementType;
        private List<MicroMatcherMetaInfoEnum> _metaInfos;
    }
}
