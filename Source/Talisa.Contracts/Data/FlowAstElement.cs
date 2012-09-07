using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.Data
{
    public class FlowAstElement
    {
        public FlowAstElement(object content, AstElementTypeEnum astElementType)
        {
            Content = content;
            AstElementType = astElementType;
        }

        public object Content { get; private set; }
        public AstElementTypeEnum AstElementType { get; private set; }
    }
}
