using BettingGame.Core.Repositories;
using BettingGame.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingGame.Data.Repositories
{
    public class PasswordResetCodeRepository : Repository<BettingGameContext>, IPasswordResetCodeRepository
    {
        public PasswordResetCodeRepository(BettingGameContext context) : base(context)
        {

        }
    }
}
