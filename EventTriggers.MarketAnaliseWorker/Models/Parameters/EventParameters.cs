namespace EventTriggers.MarketAnaliseWorker.Models.Parameters
{
    public abstract class EventParameters
    {
        protected EventParameters(Instrument instrument, string description)
        {
            Instrument = instrument;
            Description = description;
        }

        public Instrument Instrument { get; }
        public string Description { get; }
        public virtual bool IsCompleted => Instrument != null;
    }
}