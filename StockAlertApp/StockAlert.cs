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
        public int TriggerCount { get; set; } = 0; // Number of times the alert has been triggered
        public AlertType Type { get; set; }
    }
}
