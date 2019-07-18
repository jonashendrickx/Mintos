using System;
using System.Collections.Generic;
using System.Text;

namespace Mintos.Models.Enums
{
    public enum LoanType : byte
    {
        Agricultural = 1,
        Business = 2,
        Car = 3,
        InvoiceFinancing = 4,
        Mortgage = 5,
        Personal = 6,
        Pawnbroking = 7,
        ShortTerm = 8
    }
}
