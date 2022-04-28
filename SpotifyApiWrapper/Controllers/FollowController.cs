using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.Requests;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowManager _followManager;

        public FollowController(IFollowManager followManager)
        {
            _followManager = followManager;
        }


        [HttpGet]
        [Route("playlists/{playlist_id}/followers/contains")]
        [SwaggerOperation(Summary = "Check if Users Follow Playlist", Description = "Check if Users Follow Playlist")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns true if user follows playlist", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The request was made with invalid credentials", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The request was made with invalid credentials", typeof(string))]
        public async Task<IActionResult> CheckUserFollowPlaylist([FromRoute] string playlist_id, [FromQuery] string ids)
        {
            try
            {
                var followingArtists = await _followManager.CheckUserFollowPlaylist(playlist_id, ids);
                return this.HandleActionResult(HttpStatusCode.OK, followingArtists);
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
