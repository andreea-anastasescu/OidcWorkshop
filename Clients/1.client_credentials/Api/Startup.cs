using System.Collections.Generic;
using System.Web.Http;
using Api;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Security;
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
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new List<string>(){ "api1"},
               
                //AuthenticationMode = AuthenticationMode.Passive
               
            });
            app.UseWebApi(config);
        }
    }
}