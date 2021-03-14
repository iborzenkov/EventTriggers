namespace EventTriggers.Models
{
    public class Instrument
    {
        public Instrument(string name, string ticker)
        {
            Name = name;
            Ticker = ticker;
        }

        public override string ToString()
        {
            return $"{Ticker}. {Name}";
        }

        public string Name { get; }
        public string Ticker { get; }
    }
}