using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    enum CaseStudy
    {
        FA_CUP = 0,
        SUPER_TUESDAY = 1,
        US_ELECTION = 2
    };

    class Util
    {
        // first element in keyvalue pair is the index of column having words in degreeCentrality file
        //and the second element is the index of corresponding DHG in _listDHGs

        private static string[] _groundTruthPath = 
            {
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\FACup_ground_truth_topics",
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\SuperTuesday_ground_truth_topics_MERGED",
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\USElections_ground_truth_topics - Merged"
            };

        private static string[] _slidingWindowPath =
            {
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\Sliding Winodws\FA_Cup\Sliding Windows_1min.txt",
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\Sliding Winodws\Super_Tuesday\Sliding Windows_5minAggregation.txt",
            @"D:\PhD\Research\UTS Work\Results\Ground Truth\Auto Evaluation Ground Truths\Merged\Sliding Winodws\US_Election\Sliding_Windows_1minAggregation.txt"
            };

        private static string[] _windowsFeaturesPath =
            {
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\10-13-2017_FA_FullData_ConsideredForConfPaper\1min_filterword_positiveEdges-USER_BASED\Sliding_Windows_Features.csv",
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\30-10-2017_SuperTuesday_FullData\Ex-5M\Sliding_Windows_Features.csv",
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\Ex-1M_US-Election-FullData-NonFilteredWords\Sliding_Windows_Features.csv"
            };

        private static string[] _rawDataPath =
            {
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\10-13-2017_FA_FullData_ConsideredForConfPaper\1min_filterword_positiveEdges-USER_BASED\Degree_Centrality_Scores.csv",
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\30-10-2017_SuperTuesday_FullData\Ex-5M\Degree_Centrality_Scores.csv",
            @"D:\PhD\Research\UTS Work\Results\Non-Weighted Edge Results\Ex-1M_US-Election-FullData-NonFilteredWords\Degree_Centrality_Scores.csv"
            };


        public static string GroundTruthPath(int study)
        {
            return _groundTruthPath[study];
        }
        public static string SlidingWindowPath(int study)
        {
            return _slidingWindowPath[study];
        }
        public static string WindowsFeaturesPath(int study)
        {
            return _windowsFeaturesPath[study];
        }
        public static string RawDataPath(int study)
        {
            return _rawDataPath[study];
        }


        public static List<KeyValuePair<int, int>>  IndexMapper(string line, ListDHGs listDHGs)
        {

            List<KeyValuePair<int, int>> indexMap = new List<KeyValuePair<int, int>>();


            string[] columns = line.Trim().Split(new char[] { ',' }, line.Length);
            int DHGindex;

            // in condition "i+1" is because of an additional empty column at the end of file.
            for (int i = 0; i+1 < columns.Length; i+=4)
            {
                //if ( !string.IsNullOrEmpty(columns[i]))
                //{
                //    int dummy = 0;
                //}

                if ( (DHGindex = listDHGs.SearchDHGIndex(columns[i],columns[i+1])) != -1)
                {
                    indexMap.Add(new KeyValuePair<int, int>(i, DHGindex));
                }

            }

            return indexMap;
        }

        public static StringBuilder GenerateText(CandidateTopics candTopic)
        {
            StringBuilder strBuilder = new StringBuilder();

            float[] scores;// = candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>();

            //scores = ScaleData(candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>(), 1, 100);
            scores = candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>();


            Random rnd = new Random();

            for (int i = 0; i < candTopic.CandidateKeywords.Count; i++)
            {
                double occurence;

                if ( candTopic.CandidateKeywords[i].Word.Trim().Equals("king") ||
                    candTopic.CandidateKeywords[i].Word.Trim().Equals("price") ||
                    candTopic.CandidateKeywords[i].Word.Trim().Equals("gallon") ||
                    candTopic.CandidateKeywords[i].Word.Trim().Equals("saudi") )
                {
                    occurence = Math.Log(Math.Ceiling(scores[i]) + 102,2) + 5;
                }
                else
                {
                    occurence = Math.Log(Math.Ceiling(scores[i]) + 102,2);
                }

                for (int j = 1; j < (int)occurence; j++)
                {
                    strBuilder.Append(candTopic.CandidateKeywords[i].Word + " ");
                }
            }
            
            return strBuilder;

        }

        public static void WriteCadidateTopics(CandidateTopics candTopic, string WindowTimeSlotID)
        {

            //StringBuilder strBuilder = new StringBuilder();
            
            //float[] scores;// = candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>();

            ////scores = ScaleData(candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>(), 1, 100);
            //scores = candTopic.CandidateKeywords.Select(x => x.Ranking).ToArray<float>();


            //for (int i = 0; i < candTopic.CandidateKeywords.Count; i++)
            //{
            //    for (int j = 1; j < (int)Math.Round(scores[i], 0); j++)
            //    {
            //        strBuilder.Append(candTopic.CandidateKeywords[i].Word + " ");
            //    }
            //}

            string fileName = "Candidate_topics_" + WindowTimeSlotID;
            var fileStream = new FileStream(fileName + ".csv", FileMode.Create, FileAccess.Write);
            var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            streamWriter.Write(GenerateText(candTopic));

            streamWriter.Close();

        }

        private static float[] ScaleData(float[] data, float newMin, float newMax)
        {
            float min = data.Min();
            float max = data.Max();

            float m = (newMax - newMin) / (max - min);
            float c = newMin - min * m;
            var newarr = new float[data.Length];
            for (int i = 0; i < newarr.Length; i++)
                newarr[i] = m * data[i] + c;

            return newarr;

        }


        public static void WriteFinalResults(Evaluation eval, string fileName, Config _config, StringBuilder strBuilder)
        {

            //FA_1MIN_W_D_1_CM
            string fileStats = fileName+"\n";
            fileName += "AdjParam-" + _config.AdjustmentParameter.ToString();

            if (_config.CandidateSelectionCriteria == CandidateSelection.FEATURES_BASED_UNION)
            {
                fileName += "_Union";
                fileStats += "Selecting Candidates independantly and then taking Union of Candidate DHGs\nFeature Set,";
            }
            else if (_config.CandidateSelectionCriteria == CandidateSelection.HEARTBEAT)
            {
                fileName += "_Hratbeat";
                fileStats += "Fusing Feature Set,";
            }
            else if (_config.CandidateSelectionCriteria == CandidateSelection.SELECT_ALL)
            {
                fileName += "_SelectAll";
                //fileStats += ",";
            }

            if (!(_config.CandidateSelectionCriteria == CandidateSelection.SELECT_ALL))
            {
                if (_config.IsGF) { fileName += "-GF"; fileStats += "Growth Factor"; }
                if (_config.IsTP) { fileName += "-TP"; fileStats += ",Trend Probability"; }
                if (_config.IsDC) { fileName += "-AC"; fileStats += ",Aggregated Centrality\n"; }
            }
            
            fileStats += "Adjustment Parameter," + _config.AdjustmentParameter.ToString() + "\nTop-K," + _config.TopK.ToString() +"\n";

            fileName += "_Rank";
            fileStats += "Ranking,";

            if (_config.IsDTFRanking) { fileName += "-DTF"; fileStats += "Disp. Temp. Freq."; }
            if (_config.IsDCRanking) { fileName += "-DC"; fileStats += "Degree Centrality"; }

            fileStats += "\n\n" + strBuilder + "\n\n";

            var fileStream = new FileStream(fileName+".csv", FileMode.Create, FileAccess.Write);
            
            var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

            string lineKPre = "K-Pre";
            string lineKRec = "K-Rec";
            string lineTPre = "T-Pre";
            string lineTRec = "T-Rec";
            string lineKF1 = "K-F1";
            string lineTF1 = "T-F1";
            string lineTRecResult = "T-Rec-Results,,";
            string topTRec = "\n\n,,";
            string top = "";

            // FOR AT K = 2
            topTRec += ",2";
            lineTRecResult += "," + Math.Round(eval.TopicRecallAtK[1], 3).ToString();

            for (int i = 0; i < _config.TopK; i++)
            {
                if ( (i+1)%10 == 0)
                {
                    topTRec += "," + (i + 1).ToString();
                    lineTRecResult += "," + Math.Round(eval.TopicRecallAtK[i], 3).ToString();
                }

                top += "," + (i + 1).ToString();
                lineKPre += "," + Math.Round(eval.KeywordPercisionAtK[i],3).ToString();
                lineKRec += "," + Math.Round(eval.KeywordRecallAtK[i], 3).ToString();
                lineTPre += "," + Math.Round(eval.TopicPercisionAtK[i], 3).ToString();
                lineTRec += "," + Math.Round(eval.TopicRecallAtK[i], 3).ToString();
                lineKF1 += "," + Math.Round(eval.KeywordF1AtK[i], 3).ToString();
                lineTF1 += "," + Math.Round(eval.TopicF1AtK[i], 3).ToString();
            }

            
            streamWriter.WriteLine(fileStats);
            streamWriter.WriteLine(top);
            streamWriter.WriteLine(lineKPre);
            streamWriter.WriteLine(lineKRec);
            streamWriter.WriteLine(lineTPre);
            streamWriter.WriteLine(lineTRec);
            streamWriter.WriteLine(lineKF1);
            streamWriter.WriteLine(lineTF1);
            streamWriter.WriteLine(topTRec);
            streamWriter.WriteLine(lineTRecResult);

            streamWriter.Close();

        }

        static string[] Months = { "jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };


        public static string ConvertToFormatedDate(string timeSlotID)
        {
            try
            {
                string date;

                timeSlotID = timeSlotID.Remove(timeSlotID.Length - 4, 4);

                string[] parts = timeSlotID.Split(new char[] { '_' }, timeSlotID.Length, StringSplitOptions.RemoveEmptyEntries);

                if ( parts.Length < 4)
                {
                    throw new Exception("Date stamp is not in correct format");
                }

                date = parts[0] + " " + Months[int.Parse(parts[1])] + ", " + parts[2] + " " + parts[3] + ":" + parts[4];

                return date;
            }
            catch (Exception ex)
            {
                return timeSlotID;
            }

        }

    }
}
