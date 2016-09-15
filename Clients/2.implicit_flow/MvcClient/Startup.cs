using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
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
            string clientUrl = "http://localhost:9122";

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies",
                CookieName = "mvc.implicit.cookie"
            });

            var options = new OpenIdConnectAuthenticationOptions();
            options.ClientId = "implicit-client";
            options.Authority = idPUrl;
            options.SignInAsAuthenticationType = "Cookies";
            options.RedirectUri = clientUrl;
            options.ResponseType = "id_token token";
            options.Scope = "openid email";
            options.UseTokenLifetime = false;
            options.Notifications = new OpenIdConnectAuthenticationNotifications
            {
               
                SecurityTokenValidated = async notification =>
                {
                    var idTokenClaim = new Claim("id_token", notification.ProtocolMessage.IdToken);
                    notification.AuthenticationTicket.Identity.AddClaim(idTokenClaim);
                },
            };
            app.UseOpenIdConnectAuthentication(options);
        }
    }
}