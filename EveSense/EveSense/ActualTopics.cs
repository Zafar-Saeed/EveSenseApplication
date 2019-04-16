using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EveSense
{
    class ActualTopics
    {

        private Porter2Stemmer.EnglishPorter2Stemmer _stemmer;
        // following Regex for removing "@" and "#" sign which I didn't earlier in data pre-processing
        Regex pattern = new Regex("[@#]");
        public ActualTopics()
        {

            HasOptionalWords = false;
            ActualTopicList = new List<Topic>();
            TotalKeywords = 0;
            OtherOptionalWords = new List<string>();
            IsOtherOptionalWordsHit = new List<bool>();
            _stemmer = new Porter2Stemmer.EnglishPorter2Stemmer();
        }

        public List<Topic> ActualTopicList { get; set; }
        public int TotalKeywords { get; private set; }

        public int TotalTopics
        {
            get
            {
                return ActualTopicList.Count;
            }
        }

        public bool HasOptionalWords { get; private set; }

        public List<string> OtherOptionalWords { get; private set; }

        public List<bool> IsOtherOptionalWordsHit { get; private set; }

        public bool LoadMendatoryWords(string line)
        {
            try
            {
                string[] topics = line.Split(new char[] { ',' }, line.Length, StringSplitOptions.RemoveEmptyEntries);
                Topic tempTopic;

                foreach (string topic in topics)
                {
                    if (topic[0] == '[' && topic[topic.Length - 1] == ']')
                    {
                        string[] tempTopicKeywords = topic.Substring(1, topic.Length - 2).Split(new char[] { ' ' },topic.Length,StringSplitOptions.RemoveEmptyEntries);

                        TotalKeywords += tempTopicKeywords.Length;
                        tempTopic = new Topic();
                        for(int ind = 0; ind < tempTopicKeywords.Length; ind ++)
                        {
                            tempTopic.AddTopic(
                                _stemmer.Stem(
                                    tempTopicKeywords[ind]
                                        .Replace("@", "")
                                        .Replace("#", "")
                                        .ToLower()
                                ).Value
                            );
                        }

                        ActualTopicList.Add(tempTopic);
                    }
                    else
                        throw new Exception("The topic is not in proper format");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool LoadOptionalWords(string line)
        {
            try
            {
                // 3 is not a magic number, it's just to make sure that the white space(s) are considered as optional keywords mistakenly
                if (line.Length > 3)
                {
                    HasOptionalWords = true;
                    string[] tempKeywords = line.Split(new char[] { ',' },line.Length,StringSplitOptions.RemoveEmptyEntries);
                    TotalKeywords += tempKeywords.Length;

                    for (int ind = 0; ind < tempKeywords.Length; ind++)
                    {
                        OtherOptionalWords.Add(
                            _stemmer.Stem(
                                tempKeywords[ind]
                                    .Replace("@", "")
                                    .Replace("#", "")
                                    .ToLower()
                            ).Value
                        );

                        IsOtherOptionalWordsHit.Add(false);
                        
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public void Match(string candidateWord, ref int topicHitCount, ref int keywordHitCout)
        {
            candidateWord = candidateWord.Replace("@", "").Replace("#", "");
            int tempKeyIndex;
            foreach(Topic t in ActualTopicList)
            {
                // apply the condition for handling "win" and "won", they are still there as a separate words in the results.
                if ( (tempKeyIndex = t.TopicKeywords.IndexOf(candidateWord)) >= 0 )
                {
                    if (!t.TopicKeywordHit[tempKeyIndex])
                    {
                        t.TopicKeywordHit[tempKeyIndex] = true;
                        keywordHitCout++;
                    }

                    if ( !t.Hit)
                    {
                        t.Hit = true;
                        topicHitCount++;
                    }
                }
            }

            if (HasOptionalWords)
            {
                if ((tempKeyIndex = OtherOptionalWords.IndexOf(candidateWord)) >= 0)
                {
                    if (!IsOtherOptionalWordsHit[tempKeyIndex])
                    {
                        keywordHitCout++;
                        IsOtherOptionalWordsHit[tempKeyIndex] = true;
                    }
                    
                }
            }

        }

    }

}
