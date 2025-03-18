using System;

namespace PF_ClassLibrary.Model
{
    public class ApplicationConfiguration
    {
        public int AppConfigId { get; set; }  // Primary Key
        public string AppKey { get; set; }
        public string AppKeyValue { get; set; }
        public DateTime AppConfigTimeStamp { get; set; }
    }
}
