using System;
using System.Data.Entity;
using System.Reflection;
using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.WebApi;
using Bets.Cqrs.Query;
using Bets.Dal;
using Bets.Domain;
using Bets.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            builder.Register<IUserStore<SimpleCustomerAccount, Guid>>(c => new BetsUserStore(new DefaultCtx())).AsImplementedInterfaces();
            builder.Register(c => new IdentityFactoryOptions<BetsUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });
            builder.RegisterType<BetsUserManager>();

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
