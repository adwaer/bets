using System;
using System.Data.Entity;
using Bets.Domain;
using Microsoft.AspNet.Identity;

namespace Bets.Identity
{
    public class BetsUserManager : UserManager<SimpleCutomerAccount, int>
    {
        public BetsUserManager(IUserStore<SimpleCutomerAccount, int> store) : base(store)
        {
            UserTokenProvider = new TotpSecurityStampBasedTokenProvider<SimpleCutomerAccount, int>();
            UserValidator = new UserValidator<SimpleCutomerAccount, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public static BetsUserManager Get(DbContext dncontext)
        {
            return new BetsUserManager(new BetsUserStore(dncontext));
        }
    }
}
