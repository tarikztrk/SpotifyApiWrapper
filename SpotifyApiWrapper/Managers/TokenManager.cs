using Microsoft.Extensions.Caching.Memory;
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Managers.Interfaces;

namespace SpotifyApiWrapper.Managers
{
    public class TokenManager : ITokenManager
    {
        readonly IConfiguration _configuration;
        readonly IClientCredentials _clientCredentials;
        private readonly IMemoryCache _cacheManager;

        public TokenManager(IConfiguration configuration, IClientCredentials clientCredentials, IMemoryCache cacheManager)
        {
            _configuration = configuration;
            _clientCredentials = clientCredentials;
            _cacheManager = cacheManager;
        }

        public async Task<Token> GetToken()
        {
            var token = new Token();
            var request = new AuthParameters()
            {
                ClientId = _configuration["ClientAuthorization:ClientId"],
                ClientSecret = _configuration["ClientAuthorization:ClientSecret"],
                GrantType = _configuration["ClientAuthorization:GrantType"]
            };

            var cacheKey = "Token";

            if (_cacheManager.TryGetValue(cacheKey, out Token cacheValue))
            {
                token = cacheValue;
            }
            else
            {

                token = await _clientCredentials.GetToken(request); ;
                
                _cacheManager.Set(cacheKey, token, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(token.ExpiresIn)
                });
            }
            return token;
        }

    }
}
