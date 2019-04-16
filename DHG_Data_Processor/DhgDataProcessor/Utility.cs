using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DhgDataProcessor
{
    enum Filter
    {
        NONE = 0,
        WORDS = 1,
        OUTLIER = 2,
        MEAN = 3,
        MEAN_STANDARD_MEAN_ERROR = 4,
        PERCENTAGE = 5
    };
    enum CentralityMeasure
    {
        DEGREE_WITH_POSITIVE_EDGES = 0,
        DEGREE_WITH_ALL_EDGES = 1,
        CUSTOM_MEASURE = 2      
    };
    enum EdgeWeightCriteria
    {
        USER_BASED = 0,
        TWEET_BASED = 1,
        ACCUMULATIVE = 2
    };
    enum DuplicateTweetCriteria
    {
        MATCH_WORD_IN_SEQUENCE = 0,
        MATCH_WORD_IN_ANY_ORDER = 1
        
    };
    enum TimeUnitExpiry
    {
        MINUTE = 0,
        HOUR = 1,
        DAY = 2
    };

    class _Util
    {

        public static readonly object Locker = new object();
        public static long totalIterations = 0;
        public static long completedIterations = 0;
        public static string functionNameForProgressMsg = "";

        public static string commonPath; // = @"D:\PhD\Research\UTS Work\Results" + "\\" + DateTime.Now.ToShortDateString().Replace("/", "-");

        public static void SetCommonPath(bool IsAppRootPath)
        {   
            if (IsAppRootPath)
            {
                commonPath =
                        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\")) + DateTime.Now.ToShortDateString().Replace("/", "-");

            }
            else
                commonPath = @"D:\PhD\Research\UTS Work\Results" + "\\" + DateTime.Now.ToShortDateString().Replace("/", "-");

        }
        //public static string commonPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        
        public static string CreateFolderPath()
        {   
            ExtractionConfigration config = ExtractionConfigration.GetConfiguration;
            /*
            Ex = Expiry Time + Unit (M = Minute, H = Hour, and D = Day)
            FC = Filteration Criteria
            M  = Measure
            TM = Tweet Matching Criteria
            UM = User Matching Flag
            WC = Weight Criteria
            */
            string unit="";

            if (config.ExpiryTimeUnit == TimeUnitExpiry.MINUTE)
                unit = "M";
            else if (config.ExpiryTimeUnit == TimeUnitExpiry.HOUR)
                unit = "H";
            else if (config.ExpiryTimeUnit == TimeUnitExpiry.DAY)
                unit = "D";

            return "Ex-" + config.ExpiryTime.ToString() + unit + "_FC-" + config.FilterationCriteria.ToString() + "_M-" + config.Measure.ToString() + "_TM-" + config.TweetMatchingCriteria.ToString() + "_UM-" + config.UserMatchFlag.ToString() + "_WC-" + config.WeightCriteria.ToString();
            
        }

        public static float[][] DifferenceMatrix(float[][] A, float[][] B)
        {
            //creating NxN Matrix
            int n = A.Length;
            float[][] B_A = new float[n][];
            for (int i = 0; i < n; i++)
                B_A[i] = new float[n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    B_A[i][j] = B[i][j] - A[i][j];

            return B_A;

        }

        public static float[][] Create2DArray(int rows, int columns)
        {
            float[][] temp = new float[rows][];

            for(int i = 0; i < rows; i++)
            {
                temp[i] = new float[columns];
            }

            return temp;
        }

        // change this method according to the dataset date format
        public static bool ValidateDateFormat(string tweetDate)
        {

            try
            {
                for (int i = 0; i < tweetDate.Length; i++)
                {
                    if (tweetDate[i] < '0' || tweetDate[i] > '9')
                        return false;
                }

                int year = int.Parse(tweetDate.Substring(0, 4));
                int month = int.Parse(tweetDate.Substring(4, 2));
                int day = int.Parse(tweetDate.Substring(6, 2));
                int hour = int.Parse(tweetDate.Substring(8, 2));
                int min = int.Parse(tweetDate.Substring(10, 2));
                int sec = int.Parse(tweetDate.Substring(12, 2));

                if (month > 12 || day > 31 || hour > 23 || min > 59 || sec > 59)
                    return false;
                //_currentTweetDate = new DateTime(year, month, day, hour, min, sec); 

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        
        private List<string> days = new List<string>(new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" });
        private static List<string> months = new List<string>( new string[] { "jan", "feb", "mar", "apr", "may", "jun", "jul","aug","sep","oct","nov","dec" });


        // change this method according to dataset date string
        public static DateTime ConvertToDate(string dateStr)
        {
            try
            {
                
                int year = int.Parse(dateStr.Substring(25, 4));
                int month = months.IndexOf(dateStr.Substring(4, 3).ToLower()) + 1;
                int day = int.Parse(dateStr.Substring(8, 2));
                int hour = int.Parse(dateStr.Substring(11, 2));
                int min = int.Parse(dateStr.Substring(14, 2));
                int sec = int.Parse(dateStr.Substring(17, 2));

                return new DateTime(year, month, day, hour, min, sec);

                //return _currentTweetDate;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // change this method according to dataset date string
        public static DateTime ConvertToDateCleanedDataset(string dateStr)
        {
            try
            {

                int year = int.Parse(dateStr.Substring(25, 4));
                int month = months.IndexOf(dateStr.Substring(4, 3).ToLower()) + 1;
                int day = int.Parse(dateStr.Substring(8, 2));
                int hour = int.Parse(dateStr.Substring(11, 2));
                int min = int.Parse(dateStr.Substring(14, 2));
                int sec = int.Parse(dateStr.Substring(17, 2));

                return new DateTime(year, month, day, hour, min, sec);

                //return _currentTweetDate;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static int TimeDifference(DateTime starting, DateTime ending, TimeUnitExpiry expiryUnit)
        {
            TimeSpan span = ending.Subtract(starting);

            if (expiryUnit == TimeUnitExpiry.MINUTE)
                return span.Minutes;
            else if (expiryUnit == TimeUnitExpiry.HOUR)
                return span.Hours;
            else if (expiryUnit == TimeUnitExpiry.DAY)
                return span.Days;

            throw new Exception("Unable to calculate time difference between window's start time and current tweet time");
        }

        public static bool WriteNodeFreqInEachHeartBeat(List<_Graph> heartBeats)
        {
            // incomplete... complete it incase your want to know frequency of each node in a specific sliding window
            string saperator = "";

            try
            {
                for (int i = 1; i < heartBeats.Count; i++)
                    saperator += ",";
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool WriteToFile(List<Tweet> cleanedData, bool reverseFlag, string fileName)
        {
            try
            {
                // reverseFlag simply reverse all tweets, My data contains tweets from recent to older
                // I need to reverse it
                if (reverseFlag)
                {
                    cleanedData.Reverse();
                }


                //////////////////////////
                // Modified 20-Oct-2017 //
                //////////////////////////

                //string path = @"D:\PhD\Research\UTS Work\Results\\CleanData";

                string path =
                        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\")) + "CleanData";

                //// END OF MODIFICATION 20-Oct-2017 /////


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                //string dataSet = SortByTweetDateTime(richTextBox1.Text);

                

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                foreach (Tweet tweet in cleanedData)
                {
                    string tweetContents = "";

                    foreach (string str in tweet.TweetWords)
                        tweetContents += str + " ";

                    streamWriter.WriteLine(tweet.TweetDate.ToString("dd/MM/yyyy hh:mm:ss tt") + "\t" + tweet.UserName + "\t" + tweetContents);
                }

                streamWriter.Close();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        
        public static bool WriteTweetFrequencyDistribution(List<KeyValuePair<DateTime,int>> _list, string path)
        {

            try
            {
            
                string filePath = path.Substring(0,path.Length-3) + "_FrequencyDistribution.csv";
                
                var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                
                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.WriteLine("Year,Month,Day,Hour,Minute,DateTime,Count");
                

                foreach (KeyValuePair<DateTime,int> window in _list)
                {
                    streamWriter.WriteLine(window.Key.Year.ToString() + "," +
                                           window.Key.Month.ToString() + "," +
                                           window.Key.Day.ToString() + "," +
                                           window.Key.Hour.ToString() + "," +
                                           window.Key.Minute.ToString() + "," +
                                           window.Key.ToString(("dd_MM_yyyy-HH:mm")) + "," +
                                           window.Value.ToString());
                }

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public static bool WriteWordTweetUserDistribution(WordsUserList wordList, string fileName)
        {
            try
            {
                //string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) +
                //                "\\" + _Util.CreateFolderPath();

                string path = commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                //string dataSet = SortByTweetDateTime(richTextBox1.Text);

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.WriteLine("Word,Total Tweets, Total Users");
                WordInfo wordInfo;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = wordList.Count;
                    _Util.functionNameForProgressMsg = "WriteWordTweetUserDistribution";
                }

                long count = 0;

                foreach (string word in wordList.GetKeys())
                {
                    count++;

                    wordInfo = wordList.GetWordInfo(word);
                    streamWriter.WriteLine(word + "," + wordInfo.TotalTweets.ToString()+","+wordInfo.TotalUsers.ToString());

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = count;
                    }

                }

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool WriteUserTweetDistribution(UsersWordList userList, string fileName)
        {
            long count = 0;

            try
            {
                //string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) +
                //                "\\" + _Util.CreateFolderPath();

                string path = commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                //string dataSet = SortByTweetDateTime(richTextBox1.Text);
                
                UserInfo user;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = userList.Count;
                    _Util.functionNameForProgressMsg = "WriteUserTweetDistribution";
                }

                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine("User Name,Total Tweets, Unique Words");
                    foreach (string userName in userList.GetKeys())
                    {

                        user = userList.GetUser(userName);
                        streamWriter.WriteLine(userName + "," + user.TotalTweets.ToString() + "," + user.GetTotalUniqueWords.ToString());

                        lock (_Util.Locker)
                        {
                            _Util.completedIterations = ++count;
                        }
                    }
                }
                
                //streamWriter.Close();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public static bool WriteWordDistributionToCSV(Hashtable words, string fileName)
        {

            long count = 0;
            List<KeyValuePair<string, float>> sortedList;
            try
            {
                sortedList = GetSortedNodeList(words);

                //string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) +
                //                "\\" + _Util.CreateFolderPath();

                string path = commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path+"\\"+fileName, FileMode.Create, FileAccess.Write);

                //string dataSet = SortByTweetDateTime(richTextBox1.Text);
                
                string line = "";

                lock (_Util.Locker)
                {
                    _Util.totalIterations = sortedList.Count;
                    _Util.functionNameForProgressMsg = "WriteWordDistributionToCSV";
                }
                
                

                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    foreach (KeyValuePair<string, float> wordPair in sortedList)
                    {
                        line = (count++).ToString() + "," + wordPair.Key + "," + wordPair.Value.ToString();
                        streamWriter.WriteLine(line);

                        lock (_Util.Locker)
                        {
                            _Util.completedIterations = count;
                        }

                    }
                }
                    
                //streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool WriteRemovedTweetsToCSV(List<Tweet> removedTweetList, List<Tweet> matchingTweetList, List<int> removedTweetIndexes, string fileName, string datasetName)
        {

            try
            {



                //////////////////////////
                // Modified 20-Oct-2017 //
                //////////////////////////

                //string removedTweetIndexesFilePath = @"D:\PhD\Research\UTS Work\Results\\RemovedTweetsIndex";

                string removedTweetIndexesFilePath = 
                        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\"))+ "RemovedTweetsIndex";

                //// END OF MODIFICATION 20-Oct-2017 /////

                
                string path = commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                //string dataSet = SortByTweetDateTime(richTextBox1.Text);

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                int count = 0;

                string line = "";

                for (int i = 0; i < removedTweetList.Count; i++)
                {

                    line = (count++).ToString() + "," + removedTweetList[i].TweetDate.ToString() + "," + removedTweetList[i].UserName + "," + string.Join(" ", removedTweetList[i].TweetWords);
                    streamWriter.WriteLine(line);
                    line = "," + matchingTweetList[i].TweetDate.ToString() + "," + matchingTweetList[i].UserName + "," + string.Join(" ", matchingTweetList[i].TweetWords);
                    streamWriter.WriteLine(line);
                    streamWriter.WriteLine(",,,");
                }

                streamWriter.Close();
                

                // Writing Indexes to file, in case of error/excpetion later on in the application,
                // i don't have to go through expensive process of finding duplicate tweets,
                // rather, I can use indexes from written file and directly delete those from _CleanDataset
                if (!Directory.Exists(removedTweetIndexesFilePath))
                {
                    Directory.CreateDirectory(removedTweetIndexesFilePath);
                }

                fileStream = new FileStream(removedTweetIndexesFilePath + "\\Indexes_" + datasetName + ".csv", FileMode.Create, FileAccess.Write);
                                                streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                line = "";

                for (int i = 0; i < removedTweetIndexes.Count; i++)
                {

                    line = i.ToString() +"," + removedTweetIndexes[i].ToString();
                    streamWriter.WriteLine(line);
                    
                }

                streamWriter.Close();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool WriteCentralityScoreToCSV(List<KeyValuePair<int, float>> scoresList)
        {

           
            

            return true;
        }

        public static List<KeyValuePair<string, float>> GetSortedNodeList(Hashtable words)
        {
            //float tempScore;
            //string tempNode;

            List<KeyValuePair<string, float>> sortedList = new List<KeyValuePair<string, float>>();
            ICollection col = words.Keys;

            
            //create copies
            List<string> allWords = new List<string>();
            List<float> frequencies = new List<float>();

            lock (_Util.Locker)
            {
                _Util.totalIterations = words.Count;
                _Util.functionNameForProgressMsg = "GetSortedNodeList (Copying Word List)";
            }

            long count = 0;

            foreach (string key in words.Keys)
            {
                sortedList.Add(new KeyValuePair<string, float>(key, (float)words[key]));

                lock (_Util.Locker)
                {
                    _Util.completedIterations = ++count;
                }
            }


            //KeyValuePair<string, float> tempWordFreq;

            ////////////////////////////////////////////////////////////
            // IMPLEMENT QUICK SORT HERE, IT IS TAKING TOO MUCH TIME ///
            ////////////////////////////////////////////////////////////

            // Now -> Already implemented, see the code after lock statement
             
            //for (int i = 0; i < sortedList.Count - 1; i++)
            //{
            //    for (int j = 0; j < sortedList.Count - i - 1; j++)
            //    {

            //        if (sortedList[j].Value < sortedList[j + 1].Value) /* For Ascending order use < */
            //        {
            //            tempWordFreq = sortedList[j];
            //            sortedList[j] = sortedList[j + 1];
            //            sortedList[j + 1] = tempWordFreq;
            //        }
            //    }
            //}

            lock (_Util.Locker)
            {
                _Util.functionNameForProgressMsg = "GetSortedNodeList (Quick Sorting)";
            }

            //return quicksortNodes(sortedList);
            return sortedList;

        }

        private static List<KeyValuePair<string, float>> quicksortNodes(List<KeyValuePair<string, float>> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            KeyValuePair<string, float> pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);
            List<KeyValuePair<string, float>> smaller = new List<KeyValuePair<string, float>>();
            List<KeyValuePair<string, float>> greater = new List<KeyValuePair<string, float>>();

            foreach (KeyValuePair<string, float> item in list)
            {
                // little hack here:
                // with if (item.Value < pivotValue.Value) smaller.Add(item);
                // it sorts in ascending order, I have just inverted the relational operator to make it descending
                if (item.Value > pivotValue.Value)
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }

            List<KeyValuePair<string, float>> sorted = quicksortNodes(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(quicksortNodes(greater));
            return sorted;
        }

        public static List<KeyValuePair<NodeInfo,float>> quicksortNodesListForGraph(List<KeyValuePair<NodeInfo, float>> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            KeyValuePair<NodeInfo, float> pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);

            List<KeyValuePair<NodeInfo, float>> smaller = new List<KeyValuePair<NodeInfo, float>>();
            List<KeyValuePair<NodeInfo, float>> greater = new List<KeyValuePair<NodeInfo, float>>();

            foreach (KeyValuePair<NodeInfo, float> item in list)
            {
                // little hack here:
                // with if (item.Value < pivotValue.Value) smaller.Add(item);
                // it sorts in ascending order, I have just inverted the relational operator to make it descending
                if (item.Value > pivotValue.Value)
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }

            List<KeyValuePair<NodeInfo, float>> sorted = quicksortNodesListForGraph(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(quicksortNodesListForGraph(greater));
            return sorted;
        }

        public static List<NodeInfo> quicksortListNodesInfo(List<NodeInfo> list)
        {

            #region "   OLD RECURSIVE IMPLEMENTATION QUICK SORT, I AM CHANGING THIS TO iterative  "
            //if (list.Count <= 1) return list;
            //int pivotPosition = list.Count / 2;
            //NodeInfo pivotValue = list[pivotPosition];
            //list.RemoveAt(pivotPosition);

            //List<NodeInfo> smaller = new List<NodeInfo>();
            //List<NodeInfo> greater = new List<NodeInfo>();

            //foreach (NodeInfo item in list)
            //{
            //    // little hack here:
            //    // with if (item.Value < pivotValue.Value) smaller.Add(item);
            //    // it sorts in ascending order, I have just inverted the relational operator to make it descending
            //    if (string.Compare(item.NodeName, pivotValue.NodeName) == -1)
            //    {
            //        smaller.Add(item);
            //    }
            //    else
            //    {
            //        greater.Add(item);
            //    }
            //}

            //List<NodeInfo> sorted = quicksortListNodesInfo(smaller);
            //sorted.Add(pivotValue);
            //sorted.AddRange(quicksortListNodesInfo(greater));
            //return sorted;

            #endregion
            

            return (list.OrderBy(x => x.NodeName)).ToList<NodeInfo>();

        }
        
    } // end of class
} // end of namespace
