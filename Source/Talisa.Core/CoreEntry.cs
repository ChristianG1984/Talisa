using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts;
using System.Diagnostics;
using SachsenCoder.Talisa.Core.Leafs;

namespace SachsenCoder.Talisa.Core
{
    public class CoreEntry
    {
        public CoreEntry(IUserInterface userInterface)
        {
            var createFlowToken = new Create_Flow_Token_Collection();
            var createFlowPatternResult = new Create_Flow_PatternResult();
            var createFlowAst = new Create_Flow_Ast();

            userInterface.RawFlowCode += createFlowToken.Process;
            createFlowToken.Result += userInterface.ReceiveFlowTokenList;
            createFlowToken.Result += createFlowPatternResult.Process;
            createFlowPatternResult.Result += createFlowAst.Process;
            createFlowAst.Result += userInterface.ReceiveFlowAst;
        }
    }
}
