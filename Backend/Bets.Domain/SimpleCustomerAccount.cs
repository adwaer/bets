using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public class SimpleCustomerAccount : IdentityUser<Guid, IdentityUserLogin<Guid>, UserRole, IdentityUserClaim<Guid>>, ICustomerAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        [Index("IX_Unique", 1, IsUnique = true), MaxLength(255)]
        public override string UserName { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
