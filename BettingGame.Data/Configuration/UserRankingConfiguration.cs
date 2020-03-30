using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class UserRankingConfiguration : IEntityTypeConfiguration<UserRanking>
    {
        public void Configure(EntityTypeBuilder<UserRanking> builder)
        {
            builder.HasKey(ranking => ranking.UserId);

            builder.Property(ranking => ranking.UserId)
                .ValueGeneratedNever();

            builder.Property(ranking => ranking.Score)
                .IsRequired();

            builder.Property(ranking => ranking.Rank)
                .IsRequired();

            builder.Property(ranking => ranking.DifferenceToLastRanking)
                .IsRequired();

            builder.HasOne(ranking => ranking.User)
                .WithOne(user => user.Ranking)
                .HasForeignKey<UserRanking>(ranking => ranking.UserId);
        }
    }
}
