using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Bets.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bets.Identity
{
    public class BetsUserStore : UserStore<SimpleCutomerAccount, IdentityRole<int, UserRole>, int, IdentityUserLogin<int>, UserRole, IdentityUserClaim<int>>
    {
        public BetsUserStore(DbContext ctx) : base(ctx) { }

        /// <summary>
        /// Insert an entity
        /// </summary>
        /// <param name="user"/>
        public override Task CreateAsync(SimpleCutomerAccount user)
        {
            if (user.Customer == null)
            {
                user.Customer = new Customer
                {
                    DisplayName = user.UserName
                };
            }

            Context
                .Set<SimpleCutomerAccount>()
                .Add(user);

            //if (!user.Roles.Any())
            //{
            //    user.Roles.Add(new UserRole
            //    {
            //        RoleId = Guid.Empty
            //    });
            //}

            Context.Entry(user).State = EntityState.Added;
            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="user"/>
        public override Task UpdateAsync(SimpleCutomerAccount user)
        {
            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Mark an entity for deletion
        /// </summary>
        /// <param name="user"/>
        public override Task DeleteAsync(SimpleCutomerAccount user)
        {
            throw new NotImplementedException();
            //user.IsDeleted = true;
            user.UserName = $"{user.UserName}_{user.Id}";

            return UpdateAsync(user);
        }
        /// <summary>
        /// Find a user by id
        /// </summary>
        /// <param name="userId"/>
        /// <returns/>
        public override async Task<SimpleCutomerAccount> FindByIdAsync(int userId)
        {
            SimpleCutomerAccount user = (await Context.Set<SimpleCutomerAccount>().FirstOrDefaultAsync(u => u.Id == userId));
            return user;
        }
        /// <summary>
        /// Find a user by name
        /// </summary>
        /// <param name="userName"/>
        /// <returns/>
        public override async Task<SimpleCutomerAccount> FindByNameAsync(string userName)
        {
            return await Context
                .Set<SimpleCutomerAccount>()
                .FirstOrDefaultAsync(ac => ac.Email == userName);
        }
    }
}
