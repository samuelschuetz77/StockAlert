using System;
using System.Collections.Generic;
using Xunit;
using StockAlertApp;

namespace StockAlertApp
{
    public class StockAlertTests
    {
        [Fact]
        public void SaveAlert_ShouldAddAlertToCollection()
        {

            var alertService = new AlertService();
            var alert = new StockAlert
            {
                Symbol = "AAPL",
                ThresholdPrice = 150.0m,
                Type = AlertType.Above
            };

         
            alertService.SaveAlert(alert);
            var alerts = alertService.LoadAlerts();

   
            Assert.Equal(1, alerts.Count);
            Assert.Equal("AAPL", alerts[0].Symbol);
            Assert.Equal(150.0m, alerts[0].ThresholdPrice);
            Assert.Equal(AlertType.Above, alerts[0].Type);
        }

        [Fact]
        public void RemoveAlert_ShouldRemoveAlertFromCollection()
        {
   
            var alertService = new AlertService();
            var alert = new StockAlert
            {
                Symbol = "GOOG",
                ThresholdPrice = 2500.0m,
                Type = AlertType.Below
            };
            alertService.SaveAlert(alert);

          
            alertService.RemoveAlert(alert);
            var alerts = alertService.LoadAlerts();

  
            Assert.Equal(0, alerts.Count);
        }

        [Fact]
        public void StockAlert_ShouldSetAndGetPropertiesCorrectly()
        {
          
            var alert = new StockAlert();

 
            alert.Symbol = "MSFT";
            alert.ThresholdPrice = 300.0m;
            alert.Type = AlertType.Above;

            Assert.Equal("MSFT", alert.Symbol);
            Assert.Equal(300.0m, alert.ThresholdPrice);
            Assert.Equal(AlertType.Above, alert.Type);
            Assert.Equal(0, alert.TriggerCount); 
        }

        [Fact]
        public void FetchStockData_ShouldReturnValidStockData()
        {

            var stockDataService = new StockDataService();
            var symbol = "AAPL";

            var stockData = stockDataService.GetStockData(symbol).Result;

            Assert.NotNull(stockData);
            Assert.Equal("AAPL", stockData.Symbol);
            Assert.True(stockData.CurrentPrice.HasValue);
            Assert.True(stockData.DailyHigh.HasValue);
            Assert.True(stockData.DailyLow.HasValue);
        }
    }
}


