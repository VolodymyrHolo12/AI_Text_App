namespace AITextApp.ViewModels
{
    public class MainPageViewModel
    {
        public ApiKeyViewModel ApiKeyViewModel { get; }
        public ShortcutViewModel ShortcutViewModel { get; }
        public PromptViewModel PromptViewModel { get; }

        public MainPageViewModel(ApiKeyViewModel apiKeyViewModel, PromptViewModel promptViewModel, ShortcutViewModel shortcutViewModel)
        {
            ApiKeyViewModel = apiKeyViewModel;
            PromptViewModel = promptViewModel;
            ShortcutViewModel = shortcutViewModel;
        }
    }
}
