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
            _startFlowTokens = new List<FlowTokenTypeEnum>();
            _endFlowTokens = new List<FlowTokenTypeEnum>();
            _allowAnyBetween = false;
        }

        public FlowPattern StartsWith(params FlowTokenTypeEnum[] startFlowTokens)
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

        public void EndsWith(params FlowTokenTypeEnum[] endFlowTokens)
        {
            _endFlowTokens.Clear();
            _endFlowTokens.AddRange(endFlowTokens);
        }

        private List<FlowTokenTypeEnum> _startFlowTokens;
        private List<FlowTokenTypeEnum> _endFlowTokens;
        private bool _allowAnyBetween;
    }
}
