using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.Data
{
    public class FlowToken
    {
        public FlowToken(int position, FlowTokenTypeEnum tokenType, string content)
        {
            Position = position;
            TokenType = tokenType;
            Content = content;
            Length = content.Length;
        }

        public int Position { get; private set; }
        public int Length { get; private set; }
        public FlowTokenTypeEnum TokenType { get; private set; }
        public string Content { get; private set; }
    }
}
