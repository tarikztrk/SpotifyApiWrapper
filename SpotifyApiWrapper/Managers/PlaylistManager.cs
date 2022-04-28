using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class PlaylistManager : IPlaylistManager
    {
        private readonly ITokenManager _tokenManager;

        public PlaylistManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<List<Image>> GetPlaylistImages(string playlistId)
        {
            var playlistImage = new List<Image>();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.PlaylistImages(playlistId);

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    playlistImage = JsonSerializer.Deserialize<List<Image>>(jsonResponse);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new SpotifyApiException("Playlist images not found", response.StatusCode);
                }
                else
                {
                    throw new SpotifyApiException("Something got wrong.", response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                if (ex is SpotifyApiException)
                {
                    throw;
                }
                throw new Exception();
            }
            return playlistImage;
        }

        public async Task<Playlists> GetPlaylist(string playlistId, string market, string fields)
        {
            var playlist = new Playlists();
            var token = await _tokenManager.GetToken();
            try
            {
                var url = SpotifyUrls.Playlist(playlistId);

                url = ApiHelper.AddParameter(url, "market", market);

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    playlist = JsonSerializer.Deserialize<Playlists>(jsonResponse);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new SpotifyApiException("Playlist not found", response.StatusCode);
                }
                else
                {
                    throw new SpotifyApiException("Something got wrong.", response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                if (ex is SpotifyApiException)
                {
                    throw;
                }
                throw new Exception();
            }
            return playlist;
        }
    }
}
