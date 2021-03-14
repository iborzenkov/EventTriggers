using System;

namespace EventTriggers.Models.Events
{
    public abstract class Event
    {
        protected Event()
        {
        }

        public Guid Id { get; protected set; }
    }
}