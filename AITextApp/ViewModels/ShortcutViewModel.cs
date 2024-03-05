using AITextApp.Events;
using AITextApp.Models;
using com.jarvisniu.utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AITextApp.Services.Interfaces;
using IClipboard = TextCopy.IClipboard;

namespace AITextApp.ViewModels
{
    public class ShortcutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand StartShortcutSettingCommand { get; }

        private readonly KeyListener _keyListener;
        private readonly IEventAggregator _eventAggregator;
        private readonly ITextProcessingService _textProcessingService;

        private string _shortcut = "CTRL + M";
        public string Shortcut
        {
            get { return _shortcut; }
            set 
            { 
                _shortcut = value;
                OnPropertyChanged(nameof(Shortcut));
            }
        }

        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
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

        private TextProcessingModel _requestParams = new();

        public ShortcutViewModel(IEventAggregator eventAggregator, ITextProcessingService textProcessingService)
        {
            _eventAggregator = eventAggregator;
            _textProcessingService = textProcessingService;

            _eventAggregator.GetEvent<ApiKeyChangedEvent>().Subscribe(OnApiKeyChanged);
            _eventAggregator.GetEvent<PromptChangedEvent>().Subscribe(OnPromptChanged);
            _keyListener = new()
            {
                onSettingChange = OnSettingChange,
                onSettingConfirm = OnSettingConfirm
            };
            _keyListener.onPress(_shortcut, OnShortcutCustomPressed);
            StartShortcutSettingCommand = new Command(() => _keyListener.startSetting());
        }

        private async void OnShortcutCustomPressed()
        {
            await _textProcessingService.UpdateSelectedText(_requestParams);
        }

        private void OnSettingChange(string keyString)
        {
            HandleHotkeyPressed(delegate
            {
                IsEnabled = true;
                Shortcut = keyString;
            });
        }

        private void OnSettingConfirm(string keyString)
        {
            HandleHotkeyPressed(delegate
            {
                if (_keyListener.isSystemShortcutCollision(keyString))
                {
                    IsEnabled = false;
                    Shortcut = string.Empty;
                    IsValid = false;
                    ValidationMessage = $"{keyString} shortcut has collisions with system shortcuts.";
                    return;
                }

                _keyListener.onShortcutRemove(Shortcut);
                Shortcut = keyString;               
                _keyListener.onPress(keyString, OnShortcutCustomPressed);
                IsEnabled = false;
                IsValid = true;
            });
        }

        private async static void HandleHotkeyPressed(Action action)
        {
            await MainThread.InvokeOnMainThreadAsync(action);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnApiKeyChanged(object newApiKey)
        {
            _requestParams.ApiKey = newApiKey as string ?? string.Empty;
        }

        private void OnPromptChanged(object newPrompt)
        {
            _requestParams.Prompt = newPrompt as OpenAiPromptModel;
        }
    }
}
