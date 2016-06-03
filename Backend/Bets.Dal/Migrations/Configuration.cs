using System.Configuration;
using Adwaer.Identity;
using Adwaer.Identity.Entitites;
using Microsoft.AspNet.Identity;

namespace Bets.Dal.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bets.Dal.DefaultCtx>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Bets.Dal.DefaultCtx context)
        {

            //Debugger.Launch();
            if (!context.Customers.Any())
            {
                CreateDefaultAdministrator(context);
            }

            //if (context.Bets.Any())
            //{
            //    return;
            //}

            //context.Bets.Add(new Bet
            //{
            //    Game = "Гласспул Ллойд - Уиттингтон Эндрю",
            //    Tournament = "Теннис. ATP Челленджер",
            //    Content = "Ставка верняк, Эндрю победит",
            //    Coefficient = (decimal)1.7,
            //    Forecast = "П2",
            //    GameStartDate = DateTime.UtcNow.AddHours(10),
            //    MakeDate = DateTime.UtcNow,
            //    ShowDate = DateTime.UtcNow
            //});

            //context.Bets.Add(new Bet
            //{
            //    Game = "Россия - Англия",
            //    Tournament = "Футбол. Чемпионат Европпы 2016",
            //    Content = "Россия форме и забитых голов будет не менее двух",
            //    Coefficient = (decimal)2.3,
            //    Forecast = "ТМ2,5",
            //    GameStartDate = DateTime.UtcNow.AddHours(7),
            //    MakeDate = DateTime.UtcNow,
            //    ShowDate = DateTime.UtcNow
            //});
        }

        private static void CreateDefaultAdministrator(DefaultCtx context)
        {
            const string adwaer = "adwaer@live.ru";
            const string password = "DevPas123";

            var userManager = IdentityUserManager.Get(context);

            var customer = new SimpleCustomerAccount
            {
                UserName = adwaer,
                Email = adwaer,
                EmailConfirmed = true
            };
            var result = userManager.Create(customer);
            if (!result.Succeeded)
            {
                throw new ConfigurationErrorsException("Cannot create user");
            }

            result = userManager.AddPassword(customer.Id, password);
            if (!result.Succeeded)
            {
                throw new ConfigurationErrorsException("Cannot set password for admin user");
            }
            context.SaveChanges();
        }
    }
}
