namespace AVS_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InitialLabel = new System.Windows.Forms.Label();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.ScanButton = new System.Windows.Forms.Button();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.ScanProgressBar = new System.Windows.Forms.ProgressBar();
            this.IpTable = new System.Windows.Forms.DataGridView();
            this.ExitButton = new System.Windows.Forms.Button();
            this.BroadcastTextBox = new System.Windows.Forms.TextBox();
            this.AdressTextBox = new System.Windows.Forms.TextBox();
            this.NetMaskTextBox = new System.Windows.Forms.TextBox();
            this.AdressLabel = new System.Windows.Forms.Label();
            this.BroadcastLabel = new System.Windows.Forms.Label();
            this.NetMaskLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IpTable)).BeginInit();
            this.SuspendLayout();
            // 
            // InitialLabel
            // 
            this.InitialLabel.AutoSize = true;
            this.InitialLabel.Location = new System.Drawing.Point(12, 18);
            this.InitialLabel.Name = "InitialLabel";
            this.InitialLabel.Size = new System.Drawing.Size(87, 13);
            this.InitialLabel.TabIndex = 1;
            this.InitialLabel.Text = "Сканировать от";
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(12, 43);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(22, 13);
            this.TargetLabel.TabIndex = 2;
            this.TargetLabel.Text = "До";
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScanButton.Location = new System.Drawing.Point(15, 68);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(142, 91);
            this.ScanButton.TabIndex = 17;
            this.ScanButton.Text = "Сканировать введёный диапазон";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ForThreads);
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AnalyzeButton.Location = new System.Drawing.Point(208, 68);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(142, 91);
            this.AnalyzeButton.TabIndex = 17;
            this.AnalyzeButton.Text = "Анализ выделенного диапазона";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // ScanProgressBar
            // 
            this.ScanProgressBar.Location = new System.Drawing.Point(12, 168);
            this.ScanProgressBar.Name = "ScanProgressBar";
            this.ScanProgressBar.Size = new System.Drawing.Size(339, 26);
            this.ScanProgressBar.TabIndex = 19;
            // 
            // IpTable
            // 
            this.IpTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IpTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IpTable.Location = new System.Drawing.Point(12, 200);
            this.IpTable.Name = "IpTable";
            this.IpTable.Size = new System.Drawing.Size(339, 261);
            this.IpTable.TabIndex = 20;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 553);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(338, 23);
            this.ExitButton.TabIndex = 27;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BroadcastTextBox
            // 
            this.BroadcastTextBox.Location = new System.Drawing.Point(184, 527);
            this.BroadcastTextBox.Name = "BroadcastTextBox";
            this.BroadcastTextBox.ReadOnly = true;
            this.BroadcastTextBox.Size = new System.Drawing.Size(166, 20);
            this.BroadcastTextBox.TabIndex = 26;
            // 
            // AdressTextBox
            // 
            this.AdressTextBox.Location = new System.Drawing.Point(184, 502);
            this.AdressTextBox.Name = "AdressTextBox";
            this.AdressTextBox.ReadOnly = true;
            this.AdressTextBox.Size = new System.Drawing.Size(166, 20);
            this.AdressTextBox.TabIndex = 25;
            // 
            // NetMaskTextBox
            // 
            this.NetMaskTextBox.Location = new System.Drawing.Point(184, 475);
            this.NetMaskTextBox.Name = "NetMaskTextBox";
            this.NetMaskTextBox.ReadOnly = true;
            this.NetMaskTextBox.Size = new System.Drawing.Size(166, 20);
            this.NetMaskTextBox.TabIndex = 24;
            // 
            // AdressLabel
            // 
            this.AdressLabel.AutoSize = true;
            this.AdressLabel.Location = new System.Drawing.Point(8, 505);
            this.AdressLabel.Name = "AdressLabel";
            this.AdressLabel.Size = new System.Drawing.Size(64, 13);
            this.AdressLabel.TabIndex = 23;
            this.AdressLabel.Text = "Адрес сети";
            // 
            // BroadcastLabel
            // 
            this.BroadcastLabel.AutoSize = true;
            this.BroadcastLabel.Location = new System.Drawing.Point(9, 530);
            this.BroadcastLabel.Name = "BroadcastLabel";
            this.BroadcastLabel.Size = new System.Drawing.Size(175, 13);
            this.BroadcastLabel.TabIndex = 22;
            this.BroadcastLabel.Text = "Широковещательный адрес сети";
            // 
            // NetMaskLabel
            // 
            this.NetMaskLabel.AutoSize = true;
            this.NetMaskLabel.Location = new System.Drawing.Point(8, 478);
            this.NetMaskLabel.Name = "NetMaskLabel";
            this.NetMaskLabel.Size = new System.Drawing.Size(66, 13);
            this.NetMaskLabel.TabIndex = 21;
            this.NetMaskLabel.Text = "Маска сети";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 584);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BroadcastTextBox);
            this.Controls.Add(this.AdressTextBox);
            this.Controls.Add(this.NetMaskTextBox);
            this.Controls.Add(this.AdressLabel);
            this.Controls.Add(this.BroadcastLabel);
            this.Controls.Add(this.NetMaskLabel);
            this.Controls.Add(this.IpTable);
            this.Controls.Add(this.ScanProgressBar);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.InitialLabel);
            this.Name = "Form1";
            this.Text = "АВС_1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IpTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InitialLabel;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.ProgressBar ScanProgressBar;
        private System.Windows.Forms.DataGridView IpTable;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox BroadcastTextBox;
        private System.Windows.Forms.TextBox AdressTextBox;
        private System.Windows.Forms.TextBox NetMaskTextBox;
        private System.Windows.Forms.Label AdressLabel;
        private System.Windows.Forms.Label BroadcastLabel;
        public System.Windows.Forms.Label NetMaskLabel;
    }
}

