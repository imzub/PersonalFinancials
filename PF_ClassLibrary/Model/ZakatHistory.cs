using System;

namespace PF_ClassLibrary.Model
{
    public class ZakatHistory
    {
        public long ZakatHistoryId { get; set; }
        public long AssetId { get; set; }
        public decimal AssetOldValue { get; set; }
        public decimal AssetNewValue { get; set; }
        public DateTime AssetHistoryTimeStamp { get; set; }
    }
}
