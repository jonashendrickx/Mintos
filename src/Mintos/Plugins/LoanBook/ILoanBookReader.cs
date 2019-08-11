using Mintos.Plugins.Readers.MicrosoftOffice.Contracts;
using System.Collections.Generic;

namespace Mintos.Plugins.LoanBook
{
    public interface ILoanBookReader
    {
        IEnumerable<LoanInformation> Read(string filename);
    }
}
