using AITextApp.Constants;
using AITextApp.Events;
using AITextApp.Models;
using System.ComponentModel;

namespace AITextApp.ViewModels
{
    public class PromptViewModel : INotifyPropertyChanged
    {
        private readonly List<OpenAiPromptModel> prompts = PromptConstants.OpenAiPrompts;
        private readonly IEventAggregator _eventAggregator;


        public OpenAiPromptModel SelectedPrompt => prompts[selectedIndex];

        public IEnumerable<string> Prompts => prompts.Select(p => p.SelectedTitle).ToArray();

        private int selectedIndex;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    OnPropertyChanged(nameof(SelectedPrompt));
                    _eventAggregator.GetEvent<PromptChangedEvent>().Publish(SelectedPrompt);
                }
            }
        }

        public PromptViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
