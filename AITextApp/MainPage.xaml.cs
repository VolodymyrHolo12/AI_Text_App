using AITextApp.ViewModels;

namespace AITextApp
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel MainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            MainPageViewModel = mainPageViewModel;
            BindingContext = MainPageViewModel;
        }

        private void ApiKeyEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPageViewModel.ApiKeyViewModel.ApiKey = ApiKeyInput?.Text ?? string.Empty;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainPageViewModel.PromptViewModel.SelectedIndex = PromptPicker.SelectedIndex;
        }
    }
}
