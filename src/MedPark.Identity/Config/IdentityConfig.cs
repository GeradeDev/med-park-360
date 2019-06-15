using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Config
{
    public class IdentityConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource()
                {
                    DisplayName = "firstName",
                    Name = "firstName",
                    UserClaims = new List<string>()
                    {
                        "firstName"
                    }
                },
                new IdentityResource()
                {
                    DisplayName = "identityid",
                    Name = "identityid",
                    UserClaims = new List<string>()
                    {
                        "identityid"
                    }
                },
                new IdentityResource()
                {
                    DisplayName = "Account Type",
                    Name = "accounttype",
                    UserClaims = new List<string>()
                    {
                        "accounttype"
                    }
                }
            };
        }
        
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>() {
                
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "medpark-web",
                    ClientName = "Med-Park 360",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = { "https://localhost:44356/signin-oidc" },
                    AllowedScopes = { "openid", "email", "profile", "firstName", "identityid", "accounttype" },
                    PostLogoutRedirectUris = { "https://localhost:44356/signout-callback-oidc" },

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = false,                    
                },
                new Client
                {
                    ClientId = "blog",
                    ClientName = "Gerade Geldenhuys Personal Website",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "https://localhost:44366/signin-oidc" },
                    AllowedScopes = { "openid", "email", "profile" },

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                }
            };
        }
    }
}
