namespace ArbitrageAssistant
{
    partial class ArbitAssist
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArbitAssist));
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ss_Status = new System.Windows.Forms.StatusStrip();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_RefreshPeriod = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssb_RefreshPeriod = new System.Windows.Forms.ToolStripSplitButton();
            this.saniyeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saniyeToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Binance = new System.Windows.Forms.ToolStripButton();
            this.tsb_Binance30 = new System.Windows.Forms.ToolStripButton();
            this.tsb_Bitz = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsb_Upbit = new System.Windows.Forms.ToolStripButton();
            this.tsb_Upbit30 = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_Header = new System.Windows.Forms.Label();
            this.lbl_Subtitle = new System.Windows.Forms.Label();
            this.rb_ResultValue = new System.Windows.Forms.RadioButton();
            this.rb_QuoteVolume = new System.Windows.Forms.RadioButton();
            this.tsl_Space01 = new System.Windows.Forms.ToolStripLabel();
            this.tsl_Space02 = new System.Windows.Forms.ToolStripLabel();
            this.tsl_Space03 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ss_Status.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(22, 102);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 24;
            this.dgvMain.Size = new System.Drawing.Size(859, 387);
            this.dgvMain.TabIndex = 0;
            // 
            // timer2
            // 
            this.timer2.Interval = 15000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ss_Status
            // 
            this.ss_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Status,
            this.tssl_RefreshPeriod});
            this.ss_Status.Location = new System.Drawing.Point(0, 501);
            this.ss_Status.Name = "ss_Status";
            this.ss_Status.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.ss_Status.Size = new System.Drawing.Size(904, 22);
            this.ss_Status.TabIndex = 1;
            this.ss_Status.Text = "Durum";
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(143, 17);
            this.tssl_Status.Text = "Yenileme Sıklığı: 15 saniye";
            // 
            // tssl_RefreshPeriod
            // 
            this.tssl_RefreshPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_RefreshPeriod.Margin = new System.Windows.Forms.Padding(600, 3, 1, 2);
            this.tssl_RefreshPeriod.Name = "tssl_RefreshPeriod";
            this.tssl_RefreshPeriod.Size = new System.Drawing.Size(143, 17);
            this.tssl_RefreshPeriod.Text = "Yenileme Sıklığı: 15 saniye";
            this.tssl_RefreshPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_RefreshPeriod.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Binance,
            this.toolStripSeparator2,
            this.tsb_Binance30,
            this.tsl_Space01,
            this.tsb_Bitz,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.tsl_Space02,
            this.tsb_Upbit,
            this.toolStripSeparator1,
            this.tsb_Upbit30,
            this.tsl_Space03,
            this.tspRefresh,
            this.tssb_RefreshPeriod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(904, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspRefresh
            // 
            this.tspRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspRefresh.AutoSize = false;
            this.tspRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tspRefresh.Image")));
            this.tspRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tspRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspRefresh.Name = "tspRefresh";
            this.tspRefresh.Size = new System.Drawing.Size(124, 22);
            this.tspRefresh.Text = "Yenilemeyi Kapat";
            this.tspRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tspRefresh.ToolTipText = "Yenilemeyi Kapat";
            this.tspRefresh.Click += new System.EventHandler(this.Timer_Stop);
            // 
            // tssb_RefreshPeriod
            // 
            this.tssb_RefreshPeriod.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssb_RefreshPeriod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssb_RefreshPeriod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saniyeToolStripMenuItem,
            this.saniyeToolStripMenuItem1,
            this.saniyeToolStripMenuItem2,
            this.saniyeToolStripMenuItem3});
            this.tssb_RefreshPeriod.Image = ((System.Drawing.Image)(resources.GetObject("tssb_RefreshPeriod.Image")));
            this.tssb_RefreshPeriod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssb_RefreshPeriod.Name = "tssb_RefreshPeriod";
            this.tssb_RefreshPeriod.Size = new System.Drawing.Size(105, 22);
            this.tssb_RefreshPeriod.Text = "Yenileme Süresi";
            // 
            // saniyeToolStripMenuItem
            // 
            this.saniyeToolStripMenuItem.Name = "saniyeToolStripMenuItem";
            this.saniyeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saniyeToolStripMenuItem.Text = "3 saniye";
            this.saniyeToolStripMenuItem.Click += new System.EventHandler(this.Set_TimerInterval_3);
            // 
            // saniyeToolStripMenuItem1
            // 
            this.saniyeToolStripMenuItem1.Name = "saniyeToolStripMenuItem1";
            this.saniyeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saniyeToolStripMenuItem1.Text = "5 saniye";
            this.saniyeToolStripMenuItem1.Click += new System.EventHandler(this.Set_TimerInterval_5);
            // 
            // saniyeToolStripMenuItem2
            // 
            this.saniyeToolStripMenuItem2.Name = "saniyeToolStripMenuItem2";
            this.saniyeToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.saniyeToolStripMenuItem2.Text = "10 saniye";
            this.saniyeToolStripMenuItem2.Click += new System.EventHandler(this.Set_TimerInterval_10);
            // 
            // saniyeToolStripMenuItem3
            // 
            this.saniyeToolStripMenuItem3.Name = "saniyeToolStripMenuItem3";
            this.saniyeToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.saniyeToolStripMenuItem3.Text = "30 saniye";
            this.saniyeToolStripMenuItem3.Click += new System.EventHandler(this.Set_TimerInterval_30);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Binance
            // 
            this.tsb_Binance.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Binance.Image")));
            this.tsb_Binance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Binance.Name = "tsb_Binance";
            this.tsb_Binance.Size = new System.Drawing.Size(69, 22);
            this.tsb_Binance.Text = "Binance";
            this.tsb_Binance.Click += new System.EventHandler(this.Binance_Run);
            // 
            // tsb_Binance30
            // 
            this.tsb_Binance30.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Binance30.Name = "tsb_Binance30";
            this.tsb_Binance30.Size = new System.Drawing.Size(73, 22);
            this.tsb_Binance30.Text = "Binance(30)";
            this.tsb_Binance30.Click += new System.EventHandler(this.Binance30_Run);
            // 
            // tsb_Bitz
            // 
            this.tsb_Bitz.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Bitz.Image")));
            this.tsb_Bitz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Bitz.Name = "tsb_Bitz";
            this.tsb_Bitz.Size = new System.Drawing.Size(48, 22);
            this.tsb_Bitz.Text = "BitZ";
            this.tsb_Bitz.Click += new System.EventHandler(this.Bitz_Run);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "BitZ(30)";
            this.toolStripButton1.Click += new System.EventHandler(this.Bitz30_Run);
            // 
            // tsb_Upbit
            // 
            this.tsb_Upbit.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Upbit.Image")));
            this.tsb_Upbit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Upbit.Name = "tsb_Upbit";
            this.tsb_Upbit.Size = new System.Drawing.Size(56, 22);
            this.tsb_Upbit.Text = "Upbit";
            this.tsb_Upbit.Click += new System.EventHandler(this.Upbit_Run);
            // 
            // tsb_Upbit30
            // 
            this.tsb_Upbit30.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Upbit30.Name = "tsb_Upbit30";
            this.tsb_Upbit30.Size = new System.Drawing.Size(60, 22);
            this.tsb_Upbit30.Text = "Upbit(30)";
            this.tsb_Upbit30.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsb_Upbit30.Click += new System.EventHandler(this.Upbit30_Run);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(12, 25);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(187, 57);
            this.lbl_Header.TabIndex = 3;
            this.lbl_Header.Text = "ArbitAssist";
            // 
            // lbl_Subtitle
            // 
            this.lbl_Subtitle.AutoSize = true;
            this.lbl_Subtitle.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Subtitle.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_Subtitle.Location = new System.Drawing.Point(20, 68);
            this.lbl_Subtitle.Name = "lbl_Subtitle";
            this.lbl_Subtitle.Size = new System.Drawing.Size(423, 20);
            this.lbl_Subtitle.TabIndex = 4;
            this.lbl_Subtitle.Text = "Verileri görüntülemek için üst menüden borsa seçin";
            // 
            // rb_ResultValue
            // 
            this.rb_ResultValue.AutoSize = true;
            this.rb_ResultValue.Checked = true;
            this.rb_ResultValue.Location = new System.Drawing.Point(724, 71);
            this.rb_ResultValue.Name = "rb_ResultValue";
            this.rb_ResultValue.Size = new System.Drawing.Size(157, 17);
            this.rb_ResultValue.TabIndex = 5;
            this.rb_ResultValue.TabStop = true;
            this.rb_ResultValue.Text = "Sonuç Değerine Göre Sırala";
            this.rb_ResultValue.UseVisualStyleBackColor = true;
            this.rb_ResultValue.Visible = false;
            this.rb_ResultValue.Click += new System.EventHandler(this.Binance30_Run);
            // 
            // rb_QuoteVolume
            // 
            this.rb_QuoteVolume.AutoSize = true;
            this.rb_QuoteVolume.Location = new System.Drawing.Point(724, 50);
            this.rb_QuoteVolume.Name = "rb_QuoteVolume";
            this.rb_QuoteVolume.Size = new System.Drawing.Size(149, 17);
            this.rb_QuoteVolume.TabIndex = 6;
            this.rb_QuoteVolume.Text = "İşlem Hacmine Göre Sırala";
            this.rb_QuoteVolume.UseVisualStyleBackColor = true;
            this.rb_QuoteVolume.Visible = false;
            this.rb_QuoteVolume.Click += new System.EventHandler(this.Binance_Run);
            // 
            // tsl_Space01
            // 
            this.tsl_Space01.Name = "tsl_Space01";
            this.tsl_Space01.Size = new System.Drawing.Size(10, 22);
            this.tsl_Space01.Text = " ";
            // 
            // tsl_Space02
            // 
            this.tsl_Space02.Name = "tsl_Space02";
            this.tsl_Space02.Size = new System.Drawing.Size(10, 22);
            this.tsl_Space02.Text = " ";
            // 
            // tsl_Space03
            // 
            this.tsl_Space03.Name = "tsl_Space03";
            this.tsl_Space03.Size = new System.Drawing.Size(37, 22);
            this.tsl_Space03.Text = "          ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ArbitAssist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 523);
            this.Controls.Add(this.rb_QuoteVolume);
            this.Controls.Add(this.rb_ResultValue);
            this.Controls.Add(this.lbl_Subtitle);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ss_Status);
            this.Controls.Add(this.dgvMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArbitAssist";
            this.Text = "ArbitAssist";
            this.Load += new System.EventHandler(this.ArbitAssist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ss_Status.ResumeLayout(false);
            this.ss_Status.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.StatusStrip ss_Status;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripSplitButton tssb_RefreshPeriod;
        private System.Windows.Forms.ToolStripMenuItem saniyeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saniyeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saniyeToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saniyeToolStripMenuItem3;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Label lbl_Subtitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Binance;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripStatusLabel tssl_RefreshPeriod;
        private System.Windows.Forms.RadioButton rb_ResultValue;
        private System.Windows.Forms.RadioButton rb_QuoteVolume;
        private System.Windows.Forms.ToolStripButton tsb_Bitz;
        private System.Windows.Forms.ToolStripButton tsb_Binance30;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsb_Upbit;
        private System.Windows.Forms.ToolStripButton tsb_Upbit30;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsl_Space01;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tsl_Space02;
        private System.Windows.Forms.ToolStripLabel tsl_Space03;
    }
}

