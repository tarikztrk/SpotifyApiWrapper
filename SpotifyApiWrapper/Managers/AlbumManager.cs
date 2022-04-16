using Newtonsoft.Json.Linq;
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class AlbumManager : IAlbumManager
    {
        private readonly ITokenManager _tokenManager;
        private readonly HttpClient _httpClient;

        public AlbumManager(ITokenManager tokenManager, HttpClient httpClient)
        {
            _tokenManager = tokenManager;
            _httpClient = httpClient;
        }
        public async Task<Album> GetAlbumAsync(string albumId)
        {
            var token = await _tokenManager.GetToken();

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                _httpClient.BaseAddress = new System.Uri("https://api.spotify.com/v1/");

                var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/albums/{albumId}");

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var album = JsonSerializer.Deserialize<Album>(jsonResponse);

                return album;
            }
            catch (Exception)
            {

                throw;
            }
           

        }

    }
}
