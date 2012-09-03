using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPatternMatcher
    {
        public FlowPatternMatcher()
        {
            _flowPatterns = new List<FlowPattern>();
        }

        public void Add(FlowPattern flowPattern)
        {
            _flowPatterns.Add(flowPattern);
        }

        private List<FlowPattern> _flowPatterns;
    }
}
