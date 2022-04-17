using Newtonsoft.Json.Linq;
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
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
        public async Task<Album> GetAlbumById(string id, AlbumRequest request)
        {
            var album = new Album();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.Album(id);
                if (!string.IsNullOrEmpty(request?.Market))
                {
                    url = ApiHelper.AddParameter(url, "market", request.Market);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    album = JsonSerializer.Deserialize<Album>(jsonResponse);

                    return album;

                }
            }
            catch (Exception)
            {

                throw;
            }
            return album;

        }

        //get several albums
        public async Task<AlbumsResponse> GetSeveralAlbums(SeveralAlbumRequest request)
        {
            var severalAlbums = new AlbumsResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.Albums();

                if (request?.Ids.Count > 0)
                {
                    url = ApiHelper.AddParameter(url, "ids", string.Join(",", request.Ids));
                }
                if (!string.IsNullOrEmpty(request?.Market))
                {
                    url = ApiHelper.AddParameter(url, "market", request.Market);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    severalAlbums = JsonSerializer.Deserialize<AlbumsResponse>(jsonResponse);

                    return severalAlbums;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return severalAlbums;

        }


        // get an album’s tracks
        public async Task<Paging<Track>> GetAlbumTracks(string id, AlbumTrackRequest request)
        {
            var tracks = new Paging<Track>();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.AlbumTracks(id);

                if (!string.IsNullOrEmpty(request?.Market))
                {
                    url = ApiHelper.AddParameter(url, "market", request.Market);
                }
                if (request?.Limit > 0)
                {
                    url = ApiHelper.AddParameter(url, "limit", request.Limit.ToString());
                }
                if (request?.Offset > 0)
                {
                    url = ApiHelper.AddParameter(url, "offset", request.Offset.ToString());
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    tracks = JsonSerializer.Deserialize<Paging<Track>>(jsonResponse);

                    return tracks;
                }



            }
            catch (Exception)
            {

                throw;
            }
            return tracks;
        }


    }


}
