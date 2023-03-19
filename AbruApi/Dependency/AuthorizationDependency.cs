using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AbruApi.Dependency
{
    public static class AuthorizationDependency
    {
        public static IServiceCollection AddAuthorizationDI(this IServiceCollection Services )
        {
            Services.AddAuthorization(opts =>
            {
                opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });
            return Services;
        }
    }
}
