using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities.AudioAnalysis
{
    public class AudioAnalysis
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("track")]
        public AudioTrack Track { get; set; }

        [JsonPropertyName("bars")]
        public List<Bar> Bars { get; set; }

        [JsonPropertyName("beats")]
        public List<Beat> Beats { get; set; }

        [JsonPropertyName("sections")]
        public List<Section> Sections { get; set; }

        [JsonPropertyName("segments")]
        public List<Segment> Segments { get; set; }

        [JsonPropertyName("tatums")]
        public List<Tatum> Tatums { get; set; }
    }

}
