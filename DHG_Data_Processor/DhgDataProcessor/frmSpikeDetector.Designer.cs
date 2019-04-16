namespace DhgDataProcessor
{
    partial class frmSpikeDetector
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
            this.btnData = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rtxtSpikes = new System.Windows.Forms.RichTextBox();
            this.cmbMeasure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericExpiryTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpiryTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(381, 10);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(43, 23);
            this.btnData.TabIndex = 0;
            this.btnData.Text = "Load Data";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 20);
            this.textBox1.TabIndex = 1;
            // 
            // rtxtSpikes
            // 
            this.rtxtSpikes.Location = new System.Drawing.Point(12, 65);
            this.rtxtSpikes.Name = "rtxtSpikes";
            this.rtxtSpikes.Size = new System.Drawing.Size(461, 504);
            this.rtxtSpikes.TabIndex = 2;
            this.rtxtSpikes.Text = "";
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.Items.AddRange(new object[] {
            "Mean",
            "Mean+2SD",
            "Other (Custom)"});
            this.cmbMeasure.Location = new System.Drawing.Point(67, 38);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.Size = new System.Drawing.Size(130, 21);
            this.cmbMeasure.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Measure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Window Size (Seconds):";
            // 
            // numericExpiryTime
            // 
            this.numericExpiryTime.Location = new System.Drawing.Point(332, 37);
            this.numericExpiryTime.Maximum = new decimal(new int[] {
            36000,
            0,
            0,
            0});
            this.numericExpiryTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericExpiryTime.Name = "numericExpiryTime";
            this.numericExpiryTime.Size = new System.Drawing.Size(43, 20);
            this.numericExpiryTime.TabIndex = 5;
            this.numericExpiryTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // frmSpikeDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 581);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericExpiryTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMeasure);
            this.Controls.Add(this.rtxtSpikes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnData);
            this.Name = "frmSpikeDetector";
            this.Text = "frmSpikeDetector";
            this.Load += new System.EventHandler(this.frmSpikeDetector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericExpiryTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox rtxtSpikes;
        private System.Windows.Forms.ComboBox cmbMeasure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericExpiryTime;
    }
}