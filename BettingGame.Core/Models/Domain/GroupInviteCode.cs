using System;
using System.Collections.Generic;

namespace BettingGame.Core.Models.Domain
{
    public class GroupInviteCode
    {
        public int GroupInviteCodeId { get; set; }
        public int GroupId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidUntil { get; set; }

        public Group Group { get; set; }
        public ICollection<GroupInviteCodeUsage> Usages { get; set; }
    }
}
