using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace DhgDataProcessor
{
    public partial class frmDataSetParsingAndCleaning : Form
    {
        string fileName;

        public frmDataSetParsingAndCleaning()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV|*.csv|Text|*.txt|All|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = txtDataSetFilePath.Text = openFileDialog.FileName;

            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // I must complete this today

            StreamReader file =
               new StreamReader(fileName);
            string line;

            StringBuilder strDatasetfile = new StringBuilder();
            List<string> strDataRows = new List<string>();
            List<DateTime> tweetDateTimeList = new List<DateTime>();


            string[] words;

            line = file.ReadLine();
            words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            strDatasetfile.AppendLine(words[13] + "\t" + words[1] + "\t" + words[20] + "\t" + words[0]);

            //////////////////////////////////////////////
            // Feature Set is Dataset //////////////////
            /////////////////////////////////////////////////
            //0  = User
            //1  = UserID
            //2  = UserTweets
            //3  = UserFavorites
            //4  = UserListed
            //5  = UserFollowers
            //6  = UserFriends
            //7  = UserSince
            //8  = UserSince(Year)
            //9  = UserLanguage
            //10 = UserLocation
            //11 = UserTimezone
            //12 = UserUTCOffset
            //13 = TimeOfTweet
            //14 = TweetLanguage
            //15 = TweetApp
            //16 = TweetLocation
            //17 = IsRetweet
            //18 = TweetID
            //19 = TweetURL
            //20 = Tweet

            int rt = 0;
            int lang = 0;
            bool flag = true;
            int droped = 0;
            int damage = 0;
            int tweetcount = 0;
            
            DateTime chunkedTweetDateTime = new DateTime(2012, 05, 05, 14, 0, 10); // represents the starting datetime unless minutes is changes
            DateTime tweetDateTime;
            string tempDateString;
            using (CsvFileReader reader = new CsvFileReader(fileName))
            {
                CsvRow row = new CsvRow();

                while (reader.ReadRow(row))
                {
                    if ( row.Count == 21)
                    {
                        // drop retweets and other languages
                        if (row[17].Equals("1"))
                        {
                            rt++;
                            flag = false;
                        }

                        if (!row[14].Equals("en"))
                        {
                            lang++;
                            flag = false;
                        }


                        if (flag)
                        {
                            tempDateString = row[13].Replace("+", "");

                            tweetDateTime = _Util.ConvertToDate(tempDateString);

                            //if (tweetDateTime.Minute > chunkedTweetDateTime.Minute || tweetDateTime.Hour > chunkedTweetDateTime.Hour)
                            //{
                            //    strDatasetfile.Append(SortAndCreateStringBuilder(tweetDateTimeList, strDataRows));

                            //    tweetDateTimeList.Clear();
                            //    strDataRows.Clear();
                            //    chunkedTweetDateTime = tweetDateTime;

                            //}

                            tweetDateTimeList.Add(tweetDateTime);
                            strDataRows.Add(tempDateString + "\t" + row[1] + "\t" + row[20] + "\t" + row[0]);

                            //datasetfile.AppendLine();
                            tweetcount++;
                        }
                        else
                            droped++;

                    }  // end of feature count condition (row.count == 21 ) , to ensure that tweet is not damaged
                    else
                    {
                        damage++;
                        droped++;
                    }

                    flag = true;
                    //foreach (string s in row)
                    //{
                    //    Console.Write(s);
                    //    Console.Write(" ");
                    //}
                    //Console.WriteLine();
                }

                //BackgroundWorker bw = new BackgroundWorker();

                //// this allows our worker to report progress during work
                //bw.WorkerReportsProgress = true;

                //// what to do in the background thread
                //bw.DoWork += new DoWorkEventHandler(updateWorker_DoWork);

                //// what to do when progress changed (update the progress bar for example)
                //bw.ProgressChanged += new ProgressChangedEventHandler(
                //delegate (object o, ProgressChangedEventArgs args)
                //{
                //    lblProgress.Text = string.Format("{0}% Completed", args.ProgressPercentage);
                //});

                //// what to do when worker completes its task (notify the user)
                //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                //delegate (object o, RunWorkerCompletedEventArgs args)
                //{
                //    lblProgress.Text = "Finished!";
                //});


                //// following call will run the function
                //bw.RunWorkerAsync();

                strDatasetfile.Append(SortAndCreateStringBuilder(tweetDateTimeList, strDataRows));

            }

            //while ((line = file.ReadLine()) != null)
            //{
            //    words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //    words[13] = words[13].Replace("+","");

            //    // droping retweets
                
                
            //}

            var fileStream = new FileStream(fileName.Replace(".csv","") + "_zafar.txt", FileMode.Create, FileAccess.Write);
            
            var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            
            streamWriter.Write(strDatasetfile);
            
            streamWriter.Close();


            fileStream = new FileStream(fileName.Replace(".csv", "_DropoutInfo") + "_zafar.txt", FileMode.Create, FileAccess.Write);

            streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

            streamWriter.Write("Total Tweets: " + tweetcount.ToString() + "\tTotal Dropped: " + droped.ToString() + "\tRT: " + rt.ToString() + "\tOther Lang: " + lang.ToString() + "\tDamaged Tweets: " + damage.ToString());

            streamWriter.Close();


            MessageBox.Show("Successfull.. \nTotal Tweets: " + tweetcount.ToString() + "\nTotal droped: " + droped.ToString() + "\nRT: " + rt.ToString() + "\nsOther Lang: " + lang.ToString());
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker b = sender as BackgroundWorker;

            //do some simple processing for 10 seconds
            for (int i = 1; i <= 10; i++)
                {
                    // report the progress in percent
                    b.ReportProgress(i * 10);
                    Thread.Sleep(1000);
                }


        }


        private StringBuilder SortAndCreateStringBuilder(List<DateTime> dt, List<string> data)
        {
            //use fastes algorithm for sorting
            // bubble sort is one of the most expensive sorting algorithm

            // Recommend: Insertion sort, since the data is almost sorted in dataset, OR use Quick sort
            

            DateTime tempDT;
            string tempStr;
            StringBuilder strDataRows = new StringBuilder();

            for (int i = 0; i < dt.Count ; i++)
            {
                for (int j = 0; j < dt.Count - 1 - i ; j++)
                {
                    if (DateTime.Compare( dt[j],dt[j+1]) > 0 )
                    {
                        tempDT = dt[j + 1];
                        dt[j + 1] = dt[j];
                        dt[j] = tempDT;

                        tempStr = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = tempStr;

                    }
                }
            }

            foreach(string str in data)
            {
                strDataRows.AppendLine(str);
            }

            return strDataRows;
        }

    }
}
