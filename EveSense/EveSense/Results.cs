using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitStatDescriptive;
using StatDescriptive;
using System.Collections;

namespace EveSense
{
    class Evaluation
    {
        public float[] KeywordPercisionAtK { get; set; }
        public float[] KeywordRecallAtK { get; set; }
        public float[] TopicPercisionAtK { get; set; }
        public float[] TopicRecallAtK { get; set; }
        public float[] TopicF1AtK { get; set; }
        public float[] KeywordF1AtK { get; set; }

        public Evaluation(int topK)
        {
            KeywordPercisionAtK = new float[topK];
            KeywordRecallAtK = new float[topK];
            TopicPercisionAtK = new float[topK];
            TopicRecallAtK = new float[topK];
            TopicF1AtK = new float[topK];
            KeywordF1AtK = new float[topK];
        }

        // following are for the testing purpose, just to check if the code is correctly detecting/matching topics and related keywords
        int[] matchedTopics;
        int[] matchedKeywords;

    }

    class Results
    {
        public List<KeyValuePair<string,Evaluation>> FullDatasetRawResults { get; set; }
        public Evaluation FinalResult { get; set; }
        private string _fileName;
        public Results(string fileName)
        {
            _fileName = fileName;
            FullDatasetRawResults = new List<KeyValuePair<string, Evaluation>>();
            
        }

        public StringBuilder GenerateResults(ListDHGs lstDHG, GroundTruth groundTruth, SlidingWindows slidingWindow, Config _config)
        {
            FinalResult = new Evaluation(_config.TopK);

            return DetectEventCandidates(lstDHG, groundTruth, slidingWindow, _config);
        }
        public StringBuilder DetectEventCandidates(ListDHGs lstDHG, GroundTruth groundTruth, SlidingWindows slidingWindow, Config _config)
        {

            double[] currentWinThreshold = new double[]{
                                                        0, // Threshold against Growth factor
                                                        0, // Threshold against Trend Probability
                                                        0, // Threshold against Aggregated Centrality
                                                        0 // Threshold against Fused features as Heartbeat
                                                        };

            //double currentWinThreshold = 0;

            StringBuilder strBuilder = new StringBuilder();
            foreach (SingleWindow win in slidingWindow.ListOfWindows)
            {
                

                // cross check if following LINQ line creates a shallow copy, because I need a SHALLOW COPY
                // and same reference will be passed on to multiple functions. 
                //ListDHGs candidateWindowDHGs = (ListDHGs)lstDHG.DHGs.Where(x => x.TimeSlotID.Equals(win.TimeSlotID));
                ListDHGs candidateWindowDHGs = lstDHG.Select(win.TimeSlotID);

                //candidateWindowDHGs.DHGs[0].IsEventCandidate = true;

                string str = "";
                str += win.TimeSlotID + ",";
                

                //if ( isGrowthFactor)
                //    currentWinThreshold = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => (double)x.GrowthFactor).ToArray<double>(), parameterOmega);
                //else

                //currentWinThreshold = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => x.HeartbeatScore).ToArray<double>(), _config.AdjustmentParameter);


                if (_config.CandidateSelectionCriteria == CandidateSelection.HEARTBEAT)
                {
                    currentWinThreshold[3] = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => x.HeartbeatScore).ToArray<double>(), _config.AdjustmentParameter);

                } else if (_config.CandidateSelectionCriteria == CandidateSelection.FEATURES_BASED_UNION)
                {
                    if ( _config.IsGF)
                    {
                        currentWinThreshold[0] = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => x.GrowthFactor).ToArray<double>(), _config.AdjustmentParameter);
                    }

                    if (_config.IsTP)
                    {
                        currentWinThreshold[1] = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => (x.PosTrendProbability - x.NegTrendProbability)).ToArray<double>(), _config.AdjustmentParameter);
                    }

                    if (_config.IsDC)
                    {
                        currentWinThreshold[2] = win.threshold = CalculateWindowThreshold(candidateWindowDHGs.DHGs.Select(x => x.AggregatedCentrality).ToArray<double>(), _config.AdjustmentParameter);
                    }

                }

                //////////////////////////////////////////////////////////////////////////////////
                ////////////// CANDIDATE EVENT DETECTION USING ADOPTIVE THRESHOLD /////////////////
                //////////////////////////////////////////////////////////////////////////////////

                // Total Candidates Count = 0=>GF, 1=>TP, 2=>AC, 3=>HB, 4=>Union
                double[] totalCandidates = MarkEventCandidates(candidateWindowDHGs, currentWinThreshold, _config);

                CandidateTopics candTopic = new CandidateTopics();

                /////////////////////////////////////////////////////////////////////
                //////////////////// MERGING CANDIDATE DHGs /////////////////////////
                /////////////////////////////////////////////////////////////////////
                foreach (DHGFeatures dhg in candidateWindowDHGs)
                {
                    if ( dhg.IsEventCandidate)
                    {
                        str += dhg.DHG_No + ",";

                        foreach(Term term in dhg.BoW)
                        {
                            int index;
                            if ((index = candTopic.Contains(term.Word)) >= 0)
                            {
                                //if ((float)candTopic.CandidateKeywords[term.Word] < term.Ranking)
                                //    candTopic.CandidateKeywords[term.Word] = term.Ranking;
                                if (candTopic.CandidateKeywords[index].Ranking < term.Ranking)
                                    candTopic.CandidateKeywords[index] = term;
                            }
                            else
                                candTopic.CandidateKeywords.Add(new Term(term));
                        }
                        
                    } 
                } // end of all the DHGs in candidate window

                candTopic.SortRankingWise();
                win.CandidateTopics = candTopic;

                Util.WriteCadidateTopics(candTopic, win.TimeSlotID);

                //candTopic.RemoveBoWBelow(topK);
                ///////////////////////////////////////////////////////////////
                ///// MATCHING RESULTS WITH GROUND TRUTH AND EVALUATING ///////
                ///////////////////////////////////////////////////////////////
                FullDatasetRawResults.Add(
                    new KeyValuePair<string, Evaluation>(
                        win.TimeSlotID,
                        MatchResultWithGroundTruth(
                            (ActualTopics)groundTruth
                            .TimeSlot[win.TimeSlotID],
                            candTopic, 
                            _config.TopK
                        )
                    )
                );
                
                str += ",,THRESHOLD (GF:"+ Math.Round(currentWinThreshold[0],2).ToString() +
                        " | TP:" + Math.Round(currentWinThreshold[1], 2).ToString() +
                        " | AC:" + Math.Round(currentWinThreshold[2], 2).ToString() +
                        " | HB:" + Math.Round(currentWinThreshold[3], 2).ToString() +
                        "  AND  CANDIDATE COUNT (GF:" + totalCandidates[0].ToString() +
                        " | TP:" + totalCandidates[1].ToString() +
                        " | AC:" + totalCandidates[2].ToString() +
                        " | HB:" + totalCandidates[3].ToString() +
                        " | Union:" + totalCandidates[4].ToString() + ")\n";
                strBuilder.Append(str);

            }

            MicroAveragingResults(_config.TopK);
            
            Util.WriteFinalResults(FinalResult, _fileName, _config, strBuilder);
            

            return strBuilder;
        }

        private double CalculateWindowThreshold(double[] list, double parameterOmega)
        {
            //lstDHG.DHGs.Select(x => x.HeartbeatScore).ToArray<double>()
            if (list.Length == 1)
                return list[0];

            Descriptive desp = new Descriptive(list);
            desp.Analyze();

            return desp.Result.Mean + parameterOmega * desp.Result.StdDev;
        }

        private double[] MarkEventCandidates(ListDHGs lstDHGs, double[] threshold, Config _config)
        {
            //Vary bad logic, shame on me :( 
            // Just focusing on getting work done, therfore doesn't care for the performance at this point
            // I could have used preprocessor directives for conditional inclusion of the code

            bool isEventCandidate;          
                                                  // GF, TP, AC, HB, Total
            double[] totalCandidates = new double[] {0 , 0 , 0 , 0 , 0 };

            foreach (DHGFeatures current in lstDHGs)
            {
                isEventCandidate = false;

                if ( !(_config.CandidateSelectionCriteria == CandidateSelection.SELECT_ALL))
                {
                    if (_config.CandidateSelectionCriteria == CandidateSelection.FEATURES_BASED_UNION)
                    {
                        if (_config.IsGF && current.GrowthFactor > threshold[0])
                        {
                            isEventCandidate = true;
                            totalCandidates[0] += 1;
                        }

                        if (_config.IsTP && current.TrendProbability > threshold[1])
                        {
                            isEventCandidate = true;
                            totalCandidates[1] += 1;
                        }
                        if (_config.IsDC && current.AggregatedCentrality > threshold[2])
                        {
                            isEventCandidate = true;
                            totalCandidates[2] += 1;
                        }
                    }
                    else
                    {
                        if (current.HeartbeatScore >= threshold[3])
                        {
                            isEventCandidate = true;
                            totalCandidates[3] += 1;
                        }
                    }
                }
                else
                {
                    // this block will be reached only if IsSelectAll option is checked.
                    isEventCandidate = true;
                }
                
                if (isEventCandidate)
                {
                    current.IsEventCandidate = true;
                    current.SortRankingWise(_config.IsDTFRanking, _config.IsDCRanking);
                    current.RemoveBoWBelow(_config.TopK);
                    totalCandidates[4] += 1;
                }
            }
            return totalCandidates;
        }

        private Evaluation MatchResultWithGroundTruth(ActualTopics actualTopics, CandidateTopics candTopics, int topK)
        {

            Evaluation eval = new Evaluation(topK);
            int topicHitCount = 0;
            int keywordHitCount = 0;

            for (int top = 0; top < topK; top++)
            {

                actualTopics.Match(candTopics.CandidateKeywords[top].Word ,ref topicHitCount,ref keywordHitCount);
                eval.KeywordPercisionAtK[top] = keywordHitCount / (float)(top+1); // top+1 because index starts from 0 in array
                eval.KeywordRecallAtK[top] = keywordHitCount / (float)actualTopics.TotalKeywords;
                eval.TopicPercisionAtK[top] = topicHitCount / (float)(top + 1);
                eval.TopicRecallAtK[top] = topicHitCount / (float)actualTopics.TotalTopics;

                if (eval.KeywordPercisionAtK[top] > 0 || eval.KeywordRecallAtK[top] > 0)
                    eval.KeywordF1AtK[top] = 2 * (eval.KeywordPercisionAtK[top] * eval.KeywordRecallAtK[top]) / (eval.KeywordPercisionAtK[top] + eval.KeywordRecallAtK[top]);
                else
                    eval.KeywordF1AtK[top] = 0;

                if (eval.TopicPercisionAtK[top] > 0 || eval.TopicRecallAtK[top] > 0)
                    eval.TopicF1AtK[top] = 2 * (eval.TopicPercisionAtK[top] * eval.TopicRecallAtK[top]) / (eval.TopicPercisionAtK[top] + eval.TopicRecallAtK[top]);
                else
                    eval.TopicF1AtK[top] = 0;
            }

            return eval;
        }
        
        private void MicroAveragingResults(int topK)
        {
            float sumOfKPreAtK;
            float sumOfKRecAtK;
            float sumOfTPreAtK;
            float sumOfTRecAtK;
            float sumOfKF1AtK;
            float sumOfTF1AtK;

            int totalGroundTruthTimeSlots = FullDatasetRawResults.Count;
            for (int top = 0; top < topK; top++) 
            {
                sumOfKPreAtK = 0;
                sumOfKRecAtK = 0;
                sumOfTPreAtK = 0;
                sumOfTRecAtK = 0;
                sumOfKF1AtK = 0;
                sumOfTF1AtK = 0;

                for (int res = 0; res < totalGroundTruthTimeSlots; res++)
                {
                    sumOfKPreAtK += FullDatasetRawResults[res].Value.KeywordPercisionAtK[top];
                    sumOfKRecAtK += FullDatasetRawResults[res].Value.KeywordRecallAtK[top];
                    sumOfTPreAtK += FullDatasetRawResults[res].Value.TopicPercisionAtK[top];
                    sumOfTRecAtK += FullDatasetRawResults[res].Value.TopicRecallAtK[top];
                    sumOfKF1AtK += FullDatasetRawResults[res].Value.KeywordF1AtK[top];
                    sumOfTF1AtK += FullDatasetRawResults[res].Value.TopicF1AtK[top];
                }

                FinalResult.KeywordPercisionAtK[top] = sumOfKPreAtK / totalGroundTruthTimeSlots;
                FinalResult.KeywordRecallAtK[top] = sumOfKRecAtK / totalGroundTruthTimeSlots;
                FinalResult.TopicPercisionAtK[top] = sumOfTPreAtK / totalGroundTruthTimeSlots;
                FinalResult.TopicRecallAtK[top] = sumOfTRecAtK / totalGroundTruthTimeSlots;
                FinalResult.KeywordF1AtK[top] = sumOfKF1AtK / totalGroundTruthTimeSlots;
                FinalResult.TopicF1AtK[top] = sumOfTF1AtK / totalGroundTruthTimeSlots;
            }
        }
    }
}
