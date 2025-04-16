using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlertApp
{
    public class StockData
    {
        public string Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? DailyHigh { get; set; }
        public decimal? DailyLow { get; set; }
    }
}
