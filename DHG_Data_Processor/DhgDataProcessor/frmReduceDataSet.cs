using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DhgDataProcessor
{
    public partial class frmReduceDataSet : Form
    {
        public frmReduceDataSet()
        {
            InitializeComponent();
        }

        private int _tweetCount = 0;
        private int _tweetDropCount = 0;
        private int _qualifedTweetCount = 0;
        private int _reducedSet = 0;
        private bool _progressCompleted = false;
        private Hashtable _qualifiedTimeChunk = new Hashtable();
        List<Tweet> _ReducedDataSet = new List<Tweet>();
        
        private object _locker = new object();

        private void btnReduce_Click(object sender, EventArgs e)
        {
            
                Thread tStatus = new Thread(new ThreadStart(UpdateProgressStatus));
                tStatus.Start();

                while (!tStatus.IsAlive) ;

                Thread tProcess = new Thread(new ThreadStart(Process), 10000000);
                tProcess.Start();

                while (!tProcess.IsAlive) ;
            
        }





        private void Process()
        {

            
            string line;
            Cleansing cleansing = new Cleansing();
            Tweet currentTweet;
            
            DateTime currentTweetDate;
           
            
            StreamReader file =
              new StreamReader(txtReducedSet.Text);

            while ((line = file.ReadLine()) != null)
            {
               
                if(!line.Trim().Equals("0"))
                {
                    //DateTime temp = Convert.ToDateTime(line);
                    _qualifiedTimeChunk.Add(line.Trim(),0);
                    
                }
                
            }

            file.Close();

         
                file =
              new StreamReader(txtDataSetFilePath.Text);


            while ((line = file.ReadLine()) != null)
            {

                lock (_locker)
                {
                    _tweetCount++;
                    _reducedSet = (int)((float)_qualifedTweetCount / _tweetCount) * 100;

                }

                currentTweet = cleansing.LoadCleanTweet(line, Filter.NONE, 1);
                
                if (IsTweetQualify(currentTweet.TweetDate) && currentTweet != null)
                {
                    _ReducedDataSet.Add(currentTweet);

                    lock (_locker)
                    {
                        _qualifedTweetCount++;

                    }
                }
                else
                {
                    lock (_locker)
                    {
                        _tweetDropCount++;

                    }
                }
                
            }

            
            string msg = "";

            string[] datasetFileName = txtDataSetFilePath.Text.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string[] supportingIndexFile = txtReducedSet.Text.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            string dsFileName = datasetFileName[datasetFileName.Length - 1];
            string supportFileName = supportingIndexFile[supportingIndexFile.Length - 1];

            if (_Util.WriteToFile(_ReducedDataSet,false, dsFileName + "_" + supportFileName.Replace(" ","_")))
            {
                msg = "Dataset is Successfully reduced and wrote to file";
            }
            else
            {
                msg = "Something is wrong, couldn't write reduced dataset to file";
            }

            MessageBox.Show(msg);

        }

        private bool IsTweetQualify(DateTime tweetTime)
        {
            // following is the date format (day/month/year hour:min:sec) in reduced set file
            //      5/5/2012 15:6:0

            string stringDate = tweetTime.Day.ToString() + "/" + 
                                tweetTime.Month.ToString() + "/" + 
                                tweetTime.Year + " " + 
                                tweetTime.Hour.ToString() + ":" + 
                                tweetTime.Minute + ":0";


            //if (selectedChunkTime.Year == tweetTime.Year &&
            //    selectedChunkTime.Month == tweetTime.Month &&
            //    selectedChunkTime.Day == tweetTime.Day &&
            //    selectedChunkTime.Hour == tweetTime.Hour &&
            //    selectedChunkTime.Minute == tweetTime.Minute)
            //    return true;

            if (_qualifiedTimeChunk.ContainsKey(stringDate))
                return true;

            return false;
                
        }

        private void UpdateProgressStatus()
        {
            int tweetCount;
            int tweetDropCount;
            int qualifedTweetCount;
            int reducedSet;
           

            while (!_progressCompleted)
            {
                lock (_locker)
                {
                    tweetCount = _tweetCount;
                    tweetDropCount = _tweetDropCount;
                    qualifedTweetCount = _qualifedTweetCount;
                    reducedSet = _reducedSet;
                    
                }

                SetText(_tweetCount, _tweetDropCount, _qualifedTweetCount, _reducedSet);

                Thread.Sleep(1);

            }

            SetText(_tweetCount, _tweetDropCount, _qualifedTweetCount, _reducedSet);
            Thread.Sleep(1);


        }

        private delegate void SetTextDelegate(int tweetCount, int tweetDropCount, int qualifedTweetCount, int reducedSet);
        private void SetText(int tweetCount, int tweetDropCount, int qualifedTweetCount, int reducedSet)
        {
            if (rTxtStats.InvokeRequired)
            {

                rTxtStats.BeginInvoke(new SetTextDelegate(SetText), new object[] { tweetCount, tweetDropCount, qualifedTweetCount, reducedSet });

                return;
            }

            rTxtStats.Text = "Tweet Count:\t\t\t\t\t" + tweetCount.ToString() +
                             "\nTweet Drop Count:\t\t\t\t" + tweetDropCount.ToString() +
                             "\nQualified Tweet Count:\t" + qualifedTweetCount.ToString() +
                             "\nReduced Set:\t" + reducedSet.ToString() + "%";

        }
       
        private void btnLoadReducedDataIndex_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV|*.csv|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtReducedSet.Text = openFileDialog.FileName;

            }

            if (!txtReducedSet.Text.Equals(string.Empty))
            {

            }


        }
        private void btnLoadFilteroutWords_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilteroutWords.Text = openFileDialog.FileName;

            }
        }
        private void btnLoadFilteroutUsers_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilteroutUsers.Text = openFileDialog.FileName;

            }
        }
        private void btnLoadData_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDataSetFilePath.Text = openFileDialog.FileName;

            }
        }

    }
}
