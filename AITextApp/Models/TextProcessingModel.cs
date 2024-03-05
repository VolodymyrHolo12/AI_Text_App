namespace AITextApp.Models
{
    public class TextProcessingModel
    {
        public string ApiKey { get; set; } = string.Empty;

        public OpenAiPromptModel? Prompt { get; set; } = null;
    }
}
