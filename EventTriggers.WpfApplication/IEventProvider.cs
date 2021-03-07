using System.Collections.ObjectModel;
using EventTriggers.Models.Events;

namespace EventTriggers.WpfApplication
{
    public interface IEventProvider
    {
        ObservableCollection<Event> Events { get; }
        void Add(Event @event);
        void Remove(Event @event);
    }
}