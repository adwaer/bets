using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public class SimpleCutomerAccount : IdentityUser<int, IdentityUserLogin<int>, UserRole, IdentityUserClaim<int>>, ICutomerAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Index("IX_Unique", 1, IsUnique = true), MaxLength(255)]
        public override string UserName { get; set; }
        public Customer Customer { get; set; }
    }
}
