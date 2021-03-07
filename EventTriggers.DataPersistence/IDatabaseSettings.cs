namespace EventTriggers.DataPersistence
{
    public interface IDatabaseSettings
    {
        string EventTriggersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}