using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class PlaylistsResponse
    {
        [JsonPropertyName("playlists")]
        public Paging<Playlists>? Playlists { get; set; }
    }
}
