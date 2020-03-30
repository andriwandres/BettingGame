using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }

        public User Creator { get; set; }
        public ICollection<GroupMembership> Memberships { get; set; }
        public ICollection<GroupInviteCode> InviteCodes { get; set; }
    }
}
