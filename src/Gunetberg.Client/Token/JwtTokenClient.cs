using Gunetberg.Domain.User;
using Gunetberg.Port.Output;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gunetberg.Client.Token
{
    public class JwtTokenClient : ITokenClient
    {
        private readonly TokenConfigurationOptions _tokenOptions;

        public JwtTokenClient(TokenConfigurationOptions options)
        {
                _tokenOptions = options;
        }

        public string CreateToken(AuthorizationUser authorizationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenOptions.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", authorizationUser.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
