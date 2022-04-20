using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class FollowManager : IFollowManager
    {
        private readonly ITokenManager _tokenManager;

        public FollowManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<FollowingArtistResponse> FollowingArtist(FollowingArtistRequest request)
        {
            var followingArtist = new FollowingArtistResponse();
            var token = await _tokenManager.GetToken("user-follow-read");

            try
            {
                var url = SpotifyUrls.CurrentUserFollower();

                if (request?.Type != null)
                {
                    url = url.AddParameter("type", request.Type);
                }
                
                if (request?.After != null)
                {
                    url = url.AddParameter("after", request.After);
                }
                
                if (request?.Limit != null)
                {
                    url = url.AddParameter("limit", request.Limit.ToString());
                }


                var response = await ApiHelper.GetAsyncWithScope(token, url, "user-follow-read");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    followingArtist = JsonSerializer.Deserialize<FollowingArtistResponse>(jsonResponse);
                }
            }
            catch (Exception)
            {

                throw;
            }


            return followingArtist;
        }
    }
}
