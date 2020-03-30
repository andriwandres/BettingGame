using System;

namespace BettingGame.Core.Models.Domain
{
    public class GroupInviteCodeUsage
    {
        public int GroupInviteCodeUsageId { get; set; }
        public int UserId { get; set; }
        public int GroupInviteCodeId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public GroupInviteCode GroupInviteCode { get; set; }
    }
}
