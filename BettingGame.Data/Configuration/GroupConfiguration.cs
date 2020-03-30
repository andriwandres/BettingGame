using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(group => group.GroupId);

            builder.Property(group => group.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(group => group.Description)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.Property(group => group.CreatorId)
                .IsRequired();

            builder.HasOne(group => group.Creator)
                .WithOne(user => user.Group)
                .HasForeignKey<Group>(group => group.CreatorId);

            builder.HasMany(group => group.Memberships)
                .WithOne(membership => membership.Group);
        }
    }
}
