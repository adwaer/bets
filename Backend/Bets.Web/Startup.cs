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

[assembly: OwinStartup(typeof(Bets.Web.Startup))]

namespace Bets.Web
{
    public class Startup : WebApi.Startup
    {
       
    }
}
