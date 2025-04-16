using System.Threading.Tasks;
using YahooFinanceApi;

namespace StockAlertApp
{
    public class StockDataService
    {
        public async Task<StockData> GetStockData(string symbol)
        {
            // Fetch stock data using Yahoo Finance API
            var quotes = await Yahoo.Symbols(symbol).QueryAsync();

            if (quotes != null && quotes.TryGetValue(symbol, out var quote))
            {
                return new StockData
                {
                    Symbol = symbol,
                    CurrentPrice = (decimal)quote.RegularMarketPrice,
                    DailyHigh = (decimal)quote.RegularMarketDayHigh,
                    DailyLow = (decimal)quote.RegularMarketDayLow
                };
            }

            return null; // Return null if the symbol is not found
        }
    }
}
