using FinBridge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinBridge.Data.EntityConfiguration
{
    internal class CreditScoreConfiguration : IEntityTypeConfiguration<CreditScore>
    {
        public void Configure(EntityTypeBuilder<CreditScore> builder)
        {
            builder
                .HasKey(cs => cs.CreditScoreId);

            builder
                .HasOne(cs => cs.Customer)
                .WithMany(c => c.CreditsScores)
                .HasForeignKey(cs => cs.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .Property(cs => cs.Score)
                .IsRequired()
                .HasDefaultValue(0);

            builder
            .ToTable("CreditScores", t => t.HasCheckConstraint("CK_CreditScore_Score", "[Score] >= 0 AND [Score] <= 1000"));
        }
    }
}
