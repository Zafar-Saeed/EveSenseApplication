using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{

    class EdgeInfo: IDisposable
    {
        
        public short TweetWeight { get; set; }
        public short UserWeight { get; set; }

        //key is userID (index) of Graph._UserList, value is number of times user is contributing in making of this edge
        // outlier users can be detected here too

        //public Hashtable Users { get; set; }

        ~EdgeInfo()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                //if ( Users != null)
                //Users = null;
            }
            // free native resources if there are any.
        }

        public EdgeInfo(int userID)
        {
            //Weight = 0;
            TweetWeight = 1;
            //Users = new Hashtable();
            //Users.Add(userID, 1);
            UserWeight = 1;
        }

        public EdgeInfo(EdgeInfo edge)
        {
            //Weight = edge.Weight;
            TweetWeight = edge.TweetWeight;
            UserWeight = edge.UserWeight;

            //Users = new Hashtable();

            ////deep copy
            //foreach(object key in edge.Users.Keys)
            //{
            //    Users.Add(key, Users[key]);
            //}

        }

        public EdgeInfo(int tW, int uW)
        {
            //Weight = w;
            TweetWeight = (short)tW;
            UserWeight = (short)uW;

            //Users = new Hashtable();

            //// there is a case when g_1 - g_0, where g_1[r,c] is null, then "null" is passed in userList
            //if ( uList != null)
            //{
            //    //deep copy
            //    foreach (object key in uList.Keys)
            //    {
            //        Users.Add(key, Users[key]);
            //    }
            //}
            
        }
        
        //public int UserCount
        //{
        //    get { return Users.Count; }
        //}

        public float CalculateWeight()
        {
            // not implemented yet
            return 0;
        }

        //public void AddUserInfo(int userID)
        //{
        //    if (!Users.ContainsKey(userID))
        //    {
        //        Users.Add(userID, 1);

        //        // count unique users
        //        UserWeight += 1;
        //    }
        //    else
        //        Users[userID] = (int)Users[userID] + 1; // count contribution of existing user
        //}
        
    }
}
