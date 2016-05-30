using System.Collections.Generic;

namespace Bets.Domain
{
    public class Customer : EntityBase<int>
    {
        public string DisplayName { get; set; }
        public virtual ICollection<SimpleCustomerAccount> SimpleCutomerAccounts { get; set; }
    }
}
