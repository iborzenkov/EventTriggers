using System;
using EventTriggers.Models.Events.Parameters;

namespace EventTriggers.Models.Events.EventTypes
{
    public abstract class EventType
    {
        protected EventType(string caption)
        {
            _caption = caption;
        }

        public override string ToString()
        {
            return _caption;
        }

        public abstract Event MakeEvent(EventParameters parameters);

        public abstract Guid Id { get; }

        private readonly string _caption;
    }
}