namespace AITextApp.Events
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, EventBase> _events = [];

        public TEvent GetEvent<TEvent>() where TEvent : EventBase
        {
            if (!_events.TryGetValue(typeof(TEvent), out var eventInstance))
            {
                eventInstance = Activator.CreateInstance(typeof(TEvent)) as TEvent;
                _events.Add(typeof(TEvent), eventInstance!);
            }
            return (TEvent)eventInstance!;
        }
    }
}
