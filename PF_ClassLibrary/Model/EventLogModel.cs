using System;

namespace PersonalFinancials.Models
{
    public class EventLogModel
    {
        public int EventID { get; set; } // Auto-incremented
        public string EventType { get; set; }
        public string EventMessage { get; set; }
        public string EventSource { get; set; }
        public string UserName { get; set; } // Nullable
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string AdditionalData { get; set; } // JSON/XML data
    }
}
