using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class ZakatDue
    {
        public long ZakatDueId { get; set; }
        public long AssetId { get; set; }
        public string AssetName { get; set; }
        public decimal DueZakat { get; set; }
        public bool IsZakatDueActive { get; set; }
        public string UserName { get; set; }

        // Navigation Property
        //public Asset Asset { get; set; } = new Asset();
    }
}
