using System;
using System.Collections.Generic;

namespace CyberSec
{
    public static class EventManager
    {
        private static Dictionary<string, Action> eventTable = new Dictionary<string, Action>();
        private static Dictionary<string, Action<object>> eventTableWithParam = new Dictionary<string, Action<object>>();

        public static void StartListening(string eventName, Action listener)
        {
            if (eventTable.ContainsKey(eventName))
                eventTable[eventName] += listener;
            else
                eventTable[eventName] = listener;
        }

        public static void StartListening(string eventName, Action<object> listener)
        {
            if (eventTableWithParam.ContainsKey(eventName))
                eventTableWithParam[eventName] += listener;
            else
                eventTableWithParam[eventName] = listener;
        }

        public static void StopListening(string eventName, Action listener)
        {
            if (eventTable.ContainsKey(eventName))
                eventTable[eventName] -= listener;
        }

        public static void StopListening(string eventName, Action<object> listener)
        {
            if (eventTableWithParam.ContainsKey(eventName))
                eventTableWithParam[eventName] -= listener;
        }

        public static void TriggerEvent(string eventName)
        {
            if (eventTable.ContainsKey(eventName))
                eventTable[eventName]?.Invoke();
        }

        public static void TriggerEvent(string eventName, object param)
        {
            if (eventTableWithParam.ContainsKey(eventName))
                eventTableWithParam[eventName]?.Invoke(param);
        }

        public static void Clear()
        {
            eventTable.Clear();
            eventTableWithParam.Clear();
        }
    }
}
