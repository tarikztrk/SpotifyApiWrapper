using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class Segment
    {
        [JsonPropertyName("start")]
        public decimal Start { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("confidence")]
        public decimal Confidence { get; set; }

        [JsonPropertyName("loudness_start")]
        public decimal LoudnessStart { get; set; }

        [JsonPropertyName("loudness_max_time")]
        public decimal LoudnessMaxTime { get; set; }

        [JsonPropertyName("loudness_max")]
        public decimal LoudnessMax { get; set; }

        [JsonPropertyName("loudness_end")]
        public decimal LoudnessEnd { get; set; }

        [JsonPropertyName("pitches")]
        public List<decimal> Pitches { get; set; }

        [JsonPropertyName("timbre")]
        public List<decimal> Timbre { get; set; }
    }

}
