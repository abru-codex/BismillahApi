using AbruApi.Repository.IRepository;
using AbruApi.Repository;
using AbruApi.Service;
using AbruApi.Helper;

namespace AbruApi.Dependency
{
    public static class DataServiceDependency
    {
        public static IServiceCollection AddDataServiceDI(this IServiceCollection Services)
        {
            Services.AddScoped<ITokenGenerator,TokenGenerator>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddAutoMapper(typeof(MappingConfig));
            return Services;
        }
    }
}
