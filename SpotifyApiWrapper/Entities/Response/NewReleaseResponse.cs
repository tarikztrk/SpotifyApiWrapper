using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class NewReleaseResponse
    {
        [JsonPropertyName("albums")]
        public Paging<Album>? Albums { get; set; }
    }
}
