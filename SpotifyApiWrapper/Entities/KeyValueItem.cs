
using System.Collections.Generic;
using System.Text.Json;

namespace SpotifyApiWrapper.Entities
{
    public class KeyValueItem
    {
        public string? Key { get; set; }
        public string? StringValue { get; set; }
        public bool BooleanValue { get; set; }
        public int IntegerValue { get; set; }

    }
    public static class KeyValueListExtensions
    {
        public static string ToJson(this List<KeyValueItem> keyValueItem)
        {
            var result = string.Empty;

            if (keyValueItem != null && keyValueItem.Count > 0)
            {
                result = JsonSerializer.Serialize(keyValueItem);
            }

            return result;
        }
    }
}
