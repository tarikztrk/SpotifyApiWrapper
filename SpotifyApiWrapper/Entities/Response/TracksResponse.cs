using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class TracksResponse
    {
        [JsonPropertyName("tracks")]
        public List<Artist> Tracks { get; set; }
    }
}
