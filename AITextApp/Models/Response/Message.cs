using Newtonsoft.Json;

namespace AITextApp.Models.Response
{
    public class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; } = string.Empty;

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;
    }
}
