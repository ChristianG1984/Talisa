using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.Data
{
    public class AstComment
    {
        public AstComment(IEnumerable<FlowToken> flowTokens)
        {
            _realContent = null;
            RawTokens = flowTokens;
        }

        public IEnumerable<FlowToken> RawTokens { get; private set; }
        
        public string RealContent
        {
            get
            {
                if (_realContent == null) {
                    _realContent = createContent();
                }
                return _realContent;
            }
        }

        private string createContent()
        {
            var builder = new StringBuilder();
            foreach (var token in RawTokens.Skip(1)) {
                if (token.TokenType == FlowTokenTypeEnum.CarriageReturn ||
                    token.TokenType == FlowTokenTypeEnum.Linefeed){ 
                    continue;
                }
                builder.Append(token.Content);
            }
            return builder.ToString();
        }

        private string _realContent;
    }
}
