namespace EventTriggers.MarketAnaliseWorker.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string EventTriggersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string EventTriggersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}