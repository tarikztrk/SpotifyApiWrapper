using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistManager _playlistManager;

        public PlaylistController(IPlaylistManager playlistManager)
        {
            _playlistManager = playlistManager;
        }

        [HttpGet]
        [Route("playlists/{playlist_id}/images")]
        [SwaggerOperation(Summary = "Get playlist images", Description = "Get playlist images")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the playlist images", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Returns a message if the playlist does not exist", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Returns a message if the server is unable to process the request", typeof(string))]
        public async Task<IActionResult> GetPlaylistImages([FromRoute] string playlist_id)
        {
            try
            {
                var playlistImages = await _playlistManager.GetPlaylistImages(playlist_id);
                return this.HandleActionResult(HttpStatusCode.OK, playlistImages);
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
        [Route("playlists/{playlist_id}")]
        [SwaggerOperation(Summary = "Get playlist", Description = "Get playlist")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the playlist", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Returns a message if the playlist does not exist", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Returns a message if the server is unable to process the request", typeof(string))]
        public async Task<IActionResult> GetPlaylist([FromRoute] string playlist_id, [FromQuery] string market, [FromQuery] string fields)
        {
            try
            {
                var playlist = await _playlistManager.GetPlaylist(playlist_id, market, fields);
                return this.HandleActionResult(HttpStatusCode.OK, playlist);
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
