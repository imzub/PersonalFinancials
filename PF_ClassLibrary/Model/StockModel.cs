using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class StockModel
    {
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Price { get; set; }
        public long Volume { get; set; }
        public DateTime LatestTradingDay { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Change { get; set; }
        public string ChangePercent { get; set; }
    }
}
