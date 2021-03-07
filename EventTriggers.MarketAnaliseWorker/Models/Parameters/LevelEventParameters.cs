namespace EventTriggers.MarketAnaliseWorker.Models.Parameters
{
    public class LevelEventParameters : EventParameters
    {
        public LevelEventParameters(Instrument instrument, string description, double level)
            : base(instrument, description)
        {
            Level = level;
        }

        public double Level { get; set; }

        public override bool IsCompleted
        {
            get
            {
                return base.IsCompleted && Level != 0;
            }
        }
    }
}