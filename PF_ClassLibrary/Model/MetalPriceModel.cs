using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class MetalPriceModel
    {
        public string MetalType { get; set; }
        public decimal Gold24K { get; set; }
        public decimal Gold22K { get; set; }
        public decimal Silver { get; set; }
        public decimal Units { get; set; }
    }
}
