using EventTriggers.Models.Events.EventTypes;
using EventTriggers.Models.Events.Parameters;

namespace EventTriggers.WpfApplication.ViewModels.Commands.Parameters
{
    public class MakeEventParameters
    {
        public MakeEventParameters(EventType eventType, EventParameters parameters)
        {
            EventType = eventType;
            Parameters = parameters;
        }

        public EventType EventType { get; }
        public EventParameters Parameters { get; }
        public bool IsCompleted => EventType != null && Parameters.IsCompleted;
    }
}