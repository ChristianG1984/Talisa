using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public class MicroMatcherResult
    {
        public MicroMatcherResult(SuccessInfoEnum successInfo, ContinueInfoEnum continueInfo)
        {
            SuccessInfo = successInfo;
            ContinueInfo = continueInfo;
            _myMatcher = null;
        }

        public MicroMatcherResult(SuccessInfoEnum successInfo, MicroMatcher matcher) : this(successInfo, ContinueInfoEnum.TakeMyMatcher)
        {
            MyMatcher = matcher;
        }

        public SuccessInfoEnum SuccessInfo { get; private set; }
        public ContinueInfoEnum ContinueInfo { get; private set; }

        public bool HasMatcher { get { return _myMatcher != null; } }

        public bool HasNoMatcher { get { return HasMatcher == false; } }

        public MicroMatcher MyMatcher
        {
            get
            {
                if (_myMatcher == null) {
                    throw new InvalidOperationException("MyMatcher is null and can't be used!");
                }
                return _myMatcher;
            }
            private set
            {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }
                _myMatcher = value;
            }
        }

        private MicroMatcher _myMatcher;
    }
}
