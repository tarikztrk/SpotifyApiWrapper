using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Categories;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;

namespace SpotifyApiWrapper.Managers.Interfaces
{
    public interface IBrowseManager
    {
        Task<CategoriesResponse> GetCategories(CategoriesRequest request);
        Task<Category> GetCategory(string id, CategoryRequest request);
        Task<CategoryPlaylistsResponse> GetCategoryPlaylists(string categoryId, CategoryPlaylistRequest request);
        Task<Genre> GetAvailableGenreSeeds();
        Task<FeaturedPlaylistsResponse> GetFeaturedPlaylists(FeaturedPlaylistsRequest request);
        Task<NewReleaseResponse> GetNewReleases(CategoryPlaylistRequest request);
    }
}