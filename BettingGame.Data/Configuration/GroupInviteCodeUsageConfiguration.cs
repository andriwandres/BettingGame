using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GroupInviteCodeUsageConfiguration : IEntityTypeConfiguration<GroupInviteCodeUsage>
    {
        public void Configure(EntityTypeBuilder<GroupInviteCodeUsage> builder)
        {
            builder.HasKey(usage => usage.GroupInviteCodeUsageId);

            builder.HasAlternateKey(usage => new
            {
                usage.UserId,
                usage.GroupInviteCodeId
            });

            builder.Property(usage => usage.UserId)
                .IsRequired();

            builder.Property(usage => usage.GroupInviteCodeId)
                .IsRequired();

            builder.Property(usage => usage.CreatedAt)
                .IsRequired();

            builder.HasOne(usage => usage.User)
                .WithMany(user => user.GroupInviteCodeUsages)
                .HasForeignKey(usage => usage.UserId);

            builder.HasOne(usage => usage.GroupInviteCode)
                .WithMany(invite => invite.Usages)
                .HasForeignKey(usage => usage.GroupInviteCodeId);
        }
    }
}
