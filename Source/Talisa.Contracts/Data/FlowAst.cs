using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.SmartData;

namespace SachsenCoder.Talisa.Contracts.Data
{
    public class FlowAst
    {
        public FlowAst()
        {
            _flowAstElements = new List<FlowAstElement>();
        }

        public void Add(FlowPatternResultElement content)
        {
            switch (content.ElementType) {
                case FlowAstElementTypeEnum.Comment:
                    _flowAstElements.Add(new FlowAstElement(new AstComment(content.Content), FlowAstElementTypeEnum.Comment));
                    break;
            }
        }

        public IEnumerable<FlowAstElement> FlowAstElements { get { return _flowAstElements; } }

        private List<FlowAstElement> _flowAstElements;
    }
}
