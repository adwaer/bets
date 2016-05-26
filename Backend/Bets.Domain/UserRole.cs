using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public class UserRole : IdentityUserRole<Guid>, IEntity<Guid>
    {
        public string GetId()
        {
            return Id.ToString();
        }

        public Guid Id { get; set; }
        public SimpleCustomerAccount User { get; set; }
    }
}
