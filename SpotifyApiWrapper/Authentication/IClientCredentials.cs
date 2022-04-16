using SpotifyApiWrapper.Entities;

namespace SpotifyApiWrapper.Authentication
{
    public interface IClientCredentials
    {
        string GetAuthorizationHeader();
        Task<Token> GetToken(AuthParameters parameters);
    }
}