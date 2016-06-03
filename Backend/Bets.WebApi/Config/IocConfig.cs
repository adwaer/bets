using System;
using System.Data.Entity;
using System.Reflection;
using Adwaer.Identity;
using Adwaer.Identity.Config;
using Adwaer.Identity.Entitites;
using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.WebApi;
using Bets.Cqrs.Query;
using Bets.Dal;
using Bets.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bets.WebApi.Config
{
    public class IocConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<DefaultCtx>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DefaultCtx>()
                .AsSelf()
                .InstancePerRequest();

            builder
                .RegisterType<BetsQuery>()
                .AsSelf()
                .InstancePerRequest();

            builder.Register<IUserStore<SimpleCustomerAccount, Guid>>(c => new IdentityUserStore(new DefaultCtx())).AsImplementedInterfaces();
            builder.Register(c => new IdentityFactoryOptions<IdentityUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });
            builder.RegisterType<IdentityUserManager>();

            builder
                .RegisterModule<NLogModule>();


            IdentityConfig.Ioc(builder);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(typeof(IdentityConfig).Assembly);

            return builder.Build();
        }
    }
}
