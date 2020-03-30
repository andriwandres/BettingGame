using System;
using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int CountryId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool EmailConfirmed { get; set; }

        public Group Group { get; set; }
        public Country Country { get; set; }
        public UserRanking Ranking { get; set; }
        public ICollection<Bet> Bets { get; set; }
        public ICollection<GroupMembership> GroupMemberships { get; set; }
        public ICollection<PasswordResetCode> PasswordResetCodes { get; set; }
        public ICollection<GroupInviteCodeUsage> GroupInviteCodeUsages { get; set; }
    }
}
