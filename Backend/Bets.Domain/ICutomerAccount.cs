using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Domain
{
    public interface ICutomerAccount : IEntity<int>
    {
        Customer Customer { get; set; }
    }
}
