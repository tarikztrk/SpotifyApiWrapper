using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Categories;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using System.Text.Json;

namespace SpotifyApiWrapper.Managers
{
    public class BrowseManager : IBrowseManager
    {
        private readonly ITokenManager _tokenManager;

        public BrowseManager(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<CategoriesResponse> GetCategories(CategoriesRequest request)
        {
            var category = new CategoriesResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.Categories();
                if (request?.Locale != null)
                {
                    url = ApiHelper.AddParameter(url, "locale", request.Locale);
                }

                if (request?.Country != null)
                {
                    url = ApiHelper.AddParameter(url, "country", request.Country);
                }

                if (request?.Offset != null)
                {
                    url = ApiHelper.AddParameter(url, "offset", request.Offset);
                }

                if (request?.Limit != null)
                {
                    url = ApiHelper.AddParameter(url, "limit", request.Limit);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    category = JsonSerializer.Deserialize<CategoriesResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return category;
        }

        public async Task<Category> GetCategory(string categoryId, CategoryRequest request)
        {
            var category = new Category();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.Category(categoryId);
                if (request?.Locale != null)
                {
                    url = ApiHelper.AddParameter(url, "locale", request.Locale);
                }

                if (request?.Country != null)
                {
                    url = ApiHelper.AddParameter(url, "country", request.Country);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    category = JsonSerializer.Deserialize<Category>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return category;
        }

        public async Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoryPlaylistRequest request)
        {
            var categoryPlaylists = new CategoryPlaylistsResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.CategoryPlaylists(categoryId);

                if (request?.Country != null)
                {
                    url = ApiHelper.AddParameter(url, "country", request.Country);
                }

                if (request?.Offset != null)
                {
                    url = ApiHelper.AddParameter(url, "offset", request.Offset);
                }

                if (request?.Limit != null)
                {
                    url = ApiHelper.AddParameter(url, "limit", request.Limit);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    categoryPlaylists = JsonSerializer.Deserialize<CategoryPlaylistsResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return categoryPlaylists;
        }


        //GetAvailableGenreSeeds
        public async Task<Genre> GetAvailableGenreSeeds()
        {
            var genre = new Genre();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.RecommendationGenres();
                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    genre = JsonSerializer.Deserialize<Genre>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return genre;
        }

        //GetFeaturedPlaylists
        public async Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(FeaturedPlaylistsRequest request)
        {
            var featuredPlaylists = new FeaturedPlaylistsResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.FeaturedPlaylists();
                if (request?.Country != null)
                {
                    url = ApiHelper.AddParameter(url, "country", request.Country);
                }

                if (request?.Locale != null)
                {
                    url = ApiHelper.AddParameter(url, "locale", request.Locale);
                }
                if (request?.Timestamp != null)
                {
                    url = ApiHelper.AddParameter(url, "timestamp", request.Timestamp);
                }

                if (request?.Limit != null)
                {
                    url = ApiHelper.AddParameter(url, "limit", request.Limit);
                }

                if (request?.Offset != null)
                {
                    url = ApiHelper.AddParameter(url, "offset", request.Offset);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    featuredPlaylists = JsonSerializer.Deserialize<FeaturedPlaylistsResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return featuredPlaylists;
        }

        //GetNewReleases
        public async Task<NewReleaseResponse> GetNewReleases(CategoryPlaylistRequest request)
        {
            var newReleases = new NewReleaseResponse();
            var token = await _tokenManager.GetToken();

            try
            {
                var url = SpotifyUrls.NewReleases();
                if (request?.Country != null)
                {
                    url = ApiHelper.AddParameter(url, "country", request.Country);
                }

                if (request?.Limit != null)
                {
                    url = ApiHelper.AddParameter(url, "limit", request.Limit);
                }

                if (request?.Offset != null)
                {
                    url = ApiHelper.AddParameter(url, "offset", request.Offset);
                }

                var response = await ApiHelper.GetAsync(token, url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    newReleases = JsonSerializer.Deserialize<NewReleaseResponse>(jsonResponse);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return newReleases;
        }

    }
}
