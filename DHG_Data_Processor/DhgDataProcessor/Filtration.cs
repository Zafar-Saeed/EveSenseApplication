using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class Filtration
    {
        
        
        _Progress progress;
        BagOfWords _BagOfWords;

        Hashtable _DatasetStopWords;

        public Filtration()
        {
            
            //_AllSlidingWindowsKeywords = new List<List<List<string>>>();
            //_SlidingWindowsTimeSpan = new List<KeyValuePair<KeyValuePair<DateTime, DateTime>, List<DateTime>>>();
            //_CurrentSlidingWindowKeywords = new List<List<string>>();
            
            //_DataCleaning = new Cleansing();
            progress = _Progress.GetProgress;
            _BagOfWords = BagOfWords.GetBagOfWords;
            _DatasetStopWords = new Hashtable();
            //_CleanDataSet = new List<KeyValuePair<DateTime, List<string>>>();
        }
        
        public void FilterKeyWords(int threshold)
        {
            lock ( _Util.Locker)
            {
                // activity 2 is for Filtration
                progress.Activity = 2;

                //"Removing keywords those qualitfy as stop words..."
                progress.Message = 1;

                // add code here to remove/ filter tweets + keywords, whatever needed
                // 

            }

        }

        
        public void RemoveFromRepository(string keyword)
        {
            //private List<List<List<string>>> _AllSlidingWindowsKeywords;
            //private List<KeyValuePair<KeyValuePair<DateTime, DateTime>, List<DateTime>>> _SlidingWindowsTimeSpan;

            List<List<string>> tempCurrentSlidingWindowKeywords;
            List<string> currentTweetKeywords;
            KeyValuePair<KeyValuePair<DateTime, DateTime>, List<DateTime>> tempCurrentWindowDateTime;
            //List<DateTime>  

        }

    }
}
