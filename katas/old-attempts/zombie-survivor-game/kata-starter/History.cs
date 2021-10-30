using System;
using System.Collections.Generic;

namespace Kata.Starter
{
    public class History
    {
        public DateTimeOffset StartTime { get; }
        public List<HistoryEvent> Events { get; }

        public History(DateTimeOffset startTime)
        {
            Events = new List<HistoryEvent>();
            StartTime = startTime;
        }

        public void LogEvent(HistoryEvent eventToAdd)
        {
            Events.Add(eventToAdd);
        }
    }

    public class HistoryEvent
    {
        public string EntityId { get; }
        public string EntityType { get; }
        public string Message { get; }

        public HistoryEvent(string entityId, string entityType, string message)
        {
            EntityId = entityId;
            EntityType = entityType;
            Message = message;
        }
    }
}