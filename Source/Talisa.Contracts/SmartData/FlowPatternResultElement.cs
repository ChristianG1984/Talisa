using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPatternResultElement
    {
        public FlowPatternResultElement(FlowAstElementTypeEnum flowAstElementType)
        {
            ElementType = flowAstElementType;
            _content = new List<FlowToken>();
        }

        public void Add(FlowToken flowToken)
        {
            _content.Add(flowToken);
        }

        public FlowAstElementTypeEnum ElementType { get; private set; }
        public IEnumerable<FlowToken> Content { get { return _content; } }

        private List<FlowToken> _content;
    }
}
