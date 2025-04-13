using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceApi;


namespace StockAlertApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnAddAlert_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void label6_Click(object sender, EventArgs e)
        //{

        //}

        //private void label6_Click_1(object sender, EventArgs e)
        //{

        //}

        private async void btnFetchData_Click(object sender, EventArgs e)
        {
            string symbol = txtStockSymbol.Text.Trim().ToUpper(); // Get the entered symbol and convert to uppercase

            if (string.IsNullOrEmpty(symbol))
            {
                MessageBox.Show("Please enter a stock symbol.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
             
                var quotes = await Yahoo.Symbols(symbol).QueryAsync();

                if (quotes != null && quotes.TryGetValue(symbol, out var quote))
                {

                   
                    lblCurrentPrice.Text = $"Current Price: {quote.RegularMarketPrice:C}";
                    lblHighPrice.Text = $"Daily High: {quote.RegularMarketDayHigh:C}";
                    lblLowPrice.Text = $"Daily Low: {quote.RegularMarketDayLow:C}";

                }
                else
                {
                    MessageBox.Show($"Stock symbol '{symbol}' not found.", "Symbol Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void a(object sender, EventArgs e)
        {

        }
    }
    
}
