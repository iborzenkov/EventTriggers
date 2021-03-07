using System;
using System.Windows.Input;
using EventTriggers.Models;
using EventTriggers.Models.Events;

namespace EventTriggers.WpfApplication.ViewModels.Commands
{
    public class RemoveEvent : ICommand
    {
        public RemoveEvent(IEventProvider eventProvider, ISelectedEventProvider selectedEventProvider)
        {
            _eventProvider = eventProvider;

            _selectedEventProvider = selectedEventProvider;
            _selectedEventProvider.SelectedEventChanged += SelectedEventProvider_SelectedEventChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _selectedEventProvider.SelectedEvent != null;
        }

        public void Execute(object parameter)
        {
            _eventProvider.Remove(_selectedEventProvider.SelectedEvent);
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SelectedEventProvider_SelectedEventChanged(object sender, Event @event)
        {
            OnCanExecuteChanged();
        }

        private readonly ISelectedEventProvider _selectedEventProvider;
        private readonly IEventProvider _eventProvider;
    }
}