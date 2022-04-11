using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities
{
    public class Followers
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
