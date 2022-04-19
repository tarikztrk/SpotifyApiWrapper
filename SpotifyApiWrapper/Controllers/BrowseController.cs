using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Categories;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BrowseController : ControllerBase
    {
        private readonly IBrowseManager _browseManager;

        public BrowseController(IBrowseManager browseManager)
        {
            _browseManager = browseManager;
        }

        [HttpGet]
        [Route("browse/categories")]
        [SwaggerOperation(Summary = "Get a list of categories", Description = "Get a list of categories")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of categories", typeof(CategoriesResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetCategories([FromQuery] CategoriesRequest request)
        {
            try
            {
                var categories = await _browseManager.GetCategories(request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, categories);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("browse/categories/{categoryId}")]
        [SwaggerOperation(Summary = "Get a list of categories", Description = "Get a list of categories")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of categories", typeof(CategoriesResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetCategory([FromRoute] string categoryId, [FromQuery] CategoryRequest request)
        {
            try
            {
                var category = await _browseManager.GetCategory(categoryId, request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, category);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpGet]
        [Route("browse/categories/{categoryId}/playlist")]
        [SwaggerOperation(Summary = "Get a playlistlist of categories", Description = "Get a list of categories")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of categories", typeof(CategoryPlaylistsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetCategoryPlaylist([FromRoute] string categoryId, [FromQuery] CategoryPlaylistRequest request)
        {
            try
            {
                var category = await _browseManager.GetCategoryPlaylists(categoryId, request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("browse/available-genre-seeds")]
        [SwaggerOperation(Summary = "Get a list of available genre seeds", Description = "Get a list of available genre seeds")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of available genre seeds", typeof(Genre))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetAvailableGenreSeeds()
        {
            try
            {
                var genre = await _browseManager.GetAvailableGenreSeeds();
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, genre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("browse/featured-playlists")]
        [SwaggerOperation(Summary = "Get a list of featured playlists", Description = "Get a list of featured playlists")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of featured playlists", typeof(FeaturedPlaylistsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetFeaturedPlaylists([FromQuery] FeaturedPlaylistsRequest request)
        {
            try
            {
                var featuredPlaylists = await _browseManager.GetFeaturedPlaylists(request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, featuredPlaylists);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("browse/new-releases")]
        [SwaggerOperation(Summary = "Get a list of new releases", Description = "Get a list of new releases")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of new releases", typeof(NewReleaseResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(string))]
        public async Task<IActionResult> GetNewReleases([FromQuery] CategoryPlaylistRequest request)
        {
            try
            {
                var newReleases = await _browseManager.GetNewReleases(request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, newReleases);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
