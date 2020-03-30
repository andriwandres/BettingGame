using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingGame.Data.Configuration
{
    public class PasswordResetCodeConfiguration : IEntityTypeConfiguration<PasswordResetCode>
    {
        public void Configure(EntityTypeBuilder<PasswordResetCode> builder)
        {
            builder.HasKey(reset => reset.PasswordResetCodeId);

            builder.HasAlternateKey(reset => reset.Code);

            builder.Property(reset => reset.UserId)
                .IsRequired();

            builder.Property(reset => reset.Code)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(reset => reset.CreatedAt)
                .IsRequired();

            builder.Property(reset => reset.ValidUntil)
                .IsRequired();

            builder.HasOne(reset => reset.User)
                .WithMany(user => user.PasswordResetCodes)
                .HasForeignKey(reset => reset.UserId);
        }
    }
}
