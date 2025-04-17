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

        public void RemoveAlert(StockAlert alert)
        {
            _alerts.Remove(alert);
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

                        if (thresholdCrossed && alert.TriggerCount <2)
                        {
                            alert.TriggerCount++; // Increment the trigger count
                            // Trigger the event to notify subscribers
                            OnPriceThresholdCrossed?.Invoke(this, new PriceCrossedEventArgs(alert.Symbol, data.CurrentPrice.Value, crossedDirection));
                            
                            if (alert.TriggerCount >= 2)
                            {
                                // Add a small delay before removing to ensure the notification is shown
                                await Task.Delay(100);

                                // Create event args for alert removal notification
                                var removeEventArgs = new AlertRemovedEventArgs(alert);

                                // Remove the alert
                                _alerts.Remove(alert);

                                // Trigger event to notify subscribers about removal
                                OnAlertRemoved?.Invoke(this, removeEventArgs);
                            }
                        }
                    }
                }
                await Task.Delay(5000); // Check every 5 seconds (adjust as needed)
            }
        }

        // Add a new event for alert removal notification
        public event EventHandler<AlertRemovedEventArgs> OnAlertRemoved;

        // Nested class for alert removal event arguments
        public class AlertRemovedEventArgs : EventArgs
        {
            public StockAlert RemovedAlert { get; }

            public AlertRemovedEventArgs(StockAlert alert)
            {
                RemovedAlert = alert;
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
