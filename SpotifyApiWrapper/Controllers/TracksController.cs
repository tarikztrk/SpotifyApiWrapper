using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Entities.AudioAnalysis;
using SpotifyApiWrapper.Entities.Response;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackManager _trackManager;

        public TracksController(ITrackManager trackManager)
        {
            _trackManager = trackManager;
        }

        [HttpGet]
        [Route("tracks/{id}")]
        [SwaggerOperation(Summary = "Get a track", Description = "Get a track by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Track found", typeof(Track))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Track not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetTrack([FromRoute]string id,[FromQuery]string market)
        {
           
            try
            {
                var track =await _trackManager.GetTrack(id,market);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, track);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("tracks")]
        [SwaggerOperation(Summary = "Get tracks", Description = "Get tracks by ids")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tracks found", typeof(Track))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Tracks not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetTracks([FromQuery] string ids, [FromQuery] string market)
        {
            try
            {
                var tracks = await _trackManager.GetTracks(ids, market);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, tracks);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("audio-features/{id}")]
        [SwaggerOperation(Summary = "Get audio features", Description = "Get audio features by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio features found", typeof(AudioFeatures))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Audio features not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetAudioFeatures([FromRoute]string id)
        {
            try
            {
                var audioFeatures = await _trackManager.GetAudioFeatures(id);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, audioFeatures);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("audio-features")]
        [SwaggerOperation(Summary = "Get audio features", Description = "Get audio features by ids")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio features found", typeof(AudioFeaturesResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Audio features not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetAudiosFeatures([FromQuery] string ids)
        {
            try
            {
                var audioFeatures = await _trackManager.GetAudiosFeatures(ids);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, audioFeatures);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("audio-analysis/{id}")]
        [SwaggerOperation(Summary = "Get audio analysis", Description = "Get audio analysis by id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Audio analysis found", typeof(AudioAnalysis))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Audio analysis not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
        public async Task<IActionResult> GetAudioAnalysis([FromRoute] string id)
        {
            try
            {
                var audioAnalysis = await _trackManager.GetAudioAnalysis(id);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK, audioAnalysis);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
