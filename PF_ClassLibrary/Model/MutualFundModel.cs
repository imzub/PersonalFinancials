using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class MutualFundModel
    {
        public string SchemeCode { get; set; }
        public string SchemeName { get; set; }
        public decimal NAV { get; set; }
        public string LastUpdated { get; set; }
    }
}
