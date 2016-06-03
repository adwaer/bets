using System;
using System.Data.Entity;
using Bets.Domain;
using Microsoft.AspNet.Identity;

namespace Bets.Identity
{
    public class BetsUserManager : UserManager<SimpleCustomerAccount, Guid>
    {
        public BetsUserManager(IUserStore<SimpleCustomerAccount, Guid> store) 
            : base(store)
        {
            UserTokenProvider = new TotpSecurityStampBasedTokenProvider<SimpleCustomerAccount, Guid>();
            UserValidator = new UserValidator<SimpleCustomerAccount, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public static BetsUserManager Get(DbContext dncontext)
        {
            return new BetsUserManager(new IdentityUserStore(dncontext));
        }
    }
}
