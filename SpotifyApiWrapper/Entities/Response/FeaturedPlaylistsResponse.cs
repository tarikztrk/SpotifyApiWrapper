using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class FeaturedPlaylistsResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("playlists")]
        public Paging<Playlists>? Playlists { get; set; }
    }
}
