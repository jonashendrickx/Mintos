using System;
using Mintos.Models.Enums;

namespace Mintos.Models.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }

        public Guid LoanOriginatorBranchId { get; set; }

        public string Reference { get; set; }

        public bool Buyback { get; set; }

        public DateTime? ClosedAt { get; set; }

        public string Currency { get; set; }

        public decimal InitialAmount { get; set; }

        public decimal InitialLtv { get; set; }

        public decimal InterestRate { get; set; } 

        public DateTime IssuedAt { get; set; }

        public DateTime? ListedAt { get; set; }

        public decimal Ltv { get; set; }

        public decimal RemainingAmount { get; set; }

        public ushort Term { get; set; }

        public LoanType Type { get; set; }

        public virtual LoanOriginatorBranch LoanOriginatorBranch { get; set; }
    }
}
