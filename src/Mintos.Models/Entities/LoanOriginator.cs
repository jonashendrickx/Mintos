using System;
using System.Collections.Generic;
using System.Text;

namespace Mintos.Models.Entities
{
    public class LoanOriginator
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<LoanOriginatorBranch> Branches { get; set; }
    }
}
