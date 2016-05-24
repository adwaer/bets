using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public class UserRole : IdentityUserRole<int>, IEntity<int>
    {
        public string GetId()
        {
            return Id.ToString();
        }

        public int Id { get; set; }
        public SimpleCutomerAccount User { get; set; }
    }
}
