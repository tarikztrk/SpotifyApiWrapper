using SpotifyApiWrapper.Entities.Categories;
using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class CategoryPlaylistsResponse
    {
        [JsonPropertyName("playlists")]
        public Paging<Playlists> Playlists { get; set; }
    }

}
