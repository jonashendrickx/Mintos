using System;
using System.Collections.Generic;
using System.Text;

namespace Mintos.Plugins.Readers.MicrosoftOffice.Contracts
{
    public class LoanInformation
    {
        public string Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? ListingDate { get; set; }
        public string Country { get; set; }
        public string LoanOriginator { get; set; }
        public string MintosRating { get; set; }
        public string LoanType { get; set; }
        public decimal LoanRate { get; set; }
        public ushort Term { get; set; }
        public bool Collateral { get; set; }
        public decimal InitialLtv { get; set; }
        public decimal Ltv { get; set; }
        public string LoanStatus { get; set; }
        public string BuybackReason { get; set; }
        public decimal InitialLoanAmount { get; set; }
        public decimal RemainingLoanAmount { get; set; }
        public string Currency { get; set; }
        public bool Buyback { get; set; }
    }
}
