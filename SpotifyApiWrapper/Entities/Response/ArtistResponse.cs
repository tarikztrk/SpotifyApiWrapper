using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class ArtistResponse
    {
        [JsonPropertyName("artists")]
        public List<Artist> Artists { get; set; }
    }
}
