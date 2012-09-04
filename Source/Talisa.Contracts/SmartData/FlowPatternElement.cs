using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPatternElement
    {
        public FlowPatternElement(object element)
        {
            Content = element;
            IsFlowPattern = element.GetType() == typeof(FlowPattern);
            IsFlowTokenTypeEnum = element.GetType() == typeof(FlowTokenTypeEnum);
        }

        public object Content { get; private set; }
        public bool IsFlowPattern { get; private set; }
        public bool IsFlowTokenTypeEnum { get; private set; }
    }
}
