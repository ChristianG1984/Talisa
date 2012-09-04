using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPattern
    {
        public FlowPattern()
        {
            _startFlowTokens = new List<FlowPatternElement>();
            _endFlowTokens = new List<FlowPatternElement>();
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
            return this;
        }

        public void EndsWith(params FlowPatternElement[] endFlowTokens)
        {
            _endFlowTokens.Clear();
            _endFlowTokens.AddRange(endFlowTokens);
        }

        public bool DoesMatch(FlowTokenTypeEnum flowTokenType)
        {
            throw new NotImplementedException();
        }

        private List<FlowPatternElement> _startFlowTokens;
        private List<FlowPatternElement> _endFlowTokens;
        private bool _allowAnyBetween;
    }
}
