using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Categories
{
    public class Category
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("icons")]
        public List<Image>? Icons { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
