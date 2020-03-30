using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GameResultConfiguration : IEntityTypeConfiguration<GameResult>
    {
        public void Configure(EntityTypeBuilder<GameResult> builder)
        {
            builder.HasKey(result => result.GameId);

            builder.Property(result => result.GameId)
                .ValueGeneratedNever();

            builder.Property(result => result.GameId)
                .IsRequired();

            builder.Property(result => result.HomeScore)
                .IsRequired();

            builder.Property(result => result.GuestScore)
                .IsRequired();

            builder.Property(result => result.CreatedAt)
                .IsRequired();

            builder.HasOne(result => result.Game)
                .WithOne(game => game.Result)
                .HasForeignKey<GameResult>(result => result.GameId);
        }
    }
}
