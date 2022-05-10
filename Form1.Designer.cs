namespace paypal_capture
{
    partial class PayPalCapture
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
            this.Orders = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.fullAmountRadioButton = new System.Windows.Forms.RadioButton();
            this.partialRadioButton = new System.Windows.Forms.RadioButton();
            this.partialAmountTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.voidButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Orders
            // 
            this.Orders.FormattingEnabled = true;
            this.Orders.Location = new System.Drawing.Point(12, 12);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(212, 329);
            this.Orders.TabIndex = 0;
            this.Orders.SelectedValueChanged += new System.EventHandler(this.Orders_SelectedValueChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(149, 347);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // CaptureButton
            // 
            this.CaptureButton.Location = new System.Drawing.Point(337, 347);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(75, 23);
            this.CaptureButton.TabIndex = 2;
            this.CaptureButton.Text = "Capture";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // fullAmountRadioButton
            // 
            this.fullAmountRadioButton.AutoSize = true;
            this.fullAmountRadioButton.Location = new System.Drawing.Point(290, 134);
            this.fullAmountRadioButton.Name = "fullAmountRadioButton";
            this.fullAmountRadioButton.Size = new System.Drawing.Size(120, 17);
            this.fullAmountRadioButton.TabIndex = 3;
            this.fullAmountRadioButton.TabStop = true;
            this.fullAmountRadioButton.Text = "Capture Full Amount";
            this.fullAmountRadioButton.UseVisualStyleBackColor = true;
            this.fullAmountRadioButton.CheckedChanged += new System.EventHandler(this.fullAmountRadioButton_CheckedChanged);
            // 
            // partialRadioButton
            // 
            this.partialRadioButton.AutoSize = true;
            this.partialRadioButton.Location = new System.Drawing.Point(290, 171);
            this.partialRadioButton.Name = "partialRadioButton";
            this.partialRadioButton.Size = new System.Drawing.Size(133, 17);
            this.partialRadioButton.TabIndex = 4;
            this.partialRadioButton.TabStop = true;
            this.partialRadioButton.Text = "Capture Partial Amount";
            this.partialRadioButton.UseVisualStyleBackColor = true;
            this.partialRadioButton.CheckedChanged += new System.EventHandler(this.partialRadioButton_CheckedChanged);
            // 
            // partialAmountTextBox
            // 
            this.partialAmountTextBox.Location = new System.Drawing.Point(312, 194);
            this.partialAmountTextBox.Name = "partialAmountTextBox";
            this.partialAmountTextBox.Size = new System.Drawing.Size(98, 20);
            this.partialAmountTextBox.TabIndex = 5;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountLabel.Location = new System.Drawing.Point(256, 239);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(61, 24);
            this.AmountLabel.TabIndex = 6;
            this.AmountLabel.Text = "Total: ";
            // 
            // voidButton
            // 
            this.voidButton.Location = new System.Drawing.Point(337, 377);
            this.voidButton.Name = "voidButton";
            this.voidButton.Size = new System.Drawing.Size(75, 23);
            this.voidButton.TabIndex = 7;
            this.voidButton.Text = "Cancel";
            this.voidButton.UseVisualStyleBackColor = true;
            this.voidButton.Click += new System.EventHandler(this.voidButton_Click);
            // 
            // PayPalCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.voidButton);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.partialAmountTextBox);
            this.Controls.Add(this.partialRadioButton);
            this.Controls.Add(this.fullAmountRadioButton);
            this.Controls.Add(this.CaptureButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Orders);
            this.Name = "PayPalCapture";
            this.Text = "PayPal Capture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Orders;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.RadioButton fullAmountRadioButton;
        private System.Windows.Forms.RadioButton partialRadioButton;
        private System.Windows.Forms.TextBox partialAmountTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Button voidButton;
    }
}

