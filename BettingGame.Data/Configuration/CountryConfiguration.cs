using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(country => country.CountryId);

            builder.HasAlternateKey(country => country.Name);
            builder.HasAlternateKey(country => country.Abbreviation);

            builder.Property(country => country.Name)
                .IsRequired();

            builder.Property(country => country.Abbreviation)
                .IsRequired();

            builder.Property(country => country.FlagImage)
                .IsRequired();

            builder.HasMany(country => country.Users)
                .WithOne(user => user.Country);

            builder.HasMany(country => country.Teams)
                .WithOne(team => team.Country);
        }
    }
}
