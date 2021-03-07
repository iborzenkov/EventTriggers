using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DevExpress.Mvvm;
using EventTriggers.MarketInfoProvider;
using EventTriggers.Models;
using EventTriggers.Models.Events;
using EventTriggers.Models.Events.EventTypes;
using EventTriggers.Models.Events.Parameters;
using EventTriggers.WpfApplication.ViewModels.Commands;
using EventTriggers.WpfApplication.ViewModels.Commands.Parameters;

namespace EventTriggers.WpfApplication.ViewModels
{
    public class MainViewModel : ViewModelBase, ISelectedEventProvider, IEventParameterProvider
    {
        public MainViewModel()
        {
            AddCommand = new AddEvent(_eventProvider, this);
            RemoveCommand = new RemoveEvent(_eventProvider, this);

            _eventProvider.Add(new LevelEvent(new LevelEventParameters(
                new Instrument("qqq", "FXIM"),"desc1", 1.1234)));
            //_eventProvider.Add(new LevelEvent(new LevelEventParameters("AAPL", 567.89)));
            SelectedEventType = EventTypes.FirstOrDefault();

            _instrumentProvider = new TinkoffInstrumentProvider();
        }

        public IEnumerable<Event> AllEvents => _eventProvider.Events;
        public IEnumerable<EventType> EventTypes => _eventTypeProvider.EventTypes;
        public IEnumerable<Instrument> Instruments => _instrumentProvider.Instruments;

        public EventType SelectedEventType
        {
            get => _selectedEventType;
            set
            {
                _selectedEventType = value;
                OnParametersChanged(Value);
            }
        }

        public Instrument SelectedInstrument
        {
            get => _selectedInstrument;
            set
            {
                _selectedInstrument = value;
                OnParametersChanged(Value);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnParametersChanged(Value);
            }
        }

        public double Level
        {
            get => _level;
            set
            {
                _level = value;
                OnParametersChanged(Value);
            }
        }

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                SelectedEventChanged?.Invoke(this, _selectedEvent);
            }
        }

        public MakeEventParameters Value => new MakeEventParameters(
            SelectedEventType, new LevelEventParameters(SelectedInstrument, Description, Level));

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public event EventHandler<Event> SelectedEventChanged;
        public event EventHandler<MakeEventParameters> ParametersChanged;

        protected virtual void OnParametersChanged(MakeEventParameters e)
        {
            ParametersChanged?.Invoke(this, e);
        }

        private readonly IEventProvider _eventProvider = new EventProvider();
        private readonly EventTypeProvider _eventTypeProvider = new EventTypeProvider();
        private readonly IInstrumentProvider _instrumentProvider;
        private Event _selectedEvent;
        private double _level;
        private EventType _selectedEventType;
        private string _description;
        private Instrument _selectedInstrument;
    }
}