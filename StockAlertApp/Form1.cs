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
        private readonly StockDataService _stockDataService = new StockDataService();
        private readonly AlertService _alertService = new AlertService(); // Create an instance of AlertService

        public Form1()
        {
            InitializeComponent();
            // Subscribe to the OnPriceThresholdCrossed event
            _alertService.OnPriceThresholdCrossed += AlertService_OnPriceThresholdCrossed;

            // Subscribe to the OnAlertRemoved event
            _alertService.OnAlertRemoved += AlertService_OnAlertRemoved;

            // Start monitoring alerts in the background when the form loads
            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Start the alert monitoring process
            Task.Run(async () => await _alertService.MonitorAlerts());
        }

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
                // Use StockDataService to fetch stock data
                var stockData = await _stockDataService.GetStockData(symbol);

                if (stockData != null)
                {
                    lblCurrentPrice.Text = $"Current Price: {stockData.CurrentPrice:C}";
                    lblHighPrice.Text = $"Daily High: {stockData.DailyHigh:C}";
                    lblLowPrice.Text = $"Daily Low: {stockData.DailyLow:C}";
                }
                else
                {
                    MessageBox.Show($"Stock symbol '{symbol}' not found.", "Symbol Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAlert_Click(object sender, EventArgs e)
        {
            try
            {
                string symbol = txtAlertSymbol.Text.Trim().ToUpper();
                if (decimal.TryParse(txtThresholdPrice.Text, out decimal threshold) && cmbAlertType.SelectedItem != null)
                {
                    AlertType type = (AlertType)Enum.Parse(typeof(AlertType), cmbAlertType.SelectedItem.ToString());
                    StockAlert newAlert = new StockAlert { Symbol = symbol, ThresholdPrice = threshold, Type = type };

                    // Save the alert
                    _alertService.SaveAlert(newAlert);

                    // Add the alert description to the lstAlerts ListBox
                    lstAlerts.Items.Add($"{newAlert.Symbol} - {newAlert.Type} {newAlert.ThresholdPrice:C}");

                    // Clear input fields
                    txtAlertSymbol.Clear();
                    txtThresholdPrice.Clear();
                    cmbAlertType.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Please enter a valid threshold price and select an alert type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("[ERROR] Invalid input: Threshold or Alert Type is missing.", "Error Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR] Exception in btnAddAlert_Click: {ex.Message}", "Error Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"An error occurred while adding the alert: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlertService_OnAlertRemoved(object sender, AlertService.AlertRemovedEventArgs e)
        {
            // Update the UI to remove the alert from the ListBox (must be done on the UI thread)
            if (InvokeRequired)
            {
                Invoke(new Action(() => RemoveAlertFromListBox(e.RemovedAlert)));
            }
            else
            {
                RemoveAlertFromListBox(e.RemovedAlert);
            }
        }

        private void RemoveAlertFromListBox(StockAlert alert)
        {
            // Find and remove the alert from the ListBox
            for (int i = 0; i < lstAlerts.Items.Count; i++)
            {
                string itemText = lstAlerts.Items[i].ToString();
                if (itemText.StartsWith(alert.Symbol))
                {
                    lstAlerts.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void AlertService_OnPriceThresholdCrossed(object sender, AlertService.PriceCrossedEventArgs e)
        {
            // Display the in-app alert (must be done on the UI thread)
            if (InvokeRequired)
            {
                Invoke(new Action(() => MessageBox.Show($"{e.Symbol} {e.Direction} {e.Price:C}!", "Price Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)));
            }
            else
            {
                MessageBox.Show($"{e.Symbol} {e.Direction} {e.Price:C}!", "Price Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void a(object sender, EventArgs e)
        {
            // This seems to be an unused event handler, you can likely remove it.
        }

        private void btnRemoveAlert_Click(object sender, EventArgs e)
        {
            if (lstAlerts.SelectedIndex >= 0)
            {
                // Get the selected alert description
                string selectedAlert = lstAlerts.SelectedItem.ToString();

                // Parse the symbol from the selected alert (assuming the format is "SYMBOL - TYPE PRICE")
                string symbol = selectedAlert.Split('-')[0].Trim();

                // Find the alert to remove
                var alertToRemove = _alertService.LoadAlerts().FirstOrDefault(a => a.Symbol == symbol);
                if (alertToRemove != null)
                {
                    // Remove the alert using the AlertService
                    _alertService.RemoveAlert(alertToRemove);
                }

                // Remove the alert from the ListBox
                lstAlerts.Items.RemoveAt(lstAlerts.SelectedIndex);

            }
        }

        private void btnRemoveAlert_Click_1(object sender, EventArgs e)
        {

            if (lstAlerts.SelectedIndex >= 0)
            {
                // Get the selected alert description
                string selectedAlert = lstAlerts.SelectedItem.ToString();

                // Parse the symbol from the selected alert (assuming the format is "SYMBOL - TYPE PRICE")
                string symbol = selectedAlert.Split('-')[0].Trim();

                // Find the alert to remove
                var alertToRemove = _alertService.LoadAlerts().FirstOrDefault(a => a.Symbol == symbol);
                if (alertToRemove != null)
                {
                    // Remove the alert using the AlertService
                    _alertService.RemoveAlert(alertToRemove);
                }

                // Remove the alert from the ListBox
                lstAlerts.Items.RemoveAt(lstAlerts.SelectedIndex);


            }
        }

        private void lstAlerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}