using System;
using System.Windows.Input;
using EventTriggers.Models;

namespace EventTriggers.WpfApplication.ViewModels.Commands
{
    public class AddEvent : ICommand
    {
        public AddEvent(IEventProvider eventProvider, IEventParameterProvider parameterProvider)
        {
            _eventProvider = eventProvider;

            _parameterProvider = parameterProvider;
            _parameterProvider.ParametersChanged += (sender, parameters) => OnCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return _parameterProvider.Value.IsCompleted;
        }

        public void Execute(object parameter)
        {
            var eventType = _parameterProvider.Value.EventType;
            var eventParameters = _parameterProvider.Value.Parameters;

            _eventProvider.Add(eventType.MakeEvent(eventParameters));
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private readonly IEventProvider _eventProvider;
        private readonly IEventParameterProvider _parameterProvider;
    }
}