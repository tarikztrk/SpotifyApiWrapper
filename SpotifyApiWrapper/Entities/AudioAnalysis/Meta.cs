using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class Meta
    {
        [JsonPropertyName("analyzer_version")]
        public string? AnalyzerVersion { get; set; }

        [JsonPropertyName("platform")]
        public string? Platform { get; set; }

        [JsonPropertyName("detailed_status")]
        public string? DetailedStatus { get; set; }

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("analysis_time")]
        public decimal AnalysisTime { get; set; }

        [JsonPropertyName("input_process")]
        public string? InputProcess { get; set; }
    }

}
