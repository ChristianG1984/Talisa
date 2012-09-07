using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts;
using System.Diagnostics;

namespace SachsenCoder.Talisa.Core
{
    public class MainFlow
    {
        public MainFlow(IUserInterface ui)
        {
            _userInterface = ui;
            _createFlowToken = new Create_Flow_Token_Collection();
            _createFlowAst = new Create_Flow_Ast();

            _userInterface.RawFlowCode += _createFlowToken.Process;
            _createFlowToken.Result += _userInterface.ReceiveFlowTokenList;
            _createFlowToken.Result += _createFlowAst.Process;
            _createFlowAst.Result += _userInterface.ReceiveFlowAst;
        }

        private readonly IUserInterface _userInterface;
        private readonly Create_Flow_Token_Collection _createFlowToken;
        private readonly Create_Flow_Ast _createFlowAst;
    }
}
