using System;

namespace BettingGame.Core.Models.Domain
{
    public class PasswordResetCode
    {
        public int PasswordResetCodeId { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidUntil { get; set; }

        public User User { get; set; }
    }
}
