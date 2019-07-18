using System;
using System.Collections.Generic;
using System.Text;
using Mintos.Models.Enums;

namespace Mintos.Models.Entities
{
    public class LoanOriginatorBranch
    {
        public Guid Id { get; set; }

        public Guid LoanOriginatorId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public RatingType Rating { get; set; }

        public virtual LoanOriginator LoanOriginator { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
