namespace AITextApp.Events
{
    public class PromptChangedEvent : EventBase
    {
        private readonly List<Action<object>> _subscribers = [];

        public override void Subscribe(Action<object> handler)
        {
            _subscribers.Add(handler);
        }

        public override void Publish(object data)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber(data);
            }
        }
    }
}
