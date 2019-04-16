using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class WordsUserList
    {
        // word(string) => WordDetails (WordInfo)
        Hashtable _List;

        private static WordsUserList _WordList;

        private WordsUserList()
        {
            _List = new Hashtable();   
        }

        public static WordsUserList GetWordList
        {
            get
            {
                if (_WordList == null)
                    _WordList = new WordsUserList();

                return _WordList;

            }
        }

        public int Count
        {
            get
            {
                return _List.Count;
            }
        }

        public ICollection GetKeys()
        {
            return _List.Keys;
        }

        public WordInfo GetWordInfo(string key)
        {
            return (WordInfo)_List[key];
        }

        public void AddWordsInfo(List<string> words, string user)
        {
            WordInfo wordInfo;

            foreach(string word in words)
            {
                if (_List.ContainsKey(word))
                {
                    wordInfo = (WordInfo)_List[word];
                    wordInfo.AddUser(user);
                    wordInfo.TotalTweets += 1;
                }
                else
                {
                    wordInfo = new WordInfo(word);
                    wordInfo.AddUser(user);
                    wordInfo.TotalTweets += 1;
                    _List.Add(word,wordInfo);
                }
                
            } // end of foreach loop

        }

    }
}
