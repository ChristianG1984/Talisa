using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.Data
{
    public class FlowAst
    {
        public FlowAst()
        {
            _flowAstElements = new List<FlowAstElement>();
        }

        public void Add(FlowAstElement element)
        {
            _flowAstElements.Add(element);
        }

        public IEnumerable<FlowAstElement> FlowAstElements { get { return _flowAstElements; } }

        private List<FlowAstElement> _flowAstElements;
    }
}
