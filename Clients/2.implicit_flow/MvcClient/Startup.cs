using System.Collections.Generic;
using System.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MvcClient;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MvcClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            string idPUrl = "https://localhost:44333/core";
            string clientUrl = "https://9122";

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies",
                CookieName = "mvc.implicit.cookie"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                ClientId = "mvc.owin.implicit",
                Authority = idPUrl,
                SignInAsAuthenticationType = "Cookies",
                RedirectUri = clientUrl,
                ResponseType = "id_token",
                Scope = "openid email",
                UseTokenLifetime = false
            });
        }
    }
}