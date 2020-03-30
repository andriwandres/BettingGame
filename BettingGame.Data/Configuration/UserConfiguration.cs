using BettingGame.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingGame.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.UserId);

            builder.Property(user => user.Email)
                .IsRequired();

            builder.Property(user => user.Username)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(user => user.CountryId)
                .IsRequired();

            builder.Property(user => user.PasswordHash)
                .IsRequired();

            builder.Property(user => user.PasswordSalt)
                .IsRequired();

            builder.Property(user => user.CreatedAt)
                .IsRequired();

            builder.Property(user => user.EmailConfirmed)
                .IsRequired();

            builder.HasOne(user => user.Group)
                .WithOne(group => group.Creator);

            builder.HasOne(user => user.Country)
                .WithMany(country => country.Users)
                .HasForeignKey(user => user.CountryId);

            builder.HasOne(user => user.Ranking)
                .WithOne(ranking => ranking.User);

            builder.HasMany(user => user.Bets)
                .WithOne(bet => bet.User);

            builder.HasMany(user => user.GroupMemberships)
                .WithOne(membership => membership.User);

            builder.HasMany(user => user.PasswordResetCodes)
                .WithOne(reset => reset.User);

            builder.HasMany(user => user.GroupInviteCodeUsages)
                .WithOne(usage => usage.User);
        }
    }
}
