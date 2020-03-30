using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(bet => bet.BetId);

            builder.HasAlternateKey(bet => new
            {
                bet.UserId,
                bet.GameId
            });

            builder.Property(bet => bet.UserId)
                .IsRequired();

            builder.Property(bet => bet.GameId)
                .IsRequired();

            builder.Property(bet => bet.HomeScore)
                .IsRequired();

            builder.Property(bet => bet.GuestScore)
                .IsRequired();

            builder.Property(bet => bet.LastModified)
                .IsRequired();

            builder.HasOne(bet => bet.User)
                .WithMany(user => user.Bets)
                .HasForeignKey(bet => bet.UserId);

            builder.HasOne(bet => bet.Game)
                .WithMany(game => game.Bets)
                .HasForeignKey(bet => bet.GameId);
        }
    }
}
