using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class UsersWordList
    {
        // userName(string) => UserDetails (UserInfo)
        Hashtable _List;

        private static UsersWordList _UsersWordList;

        private UsersWordList()
        {

            _List = new Hashtable();


        }

        public static UsersWordList GetUserList
        {
            get
            {
                if (_UsersWordList == null)
                    _UsersWordList = new UsersWordList();

                return _UsersWordList;

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

        public UserInfo GetUser(string key)
        {
            return (UserInfo)_List[key];
        }

        public void AddUserInfo(string userName, List<string> words)
        {
            UserInfo user;

            if (_List.ContainsKey(userName))
            {
                user = (UserInfo)_List[userName];
                user.AddWords(words);
                user.TotalTweets += 1;
            }
            else
            {
                user = new UserInfo(userName);
                user.AddWords(words);
                user.TotalTweets += 1;
                _List.Add(userName, user);
            }  
            

        }
    }

    
}
