using EventTriggers.Models.Events.Parameters;

namespace EventTriggers.Models.Events
{
    public class LevelEvent : Event
    {
        public LevelEvent(LevelEventParameters parameters)
        {
            Parameters = parameters;
        }

        public override string ToString()
        {
            return $"{Parameters.Instrument.Ticker}. Достигнут уровень {Parameters.Level}";
        }

        public LevelEventParameters Parameters { get; }
    }
}