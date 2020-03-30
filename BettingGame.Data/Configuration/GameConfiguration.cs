using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(game => game.GameId);

            builder.HasAlternateKey(game => new
            {
                game.HomeTeamId,
                game.GuestTeamId,
                game.PhaseId
            });

            builder.Property(game => game.HomeTeamId)
                .IsRequired();

            builder.Property(game => game.GuestTeamId)
                .IsRequired();

            builder.Property(game => game.PhaseId)
                .IsRequired();

            builder.Property(game => game.Date)
                .IsRequired();

            builder.Property(game => game.BetsDue)
                .IsRequired();

            builder.HasOne(game => game.HomeTeam)
                .WithMany(team => team.HomeGames)
                .HasForeignKey(game => game.HomeTeamId);

            builder.HasOne(game => game.GuestTeam)
                .WithMany(team => team.GuestGames)
                .HasForeignKey(game => game.GuestTeamId);

            builder.HasOne(game => game.Phase)
                .WithMany(phase => phase.Games)
                .HasForeignKey(game => game.PhaseId);

            builder.HasOne(game => game.Result)
                .WithOne(result => result.Game);

            builder.HasMany(game => game.Bets)
                .WithOne(bet => bet.Game);
        }
    }
}
