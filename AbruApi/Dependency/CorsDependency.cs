using System.Runtime.CompilerServices;

namespace AbruApi.Dependency
{
    public static class CorsDependency
    {
        public static IServiceCollection AddCorsDI(this IServiceCollection Services)
        {
            Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", coreConfig => coreConfig.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return Services;
        }
    }
}
