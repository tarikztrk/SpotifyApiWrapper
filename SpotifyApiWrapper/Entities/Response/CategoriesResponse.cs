using SpotifyApiWrapper.Entities.Categories;
using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class CategoriesResponse
    {
        [JsonPropertyName("categories")]
        public Paging<Category>? Categories { get; set; }
    }
}
