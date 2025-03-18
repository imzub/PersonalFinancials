using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class YearType
    {
        public long YearTypeId { get; set; }
        public string YearTypeName { get; set; } = "";
        public string YearTypeDesc { get; set; } = "";
        public int YearTypeDays { get; set; }
    }

}
