using System.ComponentModel.DataAnnotations;

namespace SpotifyApiWrapper.Entities.Requests
{
    public class ArtistRequest
    {
        public List<string>? Ids { get; set; }
    }
}
