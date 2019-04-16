using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    public class CandidateTopics
    {

        // need to change Hashtable data structure because it is not suitable for sorting
        //DONE

        public CandidateTopics()
        {
            CandidateKeywords = new List<Term>();
        }
        
        //string=> word , float=> ranking score
        public List<Term> CandidateKeywords
        {
            get; set;
        }

        public int Contains(string word)
        {
            return CandidateKeywords.FindIndex(t => t.Word.Equals(word));


            //return CandidateKeywords.Where(t => t.Word.Equals(word));
            //var result = CandidateKeywords.Where(kvp => kvp.Key.Equals(word));

            //if (result != null)
            //    return (result.First().Value);
            //else
            //    return null;
        }

        public void SortRankingWise()
        {
            CandidateKeywords = CandidateKeywords.OrderByDescending(t => t.Ranking).ToList();
        }

        public void RemoveBoWBelow(int top)
        {
            for (int i = CandidateKeywords.Count - 1; i >= top; i--)
                CandidateKeywords.RemoveAt(i);
        }

    }
}
