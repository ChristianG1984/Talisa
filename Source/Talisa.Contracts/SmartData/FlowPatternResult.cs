using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class FlowPatternResult
    {
        public FlowPatternResult()
        {
            _results = new List<FlowPatternResultElement>();
        }

        public void AddSuccesfulToken(FlowToken flowToken, FlowAstElementTypeEnum flowAstElementType)
        {
            if (_tempResult == null) { _tempResult = new FlowPatternResultElement(flowAstElementType); }
            _tempResult.Add(flowToken);
        }

        public void AddLastSuccesfulToken(FlowToken flowToken, FlowAstElementTypeEnum flowAstElementType)
        {
            AddSuccesfulToken(flowToken, flowAstElementType);
            _results.Add(_tempResult);
            _tempResult = null;
        }

        public void AddWrongToken(FlowToken flowToken, FlowAstElementTypeEnum flowAstElementType)
        {
            
        }

        public List<FlowPatternResultElement> Content { get { return _results; } }

        private List<FlowPatternResultElement> _results;
        private FlowPatternResultElement _tempResult;
    }
}
