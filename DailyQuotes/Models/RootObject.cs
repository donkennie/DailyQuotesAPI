using System.Text.Json.Serialization;

namespace DailyQuotes.Models
{
    public class RootObject
    {
        [JsonPropertyName("qotd_date")]
        public string QotdDate { get; set; }

        [JsonPropertyName("quote")]
        public Quote Quote { get; set; }
    }
}
