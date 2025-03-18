using System;

namespace PF_ClassLibrary.Model
{
    public class ExceptionLog
    {
        public long ExceptionId { get; set; }
        public string ExceptionMessage { get; set; } = "";
        public string ExceptionStackTrace { get; set; } = "";
        public string ExceptionSource { get; set; } = "";
        public DateTime ExceptionDateTime { get; set; } = DateTime.Now;
    }
}
