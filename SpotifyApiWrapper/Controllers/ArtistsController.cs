using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistManager _artistManager;

        public ArtistsController(IArtistManager artistManager)
        {
            _artistManager = artistManager;
        }


        [HttpGet]
        [Route("artists/{id}")]
        [SwaggerOperation(Summary = "Get an artist", Description = "Get an artist by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Artist found", typeof(Artist))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Artist not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetArtist([FromRoute] string id)
        {
            try
            {
                var artist = await _artistManager.GetArtist(id);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, artist);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null, "SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }


        [HttpGet]
        [Route("artists/{id}/albums")]
        [SwaggerOperation(Summary = "Get an artist's albums", Description = "Get an artist's albums")]
        [SwaggerResponse(StatusCodes.Status200OK, "Albums found", typeof(Album))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Albums not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetArtistAlbums([FromRoute] string id, [FromQuery] ArtistAlbumRequest request)
        {
            try
            {
                var albums = await _artistManager.GetArtistAlbums(id, request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, albums);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null, "SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }

        [HttpGet]
        [Route("artists")]
        [SwaggerOperation(Summary = "Get artists", Description = "Get artists")]
        [SwaggerResponse(StatusCodes.Status200OK, "Artists found", typeof(ArtistResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Artists not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetArtists([FromQuery] ArtistRequest request)
        {
            try
            {
                var artists = await _artistManager.GetArtists(request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, artists);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null, "SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }

        [HttpGet]
        [Route("artists/{id}/top-tracks")]
        [SwaggerOperation(Summary = "Get an artist's top tracks", Description = "Get an artist's top tracks")]
        [SwaggerResponse(StatusCodes.Status200OK, "Top tracks found", typeof(Track))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Top tracks not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetArtistTopTracks([FromRoute] string id, [FromQuery] string market)
        {
            try
            {
                var tracks = await _artistManager.GetArtistsTopTracks(id, market);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, tracks);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null, "SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }


        [HttpGet]
        [Route("artists/{id}/related-artists")]
        [SwaggerOperation(Summary = "Get an artist's related artists", Description = "Get an artist's related artists")]
        [SwaggerResponse(StatusCodes.Status200OK, "Related artists found", typeof(Artist))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Related artists not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetArtistRelatedArtists([FromRoute] string id)
        {
            try
            {
                var artists = await _artistManager.GetArtistsRelatedArtists(id);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, artists);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null, "SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }


    }

}
