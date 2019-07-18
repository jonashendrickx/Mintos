using Microsoft.EntityFrameworkCore;
using Mintos.Models.Entities;

namespace Mintos.DataContext.Context
{
    public class MintosContext : DbContext
    {
        public MintosContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // TODO
            builder.UseSqlServer("");
        }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<LoanOriginator> LoanOriginators { get; set; }

        public DbSet<LoanOriginatorBranch> LoanOriginatorBranches { get; set; }
    }
}
