using System;

namespace BettingGame.Core.Models.Domain
{
    public class GroupMembership
    {
        public int GroupMembershipId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
