using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class FollowingArtistResponse
    {
        [JsonPropertyName("artists")]
        public Paging<Artist>? Artists { get; set; }
    }
}
