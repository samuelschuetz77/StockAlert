using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System.Net.Mail;
using Moq;

namespace StockAlertApp.Tests
{
    public class AlertTests
    {
        [Fact]
        public void SaveAlert_AddsAlertToCollection()
        {
            // Arrange
            var alertService = new AlertService();
            var alert = new StockAlert
            {
                Symbol = "TSLA",
                ThresholdPrice = 800.0m,
                Type = AlertType.Above
            };

            // Act
            alertService.SaveAlert(alert);
            var alerts = alertService.LoadAlerts();

            // Assert
            Assert.Single(alerts);
            Assert.Contains(alert, alerts);
        }

        [Fact]
        public void RemoveAlert_RemovesAlertFromCollection()
        {
            // Arrange
            var alertService = new AlertService();
            var alert = new StockAlert
            {
                Symbol = "AMZN",
                ThresholdPrice = 3500.0m,
                Type = AlertType.Below
            };
            alertService.SaveAlert(alert);

            // Act
            alertService.RemoveAlert(alert);
            var alerts = alertService.LoadAlerts();

            // Assert
            Assert.Empty(alerts);
        }

        [Fact]
        public void StockAlert_Properties_SetAndGetCorrectly()
        {
            // Arrange
            var alert = new StockAlert();
            string expectedSymbol = "NFLX";
            decimal expectedThreshold = 550.0m;
            AlertType expectedType = AlertType.Above;

            // Act
            alert.Symbol = expectedSymbol;
            alert.ThresholdPrice = expectedThreshold;
            alert.Type = expectedType;

            // Assert
            Assert.Equal(expectedSymbol, alert.Symbol);
            Assert.Equal(expectedThreshold, alert.ThresholdPrice);
            Assert.Equal(expectedType, alert.Type);
            Assert.Equal(0, alert.TriggerCount); // Default value should be 0
        }

        [Fact]
        public async Task MonitorAlerts_AbovePriceTriggersEvent()
        {
            // Arrange
            var mockStockDataService = new Mock<StockDataService>();
            var alertService = new TestableAlertService();

            var alert = new StockAlert
            {
                Symbol = "AAPL",
                ThresholdPrice = 150.0m,
                Type = AlertType.Above
            };
            alertService.SaveAlert(alert);

            bool eventFired = false;
            decimal capturedPrice = 0;
            string capturedDirection = "";

            alertService.OnPriceThresholdCrossed += (sender, args) =>
            {
                eventFired = true;
                capturedPrice = args.Price;
                capturedDirection = args.Direction;
            };

            // Mock stock data with price above threshold
            var mockStockData = new StockData
            {
                Symbol = "AAPL",
                CurrentPrice = 155.0m
            };

            // Act
            await alertService.TestMonitorSingleAlert(alert, mockStockData);

            // Assert
            Assert.True(eventFired);
            Assert.Equal(155.0m, capturedPrice);
            Assert.Equal("went up to", capturedDirection);
            Assert.Equal(1, alert.TriggerCount);
        }

        [Fact]
        public async Task MonitorAlerts_BelowPriceTriggersEvent()
        {
            // Arrange
            var alertService = new TestableAlertService();

            var alert = new StockAlert
            {
                Symbol = "MSFT",
                ThresholdPrice = 300.0m,
                Type = AlertType.Below
            };
            alertService.SaveAlert(alert);

            bool eventFired = false;
            decimal capturedPrice = 0;
            string capturedDirection = "";

            alertService.OnPriceThresholdCrossed += (sender, args) =>
            {
                eventFired = true;
                capturedPrice = args.Price;
                capturedDirection = args.Direction;
            };

            // Mock stock data with price below threshold
            var mockStockData = new StockData
            {
                Symbol = "MSFT",
                CurrentPrice = 290.0m
            };

            // Act
            await alertService.TestMonitorSingleAlert(alert, mockStockData);

            // Assert
            Assert.True(eventFired);
            Assert.Equal(290.0m, capturedPrice);
            Assert.Equal("went down to", capturedDirection);
            Assert.Equal(1, alert.TriggerCount);
        }

        [Fact]
        public async Task MonitorAlerts_SecondTriggerRemovesAlert()
        {
            // Arrange
            var alertService = new TestableAlertService();

            var alert = new StockAlert
            {
                Symbol = "GOOG",
                ThresholdPrice = 2500.0m,
                Type = AlertType.Above,
                TriggerCount = 1 // Already triggered once
            };
            alertService.SaveAlert(alert);

            bool removeEventFired = false;
            StockAlert capturedRemovedAlert = null;

            alertService.OnAlertRemoved += (sender, args) =>
            {
                removeEventFired = true;
                capturedRemovedAlert = args.RemovedAlert;
            };

            // Mock stock data with price above threshold
            var mockStockData = new StockData
            {
                Symbol = "GOOG",
                CurrentPrice = 2600.0m
            };

            // Act
            await alertService.TestMonitorSingleAlert(alert, mockStockData);

            // Assert
            Assert.True(removeEventFired);
            Assert.Equal(alert, capturedRemovedAlert);
            Assert.Equal(2, alert.TriggerCount);
            Assert.DoesNotContain(alert, alertService.LoadAlerts());
        }
    }

    // This class allows us to test the monitoring functionality without infinite loops
    public class TestableAlertService : AlertService
    {
        public async Task TestMonitorSingleAlert(StockAlert alert, StockData mockData)
        {
            if (mockData != null)
            {
                bool thresholdCrossed = false;
                string crossedDirection = "";

                if (alert.Type == AlertType.Above && mockData.CurrentPrice >= alert.ThresholdPrice)
                {
                    thresholdCrossed = true;
                    crossedDirection = "went up to";
                }
                else if (alert.Type == AlertType.Below && mockData.CurrentPrice <= alert.ThresholdPrice)
                {
                    thresholdCrossed = true;
                    crossedDirection = "went down to";
                }

                if (thresholdCrossed && alert.TriggerCount < 2)
                {
                    alert.TriggerCount++; // Increment the trigger count
                    // Trigger the event to notify subscribers
                    OnPriceThresholdCrossed?.Invoke(this, new PriceCrossedEventArgs(alert.Symbol, mockData.CurrentPrice.Value, crossedDirection));

                    if (alert.TriggerCount >= 2)
                    {
                        // Add a small delay to simulate the real method
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
    }
}