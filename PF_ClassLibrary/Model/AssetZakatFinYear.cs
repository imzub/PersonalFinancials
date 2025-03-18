using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class AssetZakatFinYear
    {
        public long AssetZakatFinYearId { get; set; }
        public long AssetId { get; set; }
        public DateTime AssetZakatFinYearStartDate { get; set; }
        public DateTime AssetZakatFinYearEndDate { get; set; }
        public bool IsAssetZakatFinYearActive { get; set; }
        public string AssetName { get; set; } = "";

        // Navigation Property
        public Asset Asset { get; set; } = new Asset();
    }

}
