using Gunetberg.Api.Converter;
using Gunetberg.Application.Authorization;
using Gunetberg.Application.Post;
using Gunetberg.Application.Tag;
using Gunetberg.Application.User;
using Gunetberg.Client.Hash;
using Gunetberg.Client.Identity;
using Gunetberg.Client.Token;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository;
using Gunetberg.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunetberg.Host.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Api
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            services.AddTransient<RepositoryContextFactory>();

            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            //Clients
            services.AddSingleton<IHashClient, Sha256HashClient>();
            services.AddTransient<IdentityUtil>();
            services.AddSingleton<ITokenClient>(
                new JwtTokenClient(
                    configuration.GetSection(nameof(TokenConfigurationOptions)).Get<TokenConfigurationOptions>()
                )
            );

            //Services
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ITagService, TagService>();

            //Converters
            services.AddTransient<AuthorizationApiConverter>();
            services.AddTransient<UserApiConverter>();
            services.AddTransient<PostApiConverter>();
            services.AddTransient<TagApiConverter>();
            return services;
        }
    }
}
