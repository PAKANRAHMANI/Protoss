﻿using System;
using System.Collections.Generic;
using System.Text;
using Protoss.Core.Events.Handlers;

namespace Protoss.Core.Events
{
    public interface IEventListener
    {
        void Subscribe<T>(Action<T> action) where T : IDomainEvent;
        void Subscribe<T>(IEventHandler<T> @event) where T : IDomainEvent;
    }
}
