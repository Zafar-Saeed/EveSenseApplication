using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{

    // this class is usefull if too much memory is consuming
    // I need to override few mothods and operators to make it more useful
    //class _NodeList
    //{
    //    private List<string> nodes;
    //    private static _NodeList nodeList;
        
    //    public int Count
    //    {
    //        get
    //        {
    //            return nodes.Count;
    //        }
    //    }

    //    private _NodeList()
    //    {
    //        nodes = new List<string>();
    //    }
    //    public _NodeList GetNodeList
    //    {
    //        get
    //        {
    //            if (nodeList == null)
    //            {
    //                nodeList = new _NodeList();
    //                return nodeList;
    //            }
    //            else
    //                return nodeList;
    //        }
    //    } 

    //    public void Add(string nodeName)
    //    {
    //        nodes.Add(nodeName);
    //    }

    //    public int IndexOf(string nodeName)
    //    {
    //        return nodes.IndexOf(nodeName);
    //    }

    //    public string this[int index]
    //    {
    //        get
    //        {
    //            return nodes[index];
    //        }
    //        set
    //        {
    //            nodes[index] = value;
    //        }
    //    }

    //}

    class _Graph
    {
        public Hashtable _AdjucencyList { get; set; }
        public List<KeyValuePair<int,float>> _CenteralityScores { get; set; }

        // DO NOT USE HASHTABL FOR _NodeList, BECAUSE INDEXES OF ELEMENTS IN _NodeList 
        // ARE USED AS KEY IN _AdjucencyList TO IMPROVE PERFORMANCE AND SAVE MEMORY BOTH 
        public List<NodeInfo> _NodeList { get; set; }

        public DateTime _WindowStartTime { get; set; }
        public DateTime _WindowEndTime { get; set; }
        public List<UserInfo> _UserList { get; set; }

        public long _ExecutionTime { get; set; }
        
        public int TotalNodes
        {
            get
            {
                return _NodeList.Count;
            }
        }

        public int TotalTweets
        {
            get
            {
                int sumOfTweets = 0;
                foreach(UserInfo user in _UserList)
                {
                    sumOfTweets += user.TotalTweets;
                }

                return sumOfTweets;
            }
        }

        public int TotalUsers
        {
            get
            {
                return _UserList.Count;
            }
        }
        
        public int GetUserTweetCount(int userID)
        {
            return _UserList[userID].TotalTweets;
        }

        public float[][] GetAdjucencyMatrix()
        {
            // add code here to create and return adjucency matrix
            float[][] adjMatrix = _Util.Create2DArray(_NodeList.Count, _NodeList.Count);

            Hashtable edgeList;
            int sourceNodeIndex, targetNodeIndex;
            int currentRowIndex = 0;

            foreach (int nodeID in _AdjucencyList.Keys)
            {
                sourceNodeIndex = nodeID;

                edgeList = (Hashtable)_AdjucencyList[nodeID];
                

                foreach (int nodeIDinEdge in edgeList.Keys)
                {
                    targetNodeIndex = nodeIDinEdge;
                    // change here with respect to new EdgeInfo Class
                    adjMatrix[sourceNodeIndex][targetNodeIndex] = Convert.ToSingle(edgeList[nodeIDinEdge]);
                }

            }

            return adjMatrix;
        }

        public _Graph()
        {

            _ExecutionTime = 0;
            _AdjucencyList = new Hashtable();
            _CenteralityScores = new List<KeyValuePair<int,float>>();
            _NodeList = new List<NodeInfo>();
            _UserList = new List<UserInfo>();
        }

        public _Graph(EdgeInfo[,] graphMatrix, List<NodeInfo> nodes, List<UserInfo> userList) : this()
        {
            _ExecutionTime = 0;
            int rows = graphMatrix.GetLength(0);
            int cols = graphMatrix.GetLength(1);

            Hashtable list;

            for (int i = 0; i < rows; i++)
            {
                list = new Hashtable();
                for (int j = 0; j < cols; j++)
                    if (graphMatrix[i,j] != null)
                        list.Add(j, new EdgeInfo(graphMatrix[i,j]));

                _AdjucencyList.Add(i, list);
            }

            _NodeList = nodes;

            // in creating windows difference graph, userList would be of second window
            _UserList = userList;
        }

        public _Graph(EdgeInfo[][] graphMatrix, List<NodeInfo> nodes, List<UserInfo> userList) : this()
        {
            _ExecutionTime = 0;
            int rows = graphMatrix.GetLength(0);
            int cols = rows;

            Hashtable list;

            for (int i = 0; i < rows; i++)
            {
                list = new Hashtable();
                for (int j = 0; j < cols; j++)
                    if (graphMatrix[i][j] != null)
                        list.Add(j, new EdgeInfo(graphMatrix[i][j]));

                _AdjucencyList.Add(i, list);
            }

            _NodeList = nodes;

            // in creating windows difference graph, userList would be of second window
            _UserList = userList;
        }

        public _Graph(float[][] graphMatrix, List<NodeInfo> nodes) : this()
        {
            _ExecutionTime = 0;

            // this function also needs changes with respect to new added class EdgeInfo

            int rows = graphMatrix.Length;
            int cols = graphMatrix[0].Length;

            Hashtable list;
            
            for(int i = 0; i < rows; i++)
            {
                list = new Hashtable();
                for(int j = 0; j < cols; j++)
                    if ( graphMatrix[i][j] !=0)
                        list.Add(j, graphMatrix[i][j]);

                _AdjucencyList.Add(i, list);
            }

            _NodeList = nodes;
        }

        public void Union(List<NodeInfo> list1, List<NodeInfo> list2)
        {
            NodeInfo n;
            int nodeIndex;

            for(int i = 0; i < list2.Count; i++)
            {
                n = list2[i];

                nodeIndex = ContainNode(list1, n);

                // if does not exist then add new with node weight 1, otherwise add 1 to its existing weight
                if (nodeIndex == -1)
                    list1.Add(new NodeInfo(n.NodeName, 1));
                else
                    list1[nodeIndex].NodeWeight += 1;
            }
        }

        //this function returns index if node exists in List, otherwise return -1
        private int ContainNode(List<NodeInfo> list, NodeInfo node)
        {
            NodeInfo n;

            for (int i = 0; i< list.Count; i++)
            {
                n = list[i];

                if (n.IsMatch(node))
                    return i;
            }

            return -1;
        }

        public UserInfo UpdateUserInfo(string userName, List<int> indexNodeList)
        {
            UserInfo currentUser = null;

            foreach (UserInfo user in _UserList)
            {
                if (user.Name.Equals(userName))
                {
                    currentUser = user;
                    currentUser.TotalTweets += 1;
                    currentUser.AddWords(indexNodeList);
                    break;
                }
            }

            if (currentUser == null)
            {
                currentUser = new UserInfo();
                currentUser.Name = userName;
                currentUser.TotalTweets = 1;
                currentUser.AddWords(indexNodeList);
                _UserList.Add(currentUser);
            }

            return currentUser;
        }

        public int GetUserIndexFromUserList(string userName)
        {
            for(int i = 0; i < _UserList.Count; i++)
            {
                if (_UserList[i].Name.Equals(userName))
                    return i;

            }
            return -1;
        }

        public void AddNodes(Tweet tweet)
        {
            int nodeKeyIndex;
            Hashtable edgeList;
            List<NodeInfo> newNodesList = new List<NodeInfo>();
            
            foreach (string node in tweet.TweetWords)
            {
                newNodesList.Add(new NodeInfo(node, 1));
            }

            Union(_NodeList, newNodesList);


            List<int> nodeIndexList = GetIndexesNodeList(tweet.TweetWords);
            UpdateUserInfo(tweet.UserName, nodeIndexList);

            int userIndex = GetUserIndexFromUserList(tweet.UserName);

            if (userIndex == -1)
                throw new Exception("User Does not exist. It must be there in the list.l\nFunction: AddNodes(CleanTweet)\nLine: 261");

            foreach (NodeInfo node in newNodesList)
            {
                
                // I can remove following operation, because I already have indexes of all newNodeList in nodeIndexList
                // remove following if performace is reducing
                nodeKeyIndex =  IndexOfNode(_NodeList,node);
                
                edgeList = GetEdgeList(nodeKeyIndex);

                if ( edgeList == null)
                {
                    edgeList = new Hashtable();
                    _AdjucencyList.Add(nodeKeyIndex, edgeList);
                }

                foreach (NodeInfo nodeNameForEdge in newNodesList)
                {        
                    if ( !node.IsMatch(nodeNameForEdge))
                    {
                        int nodeIndexForEdge = IndexOfNode(_NodeList,nodeNameForEdge);
                        if (edgeList.ContainsKey(nodeIndexForEdge))
                        {
                            EdgeInfo edge = (EdgeInfo)edgeList[nodeIndexForEdge];

                            edge.TweetWeight += 1;
                            edge.UserWeight += 1;

                            //edge.AddUserInfo(userIndex);

                            // multiply user-tweet ratio with tweet weight to calculate cammulative weight, higher user participation will cause more weight
                            // ratio is highly influencial, find a way to reduce its influence

                            // following weight calculation has many problems, what in case tweet count has not increased in next window but user count has increased
                            // in that case Weight should be meaningful, but I am doing it zero
                            // same is the case what is user count has not increased but tweet count has increased, then weight must not be zero
                            // when user or tweet count remain same in next window, the difference will be zero, which is causing problem here
                            // DISCUS ALL THIS WITH RABEEH SB

                            //if (edge.TweetWeight != 0)
                            //    edge.Weight = edge.UserWeight / edge.TweetWeight * edge.TweetWeight;
                            //else
                            //    edge.Weight = 0;

                        }
                        else
                            edgeList.Add(nodeIndexForEdge, new EdgeInfo(userIndex));

                    } // end of nodeName != nodeNameForEdge condition
                } // end of nodeNameForEdge loop
            } // end of nodeName loop
            
        }

        private List<int> GetIndexesNodeList(List<string> words)
        {
            List<int> indexList = new List<int>();

            foreach(string str in words)
            {
                indexList.Add(IndexOfNode(_NodeList, new NodeInfo(str, 0)));
            }

            return indexList;
        }

        private int IndexOfNode(List<NodeInfo> list, NodeInfo node)
        {
            NodeInfo n;

            for(int i = 0; i < list.Count; i++)
            {
                n = list[i];

                if (n.NodeName.Equals(node.NodeName))
                    return i;
            }

            return -1;
        }

        public List<string> GetSortedCentralNodesForCSV()
        {
            // must change this function according to newly added EdgeInfo class
            List<string> scoreList = new List<string>();

            KeyValuePair<NodeInfo, float> tempNodeScore;

            List<KeyValuePair<NodeInfo, float>> sortedList = new List<KeyValuePair<NodeInfo, float>>();

            foreach (KeyValuePair<int, float> pair in _CenteralityScores)
            {
                sortedList.Add(new KeyValuePair<NodeInfo, float>(_NodeList[pair.Key], pair.Value));
            }

            sortedList = _Util.quicksortNodesListForGraph(sortedList);

            //change bubble sort algorithm if possible
            //for (int i = 0; i < sortedList.Count - 1; i++)
            //{
            //    for (int j = 0; j < sortedList.Count - i - 1; j++)
            //    {
            //        if (sortedList[j].Value < sortedList[j + 1].Value) /* For Ascending order use < */
            //        {
            //            tempNodeScore = sortedList[j];
            //            sortedList[j] = sortedList[j + 1];
            //            sortedList[j + 1] = tempNodeScore;

            //        }
            //    }
            //}

            scoreList.Add("Users: " + this.TotalUsers.ToString() + ",Tweets: " + this.TotalTweets.ToString() + ",Nodes: " + this.TotalNodes.ToString() + ",,");
            scoreList.Add(_WindowStartTime.ToString() + "," + _WindowEndTime.ToString() + ",,,");
            scoreList.Add("NodeName,NodeFreq,Centrality,,");

            // create code for for creating following CSVs
            // Each window words + centrality weights
            // Each window User Count + tweet count
            // Each window user's tweet count
            // Global Facts: 
            // WordsUserList -> each word is used by how many users
            //               -> each word is used in how many tweets
            // UsersWordList -> each user has used how may unique words
            //               -> each word is used how many times by certain user

            foreach (KeyValuePair<NodeInfo, float> pair in sortedList)
            {
                scoreList.Add(pair.Key.NodeName + "," + pair.Key.NodeWeight.ToString() + "," + pair.Value.ToString() + ",,");
            }

            return scoreList;

        }

        private void SortUserListWithRespectToTweetCount()
        {
            UserInfo tempUserInfo;
            for (int i = 0; i < _UserList.Count - 1; i++)
            {
                for (int j = 0; j < _UserList.Count - i - 1; j++)
                {
                    if (_UserList[j].TotalTweets < _UserList[j+1].TotalTweets) /* For Ascending order use < */
                    {
                        tempUserInfo = _UserList[j];
                        _UserList[j] = _UserList[j + 1];
                        _UserList[j + 1] = tempUserInfo;
                    }
                }
            }

        }
        public List<string> CreateEachUsersTweetAndWordCountForCSV()
        {
            List<string> userList = new List<string>();

            SortUserListWithRespectToTweetCount(); // sorting userList. Original list is sorted here

            userList.Add("Users: " + this.TotalUsers.ToString() + ",Tweets: " + this.TotalTweets.ToString() + ",Nodes: " + this.TotalNodes.ToString() + ",,");
            userList.Add(_WindowStartTime.ToString() + "," + _WindowEndTime.ToString() + ",,,");
            userList.Add("User Name,Total Tweets, Total Unique Words,,");
            
            foreach (UserInfo userInfo in _UserList)
                userList.Add(userInfo.Name + "," + userInfo.TotalTweets.ToString() + "," + userInfo.GetTotalUniqueWords.ToString() + ",,");

            return userList;

        }



        private List<KeyValuePair<string,float>> GetSortedNodeList()
        {
            //float tempScore;
            //string tempNode;

            List<KeyValuePair<string, float>> sortedList = new List<KeyValuePair<string, float>>();

            ////create copies
            //List<float> tempCentralistyScore = _CenteralityScores.ToList<float>();
            //List<string> tempNodeList = _NodeList.ToList();
            
            //for (int i = 0; i < tempCentralistyScore.Count - 1; i++)
            //{
            //    for (int j = 0; j < tempCentralistyScore.Count - i - 1; j++)
            //    {
            //        if (tempCentralistyScore[j] < tempCentralistyScore[j + 1]) /* For Ascending order use < */
            //        {
            //            tempScore = tempCentralistyScore[j];
            //            tempCentralistyScore[j] = tempCentralistyScore[j + 1];
            //            tempCentralistyScore[j + 1] = tempScore;

            //            tempNode = tempNodeList[j];
            //            tempNodeList[j] = tempNodeList[j + 1];
            //            tempNodeList[j + 1] = tempNode;
            //        }
            //    }
            //}

            //for(int i = 0; i < _CenteralityScores.Count; i++)
            //{
            //    sortedList.Add(new KeyValuePair<string, float>(tempNodeList[i], tempCentralistyScore[i]));
            //}

            return sortedList;

        }

        private float[][] CreateAdjucencyMatrix(Hashtable graph)
        {
            // must update this method according newly added class EdgeInfo

            Hashtable adjList;
            int sourceNodeIndex, targetNodeIndex;

            float[][] adjMatrix = new float[_NodeList.Count][];
            int currentNodeIndex = 0;

            foreach (int nodeID in graph.Keys)
            {
                sourceNodeIndex = nodeID;

                adjList = (Hashtable)graph[nodeID];

                foreach (int nodeIDinEdge in adjList.Keys)
                {
                    adjMatrix[currentNodeIndex] = new float[_NodeList.Count];

                    targetNodeIndex = nodeIDinEdge;

                   adjMatrix[sourceNodeIndex][targetNodeIndex] = (int)adjList[nodeIDinEdge];
                }
            }

            return adjMatrix;
        }
        
        public Hashtable GetEdgeList(NodeInfo n)
        {
            int nodeIndex = IndexOfNode(_NodeList,n);
            
            if (_AdjucencyList.ContainsKey(nodeIndex))
                return (Hashtable)_AdjucencyList[nodeIndex];
            else
                return null;
        }

        public Hashtable GetEdgeList(int nodeIndex)
        {
            
            if (_AdjucencyList.ContainsKey(nodeIndex))
                return (Hashtable)_AdjucencyList[nodeIndex];
            else
                return null;
        }

        public void CalculateDegreeCentrality(CentralityMeasure measure, EdgeWeightCriteria weightCriteria, _Graph previousGraph, bool edgeWeightFlag, bool nodeWeightFlag)
        {

            // add functions to calculate all sort of centrality based on measure
            // change this logic

            if (measure == CentralityMeasure.DEGREE_WITH_POSITIVE_EDGES)
                CalculateDegreeWithPositiveEdges(weightCriteria, edgeWeightFlag, nodeWeightFlag);
            else if (measure == CentralityMeasure.DEGREE_WITH_ALL_EDGES)
                CalculateDegreeWithAllEdges(weightCriteria, edgeWeightFlag, nodeWeightFlag);
            else if (measure == CentralityMeasure.CUSTOM_MEASURE)
                CalculateDegreeWithCustomMeasure(weightCriteria,previousGraph, edgeWeightFlag, nodeWeightFlag);
            
        }

        private void CalculateDegreeWithAllEdges(EdgeWeightCriteria weightCriteria, bool edgeWeightFlag, bool nodeWeightFlag)
        {
            // all edges will be considered even with "zero" weight
            // right now it is not weighted edge calculation, just considering degrees
            // NEED TO IMPLEMENT WEIGHTED EDGE CODE ///
            int countEdges = 0;

            for (int node = 0; node < _NodeList.Count; node++)
            {
                countEdges = ((Hashtable)_AdjucencyList[node]).Count;

                _CenteralityScores.Add(new KeyValuePair<int, float>(node, (countEdges / (float)(_NodeList.Count-1))));
            }
        }

        private void CalculateDegreeWithPositiveEdges(EdgeWeightCriteria weightCriteria, bool edgeWeightFlag, bool nodeWeightFlag)
        {
            
            // right now it is not weighted edge calculation, just considering positive degrees
            int countEdges = 0;
            Hashtable edgeList;
            int positiveNodeCount = 0;
            int countEdgeWeights = 0;

            //int nodeIndex = IndexOfNode(_NodeList, new NodeInfo("#bravsarg", 1));

            for (int node = 0; node < _NodeList.Count; node++)
            {

                if (_NodeList[node].NodeWeight > 0)
                    positiveNodeCount++;

                edgeList = (Hashtable)_AdjucencyList[node];

                foreach (int key in edgeList.Keys)
                {
                    if ( weightCriteria == EdgeWeightCriteria.TWEET_BASED)
                    {
                        if (((EdgeInfo)edgeList[key]).TweetWeight > 0)
                        {
                            countEdges++;
                            countEdgeWeights += ((EdgeInfo)edgeList[key]).TweetWeight;
                        }
                            
                    }
                    else if (weightCriteria == EdgeWeightCriteria.USER_BASED)
                    {
                        if (((EdgeInfo)edgeList[key]).UserWeight > 0)
                        {
                            countEdges++;
                            countEdgeWeights += ((EdgeInfo)edgeList[key]).UserWeight;
                        }
                            
                    }
                    else if (weightCriteria == EdgeWeightCriteria.ACCUMULATIVE)
                    {
                        // for accumulative, both user and tweet weight must be greater than 0, then Weight will be greater than zero

                        //if (((EdgeInfo)edgeList[key]).Weight > 0)
                        //{
                        //    countEdges++;
                        //    countEdgeWeights += (int)((EdgeInfo)edgeList[key]).Weight;
                        //}
                            
                    }
                    
                }

                int tempEdgesValue;
                int tempNodeValue;

                if (edgeWeightFlag)
                    tempEdgesValue = countEdgeWeights;
                else
                    tempEdgesValue = countEdges;

                if (nodeWeightFlag)
                    tempNodeValue = positiveNodeCount;
                else
                    tempNodeValue = _NodeList.Count - 1;
                
                _CenteralityScores.Add(new KeyValuePair<int, float>(node, (tempEdgesValue / (float)tempNodeValue)));

                //reset edge count for next node
                countEdges = 0;
            }
        }

        private void CalculateDegreeWithCustomMeasure(EdgeWeightCriteria weightCriteria, _Graph previousGraph, bool edgeWeightFlag, bool nodeWeightFlag)
        {
            // must update this according to newly added class EdgeInfo
            // it was complex that is why I am leaving it as it is, in case we use this, then I will change it according to EdgeInfo

            int countEdges = 0;
            Hashtable edgeList;

            float degreeCentrality;
            float positiveEdgeSum = 0;
            float negitiveEdgeProduct = 1;
            float previousEdgeWeight = 0;

            for (int node = 0; node < _NodeList.Count; node++)
            {
                edgeList = (Hashtable)_AdjucencyList[node];
                countEdges = edgeList.Count;

                degreeCentrality = (countEdges / (float)(_NodeList.Count - 1));

                // following is for calculating sum of positive edges and product of negitive edge with respect to previous graph

                float weight = 0;

                bool weightFailed = false;

                foreach (int key in edgeList.Keys)
                {
                    if (weightCriteria == EdgeWeightCriteria.TWEET_BASED)
                    {
                        if (((EdgeInfo)edgeList[key]).TweetWeight > 0)
                            positiveEdgeSum += ((EdgeInfo)edgeList[key]).TweetWeight;
                        else
                        {
                            // need to search specific node in previous graph, because NodeList index are not same in current and previous graph
                            // following is not working correct
                            previousEdgeWeight = ((EdgeInfo)((Hashtable)previousGraph._AdjucencyList[node])[key]).TweetWeight;
                            negitiveEdgeProduct *= (previousEdgeWeight - ((EdgeInfo)(edgeList[key])).TweetWeight) / previousEdgeWeight;
                        } 
                    }
                    else if (weightCriteria == EdgeWeightCriteria.USER_BASED)
                    {
                        if (((EdgeInfo)edgeList[key]).UserWeight > 0)
                            positiveEdgeSum += ((EdgeInfo)edgeList[key]).UserWeight;
                        else
                        {
                            // need to search specific node in previous graph, because NodeList index are not same in current and previous graph
                            // following is not working correct
                            previousEdgeWeight = ((EdgeInfo)((Hashtable)previousGraph._AdjucencyList[node])[key]).UserWeight;
                            negitiveEdgeProduct *= (previousEdgeWeight - ((EdgeInfo)(edgeList[key])).UserWeight) / previousEdgeWeight;
                        }

                    }
                    else if (weightCriteria == EdgeWeightCriteria.ACCUMULATIVE)
                    {
                        // for accumulative, both user and tweet weight must be greater than 0, then Weight will be greater than zero

                        //if (((EdgeInfo)edgeList[key]).Weight > 0)
                        //    positiveEdgeSum += ((EdgeInfo)edgeList[key]).Weight;
                        //else
                        //{
                        //    // need to search specific node in previous graph, because NodeList index are not same in current and previous graph
                        //    // following is not working correct
                        //    previousEdgeWeight = ((EdgeInfo)((Hashtable)previousGraph._AdjucencyList[node])[key]).Weight;
                        //    negitiveEdgeProduct *= (previousEdgeWeight - ((EdgeInfo)(edgeList[key])).Weight) / previousEdgeWeight;
                        //}

                    } // end of else if weightCriteria == EdgeWeightCriteria.ACCUMULATIVE
                } // end of foreach (int key in edgeList.Keys)

                _CenteralityScores.Add(new KeyValuePair<int, float>(node, degreeCentrality*positiveEdgeSum*negitiveEdgeProduct));

            } // end of for (int node = 0; node < _NodeList.Count; node++)

        }

    }

}
