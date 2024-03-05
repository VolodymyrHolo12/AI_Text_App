using AITextApp.Models;
using System.ComponentModel;

namespace AITextApp.Services.Interfaces
{
    public interface IPromptService
    {
        //string GeneratePrompt(string apiKey, string promptTemplate);

        Task<string> GetChatGPTResponseAsync(string apiKey, OpenAiPromptModel promptTemplate, string userInput);
    }
}
