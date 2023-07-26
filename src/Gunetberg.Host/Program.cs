using Gunetberg.Host.Configuration;
using Gunetberg.Host.Middleware;

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

            builder.Services.AddAppConfiguration(builder.Configuration);
            builder.Services.AddTokenConfiguration(builder.Configuration);
            builder.Services.AddCors(op =>
            {
                op.AddPolicy(
                    name:"DevCorsPolicy",
                    policy =>
                    {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                    });
            });
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
                app.UseCors("DevCorsPolicy");
            }
            
            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }


    }
}
