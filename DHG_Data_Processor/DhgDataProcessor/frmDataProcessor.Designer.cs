namespace DhgDataProcessor
{
    partial class frmDataProcessor
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtDataSetFilePath = new System.Windows.Forms.TextBox();
            this.numericExpiryTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMeasure = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtFiltrationWords = new System.Windows.Forms.TextBox();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.btnDataParser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEdgeWeightCriteria = new System.Windows.Forms.ComboBox();
            this.chkUserFlag = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTweetMatchingCriteria = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericWordLength = new System.Windows.Forms.NumericUpDown();
            this.chkWeightedEdge = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkDuplicate = new System.Windows.Forms.CheckBox();
            this.txtDuplicateTweetIndexFile = new System.Windows.Forms.TextBox();
            this.chkReverse = new System.Windows.Forms.CheckBox();
            this.chkCleanedData = new System.Windows.Forms.CheckBox();
            this.chkStemming = new System.Windows.Forms.CheckBox();
            this.chkDHGWriter = new System.Windows.Forms.CheckBox();
            this.chkWeightedNode = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioBtnMin = new System.Windows.Forms.RadioButton();
            this.radioBtnHour = new System.Windows.Forms.RadioButton();
            this.radioBtnDay = new System.Windows.Forms.RadioButton();
            this.chkApplicationPathForFiles = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpiryTime)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(29, 329);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(305, 40);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(339, 27);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(45, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtDataSetFilePath
            // 
            this.txtDataSetFilePath.Location = new System.Drawing.Point(52, 29);
            this.txtDataSetFilePath.Name = "txtDataSetFilePath";
            this.txtDataSetFilePath.Size = new System.Drawing.Size(284, 20);
            this.txtDataSetFilePath.TabIndex = 2;
            // 
            // numericExpiryTime
            // 
            this.numericExpiryTime.Location = new System.Drawing.Point(153, 55);
            this.numericExpiryTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericExpiryTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericExpiryTime.Name = "numericExpiryTime";
            this.numericExpiryTime.Size = new System.Drawing.Size(38, 20);
            this.numericExpiryTime.TabIndex = 3;
            this.numericExpiryTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expiry:";
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.Items.AddRange(new object[] {
            "Degree Centrality +ve Edges Only",
            "Degree Centrality all Edges",
            "Custom Measure"});
            this.cmbMeasure.Location = new System.Drawing.Point(152, 81);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.Size = new System.Drawing.Size(183, 21);
            this.cmbMeasure.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Measure:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "None",
            "Words",
            "Outlier with Quantile",
            "Outlier with Mean",
            "Outlier with Mean and Standard Mean error",
            "Percentage"});
            this.cmbFilter.Location = new System.Drawing.Point(153, 108);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(183, 21);
            this.cmbFilter.TabIndex = 8;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filter Words:";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.txtFiltrationWords);
            this.pnlFilter.Location = new System.Drawing.Point(339, 107);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(426, 22);
            this.pnlFilter.TabIndex = 10;
            this.pnlFilter.Visible = false;
            // 
            // txtFiltrationWords
            // 
            this.txtFiltrationWords.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFiltrationWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrationWords.ForeColor = System.Drawing.Color.Gray;
            this.txtFiltrationWords.Location = new System.Drawing.Point(0, 0);
            this.txtFiltrationWords.Name = "txtFiltrationWords";
            this.txtFiltrationWords.Size = new System.Drawing.Size(426, 21);
            this.txtFiltrationWords.TabIndex = 0;
            this.txtFiltrationWords.Text = "Write all words here with comma saperated (e.g. keyword1,keyword2,keyword3)";
            this.txtFiltrationWords.Enter += new System.EventHandler(this.txtFiltrationWords_Enter);
            this.txtFiltrationWords.Leave += new System.EventHandler(this.txtFiltrationWords_Leave);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.AutoSize = true;
            this.lblStatusMsg.Font = new System.Drawing.Font("Arial Narrow", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMsg.Location = new System.Drawing.Point(36, 385);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(55, 17);
            this.lblStatusMsg.TabIndex = 11;
            this.lblStatusMsg.Text = "Message";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status:";
            // 
            // ProgressTimer
            // 
            this.ProgressTimer.Interval = 20;
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // btnDataParser
            // 
            this.btnDataParser.Location = new System.Drawing.Point(383, 27);
            this.btnDataParser.Name = "btnDataParser";
            this.btnDataParser.Size = new System.Drawing.Size(81, 23);
            this.btnDataParser.TabIndex = 13;
            this.btnDataParser.Text = "Data Parser";
            this.btnDataParser.UseVisualStyleBackColor = true;
            this.btnDataParser.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Edge Weight:";
            // 
            // cmbEdgeWeightCriteria
            // 
            this.cmbEdgeWeightCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdgeWeightCriteria.FormattingEnabled = true;
            this.cmbEdgeWeightCriteria.Items.AddRange(new object[] {
            "User Based",
            "Tweet Based",
            "Accumulative"});
            this.cmbEdgeWeightCriteria.Location = new System.Drawing.Point(152, 135);
            this.cmbEdgeWeightCriteria.Name = "cmbEdgeWeightCriteria";
            this.cmbEdgeWeightCriteria.Size = new System.Drawing.Size(183, 21);
            this.cmbEdgeWeightCriteria.TabIndex = 14;
            // 
            // chkUserFlag
            // 
            this.chkUserFlag.AutoSize = true;
            this.chkUserFlag.Location = new System.Drawing.Point(340, 164);
            this.chkUserFlag.Name = "chkUserFlag";
            this.chkUserFlag.Size = new System.Drawing.Size(89, 19);
            this.chkUserFlag.TabIndex = 17;
            this.chkUserFlag.Text = "Match User";
            this.chkUserFlag.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Duplicate Tweet:";
            // 
            // cmbTweetMatchingCriteria
            // 
            this.cmbTweetMatchingCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTweetMatchingCriteria.FormattingEnabled = true;
            this.cmbTweetMatchingCriteria.Items.AddRange(new object[] {
            "Exact Sequence",
            "Any Order"});
            this.cmbTweetMatchingCriteria.Location = new System.Drawing.Point(153, 162);
            this.cmbTweetMatchingCriteria.Name = "cmbTweetMatchingCriteria";
            this.cmbTweetMatchingCriteria.Size = new System.Drawing.Size(183, 21);
            this.cmbTweetMatchingCriteria.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Min Word Length:";
            // 
            // numericWordLength
            // 
            this.numericWordLength.Location = new System.Drawing.Point(295, 189);
            this.numericWordLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericWordLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWordLength.Name = "numericWordLength";
            this.numericWordLength.Size = new System.Drawing.Size(39, 20);
            this.numericWordLength.TabIndex = 20;
            this.numericWordLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkWeightedEdge
            // 
            this.chkWeightedEdge.AutoSize = true;
            this.chkWeightedEdge.Location = new System.Drawing.Point(339, 84);
            this.chkWeightedEdge.Name = "chkWeightedEdge";
            this.chkWeightedEdge.Size = new System.Drawing.Size(110, 19);
            this.chkWeightedEdge.TabIndex = 22;
            this.chkWeightedEdge.Text = "Weighted Edge";
            this.chkWeightedEdge.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Min Tweets in Window:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(295, 215);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 23;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkDuplicate
            // 
            this.chkDuplicate.AutoSize = true;
            this.chkDuplicate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDuplicate.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDuplicate.Location = new System.Drawing.Point(0, 57);
            this.chkDuplicate.Name = "chkDuplicate";
            this.chkDuplicate.Size = new System.Drawing.Size(258, 19);
            this.chkDuplicate.TabIndex = 25;
            this.chkDuplicate.Text = "Read Indexes for Duplicate Tweets from File";
            this.chkDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDuplicate.UseVisualStyleBackColor = true;
            this.chkDuplicate.CheckedChanged += new System.EventHandler(this.chkDuplicate_CheckedChanged);
            // 
            // txtDuplicateTweetIndexFile
            // 
            this.txtDuplicateTweetIndexFile.Location = new System.Drawing.Point(377, 238);
            this.txtDuplicateTweetIndexFile.Name = "txtDuplicateTweetIndexFile";
            this.txtDuplicateTweetIndexFile.Size = new System.Drawing.Size(387, 20);
            this.txtDuplicateTweetIndexFile.TabIndex = 26;
            this.txtDuplicateTweetIndexFile.Visible = false;
            // 
            // chkReverse
            // 
            this.chkReverse.AutoSize = true;
            this.chkReverse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReverse.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkReverse.Location = new System.Drawing.Point(0, 38);
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(258, 19);
            this.chkReverse.TabIndex = 27;
            this.chkReverse.Text = "Reverse Dataset Order";
            this.chkReverse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReverse.UseVisualStyleBackColor = true;
            // 
            // chkCleanedData
            // 
            this.chkCleanedData.AutoSize = true;
            this.chkCleanedData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCleanedData.Checked = true;
            this.chkCleanedData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCleanedData.Location = new System.Drawing.Point(217, 4);
            this.chkCleanedData.Name = "chkCleanedData";
            this.chkCleanedData.Size = new System.Drawing.Size(117, 19);
            this.chkCleanedData.TabIndex = 28;
            this.chkCleanedData.Text = "Cleaned Dataset";
            this.chkCleanedData.UseVisualStyleBackColor = true;
            this.chkCleanedData.CheckedChanged += new System.EventHandler(this.chkCleanedData_CheckedChanged);
            // 
            // chkStemming
            // 
            this.chkStemming.AutoSize = true;
            this.chkStemming.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStemming.Checked = true;
            this.chkStemming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStemming.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkStemming.Location = new System.Drawing.Point(0, 19);
            this.chkStemming.Name = "chkStemming";
            this.chkStemming.Size = new System.Drawing.Size(258, 19);
            this.chkStemming.TabIndex = 29;
            this.chkStemming.Text = "Perform Stemming";
            this.chkStemming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStemming.UseVisualStyleBackColor = true;
            // 
            // chkDHGWriter
            // 
            this.chkDHGWriter.AutoSize = true;
            this.chkDHGWriter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDHGWriter.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDHGWriter.Location = new System.Drawing.Point(0, 0);
            this.chkDHGWriter.Name = "chkDHGWriter";
            this.chkDHGWriter.Size = new System.Drawing.Size(258, 19);
            this.chkDHGWriter.TabIndex = 30;
            this.chkDHGWriter.Text = "Write file for Graph Visualization";
            this.chkDHGWriter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDHGWriter.UseVisualStyleBackColor = true;
            this.chkDHGWriter.CheckedChanged += new System.EventHandler(this.chkGraphVisualizer_CheckedChanged);
            // 
            // chkWeightedNode
            // 
            this.chkWeightedNode.AutoSize = true;
            this.chkWeightedNode.Location = new System.Drawing.Point(451, 84);
            this.chkWeightedNode.Name = "chkWeightedNode";
            this.chkWeightedNode.Size = new System.Drawing.Size(111, 19);
            this.chkWeightedNode.TabIndex = 31;
            this.chkWeightedNode.Text = "Weighted Node";
            this.chkWeightedNode.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(564, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(365, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Reminder: Weights are effective only on Positive Edge Measure";
            this.label9.Visible = false;
            // 
            // radioBtnMin
            // 
            this.radioBtnMin.AutoSize = true;
            this.radioBtnMin.Location = new System.Drawing.Point(197, 56);
            this.radioBtnMin.Name = "radioBtnMin";
            this.radioBtnMin.Size = new System.Drawing.Size(46, 19);
            this.radioBtnMin.TabIndex = 33;
            this.radioBtnMin.Text = "Min";
            this.radioBtnMin.UseVisualStyleBackColor = true;
            // 
            // radioBtnHour
            // 
            this.radioBtnHour.AutoSize = true;
            this.radioBtnHour.Checked = true;
            this.radioBtnHour.Location = new System.Drawing.Point(239, 57);
            this.radioBtnHour.Name = "radioBtnHour";
            this.radioBtnHour.Size = new System.Drawing.Size(52, 19);
            this.radioBtnHour.TabIndex = 34;
            this.radioBtnHour.TabStop = true;
            this.radioBtnHour.Text = "Hour";
            this.radioBtnHour.UseVisualStyleBackColor = true;
            // 
            // radioBtnDay
            // 
            this.radioBtnDay.AutoSize = true;
            this.radioBtnDay.Location = new System.Drawing.Point(288, 57);
            this.radioBtnDay.Name = "radioBtnDay";
            this.radioBtnDay.Size = new System.Drawing.Size(46, 19);
            this.radioBtnDay.TabIndex = 35;
            this.radioBtnDay.Text = "Day";
            this.radioBtnDay.UseVisualStyleBackColor = true;
            // 
            // chkApplicationPathForFiles
            // 
            this.chkApplicationPathForFiles.AutoSize = true;
            this.chkApplicationPathForFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApplicationPathForFiles.Checked = true;
            this.chkApplicationPathForFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApplicationPathForFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApplicationPathForFiles.ForeColor = System.Drawing.Color.Red;
            this.chkApplicationPathForFiles.Location = new System.Drawing.Point(72, 2);
            this.chkApplicationPathForFiles.Name = "chkApplicationPathForFiles";
            this.chkApplicationPathForFiles.Size = new System.Drawing.Size(131, 20);
            this.chkApplicationPathForFiles.TabIndex = 36;
            this.chkApplicationPathForFiles.Text = "App. Root Path";
            this.chkApplicationPathForFiles.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDuplicate);
            this.panel1.Controls.Add(this.chkReverse);
            this.panel1.Controls.Add(this.chkStemming);
            this.panel1.Controls.Add(this.chkDHGWriter);
            this.panel1.Location = new System.Drawing.Point(76, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 82);
            this.panel1.TabIndex = 37;
            // 
            // frmDataProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkApplicationPathForFiles);
            this.Controls.Add(this.radioBtnDay);
            this.Controls.Add(this.radioBtnHour);
            this.Controls.Add(this.radioBtnMin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkWeightedNode);
            this.Controls.Add(this.chkCleanedData);
            this.Controls.Add(this.txtDuplicateTweetIndexFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkWeightedEdge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericWordLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTweetMatchingCriteria);
            this.Controls.Add(this.chkUserFlag);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEdgeWeightCriteria);
            this.Controls.Add(this.btnDataParser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatusMsg);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMeasure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericExpiryTime);
            this.Controls.Add(this.txtDataSetFilePath);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnProcess);
            this.Name = "frmDataProcessor";
            this.Text = "Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericExpiryTime)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericWordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TextBox txtDataSetFilePath;
        private System.Windows.Forms.NumericUpDown numericExpiryTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMeasure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtFiltrationWords;
        private System.Windows.Forms.Label lblStatusMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer ProgressTimer;
        private System.Windows.Forms.Button btnDataParser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEdgeWeightCriteria;
        private System.Windows.Forms.CheckBox chkUserFlag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTweetMatchingCriteria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericWordLength;
        private System.Windows.Forms.CheckBox chkWeightedEdge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chkDuplicate;
        private System.Windows.Forms.TextBox txtDuplicateTweetIndexFile;
        private System.Windows.Forms.CheckBox chkReverse;
        private System.Windows.Forms.CheckBox chkCleanedData;
        private System.Windows.Forms.CheckBox chkStemming;
        private System.Windows.Forms.CheckBox chkDHGWriter;
        private System.Windows.Forms.CheckBox chkWeightedNode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioBtnMin;
        private System.Windows.Forms.RadioButton radioBtnHour;
        private System.Windows.Forms.RadioButton radioBtnDay;
        private System.Windows.Forms.CheckBox chkApplicationPathForFiles;
        private System.Windows.Forms.Panel panel1;
    }
}

