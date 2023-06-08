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

            builder.Services.AddAppConfiguration();
            builder.Services.AddTokenConfiguration(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerConfiguration();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }


    }
}
