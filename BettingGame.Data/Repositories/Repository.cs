using Microsoft.EntityFrameworkCore;

namespace BettingGame.Data.Repositories
{
    public abstract class Repository<TContext> where TContext : DbContext
    {
        protected readonly TContext Context;

        public Repository(TContext context)
        {
            Context = context;
        }
    }
}
