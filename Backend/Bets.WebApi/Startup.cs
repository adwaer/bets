﻿using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Bets.Dal;
using Bets.Domain;
using Microsoft.Owin.Cors;
using Bets.WebApi.Config;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Bets.WebApi
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

        private void ConfigureApp(IContainer container, IAppBuilder app)
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
