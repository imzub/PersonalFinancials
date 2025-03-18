using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class Asset
    {
        public long AssetId { get; set; }
        public long AssetTypeId { get; set; }
        public long UserId { get; set; }
        public string AssetName { get; set; } = "";
        public string AssetDesc { get; set; } = "";
        public decimal AssetUnits { get; set; }
        public bool IsAssetZakatApplicable { get; set; }
        public DateTime AssetBoughtDate { get; set; }
        public DateTime? ZakatApplicableFromDate { get; set; }
        public decimal AssetBoughtPrice { get; set; }
        public DateTime AssetTimeStamp { get; set; }
        public bool IsAssetActive { get; set; }

        // Navigation Properties
        public AssetType AssetType { get; set; } = new AssetType();
        public User User { get; set; } = new User();
    }
}
