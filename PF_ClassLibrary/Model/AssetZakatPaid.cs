using System;

namespace PF_ClassLibrary.Model
{
    public class AssetZakatPaid
    {
        public long AssetZakatPaidId { get; set; }
        public long AssetId { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsActive { get; set; }
    }
}
