namespace AITextApp.Services.Interfaces
{
    public interface IUserActivitySimulator
    {
        Task SimulateCopyAsync();
        Task SimulatePasteAsync();
    }
}
