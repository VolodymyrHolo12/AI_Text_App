namespace AITextApp.Infrastructure
{
    public class ShortcutThrottler
    {
        private readonly TimeSpan _throttlePeriod;
        private DateTime _nextAllowedExecution;

        public ShortcutThrottler(TimeSpan throttlePeriod)
        {
            _throttlePeriod = throttlePeriod;
            _nextAllowedExecution = DateTime.Now;
        }

        public bool CanExecute()
        {
            lock (this)
            {
                if (DateTime.Now >= _nextAllowedExecution)
                {
                    _nextAllowedExecution = DateTime.Now + _throttlePeriod;
                    return true;
                }
                return false;
            }
        }
    }
}
