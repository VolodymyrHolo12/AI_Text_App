using Newtonsoft.Json;

namespace AITextApp.Models.Response
{
    public class ChatGPTResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("object")]
        public string Object { get; set; } = string.Empty;

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("usage")]
        public Usage Usage { get; set; } = new();

        [JsonProperty("choices")]
        public Choice[] Choices { get; set; } = [];
    }
}
