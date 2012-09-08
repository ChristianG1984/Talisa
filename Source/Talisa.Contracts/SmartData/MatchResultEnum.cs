using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SachsenCoder.Talisa.Contracts.SmartData
{
    public enum MatchResultEnum
    {
        StartMismatch,
        StartPartialMatch,
        StartFullMatch,
        MiddleMismatch,
        MiddlePartialMatch,
        MiddleFullMatch,
        EndMismatch,
        EndPartialMatch,
        EndFullMatch,
        UnknownState
    }
}
