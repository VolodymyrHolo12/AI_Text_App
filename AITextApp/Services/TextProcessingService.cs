using AITextApp.Infrastructure;
using AITextApp.Models;
using AITextApp.Services.Interfaces;
using IClipboard = TextCopy.IClipboard;

namespace AITextApp.Services
{
    public class TextProcessingService : ITextProcessingService
    {
        private readonly IPromptService _promptService;
        private readonly IUserActivitySimulator _userActivitySimulator;
        private readonly IClipboard _clipboard;
        private string? savedClipboardText;

        private readonly ShortcutThrottler _throttler = new(TimeSpan.FromSeconds(1));

        public TextProcessingService(IPromptService promptService, IUserActivitySimulator userActivitySimulator, IClipboard clipboard)
        {
            _promptService = promptService;
            _userActivitySimulator = userActivitySimulator;
            _clipboard = clipboard;
        }

        public async Task UpdateSelectedText(TextProcessingModel textProcessingModel)
        {
            if (_throttler.CanExecute())
            {
                var selectedText = await GetTextAsync();

                if (string.IsNullOrEmpty(selectedText))
                {
                    return;
                }

                var aiResponseText = await _promptService.GetChatGPTResponseAsync(textProcessingModel.ApiKey, textProcessingModel.Prompt, selectedText);
                await SetTextAsync(aiResponseText);
            }
        }

        private async Task<string?> GetTextAsync()
        {
            savedClipboardText = await _clipboard.GetTextAsync();

            await _userActivitySimulator.SimulateCopyAsync();

            return await _clipboard.GetTextAsync();
        }

        private async Task SetTextAsync(string text)
        {
            await _clipboard.SetTextAsync(text);

            await _userActivitySimulator.SimulatePasteAsync();

            if (savedClipboardText != null)
            {
                Thread.Sleep(50);
                await _clipboard.SetTextAsync(savedClipboardText);
            }
        }
    }
}
