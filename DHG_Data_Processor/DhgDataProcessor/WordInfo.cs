using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class WordInfo
    {
        public string Word { get; set; }
        public int TotalTweets { get; set; }

        int _WordEntropy = 0;
        public int WordEntropy { get; }
        Hashtable _Users = new Hashtable();

        public WordInfo(string userName, string word)
        {
            
            TotalTweets = 0;
            Word = word;
            _Users.Add(userName, 1);
            
        }

        public WordInfo(string word)
        {
            
            TotalTweets = 0;
            Word = word;

        }

        public WordInfo()
        {
            TotalTweets = 0;
        }

        public void AddUser(string userName)
        {
            if (_Users.ContainsKey(userName))
                _Users[userName] = (int)_Users[userName] + 1;
            else
                _Users.Add(userName, 1);
        }

        public int TotalUsers
        {
            get
            {
                return _Users.Count;
            }
            
        }

        public int FindWordEntropy()
        {
            // not implemented yet
            return 0;
        }

    }
}
