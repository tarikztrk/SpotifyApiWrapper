using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class Bar
    {
        [JsonPropertyName("start")]
        public decimal Start { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("confidence")]
        public decimal Confidence { get; set; }
    }

}
