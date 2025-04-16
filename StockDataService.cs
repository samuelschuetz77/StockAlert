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
                    CurrentPrice = quote.RegularMarketPrice ?? 0,
                    DailyHigh = quote.RegularMarketDayHigh ?? 0,
                    DailyLow = quote.RegularMarketDayLow ?? 0
                };
            }

            return null; // Return null if the symbol is not found
        }
    }
}
