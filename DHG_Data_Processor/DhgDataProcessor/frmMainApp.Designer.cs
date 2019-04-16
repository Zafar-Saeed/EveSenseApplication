namespace DhgDataProcessor
{
    partial class frmMainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainApp));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tStripDataProcessing = new System.Windows.Forms.ToolStripButton();
            this.tStripDatasetParser = new System.Windows.Forms.ToolStripButton();
            this.tStripSpikeDetector = new System.Windows.Forms.ToolStripButton();
            this.tStripTweetFreuencyDistribution = new System.Windows.Forms.ToolStripButton();
            this.tStripDataReduction = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripDataProcessing,
            this.tStripDatasetParser,
            this.tStripSpikeDetector,
            this.tStripTweetFreuencyDistribution,
            this.tStripDataReduction});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(859, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tStripDataProcessing
            // 
            this.tStripDataProcessing.Image = ((System.Drawing.Image)(resources.GetObject("tStripDataProcessing.Image")));
            this.tStripDataProcessing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripDataProcessing.Name = "tStripDataProcessing";
            this.tStripDataProcessing.Size = new System.Drawing.Size(141, 23);
            this.tStripDataProcessing.Text = "Dataset Processor";
            this.tStripDataProcessing.Click += new System.EventHandler(this.tStrip_Click);
            // 
            // tStripDatasetParser
            // 
            this.tStripDatasetParser.Image = ((System.Drawing.Image)(resources.GetObject("tStripDatasetParser.Image")));
            this.tStripDatasetParser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripDatasetParser.Name = "tStripDatasetParser";
            this.tStripDatasetParser.Size = new System.Drawing.Size(168, 23);
            this.tStripDatasetParser.Text = "Dataset Format Parser";
            this.tStripDatasetParser.Click += new System.EventHandler(this.tStrip_Click);
            // 
            // tStripSpikeDetector
            // 
            this.tStripSpikeDetector.Image = ((System.Drawing.Image)(resources.GetObject("tStripSpikeDetector.Image")));
            this.tStripSpikeDetector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripSpikeDetector.Name = "tStripSpikeDetector";
            this.tStripSpikeDetector.Size = new System.Drawing.Size(120, 23);
            this.tStripSpikeDetector.Text = "Spike Detector";
            this.tStripSpikeDetector.Click += new System.EventHandler(this.tStrip_Click);
            // 
            // tStripTweetFreuencyDistribution
            // 
            this.tStripTweetFreuencyDistribution.Image = ((System.Drawing.Image)(resources.GetObject("tStripTweetFreuencyDistribution.Image")));
            this.tStripTweetFreuencyDistribution.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripTweetFreuencyDistribution.Name = "tStripTweetFreuencyDistribution";
            this.tStripTweetFreuencyDistribution.Size = new System.Drawing.Size(170, 23);
            this.tStripTweetFreuencyDistribution.Text = "Frequency Distribution";
            this.tStripTweetFreuencyDistribution.Click += new System.EventHandler(this.tStrip_Click);
            // 
            // tStripDataReduction
            // 
            this.tStripDataReduction.Image = ((System.Drawing.Image)(resources.GetObject("tStripDataReduction.Image")));
            this.tStripDataReduction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tStripDataReduction.Name = "tStripDataReduction";
            this.tStripDataReduction.Size = new System.Drawing.Size(125, 23);
            this.tStripDataReduction.Text = "Data Reduction";
            this.tStripDataReduction.Click += new System.EventHandler(this.tStrip_Click);
            // 
            // frmMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 411);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMainApp";
            this.Text = "DHG Data Processor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tStripDataProcessing;
        private System.Windows.Forms.ToolStripButton tStripDatasetParser;
        private System.Windows.Forms.ToolStripButton tStripSpikeDetector;
        private System.Windows.Forms.ToolStripButton tStripTweetFreuencyDistribution;
        private System.Windows.Forms.ToolStripButton tStripDataReduction;
    }
}