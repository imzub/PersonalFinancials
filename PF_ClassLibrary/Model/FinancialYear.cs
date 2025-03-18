using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class FinancialYear
    {
        public long FinancialYearId { get; set; }
        public string FinancialYearName { get; set; } = "";
        public string FinancialYearDesc { get; set; } = "";
        public DateTime FinancialYearStartDate { get; set; }
        public DateTime FinancialYearEndDate { get; set; }
    }

}
