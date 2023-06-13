﻿using Gunetberg.Api.Converter;
using Gunetberg.Application.Authorization;
using Gunetberg.Application.Post;
using Gunetberg.Application.User;
using Gunetberg.Client.Token;
using Gunetberg.Port.Input;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;
using Gunetberg.Repository;
using Gunetberg.Repository.Configuration;

namespace Gunetberg.Host.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddSingleton<IConnectionFactory>(
                new ConnectionFactory(configuration.GetConnectionString("DatabaseConnection"))
            );

            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            //Clients
            services.AddTransient<ITokenClient, JwtTokenClient>();

            //Services
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();

            //Converters
            services.AddTransient<AuthorizationApiConverter>();
            services.AddTransient<UserApiConverter>();
            services.AddTransient<PostApiConverter>();
            return services;
        }
    }
}