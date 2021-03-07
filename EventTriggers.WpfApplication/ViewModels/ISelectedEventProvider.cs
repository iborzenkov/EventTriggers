using System;
using EventTriggers.Models.Events;

namespace EventTriggers.WpfApplication.ViewModels
{
    public interface ISelectedEventProvider
    {
        Event SelectedEvent { get; set; }

        event EventHandler<Event> SelectedEventChanged;
    }
}