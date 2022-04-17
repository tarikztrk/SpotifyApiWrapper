using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities
{
    public class AudioFeatures
    {
        [JsonPropertyName("danceability")]
        public decimal Danceability { get; set; }

        [JsonPropertyName("energy")]
        public decimal Energy { get; set; }

        [JsonPropertyName("key")]
        public int Key { get; set; }

        [JsonPropertyName("loudness")]
        public decimal Loudness { get; set; }

        [JsonPropertyName("mode")]
        public int Mode { get; set; }

        [JsonPropertyName("speechiness")]
        public decimal Speechiness { get; set; }

        [JsonPropertyName("acousticness")]
        public decimal Acousticness { get; set; }

        [JsonPropertyName("instrumentalness")]
        public decimal Instrumentalness { get; set; }

        [JsonPropertyName("liveness")]
        public decimal Liveness { get; set; }

        [JsonPropertyName("valence")]
        public decimal Valence { get; set; }

        [JsonPropertyName("tempo")]
        public decimal Tempo { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("track_href")]
        public string TrackHref { get; set; }

        [JsonPropertyName("analysis_url")]
        public string AnalysisUrl { get; set; }

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("time_signature")]
        public int TimeSignature { get; set; }
    }
}
