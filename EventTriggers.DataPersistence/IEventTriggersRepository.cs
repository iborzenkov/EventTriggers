﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventTriggers.Models.Events;

namespace EventTriggers.DataPersistence
{
    public interface IEventTriggersRepository
    {
        Task<Event> GetEventTrigger(Guid eventId);
        Task<IEnumerable<Event>> GetAll();
        Task<Event> CreateEvent(Event @event);
    }
}