using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Core.EventSystem
{
    public static class EventBus
    {
        private static Dictionary<EventType, Action> assignedEvents = new();

        public static void Raise(EventType eventType)
        {
            if (assignedEvents.TryGetValue(eventType, out Action existingAction))
            {
                existingAction?.Invoke();
            }
        }

        public static void Subscribe(EventType eventType, Action action)
        {
            if (assignedEvents.ContainsKey(eventType))
            {
                assignedEvents[eventType] += action;
            }
            else
            {
                assignedEvents[eventType] = action;
            }
        }

        public static void Unsubscribe(EventType eventType, Action action)
        {
            if (assignedEvents.ContainsKey(eventType))
            {
                assignedEvents[eventType] -= action;
            }
        }
    }

    public enum EventType
    {
        QuestInitiated,
        QuestCompleted,
        PlayerDied,
    }
}
