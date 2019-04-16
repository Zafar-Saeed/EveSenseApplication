using Gma.CodeCloud.Controls.Geometry;
using Gma.CodeCloud.Controls.TextAnalyses.Extractors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Gma.CodeCloud.Controls.TextAnalyses.Blacklist;
using Gma.CodeCloud.Controls.TextAnalyses.Blacklist.En;
using Gma.CodeCloud.Controls.TextAnalyses.Processing;
using Gma.CodeCloud.Controls.TextAnalyses.Stemmers;

namespace EveSense
{
    public partial class frmMain : Form
    {
        
        int _totalNumberOfLines = 0;
        int _linesProcessed = 0;
        bool _allFilesLoaded = false;

        string[] groundTruthFiles;

        GroundTruth _gTruth;
        SlidingWindows _slidingWindows;
        Hashtable _slidingWindowsThreshold;

        ListDHGs _listDHGs;
        List<KeyValuePair<int, int>> _indexMap;
        Config _config = new Config();
        List<List<KeyValuePair<string, double>>> _listChartSeries;

        bool selectWindowReady = false;

        string tempTweetText;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoadGroundTruth_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == btnLoadGroundTruth)
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        fbd.SelectedPath = @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged";
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            groundTruthFiles = Directory.GetFiles(fbd.SelectedPath);
                            lblGroundTruth.Text = fbd.SelectedPath;
                            picBoxGT.Image = Properties.Resources.greendonetick_small_inline;
                            myToolTip.SetToolTip(picBoxGT, Util.GroundTruthPath(cmbCaseStudy.SelectedIndex));
                            
                        }
                    }
                }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text|*.txt|CSV|*.csv|All|*.*";
                    openFileDialog.FilterIndex = 2;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (sender == btnLoadDegreeCentrality)
                        {
                            lblDegreeCentrality.Text = openFileDialog.FileName;
                            picBoxDC.Image = Properties.Resources.greendonetick_small_inline;
                            myToolTip.SetToolTip(picBoxDC, lblDegreeCentrality.Text);
                            
                        }
                        else if (sender == btnLoadSlidingWindowFeatures)
                        {
                            lblSlidingWindowFeatures.Text = openFileDialog.FileName;
                            picBoxWF.Image = Properties.Resources.greendonetick_small_inline;
                            myToolTip.SetToolTip(picBoxWF, lblSlidingWindowFeatures.Text);
                            int dummy = 0;
                        }
                        else if (sender == btnLoadSlidingWindows)
                        {
                            lblSlidingWindows.Text = openFileDialog.FileName;
                            picBoxSW.Image = Properties.Resources.greendonetick_small_inline;
                            myToolTip.SetToolTip(picBoxSW, lblSlidingWindows.Text);
                            int dummy = 0;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadDegreeCentralityFile(string filePath)
        {
            StreamReader file = new StreamReader(filePath);
            string line;
            //no need of first line
            line = file.ReadLine();

            if (line == null)
                return;

            // second line is for maping the DHGs in DegreeCentrality file to the _listDHGs using dates

            line = file.ReadLine();

            if (line == null)
                return;

            _indexMap = Util.IndexMapper(line, _listDHGs);

            // useless line having column labels for each DHG
            line = file.ReadLine();

            while ((line = file.ReadLine()) != null)
            {
                string[] columns = line.Trim().Split(new char[] { ',' }, line.Length);

                foreach(KeyValuePair<int,int> index in _indexMap)
                {
                    // condition is checked because network size varies in each DHG aligned in columns orientation, therefore list of BoW.Count is different
                    if ( !string.IsNullOrEmpty(columns[index.Key]))
                    {
                        _listDHGs
                        .DHGs[index.Value]
                        .BoW
                        .Add(new Term(columns[index.Key], int.Parse(columns[index.Key + 1]), float.Parse(columns[index.Key + 2]), _config.IsRankingFused, _config.IsDTFRanking, _config.IsDCRanking));
                    }
                }
            }

            string[] readLines = File.ReadAllText(filePath).Split(new char[] { '\n' });

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TO HIGHLIGHT AREA IN THE CHART SEE FOLLOWING LINK //
            // https://stackoverflow.com/questions/12821896/windows-forms-chart-add-a-value-marker
            btnLoadGroundTruth.Click += new System.EventHandler(this.btnLoadGroundTruth_Click);
            btnLoadSlidingWindows.Click += new System.EventHandler(this.btnLoadGroundTruth_Click);
            btnLoadSlidingWindowFeatures.Click += new System.EventHandler(this.btnLoadGroundTruth_Click);
            btnLoadDegreeCentrality.Click += new System.EventHandler(this.btnLoadGroundTruth_Click);

            lblSlidingWindowFeatures.Text = @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\30-10-2017_SuperTuesday_FullData\Ex-5M\Sliding_Windows_Features.csv";
            lblDegreeCentrality.Text = @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\30-10-2017_SuperTuesday_FullData\Ex-5M\Degree_Centrality_Scores.csv";
            lblSlidingWindows.Text = @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\Sliding Winodws\Super_Tuesday\Sliding Windows_5minAggregation.txt";
            
            //myToolTip.SetToolTip(picBoxDC, Util.RawDataPath(cmbCaseStudy.SelectedIndex));
            //myToolTip.SetToolTip(picBoxGT, Util.GroundTruthPath(cmbCaseStudy.SelectedIndex));
            //myToolTip.SetToolTip(picBoxSW, Util.SlidingWindowPath(cmbCaseStudy.SelectedIndex));
            //myToolTip.SetToolTip(picBoxWF, Util.WindowsFeaturesPath(cmbCaseStudy.SelectedIndex));

            cmbRanking.SelectedIndex = 
                cmbFeatureSet.SelectedIndex = 
                cmbMergeDHGs.SelectedIndex = 
                cmbCandidateSelection.SelectedIndex = 
                cmbCaseStudy.SelectedIndex = 0;

             tempTweetText = rTxtResults.Text.Trim();
            rTxtResults.Text = "";

            chkDataValues.Click += new EventHandler(GraphSettingCheckBoxes);
            chkGridLinesX.Click += new EventHandler(GraphSettingCheckBoxes);
            chkGridLinesY.Click += new EventHandler(GraphSettingCheckBoxes);
            chkDataRange.Click += new EventHandler(GraphSettingCheckBoxes);
            chkNormalizeHeartbeat.Click += new EventHandler(GraphSettingCheckBoxes);

            rTxtResults.Dock = DockStyle.Fill;
            

        }

        private BindingList<KeyValuePair<string,string>> cmbWin = new BindingList<KeyValuePair<string, string>>();

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                selectWindowReady = false;
                progressBar.Visible = true;

                if ( MessageBox.Show("Make sure file name contains \n" +
                    "Dataset name: e.g. FA or ST or US\n" +
                    "Aggregation: e.g. 1min or 5min or 10min\n" +
                    "Graph Type: e.g. W for weighted or NW for non-weighted\n" +
                    "You want to contniue..? (y/n)", "Critical", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtResultFileName.Text == "")
                        throw new Exception("Enter Result File Name...");
                    if (!chkRankDC.Checked && !chkRankDTF.Checked)
                        throw new Exception("Select Ranking Criteria");

                    _gTruth = new GroundTruth();
                    _slidingWindows = new SlidingWindows();
                    _slidingWindowsThreshold = new Hashtable();

                    _listDHGs = new ListDHGs();

                    _config.AdjustmentParameter = (double)numDownParameter.Value;
                    _config.TopK = (int)numUpDownTopBoW.Value;
                    _config.FileName = txtResultFileName.Text.Trim();

                    _config.IsGF = chkGF.Checked;
                    _config.IsTP = chkTP.Checked;
                    _config.IsDC = chkAC.Checked;
                    _config.IsDTFRanking = chkRankDTF.Checked;
                    _config.IsDCRanking = chkRankDC.Checked;
                    _config.IsRankingFused = cmbRanking.SelectedIndex == 0 ? true: false;

                    _config.CandidateSelectionCriteria = (CandidateSelection)cmbCandidateSelection.SelectedIndex;

                    

                    //if ( !_allFilesLoaded)
                    {
                        
                        _gTruth.LoadGroundTruth(groundTruthFiles);


                        string filePath = "";

                        if (chkPerformanceEvaluator.Checked) filePath = lblSlidingWindows.Text;
                        else filePath = Util.SlidingWindowPath(cmbCaseStudy.SelectedIndex);

                        _slidingWindows.LoadSlidingWindow(filePath);

                        string[] windows = _slidingWindows.ListOfWindows.Select(x => x.TimeSlotID).ToArray<string>();

                        cmbWin.Clear();

                        cmbWin.Add(new KeyValuePair<string, string>("None", "Select a Sliding Window"));
                        foreach (string winTime in windows)
                            cmbWin.Add(new KeyValuePair<string, string>(winTime, Util.ConvertToFormatedDate(winTime)));

                        //cmbSelectWindow.DataSource = null;
                        //cmbSelectWindow.Items.Clear();

                        cmbSelectWindow.DataSource = cmbWin;
                        cmbSelectWindow.DisplayMember = "Value";
                        cmbSelectWindow.ValueMember = "Key";
                        cmbSelectWindow.SelectedIndex = 0;

                        if (chkPerformanceEvaluator.Checked) filePath = lblSlidingWindowFeatures.Text;
                        else filePath = Util.WindowsFeaturesPath(cmbCaseStudy.SelectedIndex);

                        _listDHGs.LoadDHGsFeatures(filePath, _slidingWindows, _config, out _listChartSeries);

                        if (chkPerformanceEvaluator.Checked) filePath = lblDegreeCentrality.Text;
                        else filePath = Util.RawDataPath(cmbCaseStudy.SelectedIndex);

                        LoadDegreeCentralityFile(filePath);

                        //_allFilesLoaded = true;
                    }

                    chart1.Series.Clear();
                    DrawChart(_listChartSeries);

                    pnlChartOptions.Visible = true;
                    //myToolTip.SetToolTip(picBoxDC, Util.RawDataPath(cmbCaseStudy.SelectedIndex));
                    //myToolTip.SetToolTip(picBoxGT, Util.GroundTruthPath(cmbCaseStudy.SelectedIndex));
                    //myToolTip.SetToolTip(picBoxSW, Util.SlidingWindowPath(cmbCaseStudy.SelectedIndex));
                    //myToolTip.SetToolTip(picBoxWF, Util.WindowsFeaturesPath(cmbCaseStudy.SelectedIndex));
                    
                    Results rslt = new Results(txtResultFileName.Text.Trim());
                    //rTxtResults.Text = rslt.GenerateResults(_listDHGs, _gTruth, _slidingWindows, _config).ToString();
                    rslt.GenerateResults(_listDHGs, _gTruth, _slidingWindows, _config).ToString();
                    
                    selectWindowReady = true;

                    
                    rTxtResults.Text = tempTweetText;
                    //myRtb.SelectionStart = s_start;
                    //myRtb.SelectionLength = 0;
                    //myRtb.SelectionColor = color;
                    rTxtResults.Select(0, 1428);
                    //rTxtResults.SelectionStart = 0;
                    //rTxtResults.SelectionLength = 1440;
                    rTxtResults.SelectionBackColor = Color.FromArgb(255, 192, 128);

                    rTxtResults.Select(1428, 1500);
                    //rTxtResults.SelectionStart = 0;
                    //rTxtResults.SelectionLength = 1440;
                    rTxtResults.SelectionBackColor = Color.FromArgb(255, 224, 192);

                    ////myRtb.SelectionStart = s_start;
                    ////myRtb.SelectionLength = 0;
                    ////myRtb.SelectionColor = color;
                    //rTxtResults.Select(0, 1440);
                    ////rTxtResults.SelectionStart = 0;
                    ////rTxtResults.SelectionLength = 1440;
                    //rTxtResults.SelectionBackColor = Color.FromArgb(255, 128, 0);

                    //rTxtResults.Select(1442,500);
                    ////rTxtResults.SelectionStart = 0;
                    ////rTxtResults.SelectionLength = 1440;
                    //rTxtResults.SelectionBackColor = Color.FromArgb(255, 192, 128);


                    MessageBox.Show("Results are successfully generated..");

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            int dummy = 0;
        }

        private void DrawChart(List<List<KeyValuePair<string, double>>> listSeries)
        {

            chart1.Series.Clear();

            AddSeries("Heartbeat", Color.FromArgb(192, 0, 0));
            AddSeries("Network Size", Color.FromArgb(0,192, 0));
            AddSeries("User Participation", Color.FromArgb(0, 0, 192));


            //foreach (List<KeyValuePair<string, double>> series in listSeries)
            for(int i = 0; i < listSeries[0].Count; i++)
            {

                chart1.Series["Heartbeat"].Points.AddXY(listSeries[0][i].Key, listSeries[0][i].Value);
                chart1.Series["Network Size"].Points.AddXY(listSeries[1][i].Key, listSeries[1][i].Value);
                chart1.Series["User Participation"].Points.AddXY(listSeries[2][i].Key, listSeries[2][i].Value);
                cmbDataFrom.Items.Add(listSeries[0][i].Key);
                cmbDataTo.Items.Add(listSeries[0][i].Key);
                
            }

        }

        private void AddSeries(string name, Color clr)
        {
            chart1.Series.Add(name);

            chart1.Series[name].ChartType = SeriesChartType.Line;
            chart1.Series[name].IsValueShownAsLabel = false;
            chart1.Series[name].XValueType = ChartValueType.DateTime;
            //chart1.Series["Heartbeat"].LabelAngle = 45;
            chart1.Series[name].BorderWidth = 2;
            chart1.Series[name].ShadowColor = Color.Gray;
            chart1.Series[name].ShadowOffset = 1;
            chart1.Series[name].Color = clr;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            

        }

        private void GraphSettingCheckBoxes(object sender, EventArgs e)
        {
           
            if (sender == chkDataValues)
            {
                chart1.Series[0].IsValueShownAsLabel = chkDataValues.Checked;
            }
            else if ( sender == chkGridLinesX)
            {
                chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = chkGridLinesX.Checked ? ChartDashStyle.Solid : ChartDashStyle.NotSet;
            }
            else if (sender == chkGridLinesY)
            {
                chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = chkGridLinesY.Checked ? ChartDashStyle.Solid : ChartDashStyle.NotSet;
            }
            else if (sender == chkDataRange)
            {
                pnlSelectDataRange.Visible = chkDataRange.Checked;
                if ( cmbDataFrom.Items.Count > 0)
                {
                    cmbDataFrom.SelectedIndex = 0;
                    cmbDataTo.SelectedIndex = cmbDataTo.Items.Count - 1;
                }
            }
            else if (sender == chkNormalizeHeartbeat)
            {
                pnlHeartbeatNormalRange.Visible = chkNormalizeHeartbeat.Checked;
            } 
        }

        private void FeatureSetCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            count += chkAC.Checked ? 1: 0;
            count += chkTP.Checked ? 1 : 0;
            count += chkGF.Checked ? 1 : 0;
            cmbCandidateSelection.SelectedIndex = count < 2 ? 0 : cmbCandidateSelection.SelectedIndex;
        }

        private void cmbCandidateSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFeatureSet.Enabled = true;

            if ( cmbCandidateSelection.SelectedIndex == 2)
            {
                pnlFeatureSet.Enabled = false;
            }
            else
            {
                int count = 0;
                count += chkAC.Checked ? 1 : 0;
                count += chkTP.Checked ? 1 : 0;
                count += chkGF.Checked ? 1 : 0;

                if (count < 2 && cmbCandidateSelection.SelectedIndex == 1)
                {
                    MessageBox.Show("First! You have to select at least two of the features for \'FEATURES-BASED UNION\' option");
                    cmbCandidateSelection.SelectedIndex = count < 2 ? 0 : cmbCandidateSelection.SelectedIndex;
                }
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(((KeyValuePair<string, string>)cmbSelectWindow.SelectedItem).Key);
            //MessageBox.Show(((KeyValuePair<string, string>)cmbSelectWindow.SelectedItem).Value);

        }

        private void ScaleDataValues(List<List<KeyValuePair<string, double>>> listChartSeries)
        {

            //float[] data = { 0.4f, 12, 3278, 32, 89, 12 };

            List<List<KeyValuePair<string, double>>> listChartSeriesHBScaled = new List<List<KeyValuePair<string, double>>>();

            double minHB = listChartSeries.Select(x => x[0].Value).Min();
            double maxHB = listChartSeries.Select(x => x[0].Value).Max();

            double newMin = Convert.ToDouble(numUpDownHeartbeatFrom.Value);
            double newMax = Convert.ToDouble(numUpDownHeartbeatTo.Value);


            double m = (newMax - newMin) / (maxHB - minHB);
            double c = newMin - minHB * m;

            listChartSeriesHBScaled.Add(new List<KeyValuePair<string, double>>());
            listChartSeriesHBScaled.Add(new List<KeyValuePair<string, double>>());
            listChartSeriesHBScaled.Add(new List<KeyValuePair<string, double>>());

            for (int i = 0; i < listChartSeries[0].Count; i++)
            {
                listChartSeriesHBScaled[0].Add(new KeyValuePair<string,double>(listChartSeries[0][i].Key,Math.Round(m * listChartSeries[0][i].Value + c, 0)));
                listChartSeriesHBScaled[1].Add(new KeyValuePair<string, double>(listChartSeries[1][i].Key, listChartSeries[1][i].Value));
                listChartSeriesHBScaled[2].Add(new KeyValuePair<string, double>(listChartSeries[2][i].Key, listChartSeries[2][i].Value));
                
            }

            DrawChart(listChartSeriesHBScaled);

            //double minHB = data.Min();
            //double max = data.Max();
            //double newMin = Convert.ToDouble(numUpDownHeartbeatFrom.Value);
            //double newMax = Convert.ToDouble(numUpDownHeartbeatTo.Value);


            //double m = (newMax - newMin) / (max - min);
            //double c = newMin - min * m;
            //var newarr = new double[data.Length];
            //var newarrRound = new double[data.Length];

            //for (int i = 0; i < newarr.Length; i++)
            //{
            //    newarrRound[i] = Math.Round(m * data[i] + c, 0);
            //    newarr[i] = m * data[i] + c;

            //}

            int dummy = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chkNormalizeHeartbeat.Checked)
            {
                ScaleDataValues(_listChartSeries);
                pnlHeartbeatNormalRange.Visible = chkNormalizeHeartbeat.Checked;
            }
            else
            {
                DrawChart(_listChartSeries);
            }
            
            if (sender == chkDataRange)
            {
                pnlSelectDataRange.Visible = chkDataRange.Checked;
            }

        }

        private void cmbCaseStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmbCaseStudy.SelectedIndex >= 0)
                groundTruthFiles = Directory.GetFiles(Util.GroundTruthPath(cmbCaseStudy.SelectedIndex));
        }

        private void myCloudControl_Click(object sender, EventArgs e)
        {
            LayoutItem itemUderMouse;
            Point mousePositionRelativeToControl = myCloudControl.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            if (!myCloudControl.TryGetItemAtLocation(mousePositionRelativeToControl, out itemUderMouse))
            {
                return;
            }

            //MessageBox.Show(
            //    itemUderMouse.Word.GetCaption(),
            //    string.Format("Statistics for word [{0}]", itemUderMouse.Word.Text));

            txtSearch.Text += itemUderMouse.Word.Text + " ";
        }

        private void chkPerformanceEvaluator_CheckedChanged(object sender, EventArgs e)
        {
            //btnLoadDegreeCentrality.Visible = chkPerformanceEvaluator.Checked;
            //picBoxDC.Visible = chkPerformanceEvaluator.Checked;
            //btnLoadGroundTruth.Visible = chkPerformanceEvaluator.Checked;
            //picBoxGT.Visible = chkPerformanceEvaluator.Checked;
            //btnLoadSlidingWindowFeatures.Visible = chkPerformanceEvaluator.Checked;
            //picBoxWF.Visible = chkPerformanceEvaluator.Checked;
            //btnLoadSlidingWindows.Visible = chkPerformanceEvaluator.Checked;
            //picBoxSW.Visible = chkPerformanceEvaluator.Checked;
            cmbCaseStudy.Visible = !chkPerformanceEvaluator.Checked;
            pnlPerformanceEvaluation.Visible = chkPerformanceEvaluator.Checked;
        }

        private void cmbSelectWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmbSelectWindow.SelectedIndex != 0 && selectWindowReady)
            {
                
                IProgressIndicator progress = new ProgressBarWrapper(progressBar);

                string timeSlotID = cmbSelectWindow.SelectedValue.ToString();
                SingleWindow sw = _slidingWindows.GetWindow(timeSlotID);

                IEnumerable<string> terms = new StringExtractor(Util.GenerateText(sw.CandidateTopics).ToString(), progress);

                myCloudControl.WeightedWords =
                    terms
                        .CountOccurences()
                        .SortByOccurences();

                progressBar.Visible = false;
                pnlWordCloud.Visible = true;
                rTxtResults.Visible = false;


            }

        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlWordCloud.Visible = false;
            rTxtResults.Visible = true;
        }

        
    }
}
