using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowAstElement
    {
        public FlowAstElement(object content, FlowAstElementTypeEnum flowAstElementType)
        {
            Content = content;
            FlowAstElementType = flowAstElementType;
        }

        public object Content { get; private set; }
        public FlowAstElementTypeEnum FlowAstElementType { get; private set; }
    }
}
