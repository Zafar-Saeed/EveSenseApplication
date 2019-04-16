using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;

namespace DhgDataProcessor
{
    

    public partial class frmTweetFrequencyDistributor : Form
    {
        public frmTweetFrequencyDistributor()
        {
            InitializeComponent();
        }

        private int _lineCount = 0;
        private int _windowCount = 0;
        private int _TotalSpikeCount = 0;
        private int _uniqueSpikesMainWindow = 0;
        private int _uniqueSpikesOverlappingWindow = 0;
        private bool _progressCompleted = false;
        private int currentWindowTweetFrequency = 0;

        private object _locker = new object();

        private void btnGenerate_Click(object sender, EventArgs e)
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
            StreamReader file =
              new StreamReader(txtDataSetFilePath.Text);

            string line;
            DateTime currentTweetDate;
            List<KeyValuePair<DateTime, int>> tweetFrequencyDistributionList = new List<KeyValuePair<DateTime, int>>();
            DateTime previousTweetDateTime;

            line = file.ReadLine();
            //previousTweetDateTime = currentTweetDate = Convert.ToDateTime(line.Substring(0, 19), new CultureInfo("en - US"));
            
            //previousTweetDateTime = currentTweetDate = DateTime.ParseExact(Convert.ToDateTime(temp), "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            CultureInfo culture = new CultureInfo("en-US");
            previousTweetDateTime = Convert.ToDateTime(line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[0], culture);
            currentTweetDate = Convert.ToDateTime(line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[0], culture);

            while ((line = file.ReadLine()) != null)
            {
                currentWindowTweetFrequency++;

                lock (_locker)
                {
                    _lineCount++;
                }

                currentTweetDate = Convert.ToDateTime(line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)[0], culture);
                if ( currentTweetDate.Subtract(previousTweetDateTime).Minutes>= 1)
                {
                    tweetFrequencyDistributionList.Add(new KeyValuePair<DateTime, int>(previousTweetDateTime, currentWindowTweetFrequency));
                    currentWindowTweetFrequency = 0;
                    previousTweetDateTime = new DateTime(currentTweetDate.Year, currentTweetDate.Month, currentTweetDate.Day, currentTweetDate.Hour, currentTweetDate.Minute, 0);
                    currentTweetDate = new DateTime(0);

                    lock(_locker)
                    {
                        _windowCount++;
                    }
                    
                }

            }

            if ( currentTweetDate.Ticks != 0 )
            {
                tweetFrequencyDistributionList.Add(new KeyValuePair<DateTime, int>(previousTweetDateTime, currentWindowTweetFrequency));

                lock(_locker)
                {
                    _windowCount++;
                    _progressCompleted = true;
                }
            }

            
            string msg = "";

            if (_Util.WriteTweetFrequencyDistribution(tweetFrequencyDistributionList,txtDataSetFilePath.Text))
            {
                msg = "Successfully wrote tweet frequency distribution file";
            }
            else
            {
                msg = "Something is wrong, couldn't write tweet frequency distribution file";
            }

            MessageBox.Show(msg);
            
        }

        private void UpdateProgressStatus()
        {
            int lineCount;
            int windowCount;
            int spikeCount;
            int uniqueSpikesMW;
            int uniqueSpikesOW;

            while (!_progressCompleted)
            {
                lock (_locker)
                {
                    lineCount = _lineCount;
                    windowCount = _windowCount;
                    spikeCount = _TotalSpikeCount;
                    uniqueSpikesMW = _uniqueSpikesMainWindow;
                    uniqueSpikesOW = _uniqueSpikesOverlappingWindow;
                }

                SetText(_lineCount, _windowCount, _TotalSpikeCount, _uniqueSpikesMainWindow, _uniqueSpikesOverlappingWindow);

                Thread.Sleep(100);

            }

            SetText(_lineCount, _windowCount, _TotalSpikeCount, _uniqueSpikesMainWindow, _uniqueSpikesOverlappingWindow);
            Thread.Sleep(100);


        }

        private delegate void SetTextDelegate(int lineCount, int windowCount, int spikeCount, int _uniqueSpikesMW, int uniqueSpikesOW);
        private void SetText(int lineCount, int windowCount, int spikeCount, int uniqueSpikesMW, int uniqueSpikesOW)
        {
            if (rTxtStats.InvokeRequired)
            {
                
                rTxtStats.BeginInvoke(new SetTextDelegate(SetText), new object[] { lineCount, windowCount, spikeCount, uniqueSpikesMW, uniqueSpikesOW });
         
                return;
            }

            rTxtStats.Text = "Line Count:\t\t\t\t\t" + lineCount.ToString() + 
                             "\nWindows Count:\t\t\t\t" + windowCount.ToString() + 
                             "\nSpikes/Significance Count:\t" + spikeCount.ToString() +
                             "\nUnique Main Window Spikes:\t" + uniqueSpikesMW.ToString() +
                             "\nUnique Overlapping Window Spikes:\t" + uniqueSpikesOW.ToString(); 
            
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text|*.txt|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDataSetFilePath.Text =  openFileDialog.FileName;

            }
        }
    }
}
