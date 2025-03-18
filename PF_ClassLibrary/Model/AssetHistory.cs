using System;

namespace PF_ClassLibrary.Model
{
    public class AssetHistory
    {
        public long AssetHistoryId { get; set; }
        public long AssetId { get; set; }
        public string AssetOldValue { get; set; } = string.Empty;
        public string AssetNewValue { get; set; } = string.Empty;
        public DateTime AssetHistoryTimeStamp { get; set; } = DateTime.Now;

        // Optional: Navigation property (if needed)
        public Asset Asset { get; set; }
    }
}
