using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class GroupInviteCodeConfiguration : IEntityTypeConfiguration<GroupInviteCode>
    {
        public void Configure(EntityTypeBuilder<GroupInviteCode> builder)
        {
            builder.HasKey(invite => invite.GroupInviteCodeId);

            builder.HasAlternateKey(invite => invite.Code);

            builder.Property(invite => invite.Code)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(invite => invite.CreatedAt)
                .IsRequired();

            builder.Property(invite => invite.ValidUntil)
                .IsRequired();

            builder.HasOne(invite => invite.Group)
                .WithMany(group => group.InviteCodes)
                .HasForeignKey(invite => invite.GroupId);

            builder.HasMany(invite => invite.Usages)
                .WithOne(usage => usage.GroupInviteCode);
        }
    }
}
