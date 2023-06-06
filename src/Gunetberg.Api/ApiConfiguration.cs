using Gunetberg.Api.Converter;
using Gunetberg.Application;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Gunetberg.Api
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<PostApiConverter>();
            return services;
        }
    }
}
