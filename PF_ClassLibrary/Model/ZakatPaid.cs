using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class ZakatPaid
    {
        public long ZakatPaidId { get; set; }
        public long AssetId { get; set; }
        public string ZakatPaidTo { get; set; } = "";
        public decimal ZakatPaidAmount { get; set; }
        public DateTime ZakatPaidDate { get; set; }
        public bool IsZakatDueUpdated { get; set; }

        // Navigation Property
        public Asset Asset { get; set; } = new Asset();
    }
}
