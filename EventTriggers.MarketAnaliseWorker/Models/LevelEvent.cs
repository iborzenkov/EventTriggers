using EventTriggers.MarketAnaliseWorker.Models.Parameters;

namespace EventTriggers.MarketAnaliseWorker.Models
{
    public class LevelEvent : Event<LevelEventParameters>
    {
        public LevelEvent(LevelEventParameters parameters)
        {
            Parameters = parameters;
        }

        public override string ToString()
        {
            return $"{Parameters.Instrument.Ticker}. Достигнут уровень {Parameters.Level}";
        }

        //public LevelEventParameters Parameters { get; }
    }
}