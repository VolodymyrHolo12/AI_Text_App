using AITextApp.Models;
using AITextApp.Services.Interfaces;
using OpenAI.Managers;
using OpenAI;
using OpenAI.ObjectModels.RequestModels;

namespace AITextApp.Services
{
    public class PromptService : IPromptService
    {
        public async Task<string> GetChatGPTResponseAsync(string apiKey, OpenAiPromptModel promptTemplate, string userInput)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(userInput) || promptTemplate is null)
            {
                return "Invalid request params. Check your APIKey or selected prompt.";
            }

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromSystem(promptTemplate.PositivePrompt),
                    ChatMessage.FromUser(userInput)
                },
                Model = promptTemplate.Model,
                MaxTokens = promptTemplate.MaxTokens,
                Temperature = (float?)promptTemplate.Temperature
            });

            if (completionResult.Successful)
            {
                return completionResult.Choices.First().Message.Content;
            }

            return string.Empty;
        }
    }
}
