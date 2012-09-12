using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SachsenCoder.Talisa.Contracts.Data;

namespace SachsenCoder.Talisa.Core.Leafs
{
    public class Create_Flow_Token_Collection
    {
        public void Process(string data)
        {
            var flowTokenList = new List<FlowToken>();
            var contentBuilder = new StringBuilder();
            int position = 0;
            FlowTokenTypeEnum? currentTokenType = null;
            FlowTokenTypeEnum? previousTokenType = null;

            foreach (var c in data) {
                currentTokenType = getFlowTokenType(c);
                if (currentTokenType == previousTokenType || previousTokenType == null) {
                    contentBuilder.Append(c);
                    previousTokenType = currentTokenType;
                    continue;
                }
                var token = new FlowToken(position, previousTokenType.GetValueOrDefault(), contentBuilder.ToString());
                flowTokenList.Add(token);
                position += token.Length;
                contentBuilder.Clear();
                contentBuilder.Append(c);
                previousTokenType = currentTokenType;
            }

            if (contentBuilder.Length > 0) {
                flowTokenList.Add(new FlowToken(position, previousTokenType.GetValueOrDefault(), contentBuilder.ToString()));
            }
            Result(flowTokenList);
        }
        public event Action<IEnumerable<FlowToken>> Result;

        private FlowTokenTypeEnum getFlowTokenType(char c)
        {
            if (c == '\n') {
                return FlowTokenTypeEnum.Linefeed;
            } else if (c == '\r') {
                return FlowTokenTypeEnum.CarriageReturn;
            } else if (c == ' ') {
                return FlowTokenTypeEnum.Space;
            } else if (c == '\t') {
                return FlowTokenTypeEnum.Tabulator;
            } else if (c == '#') {
                return FlowTokenTypeEnum.HashSign;
            } else if (c == ',') {
                return FlowTokenTypeEnum.Comma;
            } else if (c == '.') {
                return FlowTokenTypeEnum.Dot;
            } else if (isLetter(c) || isNumber(c)) {
                return FlowTokenTypeEnum.Text;
            } else {
                return FlowTokenTypeEnum.Unknown;
            }
        }

        private bool isLetter(char c)
        {
            if ((c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z')) {
                return true;
            }
            return false;
        }

        private bool isNumber(char c)
        {
            if (c >= '0' && c <= '9') {
                return true;
            }
            return false;
        }
    }
}
