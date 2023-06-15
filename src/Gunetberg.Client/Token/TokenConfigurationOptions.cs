using System.Text;

namespace Gunetberg.Client.Token
{
    public class TokenConfigurationOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public byte[] EncodedKey => Encoding.UTF8.GetBytes(Key);
        public bool ValidateIssuer { get; set; } = true;
        public bool ValidateAudience { get; set; } = true;
        public bool ValidateLifetime { get; set; } = true;
        public bool ValidateIssuerSigningKey { get; set; } = true;
    }
}
