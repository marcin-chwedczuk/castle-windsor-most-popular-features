using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class EventTracer
    {
        private static IList<string> _events = new List<string>();

        public static int EventCount
        {
            get { return _events.Count; }
        }

        public static void AddEvent(string @event)
        {
            _events.Add(@event);
        }

        public static string GetEvent(int eventTime)
        {
            return _events[eventTime];
        }

        public static void ResetEvents()
        {
            _events.Clear();
        }
    }
}
