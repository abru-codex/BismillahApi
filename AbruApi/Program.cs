using AbruApi.Dependency;
using AbruApi.Helper;

namespace AbruApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddAuthenticationDI(builder.Configuration.GetValue<string>("ApiSettings:Secret"));
                builder.Services.AddAuthorizationDI();
                builder.Services.AddCorsDI();
                builder.Services.AddMSSQlDI(builder.Configuration.GetConnectionString("Local"));
                builder.Services.AddDataServiceDI();
                builder.Services.AddSwaggerDI();
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();

            }

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("AllowOrigin");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}