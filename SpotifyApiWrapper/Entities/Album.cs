﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace SpotifyApiWrapper.Entities
{
    public class Album
    {

        [JsonPropertyName("album_type")]
        public string? AlbumType { get; set; }

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonPropertyName("available_markets")]
        public List<string>? AvailableMarkets { get; set; }

        [JsonPropertyName("external_urls")]
        public Dictionary<string,string>? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [JsonPropertyName("images")]
        public List<Image>? Images { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public string? ReleaseDatePrecision { get; set; }

        [JsonPropertyName("restrictions")]
        public Dictionary<string, string>? Restrictions { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("artists")]
        public List<Artist>? Artists { get; set; }

        [JsonPropertyName("tracks")]
        public Paging<Track>? Tracks { get; set; }
    }

}
