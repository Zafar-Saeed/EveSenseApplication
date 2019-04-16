using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Porter2Stemmer;
using System.Globalization;
using System.IO;

namespace DhgDataProcessor
{
    class Cleansing
    {

        private Hashtable CommonAndstopWords { get; set; }
        //private char[] dirtyCharacters = { '^','?' , '(' , ')' , '!' , '&' , '\'' , ' ' , '\"' , '$' , ',' , '.' , '/' , '[' , ']' , ';' , '*',':'}; // add all dirty characters in this list
        private string acceptableCharactersRegex = "[^0-9a-zA-Z-#]+"; // add all acceptable characters in this Regex
        private EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();
        //private string commonAndStopWordFile = @"D:\PhD\Research\UTS Work\StopWordsFile.txt";
        private string commonAndStopWordFile = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory) + "StopWordsFile.txt";
        //Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\")) +  "StopWordsFile.txt";

        private WordsUserList _wordsUserList;
        private UsersWordList _usersWordList;
        
        // it would contains all keywords, their TFs, Dataset stopwords and their TFs
        BagOfWords _BagOfWords;

        public Cleansing(string filePath)
        {
            CommonAndstopWords = LoadStopWords(filePath);
            _BagOfWords = BagOfWords.GetBagOfWords;
            _wordsUserList = WordsUserList.GetWordList;
            _usersWordList = UsersWordList.GetUserList;
        }

        public Cleansing()
        {
            
            CommonAndstopWords = LoadStopWords(commonAndStopWordFile);
            _BagOfWords = BagOfWords.GetBagOfWords;
            _wordsUserList = WordsUserList.GetWordList;
            _usersWordList = UsersWordList.GetUserList;
        }

        // following function is not needed
        public void AddStopWord(string str)
        {
            CommonAndstopWords.Add(str, 0);
        }

        public Hashtable LoadStopWords(string filePath)
        {
            Hashtable hashList = new Hashtable();

            string line;
            System.IO.StreamReader file =
               new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                hashList.Add(line.ToLower().Trim(), 0);
            }

            file.Close();


            return hashList;
        }
        

        public bool ContainsURL(string tweet)
        {
            return Regex.Match(tweet, @"http[^\s]+").Success;
        }

        public Tweet CleanTweet(string tweet, bool stemmingFlag, Filter filter, int minWordLength)
        {
            
            List<string> tweetWords = new List<string>();
            string userName = "";
            DateTime tweetDate;
            string[] words;

            // initialized with default, just in case tweet does not qualify for parsing. It is a bad approach though, but works for the time being
            Tweet currentTweet = null;
            //////           Extract tweet fregments 

            // tweets without URLs are considered. Assumption: tweets with URLs are probably advertisments
            if (!ContainsURL(tweet))
            {
                
                string dateString = tweet.Substring(0, 29);
                tweetDate = _Util.ConvertToDate(dateString);

                // left with user name and tweet contents
                tweet = tweet.Substring(30, tweet.Length - 30);

                // spliting different parts of tweet => first item is user name and second item is tweet
                words = tweet.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                userName = words[0];

                // split here on all dirty characters including space
                //words = words[1].Split(dirtyCharacters, StringSplitOptions.RemoveEmptyEntries);
                
                words = Regex.Replace(words[1], acceptableCharactersRegex, " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                bool dropFlag;

                foreach (string str in words)
                {
                    int tempNumericCheck;

                    string keyword = str.Trim().ToLower();

                    // it will also remove numbers
                    if (!IsStopWord(keyword) && !tweetWords.Contains<string>(keyword) && !int.TryParse(keyword, out tempNumericCheck))
                    {
                        
                        dropFlag = false;

                        // only word droping filter will work here
                        // rest of the filter types will work only when all of the data is extracted
                        if (filter == Filter.WORDS)
                        {
                            if ( _BagOfWords._RemoveWords.ContainsKey(keyword))
                            {
                                _BagOfWords._RemoveWords[keyword] = Convert.ToSingle(_BagOfWords._RemoveWords[keyword]) + 1f;
                                dropFlag = true;
                            }
                        }

                        if (keyword.Length < minWordLength)
                        {
                            // if length of word does not qualitfy, then simply add it in to list of stop words, and set frequency if already existed
                            if (_BagOfWords._FilteredOutWords.ContainsKey(keyword))
                                _BagOfWords._FilteredOutWords[keyword] = Convert.ToSingle(_BagOfWords._FilteredOutWords[keyword]) + 1f;
                            else
                                _BagOfWords._FilteredOutWords.Add(keyword, 1f);

                            dropFlag = true;
                        }

                        // if tweet word is not in filter word
                        if (!dropFlag)
                        {
                            if (stemmingFlag)
                            {
                                keyword = stemmer.Stem(keyword).Value;
                            }

                            _BagOfWords.Add(keyword);
                            tweetWords.Add(keyword);
                        }

                        
                    } // end of stopword, duplicate and numeric condition check
                }// end of foreach word in tweet

                //tweet must contain atleast on word
                if (tweetWords.Count > 0)
                {
                    _wordsUserList.AddWordsInfo(tweetWords, userName);
                    _usersWordList.AddUserInfo(userName, tweetWords);

                    currentTweet = new Tweet(tweetDate, userName, tweetWords);
                    
                }

            } // end of URL check condition

            
            return currentTweet;
        }
     
        public Tweet LoadCleanTweet(string tweet, Filter filter, int minWordLength)
        {
            List<string> tweetWords = new List<string>();
            string userName = "";
            DateTime tweetDate;
            string[] words;

            // initialized with default, just in case tweet does not qualify for parsing. It is a bad approach though, but works for the time being
            Tweet currentTweet = null;
            //////           Extract tweet fregments 

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // FOLLOWING IS OLD ROUTINE, IT IS NOT WORKING FOR EVERY DATASET, SINCE THERE ARE LITTLE CHANGES IN DATES (I.E. DOUBLE FIGURE ISSUE, WHICH CHANGES THE STRING LENGTH)
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //string dateString = tweet.Substring(0, 21);
            //tweetDate = Convert.ToDateTime(dateString);

            //// left with user name and tweet contents
            //tweet = tweet.Substring(22, tweet.Length - 22);

            //// spliting different parts of tweet => first item is user name and second item is tweet
            //words = tweet.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //userName = words[0];

            //// split here on space only, because dataset is already cleaned
            //words = words[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////
            ////// REDEFINING ABOVE RUTINES /////
            /////////////////////////////////////
            
            words = tweet.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            
            //CultureInfo culture = new CultureInfo("en-US");

            IFormatProvider culture = new CultureInfo("en-US", true);

            // Alternate choice: If the string has been input by an end user, you might    
            // want to format it according to the current culture:   
            // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;  
            DateTime dt2 = tweetDate = DateTime.Parse(words[0], culture);


            // spliting different parts of tweet => first item is user name and second item is tweet

            userName = words[1];

            ////////////////////////////    Modified: 19-Oct-2017    ///////////////////////////////////////
            // Since I could clean the data effectively that's why I am addig following code,
            // Following code is already added in "CleanTweet" function which is responsible for cleaning tweet contents
            // If cleaning process is executed again for cleaning underlying (FA_CUP, ST, US_Ele) datasets then following lines are no longer needed
            // After removing following two lines, then again uncomment previously used line for spliting on behalf of space only
            string acceptableCharactersRegex = "[^0-9a-zA-Z-#@]+"; // add all acceptable characters in this Regex
            words = Regex.Replace(words[2], acceptableCharactersRegex, " ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // split here on space only, because dataset is already cleaned
            //words = words[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ///////////////////////////////////// END OF 19-Oct-2017 ///////////////////////////////////////
            
            bool dropFlag = false;

            foreach (string str in words)
            {
            
                string keyword = str.Trim().ToLower();

                dropFlag = false;
             
                // only word droping filter will work here
                // rest of the filter types will work only when all of the data is extracted
                if (filter == Filter.WORDS)
                {
                    if (_BagOfWords._RemoveWords.ContainsKey(keyword))
                    {
                        _BagOfWords._RemoveWords[keyword] = Convert.ToSingle(_BagOfWords._RemoveWords[keyword]) + 1f;
                        dropFlag = true;
                    }
                }
                
                // if tweet word is not in filter word
                if (!dropFlag)
                {
                    _BagOfWords.Add(keyword);
                    tweetWords.Add(keyword);
                }
             
            }// end of foreach word in tweet

            //tweet must contain atleast one word
            if (tweetWords.Count > 0)
            {
                _wordsUserList.AddWordsInfo(tweetWords, userName);
                _usersWordList.AddUserInfo(userName, tweetWords);

                currentTweet = new Tweet(tweetDate, userName, tweetWords);

            }
             
            //2743
            
            if ( currentTweet == null)
            {
                int dummy = 0;
            }   

            return currentTweet;
        }

        private bool IsStopWord(string str)
        {
            if (CommonAndstopWords.Contains(str.ToLower()))
                return true;
            else
                return false;
        }
    }
}
