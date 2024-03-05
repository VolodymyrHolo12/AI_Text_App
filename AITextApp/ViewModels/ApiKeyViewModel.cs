using AITextApp.Events;
using AITextApp.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AITextApp.ViewModels
{
    public class ApiKeyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand ValidateApiKeyCommand { get; }
        private readonly IEventAggregator _eventAggregator;

        private string _apiKey = string.Empty;
        public string ApiKey
        {
            get => _apiKey;
            set
            {
                _apiKey = value;
                OnPropertyChanged(nameof(ApiKey));
                ValidateApiKeyFormat();
                _eventAggregator.GetEvent<ApiKeyChangedEvent>().Publish(ApiKey); //TODO: move to validation method
            }
        }

        private string _validationMessage = string.Empty;
        public string ValidationMessage
        {
            get => _validationMessage;
            set
            {
                _validationMessage = value;
                OnPropertyChanged(nameof(ValidationMessage));
            }
        }

        private bool _isValid = false;
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        public ApiKeyViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ValidateApiKeyCommand = new Command(async () => await ValidateApiKeyAsync());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ValidateApiKeyFormat()
        {
            var validationResult = APIKeyValidationHelper.ValidateApiKeyFormat(_apiKey);
            IsValid = validationResult.isValid;
            ValidationMessage = validationResult.message;
        }

        private async Task ValidateApiKeyAsync()
        {
            var validationResult = await APIKeyValidationHelper.ValidateOpenAIApiKeyAsync(_apiKey);
            IsValid = validationResult.isValid;
            ValidationMessage = validationResult.message;
        }
    }
}