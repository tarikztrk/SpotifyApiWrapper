using System.ComponentModel.DataAnnotations;

namespace SpotifyApiWrapper.Entities.Requests
{
    public class SeveralAlbumRequest
    {
        public List<string>? Ids { get; set; }
        public string? Market { get; set; }
    }
}
