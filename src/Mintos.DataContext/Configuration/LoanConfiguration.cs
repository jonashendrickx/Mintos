using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mintos.Models.Entities;

namespace Mintos.DataContext.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("loans");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id").IsRequired();
            builder.Property(l => l.LoanOriginatorBranchId).HasColumnName("loan_originator_branch_id").IsRequired();
            builder.Property(l => l.Buyback).HasColumnName("buyback").IsRequired();
            builder.Property(l => l.ClosedAt).HasColumnName("closed_at").IsRequired(false);
            builder.Property(l => l.Currency).HasColumnName("currency").HasMaxLength(3).IsFixedLength(true).IsRequired();
            builder.Property(l => l.Reference).HasColumnName("reference").IsRequired();
            builder.Property(l => l.InitialAmount).HasColumnName("initial_amount").IsRequired();
            builder.Property(l => l.InitialLtv).HasColumnName("initial_ltv").IsRequired();
            builder.Property(l => l.InterestRate).HasColumnName("interest_rate").IsRequired();
            builder.Property(l => l.IssuedAt).HasColumnName("issued_at").IsRequired(false);
            builder.Property(l => l.ListedAt).HasColumnName("listed_at").IsRequired(false);
            builder.Property(l => l.Ltv).HasColumnName("ltv").IsRequired();
            builder.Property(l => l.RemainingAmount).HasColumnName("remaining_amount").IsRequired();
            builder.Property(l => l.Term).HasColumnName("term").IsRequired();
            builder.Property(l => l.Type).HasColumnName("type").IsRequired();

            builder.HasOne(l => l.LoanOriginatorBranch).WithMany(l => l.Loans).HasForeignKey(l => l.LoanOriginatorBranchId);
        }
    }
}
