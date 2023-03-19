
using Microsoft.EntityFrameworkCore;
using AbruApi.DataAccess;

namespace AbruApi.Dependency
{
    public static class DbDependency
    {
        public static IServiceCollection AddMSSQlDI(this IServiceCollection Services,string? ConString)
        {
            Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(ConString);
            });
            return Services;
        }
    }
}
