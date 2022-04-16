using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Managers.Interfaces;

namespace SpotifyApiWrapper.Managers
{
    public class TokenManager : ITokenManager
    {
        readonly IConfiguration _configuration;
        readonly IClientCredentials _clientCredentials;

        public TokenManager(IConfiguration configuration, IClientCredentials clientCredentials)
        {
            _configuration = configuration;
            _clientCredentials = clientCredentials;
        }


        public async Task<Token> GetToken()
        {
            var request = new AuthParameters()
            {
                ClientId = _configuration["ClientAuthorization:ClientId"],
                ClientSecret = _configuration["ClientAuthorization:ClientSecret"],
                GrantType = _configuration["ClientAuthorization:GrantType"]
            };

            var token = await _clientCredentials.GetToken(request);

            return token;
        }
    }
}
