using Gunetberg.Client.Token;
using Microsoft.IdentityModel.Tokens;

namespace Gunetberg.Host.Configuration
{
    public static class TokenConfiguration
    {
        public static IServiceCollection AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfigurationOptions = configuration.GetSection(nameof(TokenConfigurationOptions)).Get<TokenConfigurationOptions>();
            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    //ValidAudience = tokenConfigurationOptions.Audience,
                    //ValidIssuer = tokenConfigurationOptions.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenConfigurationOptions.EncodedKey)
                };
            });

            return services;
        }
    }
}
