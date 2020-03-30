using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GroupMembershipConfiguration : IEntityTypeConfiguration<GroupMembership>
    {
        public void Configure(EntityTypeBuilder<GroupMembership> builder)
        {
            builder.HasKey(membership => membership.GroupMembershipId);

            builder.HasAlternateKey(membership => new
            {
                membership.UserId,
                membership.GroupId
            });

            builder.Property(membership => membership.UserId)
                .IsRequired();

            builder.Property(membership => membership.GroupId)
                .IsRequired();

            builder.Property(membership => membership.CreatedAt)
                .IsRequired();

            builder.HasOne(membership => membership.User)
                .WithMany(user => user.GroupMemberships)
                .HasForeignKey(membership => membership.UserId);

            builder.HasOne(membership => membership.Group)
                .WithMany(group => group.Memberships)
                .HasForeignKey(membership => membership.GroupId);
        }
    }
}
