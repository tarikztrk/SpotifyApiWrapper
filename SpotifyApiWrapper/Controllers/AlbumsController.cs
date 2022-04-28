using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumManager _albumManager;

        public AlbumsController(IAlbumManager albumManager)
        {
            _albumManager = albumManager;
        }

        // GET: api/<AlbumsController>
        [HttpGet]
        [Route("albums/{id}")]
        [SwaggerResponse(statusCode: 200, type: typeof(Album), description: "Album")]
        [SwaggerResponse(statusCode: 400, type: typeof(HttpErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 401, type: typeof(HttpErrorResponse), description: "Unauthorized")]
        [SwaggerResponse(statusCode: 403, type: typeof(HttpErrorResponse), description: "Forbidden")]
        [SwaggerResponse(statusCode: 404, type: typeof(HttpErrorResponse), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(HttpErrorResponse), description: "Internal Server Error")]
        public async Task<IActionResult> GetAlbum([FromRoute]string id,[FromQuery]AlbumRequest request)

        {
            try
            {
                var album = await _albumManager.GetAlbumById(id,request);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK,album);
            }
            catch (SpotifyApiException businessException)
            {
                return this.HandleActionResult(businessException.StatusCode, null, businessException.Code);
            }
            catch (Exception)
            {
                return this.HandleActionResult(System.Net.HttpStatusCode.InternalServerError, null,"SPOTIFY-API-SYSTEM-EXCEPTION");
            }
        }

        [HttpGet]
        [Route("albums")]
        [SwaggerResponse(statusCode: 200, type: typeof(Album), description: "Album")]
        [SwaggerResponse(statusCode: 400, type: typeof(HttpErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 401, type: typeof(HttpErrorResponse), description: "Unauthorized")]
        [SwaggerResponse(statusCode: 403, type: typeof(HttpErrorResponse), description: "Forbidden")]
        [SwaggerResponse(statusCode: 404, type: typeof(HttpErrorResponse), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(HttpErrorResponse), description: "Internal Server Error")]
        public async Task<IActionResult> GetAlbums([FromQuery]SeveralAlbumRequest request)
        {
            try
            {
                var albums = await _albumManager.GetSeveralAlbums(request);
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
        [Route("albums/{id}/tracks")]
        [SwaggerResponse(statusCode: 200, type: typeof(Track), description: "Track")]
        [SwaggerResponse(statusCode: 400, type: typeof(HttpErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 401, type: typeof(HttpErrorResponse), description: "Unauthorized")]
        [SwaggerResponse(statusCode: 403, type: typeof(HttpErrorResponse), description: "Forbidden")]
        [SwaggerResponse(statusCode: 404, type: typeof(HttpErrorResponse), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(HttpErrorResponse), description: "Internal Server Error")]
        public async Task<IActionResult> GetAlbumTracks([FromRoute] string id, [FromQuery] AlbumTrackRequest request)
        {
            try
            {
                var tracks = await _albumManager.GetAlbumTracks(id, request);
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
        
        

    }
}
