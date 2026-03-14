

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace ItemShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources = new ApiResource[]
        {
            new ApiResource("Resourceatalog") {Scopes ={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount") {Scopes ={"DiscountFullPermission","DiscountReadPermission" }},
            new ApiResource("ResourceOrder") {Scopes ={"OrderFullPermission","OrderReadPermission" }},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources = new IdentityResource[]
        {
          new IdentityResources.OpenId(),
          new IdentityResources.Email(),
          new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes = new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Authorization to Full Catalog Transactions"),
            new ApiScope("CatalogReadPermission","Authorization to Read Catalog Transactions"),
            new ApiScope("OrderFullPermission","Authorization to Full Order Transactions"),
            new ApiScope("OrderReadPermission","Authorization to Read Order Transactions"),
            new ApiScope("OrderFullPermission","Authorization to Full Order Transactions"),
            new ApiScope("DiscountFullPermission","Authorization to Full Discont Transactions"),
            new ApiScope("DiscountReadPermission","Authorization to Read Discont Transactions"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
           new Client
           {
                ClientId ="ItemShopVisitorId",
                ClientName ="ItemShopVisitorUser",
                AllowedGrantTypes =GrantTypes.ClientCredentials,
                ClientSecrets ={new Secret("itemshopsecret".Sha256())},
                AllowedScopes ={"CatalogReadPermission",
                IdentityServerConstants.LocalApi.ScopeName}
                
           },

           new Client
           {
               ClientId ="ItemShopManagerId",
               ClientName ="ItemShopManagerUser",
               AllowedGrantTypes =GrantTypes.ClientCredentials,
               ClientSecrets ={new Secret("itemshopsecret".Sha256())},
               AllowedScopes ={"CatalogFullPermission","CatalogReadPermission","DiscountReadPermission",
               IdentityServerConstants.LocalApi.ScopeName }
           },

           new Client
           {
                ClientId ="ItemShopAdminId",
               ClientName ="ItemShopAdminUser",
               AllowedGrantTypes =GrantTypes.ClientCredentials,
               ClientSecrets ={new Secret("itemshopsecret".Sha256())},
               AllowedScopes ={"CatalogFullPermission","CatalogReadPermission","OrderFullPermission","OrderReadPermission","DiscountReadPermission","DiscountFullPermission",
               IdentityServerConstants.LocalApi.ScopeName,
               IdentityServerConstants.StandardScopes.Email,
               IdentityServerConstants.StandardScopes.OpenId,
               IdentityServerConstants.StandardScopes.Profile
               },
               AccessTokenLifetime =600

           }
        };

    }
}