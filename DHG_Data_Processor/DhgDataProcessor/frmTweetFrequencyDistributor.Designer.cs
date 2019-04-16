namespace DhgDataProcessor
{
    partial class frmTweetFrequencyDistributor
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblMainWindowsCount = new System.Windows.Forms.Label();
            this.lblEventCount = new System.Windows.Forms.Label();
            this.txtDataSetFilePath = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.lblTweetCount = new System.Windows.Forms.Label();
            this.lblUniqueMainWindowsSpikes = new System.Windows.Forms.Label();
            this.lblUniqueOverlappingWindowsSpikes = new System.Windows.Forms.Label();
            this.rTxtStats = new System.Windows.Forms.RichTextBox();
            this.numericWindowSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericSubWindowSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rBtnSingleWindow = new System.Windows.Forms.RadioButton();
            this.rBtnOverlappingWindows = new System.Windows.Forms.RadioButton();
            this.numericOverlap = new System.Windows.Forms.NumericUpDown();
            this.lblOverlap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOverlap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(126, 40);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(170, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Distribution";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblMainWindowsCount
            // 
            this.lblMainWindowsCount.AutoSize = true;
            this.lblMainWindowsCount.Location = new System.Drawing.Point(174, 432);
            this.lblMainWindowsCount.Name = "lblMainWindowsCount";
            this.lblMainWindowsCount.Size = new System.Drawing.Size(126, 15);
            this.lblMainWindowsCount.TabIndex = 17;
            this.lblMainWindowsCount.Text = "Main Windows Count:";
            this.lblMainWindowsCount.Visible = false;
            // 
            // lblEventCount
            // 
            this.lblEventCount.AutoSize = true;
            this.lblEventCount.Location = new System.Drawing.Point(149, 455);
            this.lblEventCount.Name = "lblEventCount";
            this.lblEventCount.Size = new System.Drawing.Size(152, 15);
            this.lblEventCount.TabIndex = 18;
            this.lblEventCount.Text = "Spikes/Significance Count:";
            this.lblEventCount.Visible = false;
            // 
            // txtDataSetFilePath
            // 
            this.txtDataSetFilePath.BackColor = System.Drawing.Color.White;
            this.txtDataSetFilePath.Location = new System.Drawing.Point(11, 12);
            this.txtDataSetFilePath.Name = "txtDataSetFilePath";
            this.txtDataSetFilePath.ReadOnly = true;
            this.txtDataSetFilePath.Size = new System.Drawing.Size(396, 20);
            this.txtDataSetFilePath.TabIndex = 20;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(413, 10);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(87, 23);
            this.btnLoadData.TabIndex = 19;
            this.btnLoadData.Text = "Load Dataset";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // lblTweetCount
            // 
            this.lblTweetCount.AutoSize = true;
            this.lblTweetCount.Location = new System.Drawing.Point(214, 409);
            this.lblTweetCount.Name = "lblTweetCount";
            this.lblTweetCount.Size = new System.Drawing.Size(78, 15);
            this.lblTweetCount.TabIndex = 21;
            this.lblTweetCount.Text = "Tweet Count:";
            this.lblTweetCount.Visible = false;
            // 
            // lblUniqueMainWindowsSpikes
            // 
            this.lblUniqueMainWindowsSpikes.AutoSize = true;
            this.lblUniqueMainWindowsSpikes.Location = new System.Drawing.Point(133, 477);
            this.lblUniqueMainWindowsSpikes.Name = "lblUniqueMainWindowsSpikes";
            this.lblUniqueMainWindowsSpikes.Size = new System.Drawing.Size(174, 15);
            this.lblUniqueMainWindowsSpikes.TabIndex = 22;
            this.lblUniqueMainWindowsSpikes.Text = "Unique Main Windows Spikes:";
            this.lblUniqueMainWindowsSpikes.Visible = false;
            // 
            // lblUniqueOverlappingWindowsSpikes
            // 
            this.lblUniqueOverlappingWindowsSpikes.AutoSize = true;
            this.lblUniqueOverlappingWindowsSpikes.Location = new System.Drawing.Point(99, 499);
            this.lblUniqueOverlappingWindowsSpikes.Name = "lblUniqueOverlappingWindowsSpikes";
            this.lblUniqueOverlappingWindowsSpikes.Size = new System.Drawing.Size(212, 15);
            this.lblUniqueOverlappingWindowsSpikes.TabIndex = 23;
            this.lblUniqueOverlappingWindowsSpikes.Text = "Unique Overlapping Windows Spikes:";
            this.lblUniqueOverlappingWindowsSpikes.Visible = false;
            // 
            // rTxtStats
            // 
            this.rTxtStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtStats.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtStats.Location = new System.Drawing.Point(11, 69);
            this.rTxtStats.Name = "rTxtStats";
            this.rTxtStats.Size = new System.Drawing.Size(553, 286);
            this.rTxtStats.TabIndex = 24;
            this.rTxtStats.Text = "";
            // 
            // numericWindowSize
            // 
            this.numericWindowSize.Location = new System.Drawing.Point(740, 22);
            this.numericWindowSize.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericWindowSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWindowSize.Name = "numericWindowSize";
            this.numericWindowSize.Size = new System.Drawing.Size(58, 20);
            this.numericWindowSize.TabIndex = 7;
            this.numericWindowSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericWindowSize.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Main Window Size (Min):";
            this.label2.Visible = false;
            // 
            // numericSubWindowSize
            // 
            this.numericSubWindowSize.Location = new System.Drawing.Point(740, 48);
            this.numericSubWindowSize.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericSubWindowSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSubWindowSize.Name = "numericSubWindowSize";
            this.numericSubWindowSize.Size = new System.Drawing.Size(58, 20);
            this.numericSubWindowSize.TabIndex = 9;
            this.numericSubWindowSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSubWindowSize.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Average Sub-Window Size (Seconds):";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(804, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max up to 1440min (i.e. 1 day)";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(804, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Max up to 3600sec (i.e. 1 Hour)";
            this.label4.Visible = false;
            // 
            // rBtnSingleWindow
            // 
            this.rBtnSingleWindow.AutoSize = true;
            this.rBtnSingleWindow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtnSingleWindow.Location = new System.Drawing.Point(702, 74);
            this.rBtnSingleWindow.Name = "rBtnSingleWindow";
            this.rBtnSingleWindow.Size = new System.Drawing.Size(107, 19);
            this.rBtnSingleWindow.TabIndex = 13;
            this.rBtnSingleWindow.TabStop = true;
            this.rBtnSingleWindow.Text = "Single Window";
            this.rBtnSingleWindow.UseVisualStyleBackColor = true;
            this.rBtnSingleWindow.Visible = false;
            // 
            // rBtnOverlappingWindows
            // 
            this.rBtnOverlappingWindows.AutoSize = true;
            this.rBtnOverlappingWindows.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rBtnOverlappingWindows.Location = new System.Drawing.Point(665, 97);
            this.rBtnOverlappingWindows.Name = "rBtnOverlappingWindows";
            this.rBtnOverlappingWindows.Size = new System.Drawing.Size(144, 19);
            this.rBtnOverlappingWindows.TabIndex = 14;
            this.rBtnOverlappingWindows.TabStop = true;
            this.rBtnOverlappingWindows.Text = "Overlapping Windows";
            this.rBtnOverlappingWindows.UseVisualStyleBackColor = true;
            this.rBtnOverlappingWindows.Visible = false;
            // 
            // numericOverlap
            // 
            this.numericOverlap.Location = new System.Drawing.Point(856, 94);
            this.numericOverlap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericOverlap.Name = "numericOverlap";
            this.numericOverlap.Size = new System.Drawing.Size(58, 20);
            this.numericOverlap.TabIndex = 15;
            this.numericOverlap.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOverlap.Visible = false;
            // 
            // lblOverlap
            // 
            this.lblOverlap.AutoSize = true;
            this.lblOverlap.Location = new System.Drawing.Point(806, 99);
            this.lblOverlap.Name = "lblOverlap";
            this.lblOverlap.Size = new System.Drawing.Size(49, 15);
            this.lblOverlap.TabIndex = 16;
            this.lblOverlap.Text = "Overlap";
            this.lblOverlap.Visible = false;
            // 
            // frmTweetFrequencyDistributor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 515);
            this.Controls.Add(this.rTxtStats);
            this.Controls.Add(this.lblUniqueOverlappingWindowsSpikes);
            this.Controls.Add(this.lblUniqueMainWindowsSpikes);
            this.Controls.Add(this.lblTweetCount);
            this.Controls.Add(this.txtDataSetFilePath);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.lblEventCount);
            this.Controls.Add(this.lblMainWindowsCount);
            this.Controls.Add(this.lblOverlap);
            this.Controls.Add(this.numericOverlap);
            this.Controls.Add(this.rBtnOverlappingWindows);
            this.Controls.Add(this.rBtnSingleWindow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSubWindowSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericWindowSize);
            this.Controls.Add(this.btnGenerate);
            this.Name = "frmTweetFrequencyDistributor";
            this.Text = "Tweet Frequency Distributor";
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOverlap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblMainWindowsCount;
        private System.Windows.Forms.Label lblEventCount;
        private System.Windows.Forms.TextBox txtDataSetFilePath;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label lblTweetCount;
        private System.Windows.Forms.Label lblUniqueMainWindowsSpikes;
        private System.Windows.Forms.Label lblUniqueOverlappingWindowsSpikes;
        private System.Windows.Forms.RichTextBox rTxtStats;
        private System.Windows.Forms.NumericUpDown numericWindowSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSubWindowSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rBtnSingleWindow;
        private System.Windows.Forms.RadioButton rBtnOverlappingWindows;
        private System.Windows.Forms.NumericUpDown numericOverlap;
        private System.Windows.Forms.Label lblOverlap;
    }
}