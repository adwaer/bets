using System;
using System.ComponentModel;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Bets.WebApi.Config;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Bets.BackOffice.Startup))]

namespace Bets.BackOffice
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            var container = IocConfig.Configure();
            ConfigureApp(container, app);

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Service is online.");
            });
        }

        private void ConfigureApp(Autofac.IContainer container, IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(container)
            };

            HttpConfiguration.Formatters.Clear();
            HttpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());
            HttpConfiguration.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(HttpConfiguration);

            RouteConfig.Register(HttpConfiguration);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(HttpConfiguration);
        }
    }
}
