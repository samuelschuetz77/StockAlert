using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlertApp
{
    public enum AlertType
    {
        Above,
        Below
    }
    public class StockAlert
    {
        public string Symbol { get; set; }
        public decimal ThresholdPrice { get; set; }
        public AlertType Type { get; set; }
    }
}
