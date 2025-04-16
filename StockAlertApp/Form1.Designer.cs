namespace StockAlertApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockSymbol = new System.Windows.Forms.TextBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveAlert = new System.Windows.Forms.Button();
            this.lstAlerts = new System.Windows.Forms.ListBox();
            this.btnAddAlert = new System.Windows.Forms.Button();
            this.cmbAlertType = new System.Windows.Forms.ComboBox();
            this.txtAlertSymbol = new System.Windows.Forms.TextBox();
            this.txtThresholdPrice = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLowPrice = new System.Windows.Forms.Label();
            this.lblHighPrice = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.61559F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.20051F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.18391F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStockSymbol, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFetchData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAlertSymbol, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtThresholdPrice, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.82033F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.82033F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.34752F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.01182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 539);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookshelf Symbol 7", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Stock Symbol ";
            // 
            // txtStockSymbol
            // 
            this.txtStockSymbol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStockSymbol.Location = new System.Drawing.Point(161, 84);
            this.txtStockSymbol.Margin = new System.Windows.Forms.Padding(0);
            this.txtStockSymbol.Name = "txtStockSymbol";
            this.txtStockSymbol.Size = new System.Drawing.Size(200, 20);
            this.txtStockSymbol.TabIndex = 1;
            this.txtStockSymbol.TextChanged += new System.EventHandler(this.a);
            // 
            // btnFetchData
            // 
            this.btnFetchData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnFetchData.Location = new System.Drawing.Point(195, 136);
            this.btnFetchData.Margin = new System.Windows.Forms.Padding(3, 10, 0, 10);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(135, 41);
            this.btnFetchData.TabIndex = 2;
            this.btnFetchData.Text = "Get Price Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(865, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Price Alert";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(703, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Symbol";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(649, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Price Threshold";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(684, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Alert Type";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveAlert);
            this.panel1.Controls.Add(this.lstAlerts);
            this.panel1.Controls.Add(this.btnAddAlert);
            this.panel1.Controls.Add(this.cmbAlertType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(763, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 346);
            this.panel1.TabIndex = 9;
            // 
            // btnRemoveAlert
            // 
            this.btnRemoveAlert.Location = new System.Drawing.Point(222, 158);
            this.btnRemoveAlert.Name = "btnRemoveAlert";
            this.btnRemoveAlert.Size = new System.Drawing.Size(106, 27);
            this.btnRemoveAlert.TabIndex = 3;
            this.btnRemoveAlert.Text = "Remove Alert";
            this.btnRemoveAlert.UseVisualStyleBackColor = true;
            this.btnRemoveAlert.Click += new System.EventHandler(this.btnRemoveAlert_Click_1);
            // 
            // lstAlerts
            // 
            this.lstAlerts.FormattingEnabled = true;
            this.lstAlerts.Location = new System.Drawing.Point(3, 149);
            this.lstAlerts.Name = "lstAlerts";
            this.lstAlerts.Size = new System.Drawing.Size(201, 160);
            this.lstAlerts.TabIndex = 2;
            this.lstAlerts.SelectedIndexChanged += new System.EventHandler(this.lstAlerts_SelectedIndexChanged);
            // 
            // btnAddAlert
            // 
            this.btnAddAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAlert.Location = new System.Drawing.Point(107, 53);
            this.btnAddAlert.Name = "btnAddAlert";
            this.btnAddAlert.Size = new System.Drawing.Size(121, 43);
            this.btnAddAlert.TabIndex = 1;
            this.btnAddAlert.Text = "Add Alert";
            this.btnAddAlert.UseVisualStyleBackColor = true;
            this.btnAddAlert.Click += new System.EventHandler(this.btnAddAlert_Click);
            // 
            // cmbAlertType
            // 
            this.cmbAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlertType.FormattingEnabled = true;
            this.cmbAlertType.Items.AddRange(new object[] {
            "Above",
            "Below"});
            this.cmbAlertType.Location = new System.Drawing.Point(107, 7);
            this.cmbAlertType.Name = "cmbAlertType";
            this.cmbAlertType.Size = new System.Drawing.Size(121, 21);
            this.cmbAlertType.TabIndex = 0;
            // 
            // txtAlertSymbol
            // 
            this.txtAlertSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtAlertSymbol.Location = new System.Drawing.Point(891, 73);
            this.txtAlertSymbol.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtAlertSymbol.Name = "txtAlertSymbol";
            this.txtAlertSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtAlertSymbol.TabIndex = 10;
            // 
            // txtThresholdPrice
            // 
            this.txtThresholdPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtThresholdPrice.Location = new System.Drawing.Point(891, 136);
            this.txtThresholdPrice.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtThresholdPrice.Name = "txtThresholdPrice";
            this.txtThresholdPrice.Size = new System.Drawing.Size(100, 20);
            this.txtThresholdPrice.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLowPrice);
            this.panel2.Controls.Add(this.lblHighPrice);
            this.panel2.Controls.Add(this.lblCurrentPrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 346);
            this.panel2.TabIndex = 12;
            // 
            // lblLowPrice
            // 
            this.lblLowPrice.AutoSize = true;
            this.lblLowPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowPrice.Location = new System.Drawing.Point(187, 201);
            this.lblLowPrice.Name = "lblLowPrice";
            this.lblLowPrice.Size = new System.Drawing.Size(72, 17);
            this.lblLowPrice.TabIndex = 2;
            this.lblLowPrice.Text = "Daily Low ";
            // 
            // lblHighPrice
            // 
            this.lblHighPrice.AutoSize = true;
            this.lblHighPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPrice.Location = new System.Drawing.Point(192, 138);
            this.lblHighPrice.Name = "lblHighPrice";
            this.lblHighPrice.Size = new System.Drawing.Size(72, 17);
            this.lblHighPrice.TabIndex = 1;
            this.lblHighPrice.Text = "Daily High";
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPrice.Location = new System.Drawing.Point(192, 80);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(91, 17);
            this.lblCurrentPrice.TabIndex = 0;
            this.lblCurrentPrice.Text = "Current Price";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 539);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockSymbol;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAlertSymbol;
        private System.Windows.Forms.TextBox txtThresholdPrice;
        private System.Windows.Forms.Button btnAddAlert;
        private System.Windows.Forms.ComboBox cmbAlertType;
        private System.Windows.Forms.Button btnRemoveAlert;
        private System.Windows.Forms.ListBox lstAlerts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Label lblLowPrice;
        private System.Windows.Forms.Label lblHighPrice;
    }
}

