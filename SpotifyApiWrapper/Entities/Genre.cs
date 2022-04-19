using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities
{
    public class Genre
    {
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
    }

}
