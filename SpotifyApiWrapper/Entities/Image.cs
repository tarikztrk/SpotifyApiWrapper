﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities
{
    public class Image
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("height")]
        public int? Height { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }
}
}
