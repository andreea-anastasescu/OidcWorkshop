using System.Web.Http;
using Api;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Api.Startup))]
namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}