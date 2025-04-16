using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Linq;

namespace StockAlertApp
{
    public class AlertService
    {
        // Changed to protected to allow derived classes to access alerts if needed
        protected List<StockAlert> _alerts = new List<StockAlert>();

        public List<StockAlert> LoadAlerts()
        {
            return _alerts;
        }

      
        public void SaveAlert(StockAlert alert)
        {
            _alerts.Add(alert);
            
        }

        // Public method to monitor alerts
        public async Task MonitorAlerts()
        {
            var stockDataService = new StockDataService(); // Create an instance of StockDataService

            while (true) // Run indefinitely in a background task
            {
                foreach (var alert in _alerts.ToList()) // Iterate over a copy to allow modifications
                {
                    // Use StockDataService to fetch stock data
                    StockData data = await stockDataService.GetStockData(alert.Symbol);

                    if (data != null)
                    {
                        bool thresholdCrossed = false;
                        string crossedDirection = "";

                        if (alert.Type == AlertType.Above && data.CurrentPrice >= alert.ThresholdPrice)
                        {
                            thresholdCrossed = true;
                            crossedDirection = "went up to";
                        }
                        else if (alert.Type == AlertType.Below && data.CurrentPrice <= alert.ThresholdPrice)
                        {
                            thresholdCrossed = true;
                            crossedDirection = "went down to";
                        }

                        if (thresholdCrossed)
                        {
                            // Trigger the event to notify subscribers
                            OnPriceThresholdCrossed?.Invoke(this, new PriceCrossedEventArgs(alert.Symbol, data.CurrentPrice.Value, crossedDirection));
                        }
                    }
                }
                await Task.Delay(5000); // Check every 5 seconds (adjust as needed)
            }
        }

        // Public event to notify when a price threshold is crossed
        public event EventHandler<PriceCrossedEventArgs> OnPriceThresholdCrossed;

        // Nested class for event arguments
        public class PriceCrossedEventArgs : EventArgs
        {
            public string Symbol { get; }
            public decimal Price { get; }
            public string Direction { get; }

            public PriceCrossedEventArgs(string symbol, decimal price, string direction)
            {
                Symbol = symbol;
                Price = price;
                Direction = direction;
            }
        }
    }
}
