namespace EventTriggers.MarketAnaliseWorker.Models
{
    public class Instrument
    {
        public override string ToString()
        {
            return $"{Ticker}. {Name}";
        }

        public string Name { get; set; }
        public string Ticker { get; set; }
    }
}