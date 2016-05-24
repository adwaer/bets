using System.Collections.Generic;

namespace Bets.Domain
{
    public class Customer : EntityBase<int>
    {
        public string DisplayName { get; set; }
        public ICollection<SimpleCutomerAccount> SimpleCutomerAccounts { get; set; }
    }
}
