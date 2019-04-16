using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    public class Term : IEquatable<Term>
    {
        public Term()
        {
            Word = "Default";
            Frequency = 0;
            NormalizedDegreeCentrality = 0;
            Ranking = 0;
        }

        public Term(string w, float f, float ndc, bool IsFused, bool IsDTF, bool IsDC)
        {
            Word = w;
            Frequency = f;
            NormalizedDegreeCentrality = ndc;
            if (IsFused)
                Ranking = Frequency * NormalizedDegreeCentrality;
            else if (IsDTF)
                Ranking = Frequency;
            else if (IsDC)
                Ranking = NormalizedDegreeCentrality;
        }

        public Term(Term t)
        {
            this.Word = t.Word;
            this.Frequency = t.Frequency;
            this.NormalizedDegreeCentrality = t.NormalizedDegreeCentrality;
            this.Ranking = t.Ranking;
        }

        public string Word { get; set; }
        public float Frequency { get; set; }
        public float NormalizedDegreeCentrality { get; set; }
        public float Ranking { get; set; }

        public bool Equals(Term t)
        {
            // Would still want to check for null etc. first.
            return this.Word.Equals(t.Word);
        }
    }

    public class DHGFeatures
    {
        public DHGFeatures()
        {
            TotalNodes = 0;
            TotalTweets = 0;
            TotalUsers = 0;
            StartingTime = "None";
            EndingTime = "None";
            ExecutionTime = 0;
            GrowthFactor = 0;
            NegTrendProbability = 0;
            PosTrendProbability = 0;
            AggregatedCentrality = 0;
            HeartbeatScore = 0;
            IsEventCandidate = false;
            TimeSlotID = "None";
            BoW = new List<Term>();
        }

        public string TimeSlotID { get; set; }
        public string DHG_No { get; set; }
        public bool IsEventCandidate { get; set; }
        public double HeartbeatScore { get; set; }
        public int TotalUsers { get; set; }
        public int TotalTweets { get; set; }
        public int TotalNodes { get; set; }
        public int ExecutionTime { get; set; }
        public double GrowthFactor { get; set; }
        public double NegTrendProbability { get; set; }
        public double PosTrendProbability { get; set; }
        public double TrendProbability
        {
            get
            {
                return PosTrendProbability - NegTrendProbability;
            }
        }
        public double AggregatedCentrality { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
        public List<Term> BoW { get; set; }

        public void SortRankingWise(bool IsDTFRank, bool IsDCRank)
        {
            if ( IsDCRank && IsDTFRank)
                BoW = BoW.OrderByDescending(x => x.Ranking).ToList();
            else if (IsDTFRank)
                BoW = BoW.OrderByDescending(x => x.Frequency).ToList();
            else if (IsDCRank)
                BoW = BoW.OrderByDescending(x => x.NormalizedDegreeCentrality).ToList();
        }

        public void RemoveBoWBelow(int top)
        {
            for (int i = BoW.Count - 1; i >= top; i--)
                BoW.RemoveAt(i);
        }

    }

    public class ListDHGs : IEnumerable
    {
        //public Hashtable SelectedDHGsInSlidingWindow { get; set; }
        private int position = -1;

        public ListDHGs()
        {
            DHGs = new List<DHGFeatures>();
        }
        public List<DHGFeatures> DHGs { get; set; }

        public int DHGsCount
        {
            get
            {
                return DHGs.Count;
            }
        }

        public List<string> FeatureSet { get; set; }

        public int SearchDHGIndex(string startingDate, string endingDate)
        {
            for (int i = 0; i < this.DHGsCount; i++)
            {
                if (startingDate.Equals(this.DHGs[i].StartingTime) && endingDate.Equals(this.DHGs[i].EndingTime))
                    return i;
            }

            return -1;
        }

        public  void LoadDHGsFeatures(string filePath, SlidingWindows slidingWindows, Config _config, out List<List<KeyValuePair<string, double>>> listChartSeries)
        {
            try
            {
               
                    DHGFeatures tempDHG;

                    string[] readLines = File.ReadAllText(filePath).Split(new char[] { '\n' });


                    FeatureSet = readLines[0]
                        .Trim()
                        .Split(new char[] { ',' }, readLines.Length, StringSplitOptions.RemoveEmptyEntries)
                        .ToList<string>();

                /////// LIST OF FEATURES IN SEQUENCE ///////
                //0     Window No
                //1     S_Time
                //2     E_Time
                //3     Node Freq
                //4     Neg Prob
                //5     Pos Prob
                //6     Centrality
                //7     Node Count
                //8     Tweet Count
                //9     User Count
                //10    Execution Time
                ////////////////////////////////////////////

                listChartSeries = new List<List<KeyValuePair<string, double>>>();

                List<KeyValuePair<string, double>> HB = new List<KeyValuePair<string, double>>();
                List<KeyValuePair<string, double>> NS = new List<KeyValuePair<string, double>>();
                List<KeyValuePair<string, double>> UP = new List<KeyValuePair<string, double>>();
               

                for (int i = 1; i < readLines.Length; i++)
                    {
                        if (readLines[i].Length > 9) // number of features
                        {
                            string[] featuresValue = readLines[i].Trim().Split(new char[] { ',' }, readLines.Length, StringSplitOptions.RemoveEmptyEntries);

                        double hbScore = 1;

                        if (_config.IsGF)
                            hbScore *= int.Parse(featuresValue[3]);
                        if (_config.IsTP)
                            hbScore *= (Math.Abs(float.Parse(featuresValue[5]) - float.Parse(featuresValue[4])));
                        if (_config.IsDC)
                            hbScore *= float.Parse(featuresValue[6]);

                        HB.Add(new KeyValuePair<string, double>(featuresValue[1], hbScore));
                        NS.Add(new KeyValuePair<string, double>(featuresValue[1], int.Parse(featuresValue[7])));
                        UP.Add(new KeyValuePair<string, double>(featuresValue[1], int.Parse(featuresValue[9])));




                        tempDHG = new DHGFeatures();
                            //tempDHG.TimeSlotID = slidingWindows.ContainsCandidateDHG(featuresValue[0]);

                            //if (tempDHG.TimeSlotID.Equals("Y"))
                            tempDHG.TimeSlotID = slidingWindows.ContainsCandidateDHG(featuresValue[0]);
                            if (tempDHG.TimeSlotID.StartsWith("Y"))
                            {
                                tempDHG.TimeSlotID = tempDHG.TimeSlotID.Split(new char[] { '$' }, tempDHG.TimeSlotID.Length, StringSplitOptions.RemoveEmptyEntries)[1];
                                tempDHG.DHG_No = featuresValue[0];
                                tempDHG.StartingTime = featuresValue[1];
                                tempDHG.EndingTime = featuresValue[2];
                                tempDHG.GrowthFactor = int.Parse(featuresValue[3]);
                                tempDHG.NegTrendProbability = float.Parse(featuresValue[4]);
                                tempDHG.PosTrendProbability = float.Parse(featuresValue[5]);
                                tempDHG.AggregatedCentrality = float.Parse(featuresValue[6]);
                                tempDHG.TotalNodes = int.Parse(featuresValue[7]);
                                tempDHG.TotalTweets = int.Parse(featuresValue[8]);
                                tempDHG.TotalUsers = int.Parse(featuresValue[9]);

                                // because some of the result i took long ago does not have this infromation written in the files
                                if (featuresValue.Length == 11)
                                    tempDHG.ExecutionTime = int.Parse(featuresValue[10]);
                                else
                                    tempDHG.ExecutionTime = 0;


                            //tempDHG.HeartbeatScore = tempDHG.GrowthFactor * tempDHG.AggregatedCentrality * (tempDHG.PosTrendProbability-tempDHG.NegTrendProbability);
                            //double 
                            hbScore = 1;

                                if (_config.IsGF)
                                    hbScore *= tempDHG.GrowthFactor;
                                if (_config.IsTP)
                                    hbScore *= (Math.Abs(tempDHG.PosTrendProbability - tempDHG.NegTrendProbability));
                                if (_config.IsDC)
                                    hbScore *= tempDHG.AggregatedCentrality;

                                tempDHG.HeartbeatScore = hbScore;
                                DHGs.Add(tempDHG);
                            }
                        }
                    }

                listChartSeries.Add(HB); // Heartbeat
                listChartSeries.Add(NS); // Network Size
                listChartSeries.Add(UP); // User Participation


            }

            catch (Exception ex)
            {
                throw new Exception("Unable to load Sliding Window Features file\n" + ex);
            }
        }

        public ListDHGs Select(string timeSlotID)
        {
            ListDHGs tempDhgs = new ListDHGs();

            foreach(DHGFeatures dhg in DHGs)
            {
                // cross check if it is making shallow copy, because I need shallow copy
                if (dhg.TimeSlotID.Equals(timeSlotID))
                    tempDhgs.DHGs.Add(dhg);
            }

            return tempDhgs;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }
        public ListDHGEnum GetEnumerator()
        {
            return new ListDHGEnum(DHGs);
        }

    }

    public class ListDHGEnum : IEnumerator
    {
        public List<DHGFeatures> listDHG;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public ListDHGEnum(List<DHGFeatures> list)
        {
            listDHG = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < listDHG.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public DHGFeatures Current
        {
            get
            {
                try
                {
                    return listDHG[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
