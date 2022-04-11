using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Helpers;
using SpotifyApiWrapper.Managers.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpotifyApiWrapper.Controllers
{
    [Route("api/albums")]
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
        [Route("getAlbumById/{albumId}")]
        public async Task<IActionResult> GetAlbum([FromRoute]string albumId)
        {
            try
            {
                var album =await _albumManager.GetAlbumAsync(albumId);
                return this.HandleActionResult(System.Net.HttpStatusCode.OK,album);
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
