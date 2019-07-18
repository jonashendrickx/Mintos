using System;
using System.Collections.Generic;
using System.Text;

namespace Mintos.Models.Enums
{
    public enum LoanStatusType : byte
    {
        Current = 1,
        Grace = 2,
        Finished,
        FinishedPrematurely
    }
}
