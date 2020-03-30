using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class PhaseConfiguration : IEntityTypeConfiguration<Phase>
    {
        public void Configure(EntityTypeBuilder<Phase> builder)
        {
            builder.HasKey(phase => phase.PhaseId);

            builder.Property(phase => phase.Name)
                .IsRequired();

            builder.Property(phase => phase.StartDate)
                .IsRequired();

            builder.Property(phase => phase.EndDate)
                .IsRequired();

            builder.HasMany(phase => phase.Games)
                .WithOne(game => game.Phase);
        }
    }
}
