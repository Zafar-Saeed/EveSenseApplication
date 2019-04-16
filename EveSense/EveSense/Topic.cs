using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    public class Topic
    {

        //public Topic(string[] words)
        //{
          //  Hit = false;
            //TopicKeywords = words.ToList<string>();
            //TopicKeywordHit = new bool[TopicKeywords.Count];

//        }

        public Topic()
        {
            Hit = false;
            TopicKeywords = new List<string>();
            TopicKeywordHit = new List<bool>();

        }

        public void AddTopic(string word)
        {
            TopicKeywords.Add(word);
            TopicKeywordHit.Add(false);
        }

        public bool Hit
        {
            get; set;
        }

        public List<string> TopicKeywords
        {
            get; set;
        }

        public List<bool> TopicKeywordHit
        {
            get; set;
        }

    }
}
