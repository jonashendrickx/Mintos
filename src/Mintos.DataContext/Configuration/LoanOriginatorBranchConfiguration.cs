using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mintos.Models.Entities;

namespace Mintos.DataContext.Configuration
{
    public class LoanOriginatorBranchConfiguration : IEntityTypeConfiguration<LoanOriginatorBranch>
    {
        public void Configure(EntityTypeBuilder<LoanOriginatorBranch> builder)
        {
            builder.ToTable("loan_originator_branches");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id").IsRequired();
            builder.Property(l => l.LoanOriginatorId).HasColumnName("loan_originator_id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("name").IsRequired();
            builder.Property(l => l.Rating).HasColumnName("rating").IsRequired();
            builder.Property(l => l.Country).HasColumnName("country").IsRequired();

            builder.HasOne(l => l.LoanOriginator).WithMany(l => l.Branches).HasForeignKey(l => l.LoanOriginatorId).IsRequired();
        }
    }
}
