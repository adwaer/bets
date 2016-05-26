using System;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using Bets.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Bets.Identity
{
    public static class IdentityConfig
    {
        public static void Ioc(ContainerBuilder builder)
        {
            builder.RegisterType<BetsUserStore>()
                .As<IUserStore<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<BetsUserManager>()
                .As<UserManager<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<SignInManager<SimpleCustomerAccount, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerLifetimeScope();
        }
    }
}
