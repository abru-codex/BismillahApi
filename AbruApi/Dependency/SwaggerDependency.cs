using Microsoft.OpenApi.Models;

namespace AbruApi.Dependency
{
    public static class SwaggerDependency
    {
        public static IServiceCollection AddSwaggerDI(this IServiceCollection Services)
        {
            Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authentication.\r\n\r\n "
                                + "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                   {
                       new OpenApiSecurityScheme
                       {
                           Reference=new OpenApiReference
                           {
                               Type=ReferenceType.SecurityScheme,
                               Id="Bearer"
                           },
                           Scheme="oauth2",
                           Name="Bearer",
                           In=ParameterLocation.Header
                       },
                       new List<string>()
                   }
                });
            });


            return Services;
        }
    }
}
