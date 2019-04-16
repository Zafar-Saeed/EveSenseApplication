using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Porter2Stemmer;
using System.Threading;

namespace DhgDataProcessor
{
    public partial class frmDataProcessor : Form
    {

        private Filter _filter = Filter.NONE;
        ExtractionConfigration _config = ExtractionConfigration.GetConfiguration;
        _Progress p = _Progress.GetProgress;

        public frmDataProcessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(_Util.commonPath);
            //ProgressTimer.Enabled = true;
            List<Tweet> testList = new List<Tweet>();

            lock (_Util.Locker)
            {
                p.Activity = 0;
                p.Message = 0;

            }

            _config.FilterationCriteria = _filter;


            if (_filter == Filter.WORDS)
            {
                Hashtable removeWords = new Hashtable();

                string[] tempStopWrods = txtFiltrationWords.Text.Split(new char[] { ',' }, txtFiltrationWords.Text.Length, StringSplitOptions.RemoveEmptyEntries);

                foreach (string stopWord in tempStopWrods)
                {
                    removeWords.Add(stopWord, 1);
                }

                BagOfWords.GetBagOfWords._RemoveWords = removeWords;
                _config.filterWordList = removeWords;
            }

            _config.ExpiryTime = (int)numericExpiryTime.Value;
            _config.Measure = (CentralityMeasure)cmbMeasure.SelectedIndex;
            _config.WeightCriteria = (EdgeWeightCriteria)cmbEdgeWeightCriteria.SelectedIndex;
            _config.UserMatchFlag = chkUserFlag.Checked;
            _config.TweetMatchingCriteria = (DuplicateTweetCriteria)cmbTweetMatchingCriteria.SelectedIndex;
            _config.minWordLength = (int)numericWordLength.Value;
            _config.WeightedEdgeFlag = chkWeightedEdge.Checked;
            _config.WeightedNodeFlag = chkWeightedNode.Checked;
            _config.IsDataCleaned = chkCleanedData.Checked;
            _config.IsStemmingOn = chkStemming.Checked;
            _config.IsDHGWriterOn = chkDHGWriter.Checked;
            _config.IsAppRootPath = chkApplicationPathForFiles.Checked;

            if (radioBtnMin.Checked)
                _config.ExpiryTimeUnit = TimeUnitExpiry.MINUTE;
            else if (radioBtnHour.Checked)
                _config.ExpiryTimeUnit = TimeUnitExpiry.HOUR;
            else if (radioBtnDay.Checked)
                _config.ExpiryTimeUnit = TimeUnitExpiry.DAY;

            _Util.SetCommonPath(_config.IsAppRootPath);

            //for linux
            //_Util.commonPath = "/home/zasaeed/Data/";

                Thread tStatus = new Thread(new ThreadStart(UpdateProgressStatus));
            tStatus.Start();

            while (!tStatus.IsAlive) ;

            Thread tProcess = new Thread(new ThreadStart(Process), 10000000);
            tProcess.Start();

            while (!tProcess.IsAlive) ;


            //_config.DataSetFilePath = @"C:\Users\Zafar\Documents\Visual Studio 2015\Projects\PhDExperiment\TestData.txt";

            //config.DataSetFilePath = @"D:\PhD\twitter Datasets\TweetCatcher Datasets\BRAZvsARG_ARGvsBRZ_10Nov_12Nov_WithoutRetweet.txt";

           

            
        }

        private void Process()
        {

            /////////////////////////////////////////////////////////////////////////////////
            ///// CHANGE ALL THE CONDITIONS FROM CHECK BOXES TO CONFIGURATION OBJECT ////////
            /////////////////////////////////////////////////////////////////////////////////

            try
            {
                Extractor dataExtractor = new Extractor(_config);

                lock (_Util.Locker)
                {
                    p.Activity = 7;
                    p.Message = 0;

                }

                dataExtractor.Extract();

                UsersWordList userList = UsersWordList.GetUserList;
                WordsUserList wordList = WordsUserList.GetWordList;


                bool success = false;
                // temporary condition, just to check if DHG writer is working fine, because I need to execute code again n again
                if (!chkDHGWriter.Checked)
                {
                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 2;

                    }

                    int testing = 0;
                    // UPDATE ACTIVITIES FOR WRITING FILES AND MESSAGES


                    string fileName = "WordDistribution.csv";
                    success = _Util.WriteWordDistributionToCSV(BagOfWords.GetBagOfWords._TweetWords, fileName);


                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 6;

                    }

                    fileName = "UserTweetDistribution.csv";
                    success = _Util.WriteUserTweetDistribution(userList, fileName);

                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 7;

                    }

                    fileName = "WordTweetUserDistribution.csv";
                    success = _Util.WriteWordTweetUserDistribution(wordList, fileName);

                }


                List<int> test = new List<int>();

                lock (_Util.Locker)
                {
                    p.Activity = 2;
                    p.Message = 2;
                }

                // following code will execute only if experiment is run on dirty dataset
                // other wise it will save alot of time
                if (!chkCleanedData.Checked)
                {

                    string str = txtDataSetFilePath.Text.Trim();
                    int lastIndex = str.LastIndexOf(@"\");

                    if (chkDuplicate.Checked)
                    {
                        dataExtractor.RemoveDuplicateTweetsUsingIndexFile(txtDuplicateTweetIndexFile.Text);
                    }

                    else
                    {
                        dataExtractor.RemoveDuplicateTweet();

                        lock (_Util.Locker)
                        {
                            p.Activity = 5;
                            p.Message = 4;
                        }

                        success = dataExtractor.CreateCSVForRemovedTweets("RemovedTweets.csv", str.Substring(lastIndex + 1, str.Length - lastIndex - 1));

                        if (!success)
                        {
                            int dummyvar = 0;
                        }
                    }

                    lock (_Util.Locker)
                    {
                        p.Activity = 4;
                        p.Message = 1;

                    }

                    if (chkReverse.Checked)
                        dataExtractor.CleanedData.Reverse();


                    lock (_Util.Locker)
                    {
                        p.Activity = 4;
                        p.Message = 2;

                    }

                    success = _Util.WriteToFile(dataExtractor.CleanedData, false, str.Substring(lastIndex + 1, str.Length - lastIndex - 1));

                    if (!success)
                    {
                        int dummyVar = 0;
                    }

                } // end of clean data condidtion i.e. !chkCleanedData


                lock (_Util.Locker)
                {
                    p.Activity = 1;
                    p.Message = 3;
                }

                if (!dataExtractor.CreateTimeSeriesNetwork())
                {
                    int dummyVar = 0;
                }

                lock (_Util.Locker)
                {
                    p.Activity = 5;
                    p.Message = 10;
                }

                if (!dataExtractor.CreateNetworkNodeFrequencyDistribution("Node_distribution.csv"))
                {
                    int dummyVar = 0;
                }

                lock (_Util.Locker)
                {
                    p.Activity = 1;
                    p.Message = 0;
                }

                dataExtractor.CalculateWindowsDifferences();

                lock (_Util.Locker)
                {
                    p.Activity = 1;
                    p.Message = 4;
                }


                #region " This is temp region " 



                #endregion


                dataExtractor.CalculateDegreeCentralityInDifferenceGraph();

                // temporary condition, just to check if DHG writer is working fine, because I need to execute code again n again
                if (!chkDHGWriter.Checked)
                {
                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 3;
                    }

                    success = dataExtractor.CreateCentralityScoreCSV("Degree_Centrality_Scores.csv");

                    if (!success)
                    {
                        int dummyVar = 0;
                    }

                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 8;
                    }

                    success = dataExtractor.CreateSlidingWindowsFeaturesCSV("Sliding_Windows_Features.csv");

                    if (!success)
                    {
                        int dummyVar = 0;
                    }

                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 5;
                    }

                    success = dataExtractor.CreateUserInfoInEachSlidingWindowCSV("UserInfoInEachSlidingWindow.csv");

                    if (!success)
                    {
                        int dummyVar = 0;
                    }
                }



                if (_config.IsDHGWriterOn)
                {
                    lock (_Util.Locker)
                    {
                        p.Activity = 5;
                        p.Message = 9;
                    }

                    success = dataExtractor.CreateGraphVisualizationCSV(_heartBeatGraphs);

                    if (!success)
                    {
                        int dummyVar = 0;
                    }

                }

                lock (_Util.Locker)
                {
                    p.Activity = 6;
                    p.Message = 0;
                }

                //ProgressTimer.Enabled = false;

                if (!success)
                    MessageBox.Show("Unable to write file for degree centralities");
                else
                    MessageBox.Show("Successfully wrote file for degree centralities");

                int dummy = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString() + "\n" + "Inner Exception: " + ex.InnerException.ToString() + "\n" + "Trace: " + ex.StackTrace);
            }
            
            //GC.Collect();

        }

        private  void AddFiltrationWord(string text)
        {
            string[] wordsToRemove = text.Split(new char[] { ',' }, text.Length, StringSplitOptions.RemoveEmptyEntries);
            Hashtable tempStopWords = new Hashtable();

            foreach (string word in wordsToRemove)
                if ( !tempStopWords.ContainsKey(word))
                    tempStopWords.Add(word, 1f);

            BagOfWords wordList = BagOfWords.GetBagOfWords;

            wordList._RemoveWords = tempStopWords;
        }

        private void txtFiltrationWords_Enter(object sender, EventArgs e)
        {
            txtFiltrationWords.Text = "";
            txtFiltrationWords.ForeColor = Color.Black;
        }

        private void txtFiltrationWords_Leave(object sender, EventArgs e)
        {
            if (txtFiltrationWords.Text == "")
            {
                txtFiltrationWords.Text = "Write all words here with comma saperated (e.g. keyword1,keyword2,keyword3)";
                txtFiltrationWords.ForeColor = Color.Gray;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFilter.Visible = cmbFilter.Text.Equals("words",StringComparison.CurrentCultureIgnoreCase);
            _filter = (Filter)cmbFilter.SelectedIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            cmbMeasure.SelectedIndex = 0;
            cmbEdgeWeightCriteria.SelectedIndex = 0;
            cmbTweetMatchingCriteria.SelectedIndex = 0;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDataSetFilePath.Text = _config.DataSetFilePath = openFileDialog.FileName;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //EdgeInfo[,] joinedEdgeMatrix = new EdgeInfo[2, 2];
           
            frmDataSetParsingAndCleaning frm = new frmDataSetParsingAndCleaning();

            frm.ShowDialog();

        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            ///////////// Following is not working ////////
            //string message;
            //lock (_Util.Locker)
            //{
            //    message = _Progress.GetProgress.GetMessage(p.Activity, p.Message);
            //}

            //SetLabelText(message);

            //lock (_Util.Locker)
            //{
            //    lblStatusMsg.BeginInvoke(new Action(() => lblStatusMsg.Text = _Progress.GetProgress.GetMessage(p.Activity,p.Message));
                
            //}
        }

        private void UpdateProgressStatus()
        {
            int progressCompleted = -1;
            string message;
            long totalPasses = 0;
            long completedPasses = 0;
            string funcName = "";


            while(progressCompleted != 7)
            {

                lock (_Util.Locker)
                {
                    message = _Progress.GetProgress.GetMessage(p.Activity, p.Message);
                    progressCompleted = p.Activity;
                    totalPasses  = _Util.totalIterations;
                    completedPasses = _Util.completedIterations;
                    funcName = _Util.functionNameForProgressMsg;
                }

                SetLabelText(message, totalPasses, completedPasses, funcName);
                
                Thread.Sleep(1500);

            }

        }

        private delegate void SetLabelTextDelegate(string msg,long totalPasses, long completedPasses, string functionName);
        private void SetLabelText(string msg, long totalPasses, long completedPasses, string functionName)
        {
            
            // label.Text = number.ToString();
            // Do NOT do this, as we are on a different thread.

            // Check if we need to call BeginInvoke.
            if (lblStatusMsg.InvokeRequired)
            {
                // Pass the same function to BeginInvoke,
                // but the call would come on the correct
                // thread and InvokeRequired will be false.


                lblStatusMsg.BeginInvoke(new SetLabelTextDelegate(SetLabelText), new object[] { msg, totalPasses, completedPasses, functionName });
                //lblStatusMsg.BeginInvoke(new SetLabelTextDelegate(UpdateStatusLabel), new object[] { msg });
                //lblStatusMsg.BeginInvoke(new Action(() => lblStatusMsg.Text = msg));
                //lblStatusMsg.BeginInvoke(new Action(() => lblStatusMsg.Refresh()));


                return;
            }

            lblStatusMsg.Text = msg + "\t" + completedPasses.ToString() + " out of " + totalPasses.ToString() + " Completed.." + "\tProcessing Function Name: " + functionName;
            //lblProgressPercent.Text = progressPercent.ToString();
        }

        private void chkDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuplicate.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text|*.txt|All|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDuplicateTweetIndexFile.Text = openFileDialog.FileName;

                }
                else
                    chkDuplicate.Checked = false;
            }
        }

        private void chkCleanedData_CheckedChanged(object sender, EventArgs e)
        {
            chkDuplicate.Enabled = !chkCleanedData.Checked;
        }

        List<KeyValuePair<int, int>> _heartBeatGraphs = new List<KeyValuePair<int, int>>();

        private void chkGraphVisualizer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDHGWriter.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text|*.txt|All|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDuplicateTweetIndexFile.Text = openFileDialog.FileName;

                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                    string line;
                    string[] splitLine;
                    while((line = file.ReadLine()) != null)
                    {
                        splitLine = line.Split(new char[] { ',' }, line.Length, StringSplitOptions.RemoveEmptyEntries);
                        _heartBeatGraphs.Add(new KeyValuePair<int, int>(int.Parse(splitLine[0]), int.Parse(splitLine[1])));
                    }
                }
                else
                    chkDHGWriter.Checked = false;
            }
            else
                chkDHGWriter.Checked = false;

            int dummy = 0;
        }

    }
}
