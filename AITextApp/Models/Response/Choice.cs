using Newtonsoft.Json;

namespace AITextApp.Models.Response
{
    public class Choice
    {
        [JsonProperty("message")]
        public Message Message { get; set; } = new();

        [JsonProperty("logprobs")]
        public object? Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; } = string.Empty;

        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
