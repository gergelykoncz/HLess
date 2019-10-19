using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLess.API.Identity
{
    /// <summary>
    /// IdentityServer4 configuration
    /// </summary>
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids
        {
            get
            {
                return new IdentityResource[]
                {
                    new IdentityResources.OpenId()
                };
            }
        }

        public static IEnumerable<ApiResource> Apis
        {
            get
            {
                return new ApiResource[]
                {
                    new ApiResource("hless.api", "HLess API")
                };
            }
        }

        public static IEnumerable<Client> Clients
        {
            get
            {
                return new Client[]
                {
                    new Client
                    {
                        ClientId = "spa",
                        ClientName = "SPA Client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = { new Secret("secret".Sha256())},
                        AllowOfflineAccess = true,
                        AllowedScopes = {"openid", "hless.api"}
                    }
                };
            }
        }
    }
}
