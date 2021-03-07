using EventTriggers.MarketAnaliseWorker.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using EventTriggers.MarketAnaliseWorker.Models.Parameters;

namespace EventTriggers.MarketAnaliseWorker.Services
{
    public class EventTriggerService
    {
        public EventTriggerService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _events = database.GetCollection<Event>(settings.EventTriggersCollectionName);
        }

        public List<Event> Get() =>
            _events.Find(@event => true).ToList();

        public Event Get(string id) =>
            _events.Find<Event>(@event => @event.Id == id).FirstOrDefault();

        public Event Create(Event @event)
        {
            _events.InsertOne(@event);
            return @event;
        }

        public void Update(string id, Event eventIn) =>
            _events.ReplaceOne(@event => @event.Id == id, eventIn);

        public void Remove(Event eventIn) =>
            _events.DeleteOne(@event => @event.Id == eventIn.Id);

        public void Remove(string id) =>
            _events.DeleteOne(@event => @event.Id == id);

        private readonly IMongoCollection<Event> _events;
    }
}