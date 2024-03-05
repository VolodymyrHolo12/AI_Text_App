using AITextApp.Models;

namespace AITextApp.Constants
{
    public static class PromptConstants
    {
        /// <summary>
        /// Used for debugging, will be removed when real prompts will be ready.
        /// </summary>
        public readonly static List<OpenAiPromptModel> OpenAiPrompts =
        [
            new OpenAiPromptModel
            {
                SelectedTitle = "Inspiring Poem",
                Model = "gpt-3.5-turbo",  // Updated model name
                Temperature = 0.9,
                MaxTokens = 150,
                PositivePrompt = "Write a beautiful poem about the USER_INPUT_CONSTANT.",
                Messages = [new() { Role = "user" }]  // Added messages
            },
            new OpenAiPromptModel
            {
                SelectedTitle = "Technical Summary",
                Model = "gpt-3.5-turbo",  // Updated model name
                Temperature = 0.7,
                MaxTokens = 200,
                PositivePrompt = "Summarize the key features and benefits of GPT-3 in a concise and informative manner.",
                Messages = [new() { Role = "user" }]  // Added messages
            },
            new OpenAiPromptModel
            {
                SelectedTitle = "Python Function",
                Model = "gpt-3.5-turbo",  // Updated model name
                Temperature = 0.5,
                MaxTokens = 100,
                PositivePrompt = "Write a Python function that generates a function based on user request.",
                Messages = [new() { Role = "user" }]  // Added messages
            },
            new OpenAiPromptModel
            {
                SelectedTitle = "Mysterious Adventure",
                Model = "gpt-3.5-turbo",  // Updated model name
                Temperature = 0.8,
                MaxTokens = 300,
                PositivePrompt = "Write a thrilling story about a detective investigating a haunted mansion.",
                NegativePrompt = "Avoid mentioning any specific characters or locations from popular books or movies.",
                Messages =  [new() { Role = "user" }]  // Added messages
            }
        ];
    }
}
