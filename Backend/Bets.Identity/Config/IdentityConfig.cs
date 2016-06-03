using System;
using System.Web;
using Autofac;
using Bets.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bets.Identity.Config
{
    public static class IdentityConfig
    {
        public static void Ioc(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityUserStore>()
                .As<IUserStore<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<IdentityUserManager>()
                .As<UserManager<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<SignInManager<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerLifetimeScope();

            builder
                .Register(c => IdentityMapper.Register())
                .Keyed<IMapper>("identityMapping")
                .As<IMapper>()
                .SingleInstance();
        }
    }
}
