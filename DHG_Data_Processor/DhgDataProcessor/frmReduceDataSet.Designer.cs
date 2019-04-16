namespace DhgDataProcessor
{
    partial class frmReduceDataSet
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
            this.txtDataSetFilePath = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.lblUniqueMainWindowsSpikes = new System.Windows.Forms.Label();
            this.lblTweetCount = new System.Windows.Forms.Label();
            this.lblEventCount = new System.Windows.Forms.Label();
            this.lblMainWindowsCount = new System.Windows.Forms.Label();
            this.btnReduce = new System.Windows.Forms.Button();
            this.txtReducedSet = new System.Windows.Forms.TextBox();
            this.btnLoadReducedDataIndex = new System.Windows.Forms.Button();
            this.txtFilteroutWords = new System.Windows.Forms.TextBox();
            this.btnLoadFilteroutWords = new System.Windows.Forms.Button();
            this.txtFilteroutUsers = new System.Windows.Forms.TextBox();
            this.btnLoadFilteroutUsers = new System.Windows.Forms.Button();
            this.rTxtStats = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtDataSetFilePath
            // 
            this.txtDataSetFilePath.BackColor = System.Drawing.Color.White;
            this.txtDataSetFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtDataSetFilePath.Name = "txtDataSetFilePath";
            this.txtDataSetFilePath.ReadOnly = true;
            this.txtDataSetFilePath.Size = new System.Drawing.Size(396, 20);
            this.txtDataSetFilePath.TabIndex = 22;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(414, 10);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(145, 23);
            this.btnLoadData.TabIndex = 21;
            this.btnLoadData.Text = "Load Dataset";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click_1);
            // 
            // lblUniqueMainWindowsSpikes
            // 
            this.lblUniqueMainWindowsSpikes.AutoSize = true;
            this.lblUniqueMainWindowsSpikes.Location = new System.Drawing.Point(74, 379);
            this.lblUniqueMainWindowsSpikes.Name = "lblUniqueMainWindowsSpikes";
            this.lblUniqueMainWindowsSpikes.Size = new System.Drawing.Size(73, 13);
            this.lblUniqueMainWindowsSpikes.TabIndex = 27;
            this.lblUniqueMainWindowsSpikes.Text = "Reduced Set:";
            this.lblUniqueMainWindowsSpikes.Visible = false;
            // 
            // lblTweetCount
            // 
            this.lblTweetCount.AutoSize = true;
            this.lblTweetCount.Location = new System.Drawing.Point(76, 318);
            this.lblTweetCount.Name = "lblTweetCount";
            this.lblTweetCount.Size = new System.Drawing.Size(71, 13);
            this.lblTweetCount.TabIndex = 26;
            this.lblTweetCount.Text = "Tweet Count:";
            this.lblTweetCount.Visible = false;
            // 
            // lblEventCount
            // 
            this.lblEventCount.AutoSize = true;
            this.lblEventCount.Location = new System.Drawing.Point(32, 360);
            this.lblEventCount.Name = "lblEventCount";
            this.lblEventCount.Size = new System.Drawing.Size(115, 13);
            this.lblEventCount.TabIndex = 25;
            this.lblEventCount.Text = "Qualified Tweet Count:";
            this.lblEventCount.Visible = false;
            // 
            // lblMainWindowsCount
            // 
            this.lblMainWindowsCount.AutoSize = true;
            this.lblMainWindowsCount.Location = new System.Drawing.Point(50, 339);
            this.lblMainWindowsCount.Name = "lblMainWindowsCount";
            this.lblMainWindowsCount.Size = new System.Drawing.Size(97, 13);
            this.lblMainWindowsCount.TabIndex = 24;
            this.lblMainWindowsCount.Text = "Tweet Drop Count:";
            this.lblMainWindowsCount.Visible = false;
            // 
            // btnReduce
            // 
            this.btnReduce.Location = new System.Drawing.Point(12, 116);
            this.btnReduce.Name = "btnReduce";
            this.btnReduce.Size = new System.Drawing.Size(547, 23);
            this.btnReduce.TabIndex = 28;
            this.btnReduce.Text = "Reduce Dataset";
            this.btnReduce.UseVisualStyleBackColor = true;
            this.btnReduce.Click += new System.EventHandler(this.btnReduce_Click);
            // 
            // txtReducedSet
            // 
            this.txtReducedSet.BackColor = System.Drawing.Color.White;
            this.txtReducedSet.Location = new System.Drawing.Point(12, 38);
            this.txtReducedSet.Name = "txtReducedSet";
            this.txtReducedSet.ReadOnly = true;
            this.txtReducedSet.Size = new System.Drawing.Size(396, 20);
            this.txtReducedSet.TabIndex = 30;
            // 
            // btnLoadReducedDataIndex
            // 
            this.btnLoadReducedDataIndex.Location = new System.Drawing.Point(414, 36);
            this.btnLoadReducedDataIndex.Name = "btnLoadReducedDataIndex";
            this.btnLoadReducedDataIndex.Size = new System.Drawing.Size(145, 23);
            this.btnLoadReducedDataIndex.TabIndex = 29;
            this.btnLoadReducedDataIndex.Text = "Load Reduced Data Index";
            this.btnLoadReducedDataIndex.UseVisualStyleBackColor = true;
            this.btnLoadReducedDataIndex.Click += new System.EventHandler(this.btnLoadReducedDataIndex_Click);
            // 
            // txtFilteroutWords
            // 
            this.txtFilteroutWords.BackColor = System.Drawing.Color.White;
            this.txtFilteroutWords.Location = new System.Drawing.Point(13, 64);
            this.txtFilteroutWords.Name = "txtFilteroutWords";
            this.txtFilteroutWords.ReadOnly = true;
            this.txtFilteroutWords.Size = new System.Drawing.Size(396, 20);
            this.txtFilteroutWords.TabIndex = 32;
            // 
            // btnLoadFilteroutWords
            // 
            this.btnLoadFilteroutWords.Location = new System.Drawing.Point(415, 62);
            this.btnLoadFilteroutWords.Name = "btnLoadFilteroutWords";
            this.btnLoadFilteroutWords.Size = new System.Drawing.Size(145, 23);
            this.btnLoadFilteroutWords.TabIndex = 31;
            this.btnLoadFilteroutWords.Text = "Load Filterout Words";
            this.btnLoadFilteroutWords.UseVisualStyleBackColor = true;
            this.btnLoadFilteroutWords.Click += new System.EventHandler(this.btnLoadFilteroutWords_Click);
            // 
            // txtFilteroutUsers
            // 
            this.txtFilteroutUsers.BackColor = System.Drawing.Color.White;
            this.txtFilteroutUsers.Location = new System.Drawing.Point(13, 90);
            this.txtFilteroutUsers.Name = "txtFilteroutUsers";
            this.txtFilteroutUsers.ReadOnly = true;
            this.txtFilteroutUsers.Size = new System.Drawing.Size(396, 20);
            this.txtFilteroutUsers.TabIndex = 34;
            // 
            // btnLoadFilteroutUsers
            // 
            this.btnLoadFilteroutUsers.Location = new System.Drawing.Point(415, 88);
            this.btnLoadFilteroutUsers.Name = "btnLoadFilteroutUsers";
            this.btnLoadFilteroutUsers.Size = new System.Drawing.Size(145, 23);
            this.btnLoadFilteroutUsers.TabIndex = 33;
            this.btnLoadFilteroutUsers.Text = "Load Filterout Users";
            this.btnLoadFilteroutUsers.UseVisualStyleBackColor = true;
            this.btnLoadFilteroutUsers.Click += new System.EventHandler(this.btnLoadFilteroutUsers_Click);
            // 
            // rTxtStats
            // 
            this.rTxtStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtStats.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtStats.Location = new System.Drawing.Point(13, 145);
            this.rTxtStats.Name = "rTxtStats";
            this.rTxtStats.Size = new System.Drawing.Size(546, 170);
            this.rTxtStats.TabIndex = 35;
            this.rTxtStats.Text = "";
            // 
            // frmReduceDataSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 474);
            this.Controls.Add(this.rTxtStats);
            this.Controls.Add(this.txtFilteroutUsers);
            this.Controls.Add(this.btnLoadFilteroutUsers);
            this.Controls.Add(this.txtFilteroutWords);
            this.Controls.Add(this.btnLoadFilteroutWords);
            this.Controls.Add(this.txtReducedSet);
            this.Controls.Add(this.btnLoadReducedDataIndex);
            this.Controls.Add(this.btnReduce);
            this.Controls.Add(this.lblUniqueMainWindowsSpikes);
            this.Controls.Add(this.lblTweetCount);
            this.Controls.Add(this.lblEventCount);
            this.Controls.Add(this.lblMainWindowsCount);
            this.Controls.Add(this.txtDataSetFilePath);
            this.Controls.Add(this.btnLoadData);
            this.Name = "frmReduceDataSet";
            this.Text = "Reduce Dataset";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataSetFilePath;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Label lblUniqueMainWindowsSpikes;
        private System.Windows.Forms.Label lblTweetCount;
        private System.Windows.Forms.Label lblEventCount;
        private System.Windows.Forms.Label lblMainWindowsCount;
        private System.Windows.Forms.Button btnReduce;
        private System.Windows.Forms.TextBox txtReducedSet;
        private System.Windows.Forms.Button btnLoadReducedDataIndex;
        private System.Windows.Forms.TextBox txtFilteroutWords;
        private System.Windows.Forms.Button btnLoadFilteroutWords;
        private System.Windows.Forms.TextBox txtFilteroutUsers;
        private System.Windows.Forms.Button btnLoadFilteroutUsers;
        private System.Windows.Forms.RichTextBox rTxtStats;
    }
}