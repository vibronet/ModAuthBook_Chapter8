using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;

namespace WebAppChapter8
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
            new OpenIdConnectAuthenticationOptions
            {
                ClientId = "818e9037-fc84-46f9-88dd-f8f4738f4e01",//"95dcbcfd-5a64-4efe-a5e3-f4ed2043c46c",
                // Authority = "https://login.microsoftonline.com/DeveloperTenant.onmicrosoft.com",
                // using the common endpoint for the multitenant scenarios.
                Authority = "https://login.microsoftonline.com/common",
                // code for taking control of the issuer validation logic
                TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                {
                    // uncomment this assignment if you want to test sign in form a different tenant without coding custom issuer validation yet
                    ValidateIssuer = false,

                    // pseudo - code as a placeholder for your own issuer validation logic
                    //     IssuerValidator = (issuer, token, tvp) =>
                    //     {
                    //        //if(db.Issuers.FirstOrDefault(b => (b.Issuer == issuer)) == null)
                    //        return issuer;
                    //        //else
                    //        //    throw new SecurityTokenInvalidIssuerException("Invalid issuer");
                    //    },

                    // this assignment makes the incoming Azure AD roles claims available for use with [Authorize] and IsInRole
                    // RoleClaimType = "roles",
                    // this assignment makes the incoming Azure AD groups claims available for use with [Authorize] and IsInRole
                    // RoleClaimType = "groups",
                },
                PostLogoutRedirectUri = "https://localhost:44300/",
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    RedirectToIdentityProvider = (context) =>
                    {
                        // uncomment the line below for triggering the admin consent flow at sign in time
                        // context.ProtocolMessage.Prompt = "admin_consent";
                        return Task.FromResult(0);
                    },
                },
            }
            );
            

        }
    }
}