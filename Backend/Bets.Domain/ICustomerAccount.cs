using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public interface ICustomerAccount : IEntity<Guid>
    {
        Customer Customer { get; set; }
    }
}
