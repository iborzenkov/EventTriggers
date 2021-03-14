using EventTriggers.Models.Events;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace EventTriggers.DataPersistence.Services
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

        public Event Get(Guid id) =>
            _events.Find<Event>(@event => @event.Id == id).FirstOrDefault();

        public Event Create(Event @event)
        {
            _events.InsertOne(@event);
            return @event;
        }

        public void Update(Guid id, Event eventIn) =>
            _events.ReplaceOne(@event => @event.Id == id, eventIn);

        public void Remove(Event eventIn) =>
            _events.DeleteOne(@event => @event.Id == eventIn.Id);

        public void Remove(Guid id) =>
            _events.DeleteOne(@event => @event.Id == id);

        private readonly IMongoCollection<Event> _events;
    }
}