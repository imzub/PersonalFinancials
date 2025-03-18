using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class AssetType
    {
        public long AssetTypeId { get; set; }
        public string AssetTypeName { get; set; } = "";
        public string AssetTypeDesc { get; set; } = "";
        public decimal AssetTypeCurrentValuePerUnit { get; set; }

        // Navigation Property
        public List<Asset> Assets { get; set; } = new List<Asset>();
    }
}
