using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SpotifyApiWrapper.Entities
{
    public class Paging<T>
    {
        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        [JsonPropertyName("href")]
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

}
