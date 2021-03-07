using System.Collections.ObjectModel;
using EventTriggers.Models;
using EventTriggers.Models.Events;

namespace EventTriggers.WpfApplication
{
    public class EventProvider : IEventProvider
    {
        public void Add(Event @event)
        {
            _events.Add(@event);
        }

        public void Remove(Event @event)
        {
            _events.Remove(@event);
        }

        private readonly ObservableCollection<Event> _events = new ObservableCollection<Event>();
        public ObservableCollection<Event> Events => _events;
    }
}