using Gunetberg.Host.Configuration;

namespace Gunetberg.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddApplicationDependencies(CreateHostBuilder(args).Build()).Run();
        }

        public static WebApplicationBuilder CreateHostBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiConfiguration();
            builder.Services.AddTokenConfiguration(builder.Configuration);
            builder.Services.AddSwaggerConfiguration();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static WebApplication AddApplicationDependencies(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers().RequireAuthorization();
            });

            return app;
        }


    }
}
