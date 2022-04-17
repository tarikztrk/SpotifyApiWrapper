using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class Section
    {
        [JsonPropertyName("start")]
        public decimal Start { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("confidence")]
        public decimal Confidence { get; set; }

        [JsonPropertyName("loudness")]
        public decimal Loudness { get; set; }

        [JsonPropertyName("tempo")]
        public decimal Tempo { get; set; }

        [JsonPropertyName("tempo_confidence")]
        public decimal TempoConfidence { get; set; }

        [JsonPropertyName("key")]
        public int Key { get; set; }

        [JsonPropertyName("key_confidence")]
        public decimal KeyConfidence { get; set; }

        [JsonPropertyName("mode")]
        public int Mode { get; set; }

        [JsonPropertyName("mode_confidence")]
        public decimal ModeConfidence { get; set; }

        [JsonPropertyName("time_signature")]
        public int TimeSignature { get; set; }

        [JsonPropertyName("time_signature_confidence")]
        public decimal TimeSignatureConfidence { get; set; }
    }

}
