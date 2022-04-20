using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("me/following")]
        [SwaggerOperation(Summary = "Get the current user’s followed artists", Description = "Get the current user’s followed artists")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the current user’s followed artists", typeof(FollowingArtistResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The request was made with invalid credentials", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The request was made with invalid credentials", typeof(string))]
        public async Task<IActionResult> GetFollowingArtist([FromQuery] FollowingArtistRequest request)
        {
            try
            {
                var followingArtists =await _followManager.FollowingArtist(request);
                return this.HandleActionResult(HttpStatusCode.OK, followingArtists);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
