using EventTriggers.DataPersistence;

namespace EventTriggers.Web.Service
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string EventTriggersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}