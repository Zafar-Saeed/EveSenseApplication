using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class BagOfWords
    {
        //List<string> _WordsList;
        //List<int> _TFsList;

        public Hashtable _TweetWords { get; set; }
        public Hashtable _RemoveWords { get; set; }
        public Hashtable _FilteredOutWords { get; set; }

        private static BagOfWords _BagOfWords;

        private BagOfWords()
        {
            //_WordsList = new List<string>();
            //_TFsList = new List<int>();

            // both of the following have strings as keys and float as frequency
            _TweetWords = new Hashtable();
            _RemoveWords = new Hashtable();
            _FilteredOutWords = new Hashtable();
                
        }

        public static BagOfWords GetBagOfWords
        {
            get
            {
                if (_BagOfWords == null)
                    _BagOfWords = new BagOfWords();

                return _BagOfWords;

            }
        }

        //public KeyValuePair<string,int> this[int index]
        //{
        //    get
        //    {
        //        if (index < _WordsList.Count)
        //            return new KeyValuePair<string, int>(_WordsList[index], _TFsList[index]);
        //        else
        //            return new KeyValuePair<string,int>("",-1);

        //    }

        //    set
        //    {
        //        _WordsList[index] = value.Key;
        //        _TFsList[index] = value.Value;
        //    }

        //}
        
        public int Count
        {
            get
            {
                return _TweetWords.Count; // _WordsList.Count;
            }
        }

        public int GetWordTF(string word)
        {
            //if (_WordsList.Contains<string>(word))
            //    return _WordsList.IndexOf(word);
            //else
            //    return -1;

            if (_TweetWords.ContainsKey(word))
                return (int)_TweetWords[word];
            else
                return -1;

        }

        //public int GetIndexOf(string word)
        //{
        //    if (_WordsList.Contains<string>(word))
        //        return _WordsList.IndexOf(word);

        //    return -1;
        //}

        public void Add(string word)
        {
            //if (_WordsList.Contains<string>(word))
            //{
            //    int index = _WordsList.IndexOf(word);
            //    _TFsList[index] += 1;
            //}
            //else
            //{
            //    _WordsList.Add(word);
            //    _TFsList.Add(1);
            //}

            if (_TweetWords.ContainsKey(word))
                _TweetWords[word] = (float)_TweetWords[word] + 1;
            else
                _TweetWords.Add(word,1f);
             
        }

        private void SortByTF()
        {
            //int tempTF;
            //string tempKeyword;

            //for (int i = 0; i < _TFsList.Count - 1; i++)
            //{
            //    for (int j = 0; j < _TFsList.Count - i - 1; j++)
            //    {
            //        if (_TFsList[j] > _TFsList[j + 1]) /* For Ascending order use < */
            //        {
            //            tempTF = _TFsList[j];
            //            _TFsList[j] = _TFsList[j + 1];
            //            _TFsList[j + 1] = tempTF;

            //            tempKeyword = _WordsList[j];
            //            _WordsList[j] = _WordsList[j + 1];
            //            _WordsList[j + 1] = tempKeyword;
            //        }
            //    } // end of for loop j
            //} // end of for loop i
        }

        public void RemoveFromBagOfWordsUnderThreshold(int threshold)
        {

           // I need to finish this function properly, it is not fully completed or test yet
           // This function is useful when droping words under certain threshold
            
            ArrayList keys = new ArrayList(_TweetWords.Keys);
            foreach (int key in keys)
            {
                if ( (int)_TweetWords[key] < threshold)
                {
                    _RemoveWords.Add(key, (int)_TweetWords[key]);
                    _TweetWords.Remove(key);
                }
                
            }
            
        }
        
    } // end of BagOfWords Class
}
