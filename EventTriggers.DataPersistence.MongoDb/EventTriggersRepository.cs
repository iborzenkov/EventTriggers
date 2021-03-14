using EventTriggers.Models.Events;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventTriggers.DataPersistence
{
    public class EventTriggersRepository : IEventTriggersRepository
    {
        public EventTriggersRepository(IDatabaseSettings options, ILogger<EventTriggersRepository> logger)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var configuration = options;
            var client = new MongoClient(configuration.ConnectionString);

            _database = client.GetDatabase(configuration.DatabaseName);
            _collection = _database.GetCollection<Event>(configuration.EventTriggersCollectionName);
            _logger = logger;
        }

        public async Task<Event> GetEventTrigger(Guid eventId)
        {
            return await _collection.Find(x => x.Id == eventId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Event> CreateEvent(Event @event)
        {
            try
            {
                await _collection.InsertOneAsync(@event);

                return @event;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Event> _collection;
        private readonly ILogger<EventTriggersRepository> _logger;
    }
}