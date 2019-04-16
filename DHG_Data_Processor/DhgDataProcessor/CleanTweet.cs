using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class Tweet
    {
        public DateTime TweetDate { get; set; }
        public string UserName { get; set; }
        List<string> _Words = new List<string>();

        public List<string> TweetWords
        {
            get { return _Words; }
            set { _Words = value; }
        }

        public Tweet(DateTime dt, string uName, List<string> words)
        {
            TweetDate = dt;
            UserName = uName;
            _Words = words;
        }

        public string TweetToString()
        {
            
            return TweetDate.ToString() + "\t";
        }

    }
}
