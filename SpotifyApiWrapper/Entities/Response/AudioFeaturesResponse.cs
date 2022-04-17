using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.Response
{
    public class AudioFeaturesResponse
    {
        [JsonPropertyName("audio_features")]
        public List<AudioFeatures> AudioFeatures { get; set; }
    }
}
