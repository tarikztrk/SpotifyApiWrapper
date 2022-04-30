using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class AudioTrack
    {
        [JsonPropertyName("num_samples")]
        public int NumSamples { get; set; }

        [JsonPropertyName("duration")]
        public decimal Duration { get; set; }

        [JsonPropertyName("sample_md5")]
        public string? SampleMd5 { get; set; }

        [JsonPropertyName("offset_seconds")]
        public int OffsetSeconds { get; set; }

        [JsonPropertyName("window_seconds")]
        public int WindowSeconds { get; set; }

        [JsonPropertyName("analysis_sample_rate")]
        public int AnalysisSampleRate { get; set; }

        [JsonPropertyName("analysis_channels")]
        public int AnalysisChannels { get; set; }

        [JsonPropertyName("end_of_fade_in")]
        public decimal EndOfFadeIn { get; set; }

        [JsonPropertyName("start_of_fade_out")]
        public decimal StartOfFadeOut { get; set; }

        [JsonPropertyName("loudness")]
        public decimal Loudness { get; set; }

        [JsonPropertyName("tempo")]
        public decimal Tempo { get; set; }

        [JsonPropertyName("tempo_confidence")]
        public decimal TempoConfidence { get; set; }

        [JsonPropertyName("time_signature")]
        public int TimeSignature { get; set; }

        [JsonPropertyName("time_signature_confidence")]
        public decimal TimeSignatureConfidence { get; set; }

        [JsonPropertyName("key")]
        public int Key { get; set; }

        [JsonPropertyName("key_confidence")]
        public decimal KeyConfidence { get; set; }

        [JsonPropertyName("mode")]
        public int Mode { get; set; }

        [JsonPropertyName("mode_confidence")]
        public decimal ModeConfidence { get; set; }

        [JsonPropertyName("codestring")]
        public string? Codestring { get; set; }

        [JsonPropertyName("code_version")]
        public decimal CodeVersion { get; set; }

        [JsonPropertyName("echoprintstring")]
        public string? Echoprintstring { get; set; }

        [JsonPropertyName("echoprint_version")]
        public decimal EchoprintVersion { get; set; }

        [JsonPropertyName("synchstring")]
        public string? Synchstring { get; set; }

        [JsonPropertyName("synch_version")]
        public decimal SynchVersion { get; set; }

        [JsonPropertyName("rhythmstring")]
        public string? Rhythmstring { get; set; }

        [JsonPropertyName("rhythm_version")]
        public decimal RhythmVersion { get; set; }
    }

}
