namespace AITextApp.Events
{
    public interface IEventAggregator
    {
        // Generic method to get an event by its type
        TEvent GetEvent<TEvent>() where TEvent : EventBase;
    }
}
