namespace AITextApp.Events
{
    public abstract class EventBase
    {
        public abstract void Subscribe(Action<object> handler);
        public abstract void Publish(object data);
    }
}
