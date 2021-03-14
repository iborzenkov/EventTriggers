using EventTriggers.Models.Events.EventTypes;
using System.Collections.Generic;

namespace EventTriggers.Models
{
    public class EventTypeProvider
    {
        public EventTypeProvider()
        {
            _eventTypes.Add(new LevelEventType());
        }

        public IEnumerable<EventType> EventTypes => _eventTypes;


        private readonly List<EventType> _eventTypes = new List<EventType>();
    }
}
