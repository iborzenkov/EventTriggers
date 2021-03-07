using System;
using EventTriggers.MarketAnaliseWorker.Models.Parameters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventTriggers.MarketAnaliseWorker.Models
{
    public abstract class Event<T> where T: EventParameters
    {
        protected Event()
        {
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public T Parameters { get; set; }
    }
}