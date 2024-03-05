using System.Text.Json.Serialization;

namespace AITextApp.Models
{
    public class OpenAiPromptModel
    {
        [JsonPropertyName("selected_title")]
        public string SelectedTitle { get; set; } = string.Empty;

        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; } = null;

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get;set; } = null;

        [JsonPropertyName("positive_prompt")]
        public string PositivePrompt { get; set;} = string.Empty;

        [JsonPropertyName("negative_prompt")]
        public string NegativePrompt { get; set; } = string.Empty;

        [JsonPropertyName("messages")]
        public Message[] Messages { get; set; } = [];
    }

    // New model class for messages
    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}
