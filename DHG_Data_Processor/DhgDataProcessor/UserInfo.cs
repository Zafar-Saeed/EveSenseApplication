using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class UserInfo
    {
        public string Name { get; set; }
        public int TotalTweets { get; set; }

        //int _AuthorshipScore = 0;
        //public int AuthorshipScore { get; }

        // in case of _Graph, I am storing indexes of Nodes as keys in Hashtable
        // in case of UsersWordList, I am storing Node Names as keys in Hashtable
        Hashtable _WordsAndTF = new Hashtable();


        public UserInfo(string name, List<string> words)
        {
            TotalTweets = 0;
            Name = name;
            
            foreach (string word in words)
                AddWord(word);
        }

        public UserInfo()
        {
            TotalTweets = 0;
        }

        public UserInfo(string name)
        {
            TotalTweets = 0;
            Name = name;
        }
        public int GetTotalUniqueWords
        {
            get
            {
                return _WordsAndTF.Count;
            }
            
        }

        public void AddWord(string word)
        {
            if (_WordsAndTF.ContainsKey(word))
                _WordsAndTF[word] = (int)_WordsAndTF[word] + 1;
            else
                _WordsAndTF.Add(word, 1);
        }

        public void AddWords(List<string> words)
        {
            foreach (string word in words)
                AddWord(word);
        }

        // overloaded methods for in case UserInfo class is used by Graph class
        public void AddWord(int word)
        {
            if (_WordsAndTF.ContainsKey(word))
                _WordsAndTF[word] = (int)_WordsAndTF[word] + 1;
            else
                _WordsAndTF.Add(word, 1);
        }

        public void AddWords(List<int> words)
        {
            foreach (int word in words)
                AddWord(word);
        }

        // following method must have an overloaded method in case when UserInfo class is used by Graph class
        public int FindAuthorshipScore()
        {
            // not implemented yet
            return 0;
        }

    }
}
