namespace EveSense
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.pnlAppIcon = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblGroundTruth = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.txtResultFileName = new System.Windows.Forms.TextBox();
            this.lblSlidingWindows = new System.Windows.Forms.Label();
            this.lblSlidingWindowFeatures = new System.Windows.Forms.Label();
            this.lblDegreeCentrality = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadSlidingWindows = new System.Windows.Forms.Button();
            this.btnLoadSlidingWindowFeatures = new System.Windows.Forms.Button();
            this.btnLoadDegreeCentrality = new System.Windows.Forms.Button();
            this.btnLoadGroundTruth = new System.Windows.Forms.Button();
            this.chkRankDC = new System.Windows.Forms.CheckBox();
            this.chkRankDTF = new System.Windows.Forms.CheckBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlWordCloud = new System.Windows.Forms.Panel();
            this.myCloudControl = new Gma.CodeCloud.Controls.CloudControl();
            this.rTxtResults = new System.Windows.Forms.RichTextBox();
            this.pnlWindowsAndSearching = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.cmbSelectWindow = new System.Windows.Forms.ComboBox();
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlChartOptions = new System.Windows.Forms.Panel();
            this.btnRefereshGraph = new System.Windows.Forms.Button();
            this.grpGraphSettings = new System.Windows.Forms.GroupBox();
            this.pnlHeartbeatNormalRange = new System.Windows.Forms.Panel();
            this.numUpDownHeartbeatTo = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numUpDownHeartbeatFrom = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.chkNormalizeHeartbeat = new System.Windows.Forms.CheckBox();
            this.pnlSelectDataRange = new System.Windows.Forms.Panel();
            this.cmbDataTo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDataFrom = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlGraphSettings = new System.Windows.Forms.Panel();
            this.chkDataRange = new System.Windows.Forms.CheckBox();
            this.chkGridLinesY = new System.Windows.Forms.CheckBox();
            this.chkGridLinesX = new System.Windows.Forms.CheckBox();
            this.chkDataValues = new System.Windows.Forms.CheckBox();
            this.pnlRankingCriteria = new System.Windows.Forms.Panel();
            this.cmbMergeDHGs = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.numUpDwnDC = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numUpDwnDTF = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbRanking = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlFeatureSet = new System.Windows.Forms.Panel();
            this.numUpDwnAC = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numUpDwnTP = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpDwnGF = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFeatureSetSeparator = new System.Windows.Forms.Panel();
            this.cmbFeatureSet = new System.Windows.Forms.ComboBox();
            this.chkAC = new System.Windows.Forms.CheckBox();
            this.chkTP = new System.Windows.Forms.CheckBox();
            this.chkGF = new System.Windows.Forms.CheckBox();
            this.cmbCandidateSelection = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlConfigurationMenu = new System.Windows.Forms.Panel();
            this.pnlEvaluationParam = new System.Windows.Forms.Panel();
            this.pnlLoadFiles = new System.Windows.Forms.Panel();
            this.pnlPerformanceEvaluation = new System.Windows.Forms.Panel();
            this.pnlLoadFileIcon = new System.Windows.Forms.Panel();
            this.picBoxDC = new System.Windows.Forms.PictureBox();
            this.picBoxWF = new System.Windows.Forms.PictureBox();
            this.picBoxSW = new System.Windows.Forms.PictureBox();
            this.picBoxGT = new System.Windows.Forms.PictureBox();
            this.pnlProgressBar = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cmbCaseStudy = new System.Windows.Forms.ComboBox();
            this.chkPerformanceEvaluator = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.numUpDownTopBoW = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numDownParameter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlLoad.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.pnlWordCloud.SuspendLayout();
            this.pnlWindowsAndSearching.SuspendLayout();
            this.pnlGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlChartOptions.SuspendLayout();
            this.grpGraphSettings.SuspendLayout();
            this.pnlHeartbeatNormalRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeartbeatTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeartbeatFrom)).BeginInit();
            this.pnlSelectDataRange.SuspendLayout();
            this.pnlGraphSettings.SuspendLayout();
            this.pnlRankingCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDTF)).BeginInit();
            this.pnlFeatureSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGF)).BeginInit();
            this.pnlConfigurationMenu.SuspendLayout();
            this.pnlEvaluationParam.SuspendLayout();
            this.pnlLoadFiles.SuspendLayout();
            this.pnlPerformanceEvaluation.SuspendLayout();
            this.pnlLoadFileIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGT)).BeginInit();
            this.pnlProgressBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTopBoW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoad
            // 
            this.pnlLoad.Controls.Add(this.pnlAppIcon);
            this.pnlLoad.Controls.Add(this.button1);
            this.pnlLoad.Controls.Add(this.lblGroundTruth);
            this.pnlLoad.Controls.Add(this.lblData);
            this.pnlLoad.Controls.Add(this.lblStatusMessage);
            this.pnlLoad.Controls.Add(this.txtResultFileName);
            this.pnlLoad.Controls.Add(this.lblSlidingWindows);
            this.pnlLoad.Controls.Add(this.lblSlidingWindowFeatures);
            this.pnlLoad.Controls.Add(this.lblDegreeCentrality);
            this.pnlLoad.Controls.Add(this.panel2);
            this.pnlLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLoad.Location = new System.Drawing.Point(0, 0);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(1204, 45);
            this.pnlLoad.TabIndex = 5;
            // 
            // pnlAppIcon
            // 
            this.pnlAppIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAppIcon.BackgroundImage")));
            this.pnlAppIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAppIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAppIcon.Location = new System.Drawing.Point(840, 0);
            this.pnlAppIcon.Name = "pnlAppIcon";
            this.pnlAppIcon.Size = new System.Drawing.Size(46, 45);
            this.pnlAppIcon.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1068, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 22);
            this.button1.TabIndex = 28;
            this.button1.Text = "Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // lblGroundTruth
            // 
            this.lblGroundTruth.AutoSize = true;
            this.lblGroundTruth.Location = new System.Drawing.Point(853, 0);
            this.lblGroundTruth.Name = "lblGroundTruth";
            this.lblGroundTruth.Size = new System.Drawing.Size(37, 15);
            this.lblGroundTruth.TabIndex = 6;
            this.lblGroundTruth.Text = "paths";
            this.lblGroundTruth.Visible = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(1025, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(37, 15);
            this.lblData.TabIndex = 26;
            this.lblData.Text = "paths";
            this.lblData.Visible = false;
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Calibri", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(955, 13);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(122, 19);
            this.lblStatusMessage.TabIndex = 0;
            this.lblStatusMessage.Text = "Status Message: ";
            this.lblStatusMessage.Visible = false;
            // 
            // txtResultFileName
            // 
            this.txtResultFileName.Location = new System.Drawing.Point(598, 3);
            this.txtResultFileName.Name = "txtResultFileName";
            this.txtResultFileName.Size = new System.Drawing.Size(249, 20);
            this.txtResultFileName.TabIndex = 8;
            this.txtResultFileName.Text = "Test_";
            this.txtResultFileName.Visible = false;
            // 
            // lblSlidingWindows
            // 
            this.lblSlidingWindows.AutoSize = true;
            this.lblSlidingWindows.Location = new System.Drawing.Point(896, 0);
            this.lblSlidingWindows.Name = "lblSlidingWindows";
            this.lblSlidingWindows.Size = new System.Drawing.Size(37, 15);
            this.lblSlidingWindows.TabIndex = 9;
            this.lblSlidingWindows.Text = "paths";
            this.lblSlidingWindows.Visible = false;
            // 
            // lblSlidingWindowFeatures
            // 
            this.lblSlidingWindowFeatures.AutoSize = true;
            this.lblSlidingWindowFeatures.Location = new System.Drawing.Point(939, -2);
            this.lblSlidingWindowFeatures.Name = "lblSlidingWindowFeatures";
            this.lblSlidingWindowFeatures.Size = new System.Drawing.Size(37, 15);
            this.lblSlidingWindowFeatures.TabIndex = 8;
            this.lblSlidingWindowFeatures.Text = "paths";
            this.lblSlidingWindowFeatures.Visible = false;
            // 
            // lblDegreeCentrality
            // 
            this.lblDegreeCentrality.AutoSize = true;
            this.lblDegreeCentrality.Location = new System.Drawing.Point(982, -2);
            this.lblDegreeCentrality.Name = "lblDegreeCentrality";
            this.lblDegreeCentrality.Size = new System.Drawing.Size(37, 15);
            this.lblDegreeCentrality.TabIndex = 7;
            this.lblDegreeCentrality.Text = "paths";
            this.lblDegreeCentrality.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(886, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 45);
            this.panel2.TabIndex = 30;
            // 
            // btnLoadSlidingWindows
            // 
            this.btnLoadSlidingWindows.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadSlidingWindows.Location = new System.Drawing.Point(0, 22);
            this.btnLoadSlidingWindows.Name = "btnLoadSlidingWindows";
            this.btnLoadSlidingWindows.Size = new System.Drawing.Size(172, 22);
            this.btnLoadSlidingWindows.TabIndex = 2;
            this.btnLoadSlidingWindows.Text = "Sliding Windows";
            this.btnLoadSlidingWindows.UseVisualStyleBackColor = true;
            // 
            // btnLoadSlidingWindowFeatures
            // 
            this.btnLoadSlidingWindowFeatures.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadSlidingWindowFeatures.Location = new System.Drawing.Point(0, 44);
            this.btnLoadSlidingWindowFeatures.Name = "btnLoadSlidingWindowFeatures";
            this.btnLoadSlidingWindowFeatures.Size = new System.Drawing.Size(172, 22);
            this.btnLoadSlidingWindowFeatures.TabIndex = 3;
            this.btnLoadSlidingWindowFeatures.Text = "Windows Features";
            this.btnLoadSlidingWindowFeatures.UseVisualStyleBackColor = true;
            // 
            // btnLoadDegreeCentrality
            // 
            this.btnLoadDegreeCentrality.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadDegreeCentrality.Location = new System.Drawing.Point(0, 66);
            this.btnLoadDegreeCentrality.Name = "btnLoadDegreeCentrality";
            this.btnLoadDegreeCentrality.Size = new System.Drawing.Size(172, 22);
            this.btnLoadDegreeCentrality.TabIndex = 4;
            this.btnLoadDegreeCentrality.Text = "Load Raw Results";
            this.btnLoadDegreeCentrality.UseVisualStyleBackColor = true;
            // 
            // btnLoadGroundTruth
            // 
            this.btnLoadGroundTruth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadGroundTruth.Location = new System.Drawing.Point(0, 0);
            this.btnLoadGroundTruth.Name = "btnLoadGroundTruth";
            this.btnLoadGroundTruth.Size = new System.Drawing.Size(172, 22);
            this.btnLoadGroundTruth.TabIndex = 5;
            this.btnLoadGroundTruth.Text = "Ground Truth";
            this.btnLoadGroundTruth.UseVisualStyleBackColor = true;
            // 
            // chkRankDC
            // 
            this.chkRankDC.AutoSize = true;
            this.chkRankDC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRankDC.Checked = true;
            this.chkRankDC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRankDC.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRankDC.Location = new System.Drawing.Point(0, 39);
            this.chkRankDC.Name = "chkRankDC";
            this.chkRankDC.Size = new System.Drawing.Size(198, 19);
            this.chkRankDC.TabIndex = 16;
            this.chkRankDC.Text = "Rank with Degree Centrality";
            this.chkRankDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRankDC.UseVisualStyleBackColor = true;
            // 
            // chkRankDTF
            // 
            this.chkRankDTF.AutoSize = true;
            this.chkRankDTF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRankDTF.Checked = true;
            this.chkRankDTF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRankDTF.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRankDTF.Location = new System.Drawing.Point(0, 20);
            this.chkRankDTF.Name = "chkRankDTF";
            this.chkRankDTF.Size = new System.Drawing.Size(198, 19);
            this.chkRankDTF.TabIndex = 15;
            this.chkRankDTF.Text = "Rank with DTF";
            this.chkRankDTF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRankDTF.UseVisualStyleBackColor = true;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.pnlWordCloud);
            this.pnlData.Controls.Add(this.rTxtResults);
            this.pnlData.Controls.Add(this.pnlWindowsAndSearching);
            this.pnlData.Controls.Add(this.pnlGraph);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(200, 45);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1004, 703);
            this.pnlData.TabIndex = 6;
            // 
            // pnlWordCloud
            // 
            this.pnlWordCloud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlWordCloud.BackgroundImage")));
            this.pnlWordCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWordCloud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWordCloud.Controls.Add(this.myCloudControl);
            this.pnlWordCloud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWordCloud.Location = new System.Drawing.Point(0, 329);
            this.pnlWordCloud.Name = "pnlWordCloud";
            this.pnlWordCloud.Size = new System.Drawing.Size(398, 374);
            this.pnlWordCloud.TabIndex = 2;
            // 
            // myCloudControl
            // 
            this.myCloudControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myCloudControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myCloudControl.LayoutType = Gma.CodeCloud.Controls.LayoutType.Spiral;
            this.myCloudControl.Location = new System.Drawing.Point(0, 0);
            this.myCloudControl.MaxFontSize = 68;
            this.myCloudControl.MinFontSize = 6;
            this.myCloudControl.Name = "myCloudControl";
            this.myCloudControl.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.Navy,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
            this.myCloudControl.Size = new System.Drawing.Size(396, 372);
            this.myCloudControl.TabIndex = 0;
            this.myCloudControl.WeightedWords = null;
            this.myCloudControl.Click += new System.EventHandler(this.myCloudControl_Click);
            // 
            // rTxtResults
            // 
            this.rTxtResults.BackColor = System.Drawing.Color.White;
            this.rTxtResults.Dock = System.Windows.Forms.DockStyle.Right;
            this.rTxtResults.Location = new System.Drawing.Point(398, 329);
            this.rTxtResults.Name = "rTxtResults";
            this.rTxtResults.Size = new System.Drawing.Size(606, 374);
            this.rTxtResults.TabIndex = 9;
            this.rTxtResults.Text = resources.GetString("rTxtResults.Text");
            this.rTxtResults.WordWrap = false;
            // 
            // pnlWindowsAndSearching
            // 
            this.pnlWindowsAndSearching.Controls.Add(this.txtSearch);
            this.pnlWindowsAndSearching.Controls.Add(this.btnSearch);
            this.pnlWindowsAndSearching.Controls.Add(this.btnClearSearch);
            this.pnlWindowsAndSearching.Controls.Add(this.cmbSelectWindow);
            this.pnlWindowsAndSearching.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWindowsAndSearching.Location = new System.Drawing.Point(0, 306);
            this.pnlWindowsAndSearching.Name = "pnlWindowsAndSearching";
            this.pnlWindowsAndSearching.Size = new System.Drawing.Size(1004, 23);
            this.pnlWindowsAndSearching.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(646, 26);
            this.txtSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(646, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearSearch.Location = new System.Drawing.Point(711, 0);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(45, 23);
            this.btnClearSearch.TabIndex = 25;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // cmbSelectWindow
            // 
            this.cmbSelectWindow.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbSelectWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectWindow.FormattingEnabled = true;
            this.cmbSelectWindow.Location = new System.Drawing.Point(756, 0);
            this.cmbSelectWindow.Name = "cmbSelectWindow";
            this.cmbSelectWindow.Size = new System.Drawing.Size(248, 21);
            this.cmbSelectWindow.TabIndex = 24;
            this.cmbSelectWindow.SelectedIndexChanged += new System.EventHandler(this.cmbSelectWindow_SelectedIndexChanged);
            // 
            // pnlGraph
            // 
            this.pnlGraph.BackgroundImage = global::EveSense.Properties.Resources.SuperTuesday_updated;
            this.pnlGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGraph.Controls.Add(this.chart1);
            this.pnlGraph.Controls.Add(this.pnlChartOptions);
            this.pnlGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGraph.Location = new System.Drawing.Point(0, 0);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(1004, 306);
            this.pnlGraph.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(154, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.ShadowOffset = 3;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(848, 304);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlChartOptions
            // 
            this.pnlChartOptions.BackColor = System.Drawing.Color.White;
            this.pnlChartOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartOptions.Controls.Add(this.btnRefereshGraph);
            this.pnlChartOptions.Controls.Add(this.grpGraphSettings);
            this.pnlChartOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChartOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlChartOptions.Name = "pnlChartOptions";
            this.pnlChartOptions.Size = new System.Drawing.Size(154, 304);
            this.pnlChartOptions.TabIndex = 1;
            this.pnlChartOptions.Visible = false;
            // 
            // btnRefereshGraph
            // 
            this.btnRefereshGraph.BackColor = System.Drawing.Color.Lime;
            this.btnRefereshGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefereshGraph.Location = new System.Drawing.Point(0, 274);
            this.btnRefereshGraph.Name = "btnRefereshGraph";
            this.btnRefereshGraph.Size = new System.Drawing.Size(152, 25);
            this.btnRefereshGraph.TabIndex = 2;
            this.btnRefereshGraph.Text = "Refresh Graph";
            this.btnRefereshGraph.UseVisualStyleBackColor = false;
            this.btnRefereshGraph.Click += new System.EventHandler(this.button2_Click);
            // 
            // grpGraphSettings
            // 
            this.grpGraphSettings.Controls.Add(this.pnlHeartbeatNormalRange);
            this.grpGraphSettings.Controls.Add(this.chkNormalizeHeartbeat);
            this.grpGraphSettings.Controls.Add(this.pnlSelectDataRange);
            this.grpGraphSettings.Controls.Add(this.pnlGraphSettings);
            this.grpGraphSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGraphSettings.Location = new System.Drawing.Point(0, 0);
            this.grpGraphSettings.Name = "grpGraphSettings";
            this.grpGraphSettings.Size = new System.Drawing.Size(152, 274);
            this.grpGraphSettings.TabIndex = 0;
            this.grpGraphSettings.TabStop = false;
            this.grpGraphSettings.Text = "Graph Settings";
            // 
            // pnlHeartbeatNormalRange
            // 
            this.pnlHeartbeatNormalRange.Controls.Add(this.numUpDownHeartbeatTo);
            this.pnlHeartbeatNormalRange.Controls.Add(this.label13);
            this.pnlHeartbeatNormalRange.Controls.Add(this.numUpDownHeartbeatFrom);
            this.pnlHeartbeatNormalRange.Controls.Add(this.label14);
            this.pnlHeartbeatNormalRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeartbeatNormalRange.Location = new System.Drawing.Point(3, 191);
            this.pnlHeartbeatNormalRange.Name = "pnlHeartbeatNormalRange";
            this.pnlHeartbeatNormalRange.Size = new System.Drawing.Size(146, 75);
            this.pnlHeartbeatNormalRange.TabIndex = 22;
            this.pnlHeartbeatNormalRange.Visible = false;
            // 
            // numUpDownHeartbeatTo
            // 
            this.numUpDownHeartbeatTo.DecimalPlaces = 2;
            this.numUpDownHeartbeatTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDownHeartbeatTo.Location = new System.Drawing.Point(0, 50);
            this.numUpDownHeartbeatTo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownHeartbeatTo.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownHeartbeatTo.Name = "numUpDownHeartbeatTo";
            this.numUpDownHeartbeatTo.Size = new System.Drawing.Size(146, 20);
            this.numUpDownHeartbeatTo.TabIndex = 17;
            this.numUpDownHeartbeatTo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(0, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "Max:";
            // 
            // numUpDownHeartbeatFrom
            // 
            this.numUpDownHeartbeatFrom.DecimalPlaces = 2;
            this.numUpDownHeartbeatFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDownHeartbeatFrom.Location = new System.Drawing.Point(0, 15);
            this.numUpDownHeartbeatFrom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownHeartbeatFrom.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numUpDownHeartbeatFrom.Name = "numUpDownHeartbeatFrom";
            this.numUpDownHeartbeatFrom.Size = new System.Drawing.Size(146, 20);
            this.numUpDownHeartbeatFrom.TabIndex = 16;
            this.numUpDownHeartbeatFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Min:";
            // 
            // chkNormalizeHeartbeat
            // 
            this.chkNormalizeHeartbeat.AutoSize = true;
            this.chkNormalizeHeartbeat.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNormalizeHeartbeat.Location = new System.Drawing.Point(3, 172);
            this.chkNormalizeHeartbeat.Name = "chkNormalizeHeartbeat";
            this.chkNormalizeHeartbeat.Size = new System.Drawing.Size(146, 19);
            this.chkNormalizeHeartbeat.TabIndex = 21;
            this.chkNormalizeHeartbeat.Text = "Scale Heartbeat";
            this.chkNormalizeHeartbeat.UseVisualStyleBackColor = true;
            // 
            // pnlSelectDataRange
            // 
            this.pnlSelectDataRange.Controls.Add(this.cmbDataTo);
            this.pnlSelectDataRange.Controls.Add(this.label12);
            this.pnlSelectDataRange.Controls.Add(this.cmbDataFrom);
            this.pnlSelectDataRange.Controls.Add(this.label11);
            this.pnlSelectDataRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectDataRange.Location = new System.Drawing.Point(3, 94);
            this.pnlSelectDataRange.Name = "pnlSelectDataRange";
            this.pnlSelectDataRange.Size = new System.Drawing.Size(146, 78);
            this.pnlSelectDataRange.TabIndex = 18;
            this.pnlSelectDataRange.Visible = false;
            // 
            // cmbDataTo
            // 
            this.cmbDataTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbDataTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDataTo.FormattingEnabled = true;
            this.cmbDataTo.Location = new System.Drawing.Point(0, 51);
            this.cmbDataTo.Name = "cmbDataTo";
            this.cmbDataTo.Size = new System.Drawing.Size(146, 21);
            this.cmbDataTo.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "To:";
            // 
            // cmbDataFrom
            // 
            this.cmbDataFrom.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbDataFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataFrom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDataFrom.FormattingEnabled = true;
            this.cmbDataFrom.Location = new System.Drawing.Point(0, 15);
            this.cmbDataFrom.Name = "cmbDataFrom";
            this.cmbDataFrom.Size = new System.Drawing.Size(146, 21);
            this.cmbDataFrom.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "From:";
            // 
            // pnlGraphSettings
            // 
            this.pnlGraphSettings.Controls.Add(this.chkDataRange);
            this.pnlGraphSettings.Controls.Add(this.chkGridLinesY);
            this.pnlGraphSettings.Controls.Add(this.chkGridLinesX);
            this.pnlGraphSettings.Controls.Add(this.chkDataValues);
            this.pnlGraphSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGraphSettings.Location = new System.Drawing.Point(3, 16);
            this.pnlGraphSettings.Name = "pnlGraphSettings";
            this.pnlGraphSettings.Size = new System.Drawing.Size(146, 78);
            this.pnlGraphSettings.TabIndex = 20;
            // 
            // chkDataRange
            // 
            this.chkDataRange.AutoSize = true;
            this.chkDataRange.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDataRange.Location = new System.Drawing.Point(0, 57);
            this.chkDataRange.Name = "chkDataRange";
            this.chkDataRange.Size = new System.Drawing.Size(146, 19);
            this.chkDataRange.TabIndex = 19;
            this.chkDataRange.Text = "Select Data Range";
            this.chkDataRange.UseVisualStyleBackColor = true;
            // 
            // chkGridLinesY
            // 
            this.chkGridLinesY.AutoSize = true;
            this.chkGridLinesY.Checked = true;
            this.chkGridLinesY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGridLinesY.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkGridLinesY.Location = new System.Drawing.Point(0, 38);
            this.chkGridLinesY.Name = "chkGridLinesY";
            this.chkGridLinesY.Size = new System.Drawing.Size(146, 19);
            this.chkGridLinesY.TabIndex = 15;
            this.chkGridLinesY.Text = "Show Y-axis Gridlines";
            this.chkGridLinesY.UseVisualStyleBackColor = true;
            // 
            // chkGridLinesX
            // 
            this.chkGridLinesX.AutoSize = true;
            this.chkGridLinesX.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkGridLinesX.Location = new System.Drawing.Point(0, 19);
            this.chkGridLinesX.Name = "chkGridLinesX";
            this.chkGridLinesX.Size = new System.Drawing.Size(146, 19);
            this.chkGridLinesX.TabIndex = 17;
            this.chkGridLinesX.Text = "Show X-axis Gridlines";
            this.chkGridLinesX.UseVisualStyleBackColor = true;
            // 
            // chkDataValues
            // 
            this.chkDataValues.AutoSize = true;
            this.chkDataValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDataValues.Location = new System.Drawing.Point(0, 0);
            this.chkDataValues.Name = "chkDataValues";
            this.chkDataValues.Size = new System.Drawing.Size(146, 19);
            this.chkDataValues.TabIndex = 16;
            this.chkDataValues.Text = "Show Data Values";
            this.chkDataValues.UseVisualStyleBackColor = true;
            // 
            // pnlRankingCriteria
            // 
            this.pnlRankingCriteria.Controls.Add(this.cmbMergeDHGs);
            this.pnlRankingCriteria.Controls.Add(this.panel8);
            this.pnlRankingCriteria.Controls.Add(this.numUpDwnDC);
            this.pnlRankingCriteria.Controls.Add(this.label6);
            this.pnlRankingCriteria.Controls.Add(this.numUpDwnDTF);
            this.pnlRankingCriteria.Controls.Add(this.label7);
            this.pnlRankingCriteria.Controls.Add(this.panel7);
            this.pnlRankingCriteria.Controls.Add(this.cmbRanking);
            this.pnlRankingCriteria.Controls.Add(this.chkRankDC);
            this.pnlRankingCriteria.Controls.Add(this.chkRankDTF);
            this.pnlRankingCriteria.Controls.Add(this.label8);
            this.pnlRankingCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRankingCriteria.Location = new System.Drawing.Point(0, 230);
            this.pnlRankingCriteria.Name = "pnlRankingCriteria";
            this.pnlRankingCriteria.Size = new System.Drawing.Size(198, 184);
            this.pnlRankingCriteria.TabIndex = 14;
            // 
            // cmbMergeDHGs
            // 
            this.cmbMergeDHGs.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbMergeDHGs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMergeDHGs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMergeDHGs.FormattingEnabled = true;
            this.cmbMergeDHGs.Items.AddRange(new object[] {
            "Remove Duplicates",
            "Combine Duplicate Score",
            "Average Duplicate Score"});
            this.cmbMergeDHGs.Location = new System.Drawing.Point(0, 159);
            this.cmbMergeDHGs.Name = "cmbMergeDHGs";
            this.cmbMergeDHGs.Size = new System.Drawing.Size(198, 21);
            this.cmbMergeDHGs.TabIndex = 25;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Silver;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 154);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(198, 5);
            this.panel8.TabIndex = 24;
            // 
            // numUpDwnDC
            // 
            this.numUpDwnDC.DecimalPlaces = 2;
            this.numUpDwnDC.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDwnDC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDwnDC.Location = new System.Drawing.Point(0, 134);
            this.numUpDwnDC.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnDC.Name = "numUpDwnDC";
            this.numUpDwnDC.Size = new System.Drawing.Size(198, 20);
            this.numUpDwnDC.TabIndex = 22;
            this.numUpDwnDC.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Degree Centrality Coeff.";
            // 
            // numUpDwnDTF
            // 
            this.numUpDwnDTF.DecimalPlaces = 2;
            this.numUpDwnDTF.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDwnDTF.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDwnDTF.Location = new System.Drawing.Point(0, 99);
            this.numUpDwnDTF.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnDTF.Name = "numUpDwnDTF";
            this.numUpDwnDTF.Size = new System.Drawing.Size(198, 20);
            this.numUpDwnDTF.TabIndex = 19;
            this.numUpDwnDTF.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Displaced Temp. Freq. Coeff.";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 79);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 5);
            this.panel7.TabIndex = 20;
            // 
            // cmbRanking
            // 
            this.cmbRanking.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbRanking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRanking.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbRanking.FormattingEnabled = true;
            this.cmbRanking.Items.AddRange(new object[] {
            "Fused Ranking",
            "Linearly Combined"});
            this.cmbRanking.Location = new System.Drawing.Point(0, 58);
            this.cmbRanking.Name = "cmbRanking";
            this.cmbRanking.Size = new System.Drawing.Size(198, 21);
            this.cmbRanking.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "▼ ------ Ranking ------ ▼ ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFeatureSet
            // 
            this.pnlFeatureSet.Controls.Add(this.numUpDwnAC);
            this.pnlFeatureSet.Controls.Add(this.label5);
            this.pnlFeatureSet.Controls.Add(this.numUpDwnTP);
            this.pnlFeatureSet.Controls.Add(this.label4);
            this.pnlFeatureSet.Controls.Add(this.numUpDwnGF);
            this.pnlFeatureSet.Controls.Add(this.label3);
            this.pnlFeatureSet.Controls.Add(this.pnlFeatureSetSeparator);
            this.pnlFeatureSet.Controls.Add(this.cmbFeatureSet);
            this.pnlFeatureSet.Controls.Add(this.chkAC);
            this.pnlFeatureSet.Controls.Add(this.chkTP);
            this.pnlFeatureSet.Controls.Add(this.chkGF);
            this.pnlFeatureSet.Controls.Add(this.cmbCandidateSelection);
            this.pnlFeatureSet.Controls.Add(this.label9);
            this.pnlFeatureSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFeatureSet.Location = new System.Drawing.Point(0, 0);
            this.pnlFeatureSet.Name = "pnlFeatureSet";
            this.pnlFeatureSet.Size = new System.Drawing.Size(198, 230);
            this.pnlFeatureSet.TabIndex = 10;
            // 
            // numUpDwnAC
            // 
            this.numUpDwnAC.DecimalPlaces = 2;
            this.numUpDwnAC.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDwnAC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDwnAC.Location = new System.Drawing.Point(0, 209);
            this.numUpDwnAC.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnAC.Name = "numUpDwnAC";
            this.numUpDwnAC.Size = new System.Drawing.Size(198, 20);
            this.numUpDwnAC.TabIndex = 19;
            this.numUpDwnAC.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Aggreg. Centrality Coeff.";
            // 
            // numUpDwnTP
            // 
            this.numUpDwnTP.DecimalPlaces = 2;
            this.numUpDwnTP.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDwnTP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDwnTP.Location = new System.Drawing.Point(0, 174);
            this.numUpDwnTP.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnTP.Name = "numUpDwnTP";
            this.numUpDwnTP.Size = new System.Drawing.Size(198, 20);
            this.numUpDwnTP.TabIndex = 17;
            this.numUpDwnTP.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Trend Prob. Coeff.";
            // 
            // numUpDwnGF
            // 
            this.numUpDwnGF.DecimalPlaces = 2;
            this.numUpDwnGF.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDwnGF.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDwnGF.Location = new System.Drawing.Point(0, 139);
            this.numUpDwnGF.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnGF.Name = "numUpDwnGF";
            this.numUpDwnGF.Size = new System.Drawing.Size(198, 20);
            this.numUpDwnGF.TabIndex = 14;
            this.numUpDwnGF.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Growth Factor Coeff.";
            // 
            // pnlFeatureSetSeparator
            // 
            this.pnlFeatureSetSeparator.BackColor = System.Drawing.Color.Silver;
            this.pnlFeatureSetSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFeatureSetSeparator.Location = new System.Drawing.Point(0, 119);
            this.pnlFeatureSetSeparator.Name = "pnlFeatureSetSeparator";
            this.pnlFeatureSetSeparator.Size = new System.Drawing.Size(198, 5);
            this.pnlFeatureSetSeparator.TabIndex = 15;
            // 
            // cmbFeatureSet
            // 
            this.cmbFeatureSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbFeatureSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeatureSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbFeatureSet.FormattingEnabled = true;
            this.cmbFeatureSet.Items.AddRange(new object[] {
            "Fuse Features",
            "Linearly Combined"});
            this.cmbFeatureSet.Location = new System.Drawing.Point(0, 98);
            this.cmbFeatureSet.Name = "cmbFeatureSet";
            this.cmbFeatureSet.Size = new System.Drawing.Size(198, 21);
            this.cmbFeatureSet.TabIndex = 13;
            // 
            // chkAC
            // 
            this.chkAC.AutoSize = true;
            this.chkAC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAC.Checked = true;
            this.chkAC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAC.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAC.Location = new System.Drawing.Point(0, 79);
            this.chkAC.Name = "chkAC";
            this.chkAC.Size = new System.Drawing.Size(198, 19);
            this.chkAC.TabIndex = 12;
            this.chkAC.Text = "Degree Centrality";
            this.chkAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAC.UseVisualStyleBackColor = true;
            this.chkAC.CheckedChanged += new System.EventHandler(this.FeatureSetCheckBoxes_CheckedChanged);
            // 
            // chkTP
            // 
            this.chkTP.AutoSize = true;
            this.chkTP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTP.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkTP.Location = new System.Drawing.Point(0, 60);
            this.chkTP.Name = "chkTP";
            this.chkTP.Size = new System.Drawing.Size(198, 19);
            this.chkTP.TabIndex = 11;
            this.chkTP.Text = "Trend Probablity";
            this.chkTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTP.UseVisualStyleBackColor = true;
            this.chkTP.CheckedChanged += new System.EventHandler(this.FeatureSetCheckBoxes_CheckedChanged);
            // 
            // chkGF
            // 
            this.chkGF.AutoSize = true;
            this.chkGF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGF.Checked = true;
            this.chkGF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGF.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkGF.Location = new System.Drawing.Point(0, 41);
            this.chkGF.Name = "chkGF";
            this.chkGF.Size = new System.Drawing.Size(198, 19);
            this.chkGF.TabIndex = 10;
            this.chkGF.Text = "Growth Factor";
            this.chkGF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGF.UseVisualStyleBackColor = true;
            this.chkGF.CheckedChanged += new System.EventHandler(this.FeatureSetCheckBoxes_CheckedChanged);
            // 
            // cmbCandidateSelection
            // 
            this.cmbCandidateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCandidateSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCandidateSelection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCandidateSelection.FormattingEnabled = true;
            this.cmbCandidateSelection.Items.AddRange(new object[] {
            "HEARTBEAT",
            "FEATURES-BASED UNION",
            "SELECT ALL"});
            this.cmbCandidateSelection.Location = new System.Drawing.Point(0, 20);
            this.cmbCandidateSelection.Name = "cmbCandidateSelection";
            this.cmbCandidateSelection.Size = new System.Drawing.Size(198, 21);
            this.cmbCandidateSelection.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "▼ ----- Features ----- ▼  ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.Lime;
            this.btnProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProcess.Location = new System.Drawing.Point(0, 128);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(198, 25);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlConfigurationMenu
            // 
            this.pnlConfigurationMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfigurationMenu.Controls.Add(this.pnlEvaluationParam);
            this.pnlConfigurationMenu.Controls.Add(this.pnlRankingCriteria);
            this.pnlConfigurationMenu.Controls.Add(this.pnlFeatureSet);
            this.pnlConfigurationMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConfigurationMenu.Location = new System.Drawing.Point(0, 45);
            this.pnlConfigurationMenu.Name = "pnlConfigurationMenu";
            this.pnlConfigurationMenu.Size = new System.Drawing.Size(200, 703);
            this.pnlConfigurationMenu.TabIndex = 8;
            // 
            // pnlEvaluationParam
            // 
            this.pnlEvaluationParam.Controls.Add(this.pnlLoadFiles);
            this.pnlEvaluationParam.Controls.Add(this.panel1);
            this.pnlEvaluationParam.Controls.Add(this.label10);
            this.pnlEvaluationParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvaluationParam.Location = new System.Drawing.Point(0, 414);
            this.pnlEvaluationParam.Name = "pnlEvaluationParam";
            this.pnlEvaluationParam.Size = new System.Drawing.Size(198, 287);
            this.pnlEvaluationParam.TabIndex = 29;
            // 
            // pnlLoadFiles
            // 
            this.pnlLoadFiles.Controls.Add(this.btnProcess);
            this.pnlLoadFiles.Controls.Add(this.pnlPerformanceEvaluation);
            this.pnlLoadFiles.Controls.Add(this.pnlProgressBar);
            this.pnlLoadFiles.Controls.Add(this.cmbCaseStudy);
            this.pnlLoadFiles.Controls.Add(this.chkPerformanceEvaluator);
            this.pnlLoadFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoadFiles.Location = new System.Drawing.Point(0, 95);
            this.pnlLoadFiles.Name = "pnlLoadFiles";
            this.pnlLoadFiles.Size = new System.Drawing.Size(198, 192);
            this.pnlLoadFiles.TabIndex = 26;
            // 
            // pnlPerformanceEvaluation
            // 
            this.pnlPerformanceEvaluation.Controls.Add(this.btnLoadDegreeCentrality);
            this.pnlPerformanceEvaluation.Controls.Add(this.btnLoadSlidingWindowFeatures);
            this.pnlPerformanceEvaluation.Controls.Add(this.btnLoadSlidingWindows);
            this.pnlPerformanceEvaluation.Controls.Add(this.btnLoadGroundTruth);
            this.pnlPerformanceEvaluation.Controls.Add(this.pnlLoadFileIcon);
            this.pnlPerformanceEvaluation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPerformanceEvaluation.Location = new System.Drawing.Point(0, 40);
            this.pnlPerformanceEvaluation.Name = "pnlPerformanceEvaluation";
            this.pnlPerformanceEvaluation.Size = new System.Drawing.Size(198, 88);
            this.pnlPerformanceEvaluation.TabIndex = 31;
            this.pnlPerformanceEvaluation.Visible = false;
            // 
            // pnlLoadFileIcon
            // 
            this.pnlLoadFileIcon.Controls.Add(this.picBoxDC);
            this.pnlLoadFileIcon.Controls.Add(this.picBoxWF);
            this.pnlLoadFileIcon.Controls.Add(this.picBoxSW);
            this.pnlLoadFileIcon.Controls.Add(this.picBoxGT);
            this.pnlLoadFileIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLoadFileIcon.Location = new System.Drawing.Point(172, 0);
            this.pnlLoadFileIcon.Name = "pnlLoadFileIcon";
            this.pnlLoadFileIcon.Size = new System.Drawing.Size(26, 88);
            this.pnlLoadFileIcon.TabIndex = 27;
            // 
            // picBoxDC
            // 
            this.picBoxDC.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxDC.Image = global::EveSense.Properties.Resources.x_wrong_cross_no_md;
            this.picBoxDC.Location = new System.Drawing.Point(0, 66);
            this.picBoxDC.Name = "picBoxDC";
            this.picBoxDC.Size = new System.Drawing.Size(26, 22);
            this.picBoxDC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxDC.TabIndex = 17;
            this.picBoxDC.TabStop = false;
            // 
            // picBoxWF
            // 
            this.picBoxWF.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxWF.Image = global::EveSense.Properties.Resources.x_wrong_cross_no_md;
            this.picBoxWF.Location = new System.Drawing.Point(0, 44);
            this.picBoxWF.Name = "picBoxWF";
            this.picBoxWF.Size = new System.Drawing.Size(26, 22);
            this.picBoxWF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxWF.TabIndex = 18;
            this.picBoxWF.TabStop = false;
            // 
            // picBoxSW
            // 
            this.picBoxSW.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxSW.Image = global::EveSense.Properties.Resources.x_wrong_cross_no_md;
            this.picBoxSW.Location = new System.Drawing.Point(0, 22);
            this.picBoxSW.Name = "picBoxSW";
            this.picBoxSW.Size = new System.Drawing.Size(26, 22);
            this.picBoxSW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSW.TabIndex = 15;
            this.picBoxSW.TabStop = false;
            // 
            // picBoxGT
            // 
            this.picBoxGT.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBoxGT.Image = global::EveSense.Properties.Resources.x_wrong_cross_no_md;
            this.picBoxGT.Location = new System.Drawing.Point(0, 0);
            this.picBoxGT.Name = "picBoxGT";
            this.picBoxGT.Size = new System.Drawing.Size(26, 22);
            this.picBoxGT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxGT.TabIndex = 14;
            this.picBoxGT.TabStop = false;
            // 
            // pnlProgressBar
            // 
            this.pnlProgressBar.Controls.Add(this.progressBar);
            this.pnlProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgressBar.Location = new System.Drawing.Point(0, 177);
            this.pnlProgressBar.Name = "pnlProgressBar";
            this.pnlProgressBar.Size = new System.Drawing.Size(198, 15);
            this.pnlProgressBar.TabIndex = 30;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(198, 15);
            this.progressBar.TabIndex = 29;
            this.progressBar.Visible = false;
            // 
            // cmbCaseStudy
            // 
            this.cmbCaseStudy.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCaseStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaseStudy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCaseStudy.FormattingEnabled = true;
            this.cmbCaseStudy.Items.AddRange(new object[] {
            "FA Cup Final",
            "Super Tuesday",
            "US Election",
            "Other"});
            this.cmbCaseStudy.Location = new System.Drawing.Point(0, 19);
            this.cmbCaseStudy.Name = "cmbCaseStudy";
            this.cmbCaseStudy.Size = new System.Drawing.Size(198, 21);
            this.cmbCaseStudy.TabIndex = 27;
            this.cmbCaseStudy.SelectedIndexChanged += new System.EventHandler(this.cmbCaseStudy_SelectedIndexChanged);
            // 
            // chkPerformanceEvaluator
            // 
            this.chkPerformanceEvaluator.AutoSize = true;
            this.chkPerformanceEvaluator.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerformanceEvaluator.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkPerformanceEvaluator.Location = new System.Drawing.Point(0, 0);
            this.chkPerformanceEvaluator.Name = "chkPerformanceEvaluator";
            this.chkPerformanceEvaluator.Size = new System.Drawing.Size(198, 19);
            this.chkPerformanceEvaluator.TabIndex = 28;
            this.chkPerformanceEvaluator.Text = "Evaluate Performance";
            this.chkPerformanceEvaluator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPerformanceEvaluator.UseVisualStyleBackColor = true;
            this.chkPerformanceEvaluator.CheckedChanged += new System.EventHandler(this.chkPerformanceEvaluator_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.numUpDownTopBoW);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numDownParameter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 75);
            this.panel1.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Silver;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 70);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(198, 5);
            this.panel10.TabIndex = 16;
            // 
            // numUpDownTopBoW
            // 
            this.numUpDownTopBoW.Dock = System.Windows.Forms.DockStyle.Top;
            this.numUpDownTopBoW.Location = new System.Drawing.Point(0, 50);
            this.numUpDownTopBoW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownTopBoW.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numUpDownTopBoW.Name = "numUpDownTopBoW";
            this.numUpDownTopBoW.Size = new System.Drawing.Size(198, 20);
            this.numUpDownTopBoW.TabIndex = 2;
            this.numUpDownTopBoW.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keep Top:";
            // 
            // numDownParameter
            // 
            this.numDownParameter.DecimalPlaces = 1;
            this.numDownParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.numDownParameter.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDownParameter.Location = new System.Drawing.Point(0, 15);
            this.numDownParameter.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDownParameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numDownParameter.Name = "numDownParameter";
            this.numDownParameter.Size = new System.Drawing.Size(198, 20);
            this.numDownParameter.TabIndex = 4;
            this.numDownParameter.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameter ω:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Blue;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "▼ ------- Others ------- ▼";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(131, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(131, 29);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 748);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlConfigurationMenu);
            this.Controls.Add(this.pnlLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "EveSense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLoad.ResumeLayout(false);
            this.pnlLoad.PerformLayout();
            this.pnlData.ResumeLayout(false);
            this.pnlWordCloud.ResumeLayout(false);
            this.pnlWindowsAndSearching.ResumeLayout(false);
            this.pnlWindowsAndSearching.PerformLayout();
            this.pnlGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlChartOptions.ResumeLayout(false);
            this.grpGraphSettings.ResumeLayout(false);
            this.grpGraphSettings.PerformLayout();
            this.pnlHeartbeatNormalRange.ResumeLayout(false);
            this.pnlHeartbeatNormalRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeartbeatTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeartbeatFrom)).EndInit();
            this.pnlSelectDataRange.ResumeLayout(false);
            this.pnlSelectDataRange.PerformLayout();
            this.pnlGraphSettings.ResumeLayout(false);
            this.pnlGraphSettings.PerformLayout();
            this.pnlRankingCriteria.ResumeLayout(false);
            this.pnlRankingCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDTF)).EndInit();
            this.pnlFeatureSet.ResumeLayout(false);
            this.pnlFeatureSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGF)).EndInit();
            this.pnlConfigurationMenu.ResumeLayout(false);
            this.pnlEvaluationParam.ResumeLayout(false);
            this.pnlEvaluationParam.PerformLayout();
            this.pnlLoadFiles.ResumeLayout(false);
            this.pnlLoadFiles.PerformLayout();
            this.pnlPerformanceEvaluation.ResumeLayout(false);
            this.pnlLoadFileIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGT)).EndInit();
            this.pnlProgressBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTopBoW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblSlidingWindows;
        private System.Windows.Forms.Label lblSlidingWindowFeatures;
        private System.Windows.Forms.Label lblDegreeCentrality;
        private System.Windows.Forms.Label lblGroundTruth;
        private System.Windows.Forms.Button btnLoadSlidingWindows;
        private System.Windows.Forms.Button btnLoadSlidingWindowFeatures;
        private System.Windows.Forms.Button btnLoadDegreeCentrality;
        private System.Windows.Forms.Button btnLoadGroundTruth;
        private System.Windows.Forms.TextBox txtResultFileName;
        private System.Windows.Forms.CheckBox chkAC;
        private System.Windows.Forms.CheckBox chkTP;
        private System.Windows.Forms.CheckBox chkGF;
        private System.Windows.Forms.CheckBox chkRankDC;
        private System.Windows.Forms.CheckBox chkRankDTF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolTip myToolTip;
        private System.Windows.Forms.Panel pnlRankingCriteria;
        private System.Windows.Forms.Panel pnlFeatureSet;
        private System.Windows.Forms.ComboBox cmbRanking;
        private System.Windows.Forms.ComboBox cmbFeatureSet;
        private System.Windows.Forms.NumericUpDown numUpDwnDC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUpDwnDTF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.NumericUpDown numUpDwnAC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numUpDwnTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpDwnGF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFeatureSetSeparator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMergeDHGs;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.ComboBox cmbSelectWindow;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlWordCloud;
        private System.Windows.Forms.Panel pnlConfigurationMenu;
        private System.Windows.Forms.Panel pnlEvaluationParam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.NumericUpDown numUpDownTopBoW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDownParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlLoadFiles;
        private System.Windows.Forms.RichTextBox rTxtResults;
        private System.Windows.Forms.Panel pnlWindowsAndSearching;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlChartOptions;
        private System.Windows.Forms.GroupBox grpGraphSettings;
        private System.Windows.Forms.Panel pnlHeartbeatNormalRange;
        private System.Windows.Forms.NumericUpDown numUpDownHeartbeatTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numUpDownHeartbeatFrom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkNormalizeHeartbeat;
        private System.Windows.Forms.Panel pnlSelectDataRange;
        private System.Windows.Forms.ComboBox cmbDataTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDataFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlGraphSettings;
        private System.Windows.Forms.CheckBox chkDataRange;
        private System.Windows.Forms.CheckBox chkGridLinesY;
        private System.Windows.Forms.CheckBox chkGridLinesX;
        private System.Windows.Forms.CheckBox chkDataValues;
        private System.Windows.Forms.Button btnRefereshGraph;
        private System.Windows.Forms.ComboBox cmbCandidateSelection;
        private System.Windows.Forms.ComboBox cmbCaseStudy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlAppIcon;
        private Gma.CodeCloud.Controls.CloudControl myCloudControl;
        private System.Windows.Forms.CheckBox chkPerformanceEvaluator;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel pnlProgressBar;
        private System.Windows.Forms.Panel pnlPerformanceEvaluation;
        private System.Windows.Forms.Panel pnlLoadFileIcon;
        private System.Windows.Forms.PictureBox picBoxDC;
        private System.Windows.Forms.PictureBox picBoxWF;
        private System.Windows.Forms.PictureBox picBoxSW;
        private System.Windows.Forms.PictureBox picBoxGT;
    }
}

