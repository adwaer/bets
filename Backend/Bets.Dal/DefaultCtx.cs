using System.Data.Entity;
using Adwaer.Identity.Entitites;
using Bets.Domain;

namespace Bets.Dal
{
    public class DefaultCtx : DbContext
    {
        public DefaultCtx()
            :base("ctx")
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
