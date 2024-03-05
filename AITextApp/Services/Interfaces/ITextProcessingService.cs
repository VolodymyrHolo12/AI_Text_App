using AITextApp.Models;

namespace AITextApp.Services.Interfaces
{
    public interface ITextProcessingService
    {
        Task UpdateSelectedText(TextProcessingModel textProcessingModel);
    }
}
