using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class AlbumsResponse
    {
        [JsonPropertyName("albums")]
        public List<Album> Albums { get; set; }
    }
}
