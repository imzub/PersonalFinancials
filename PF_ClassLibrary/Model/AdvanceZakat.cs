using System;

namespace PF_ClassLibrary.Model
{
    public class AdvanceZakat
    {
        public long AdvZakatId { get; set; }
        public decimal AdvZakatIn { get; set; }
        public decimal AdvZakatOut { get; set; }
        public decimal AdvZakatBalance { get; set; }
        public long? AssetId { get; set; }
        public string AdvZakatPaidTo { get; set; }
        public DateTime AdvZakatPaidDate { get; set; }
        public bool IsAdvZakatPaid { get; set; }
        public bool IsActive { get; set; }
        public string Comments { get; set; }
        public DateTime? Timestamp { get; set; }
        public long ZakatDueId { get; set; }
    }
}
