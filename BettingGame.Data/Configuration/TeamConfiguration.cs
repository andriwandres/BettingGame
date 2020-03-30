using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(team => team.TeamId);

            builder.HasAlternateKey(team => new
            {
                team.Name,
                team.Abbreviation,
                team.CountryId
            });

            builder.Property(team => team.CountryId)
                .IsRequired();

            builder.Property(team => team.Name)
                .IsRequired();

            builder.Property(team => team.Abbreviation)
                .IsRequired();

            builder.HasOne(team => team.Country)
                .WithMany(country => country.Teams)
                .HasForeignKey(team => team.CountryId);

            builder.HasMany(team => team.HomeGames)
                .WithOne(game => game.HomeTeam);

            builder.HasMany(team => team.GuestGames)
                .WithOne(game => game.GuestTeam);
        }
    }
}
