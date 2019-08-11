using System;
using System.Collections.Generic;
using System.Text;

namespace Mintos.Plugins.Readers.MicrosoftOffice.Contracts
{
    public class LoanBookResult
    {
        public ICollection<LoanInformation> Loans { get; set; }
    }
}
