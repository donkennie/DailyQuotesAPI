using System.Text.Json.Serialization;

namespace DailyQuotes.DTOs
{
    public class Response
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
