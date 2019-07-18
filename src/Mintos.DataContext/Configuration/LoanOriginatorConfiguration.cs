using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mintos.Models.Entities;

namespace Mintos.DataContext.Configuration
{
    public class LoanOriginatorConfiguration : IEntityTypeConfiguration<LoanOriginator>
    {
        public void Configure(EntityTypeBuilder<LoanOriginator> builder)
        {
            builder.ToTable("loan_originators");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("name").IsRequired();

            builder.HasMany<LoanOriginatorBranch>().WithOne(l => l.LoanOriginator).HasForeignKey(l => l.LoanOriginatorId);
        }
    }
}
