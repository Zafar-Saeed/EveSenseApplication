using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DhgDataProcessor
{
    class Extractor
    {
        private List<_Graph> _SlidingWindowsGraphs = new List<_Graph>();
        
        private List<_Graph> _WindowsDifferences;

        ExtractionConfigration _config;
        // Sat Nov 12 02:32:24 0000 2016 => usrNeme => word1, word2, word3, ... , wordN
        List<Tweet> _CleanDataSet;

        // Two parallel list tells that tweet in first list is actually removed because matched with the tweet in _matchingTweets
        // which is duplicated
        List<Tweet> _RemovedTweets = new List<Tweet>();
        // matched with following tweet
        List<Tweet> _MatchingTweets = new List<Tweet>();

        // indexes of duplicate tweets in _CleanDataset
        List<int> _removeTweetIndexes = new List<int>();

        public int DuplicateTweets { get; set; }

        public List<Tweet> CleanedData
        {
            get { return _CleanDataSet; }
        }

        
        public int TotalWindows
        {
            get
            {
                return _SlidingWindowsGraphs.Count;
            }
        }

        public bool WriteHeartBeats()
        {
            return _Util.WriteNodeFreqInEachHeartBeat(_WindowsDifferences);
        }

        public Extractor(ExtractionConfigration config)
        {
            _config = config;
            DuplicateTweets = 0;
            _CleanDataSet = new List<Tweet>();
            _WindowsDifferences = new List<_Graph>();

            
        }

        // this method will do all the work:
        // Cleasing + Filtration + Sliding Windows Graph Extraction + Sliding Window Difference Calculation + Centrality Score Calculations
    

        public void Extract()
        {
            Cleansing cleansing = new Cleansing();
            Tweet currentTweet;
            _Progress prog = _Progress.GetProgress;

            StreamReader file =
               new StreamReader(_config.DataSetFilePath);
            string line;

            long countTweetLine = 0;

            lock (_Util.Locker)
            {
                prog.Activity = 4;
                prog.Message = 0;
                _Util.totalIterations = 0;
                _Util.completedIterations = countTweetLine;
                _Util.functionNameForProgressMsg = "Extract (Loading Tweets and Cleaning)";
            }
            
            while ((line = file.ReadLine()) != null)
            {
                
                if (_config.IsDataCleaned)
                {
                    countTweetLine++;

                    //if ( countTweetLine == 2742)
                    //{
                    //    int breaking = 0;
                    //}
                    currentTweet = cleansing.LoadCleanTweet(line, _config.FilterationCriteria, _config.minWordLength);
                    
                    if ( currentTweet != null)
                    {
                        /////////////////////////////////////////////////////////////////////////////////////
                        /// TEMPORARY CODE TO AVOID STEMMING ISSUE SPECIFICALLY FOR US ELECTION DATA SET ////
                        /////////////////////////////////////////////////////////////////////////////////////
                        //(win wins won) (call called calling) (projecting project projects projection) (hold held)

                        for (int ind = 0; ind < currentTweet.TweetWords.Count; ind++)
                        {
                            if (currentTweet.TweetWords[ind].Equals("won") ||
                                currentTweet.TweetWords[ind].Equals("wins"))
                            {
                                currentTweet.TweetWords[ind] = "win";
                            }
                            else if (currentTweet.TweetWords[ind].Equals("projecting") ||
                                    currentTweet.TweetWords[ind].Equals("projects") ||
                                    currentTweet.TweetWords[ind].Equals("projection") ||
                                    currentTweet.TweetWords[ind].Equals("projections"))
                            {
                                currentTweet.TweetWords[ind] = "project";
                            }
                            else if (currentTweet.TweetWords[ind].Equals("held") ||
                                    currentTweet.TweetWords[ind].Equals("holds"))
                            {
                                currentTweet.TweetWords[ind] = "hold";
                            }
                            else if (currentTweet.TweetWords[ind].Equals("calls") ||
                                    currentTweet.TweetWords[ind].Equals("callled") ||
                                    currentTweet.TweetWords[ind].Equals("calling"))
                            {
                                currentTweet.TweetWords[ind] = "call";
                            }
                            else if (currentTweet.TweetWords[ind].Equals("leading"))
                            {
                                currentTweet.TweetWords[ind] = "lead";
                            }
                            else if (currentTweet.TweetWords[ind].Equals("votes"))
                            {
                                currentTweet.TweetWords[ind] = "vote";
                            }


                        }
                        /////////////////////////////////////////////// END OF HARD FIXING /////////////////////////////////////////////

                        _CleanDataSet.Add(currentTweet);
                    }
                    
                }

                else
                {
                    // first 29 characters are for date and time, tweet must be atleast 30 characters
                    if (line.Length > 30)
                    {
                        // second parameter is for DoStemming Flag
                        currentTweet = cleansing.CleanTweet(line, _config.IsStemmingOn, _config.FilterationCriteria, _config.minWordLength);
                        if (currentTweet != null)
                        {
                            _CleanDataSet.Add(currentTweet);

                        }
                    } // end of line.length > 30 condition
                } // end of else part, if data is not clean

                lock (_Util.Locker)
                {   
                    _Util.completedIterations = countTweetLine;
                }

            } // end of while loop
            
        }

        public void RemoveDuplicateTweetsUsingIndexFile(string filePath)
        {
            _Progress prog = _Progress.GetProgress;
            StreamReader file =
               new StreamReader(filePath);
            string line;

            lock (_Util.Locker)
            {
                _Util.totalIterations = 0;
                _Util.completedIterations = 0;
                _Util.functionNameForProgressMsg = "RemoveDuplicateTweetsUsingIndexFile (Removing)";
            }


            while ((line = file.ReadLine()) != null)
            {
                string[] splitStr = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                _CleanDataSet.RemoveAt(int.Parse(splitStr[1]));
            }

        }

        public void RemoveDuplicateTweet()
        {
            // Test this method

            // it is better to use Kullback Leibler Distance Measure (but for offensive filtering)

            Tweet tweet,matchWithTweet;
            

            lock (_Util.Locker)
            {
                _Util.totalIterations = _CleanDataSet.Count;
                _Util.functionNameForProgressMsg = "RemoveDuplicateTweet (Searching)";
            }
           

            for (int tweetToCheck = _CleanDataSet.Count - 1; tweetToCheck > 0 ; tweetToCheck--)
            {
                tweet = _CleanDataSet[tweetToCheck];

                for(int matchingTweet = tweetToCheck - 1; matchingTweet >= 0 ; matchingTweet--)
                {
                    matchWithTweet = _CleanDataSet[matchingTweet];

                    if (IsSame(tweet, matchWithTweet, _config.UserMatchFlag, _config.TweetMatchingCriteria))
                    {
                        //_CleanDataSet.RemoveAt(tweetToCheck);
                        //DuplicateTweets += 1;

                        //if ( tweetToCheck >= 360 )
                        //{
                        //    int dummybreak = 0;
                        //}

                        _RemovedTweets.Add(_CleanDataSet[tweetToCheck]);
                        _MatchingTweets.Add(_CleanDataSet[matchingTweet]);

                        _removeTweetIndexes.Add(tweetToCheck);

                       
                        // no need to check further if once tweet is matched
                        break;
                    }
                }

                lock (_Util.Locker)
                {
                    _Util.completedIterations = _CleanDataSet.Count - tweetToCheck;
                    _Util.functionNameForProgressMsg = "RemoveDuplicateTweet (Searched - " + _removeTweetIndexes.Count.ToString() + " )";
                }

            }

            DuplicateTweets = _removeTweetIndexes.Count;

            lock (_Util.Locker)
            {
                _Util.functionNameForProgressMsg = "RemoveDuplicateTweet (Removing..)";
            }

            foreach (int index in _removeTweetIndexes)
            {
                _CleanDataSet.RemoveAt(index);
            }

            
        }

        public bool CreateCSVForRemovedTweets(string filename, string datasetName)
        {
            return _Util.WriteRemovedTweetsToCSV(_RemovedTweets, _MatchingTweets, _removeTweetIndexes, filename, datasetName);
        }

        public bool IsSame(Tweet tweet, Tweet toMatchWithTweet, bool userFlag, DuplicateTweetCriteria tweetMatchingCriteria)
        {
            bool contentsMatched = MatchWordLists(tweet.TweetWords, toMatchWithTweet.TweetWords, tweetMatchingCriteria);

            bool userMatched = false;
            if (userFlag)
            {
                if (tweet.UserName.Equals(toMatchWithTweet.UserName))
                    userMatched = true;

                return (contentsMatched && userMatched);
            }
            else
                return contentsMatched;
        }

        public bool MatchWordLists(List<string> list1, List<string> list2, DuplicateTweetCriteria tweetMatchingCriteria)
        {
            bool tweetMatched = true;

            List<string> trimedList1 = new List<string>();
            List<string> trimedList2 = new List<string>();

            ////// Trimed list of words only and ignoring mentions and hashtags ///////
            foreach (string str in list1)
                if (!str.Contains("@") && !str.Contains("#"))
                    trimedList1.Add(str);

            foreach (string str in list2)
                if (!str.Contains("@") && !str.Contains("#"))
                    trimedList2.Add(str);
            ////////////////////////////////////////////////////////////////////////////


            if (trimedList1.Count == trimedList2.Count)
            {
                if (tweetMatchingCriteria == DuplicateTweetCriteria.MATCH_WORD_IN_SEQUENCE)
                {
                    int i;
                    
                    for (i = 0; i < trimedList1.Count; i++)
                    {
                            if (!trimedList1[i].Equals(trimedList2[i], StringComparison.OrdinalIgnoreCase))
                            {
                                tweetMatched = false;
                                break;
                            }
                    }
                }
                else if ( tweetMatchingCriteria == DuplicateTweetCriteria.MATCH_WORD_IN_ANY_ORDER)
                {
                    
                    foreach (string strList1 in trimedList1)
                    {
                        if (!trimedList2.Any<string>(s => s.Equals(strList1, StringComparison.OrdinalIgnoreCase)))
                        {
                            tweetMatched = false;
                            break;
                        }
                    }
                }
            } // end of condition list1.Count == list2.Count
            else
                tweetMatched = false;

            return tweetMatched;
        }

        public bool CreateTimeSeriesNetwork()
        {
            _Graph currentWindowGraph = new _Graph();
            
            DateTime previousTweetDateTime = _CleanDataSet[0].TweetDate;

            currentWindowGraph._WindowStartTime = previousTweetDateTime;

            lock (_Util.Locker)
            {
                _Util.totalIterations = _CleanDataSet.Count;
                _Util.functionNameForProgressMsg = "CreateTimeSeriesNetwork";
            }

            long count = 0;
            
            foreach (Tweet tweet in _CleanDataSet)
            {
                currentWindowGraph = AddToWindow(currentWindowGraph, tweet, _config.ExpiryTime, previousTweetDateTime);

                previousTweetDateTime = tweet.TweetDate;

                lock (_Util.Locker)
                {
                    _Util.completedIterations = ++count;
                }
            }

            currentWindowGraph._WindowEndTime = previousTweetDateTime;
            _SlidingWindowsGraphs.Add(currentWindowGraph);

            return true;
        }

        private _Graph AddToWindow(_Graph currentWindowGraph, Tweet tweet, int expiry, DateTime previousTweetDateTime)
        {
          
            
            if (_Util.TimeDifference(currentWindowGraph._WindowStartTime, tweet.TweetDate, _config.ExpiryTimeUnit) >= expiry)
            {
                //CloseCurrentSlidingWindowAndAddToList(previousTweetDateTime, currentWindowGraph);
                //close current sliding window and add new one
                currentWindowGraph._WindowEndTime = previousTweetDateTime;
                _SlidingWindowsGraphs.Add(currentWindowGraph);

                currentWindowGraph = new _Graph();
                currentWindowGraph._WindowStartTime = tweet.TweetDate;
               
            }
            
            currentWindowGraph.AddNodes(tweet);

            return currentWindowGraph;
        }

        public void CloseCurrentSlidingWindowAndAddToList(DateTime slidingWindowEndTime, _Graph g)
        {
            g._WindowEndTime = slidingWindowEndTime;
            _SlidingWindowsGraphs.Add(g);
            g = new _Graph();
            
        }

        private List<NodeInfo> NodeUnion(_Graph graph_0, _Graph graph_1)
        {
            List<NodeInfo> joinedNodes = new List<NodeInfo>();

            List<NodeInfo> graph_0_Nodes = graph_0._NodeList;
            List<NodeInfo> graph_1_Nodes = graph_1._NodeList;

            foreach (NodeInfo node in graph_0_Nodes)
            {
                joinedNodes.Add(new NodeInfo(node));
            }

            foreach (NodeInfo node in graph_1._NodeList)
            {
                // additional nodes from second graph, if node does not exist then add it in list with weight zero
                // this is just for matrix calculation, since for subtraction, both matrices should have same nxn
                // by this we are adding new nodes in combined node list for Graph_0, but weight will be zero
                // we did all this to maintain the weights of graphs, which might be useful in future.
                int nodeIndex = ContainNode(joinedNodes, node);
                if ( nodeIndex == -1)
                {
                    //joinedNodes.Add(new Node(node.NodeName,node.NodeWeight));
                    joinedNodes.Add(new NodeInfo(node.NodeName, 0));
                }
                //else
                //{
                //    // adding node frequency of both windows in joined node list
                //    joinedNodes[nodeIndex].NodeWeight += node.NodeWeight;
                //}
            }

            return joinedNodes;
        }

        private int ContainNode(List<NodeInfo> list, NodeInfo node)
        {
            NodeInfo n;

            for (int i = 0; i < list.Count; i++)
            {
                n = list[i];

                if (n.IsMatch(node))
                    return i;
            }

            return -1;
        }

        private _Graph FindSlidingWindowDifference(_Graph graph_0 , _Graph graph_1)
        {

            DateTime processStart = DateTime.Now;

            // We are making combinedNodes saparetly because, for both graph node weight should be consistance
            // these weights might be useful in future. . . For further detail read comments in NodeUnion function
            List<NodeInfo> combinedNodesGraph_0 = _Util.quicksortListNodesInfo(NodeUnion(graph_0, graph_1));
            List<NodeInfo> combinedNodesGraph_1 = _Util.quicksortListNodesInfo(NodeUnion(graph_1, graph_0));

            // weights_1  - weights_0 would be new weights for difference window
            // following list would be in similar order to combinedNodesGraph_1
            List<NodeInfo> weightedCombinedList = DifferenceInWeightedNodeList(combinedNodesGraph_0, combinedNodesGraph_1);

            
            _Graph g =
                new _Graph(
                    DifferenceMatrix(
                                    CreateJoinedAdjucencyMatrix(graph_0, combinedNodesGraph_0), combinedNodesGraph_0,
                                    CreateJoinedAdjucencyMatrix(graph_1, combinedNodesGraph_1), combinedNodesGraph_1),
                          weightedCombinedList, 
                          graph_1._UserList
                          );

            g._WindowStartTime = graph_0._WindowStartTime;
            g._WindowEndTime = graph_1._WindowEndTime;

            TimeSpan executionTime = DateTime.Now.Subtract(processStart);
            g._ExecutionTime += (executionTime.Days * 24 * 60 * 60*1000) + (executionTime.Hours * 60 * 60 * 1000) + (executionTime.Minutes * 60 * 1000) + executionTime.Milliseconds;
            return g;
            
        }

        private EdgeInfo[,] DifferenceMatrix(EdgeInfo[,] graphMatrix_0, List<NodeInfo> nodeList_0, EdgeInfo[,] graphMatrix_1, List<NodeInfo> nodeList_1)
        {
            //both NodeLists have same number of nodes and same nodes but might be in different order
            EdgeInfo[,] differenceMatrix = new EdgeInfo[nodeList_1.Count, nodeList_1.Count];

            int rowIndex, colIndex;
            EdgeInfo tempEdge;

            for(int row = 0; row < differenceMatrix.GetLength(0); row++)
            {
                for(int col = 0; col < differenceMatrix.GetLength(1); col++)
                {
                    //finding indexes in second matrix, because the order of nodes in both matrices are NOT identical
                    //rowIndex = IndexOfNode(nodeList_0, nodeList_1[row]);
                    //colIndex = IndexOfNode(nodeList_0, nodeList_1[col]);

                    // now nodeList_0 and nodeList_1 is in same order, 
                    //therefore no need of finding indexes in second matrix as I did in above statements
                    rowIndex = row;
                    colIndex = col;
                    
                    // I am not recording difference in user list
                    // if needed in future, here is the place for finding difference in users (i.e. how many new or old users) then create EdgeInfo object
                    // Edge will be created even if Tweet weight or User weight or both is "zero"
                    
                    bool null_flag_graphMatrix_1 = graphMatrix_1[row, col] == null ? true : false;
                    bool null_flag_graphMatrix_0 = graphMatrix_0[rowIndex, colIndex] == null ? true : false;

                    if ( null_flag_graphMatrix_1)
                    {
                        if ( null_flag_graphMatrix_0)
                        {
                            tempEdge = null;
                        }
                        else
                        {
                            tempEdge = new EdgeInfo(
                                                    - graphMatrix_0[rowIndex, colIndex].TweetWeight,
                                                    - graphMatrix_0[rowIndex, colIndex].UserWeight
                                                    );
                        }
                    }
                    else
                    {
                        if (null_flag_graphMatrix_0)
                        {
                            tempEdge = new EdgeInfo(
                                                    graphMatrix_1[row, col].TweetWeight,
                                                    graphMatrix_1[row, col].UserWeight
                                                    );
                        }
                        else
                        {
                            tempEdge = new EdgeInfo(
                                                    graphMatrix_1[row, col].TweetWeight - graphMatrix_0[rowIndex, colIndex].TweetWeight,
                                                    graphMatrix_1[row, col].UserWeight - graphMatrix_0[rowIndex, colIndex].UserWeight
                                                    );
                        }
                    }
                    
                    differenceMatrix[row,col] = tempEdge;
                }
            }

            return differenceMatrix;
        }

        private EdgeInfo[][] DifferenceMatrix(EdgeInfo[][] graphMatrix_0, List<NodeInfo> nodeList_0, EdgeInfo[][] graphMatrix_1, List<NodeInfo> nodeList_1)
        {
            //both NodeLists have same number of nodes and same nodes but might be in different order
            //EdgeInfo[,] differenceMatrix = new EdgeInfo[nodeList_1.Count, nodeList_1.Count];

            EdgeInfo[][] differenceMatrix = new EdgeInfo[nodeList_1.Count][];

            for(int i= 0; i < nodeList_1.Count; i++)
            {
                differenceMatrix[i] = new EdgeInfo[nodeList_1.Count];
            }
            
            int rowIndex, colIndex;
            EdgeInfo tempEdge;

            for (int row = 0; row < nodeList_1.Count; row++)
            {
                for (int col = 0; col < nodeList_1.Count; col++)
                {
                    //finding indexes in second matrix, because the order of nodes in both matrices are NOT identical
                    //rowIndex = IndexOfNode(nodeList_0, nodeList_1[row]);
                    //colIndex = IndexOfNode(nodeList_0, nodeList_1[col]);

                    // now nodeList_0 and nodeList_1 is in same order, 
                    //therefore no need of finding indexes in second matrix as I did in above statements
                    rowIndex = row;
                    colIndex = col;

                    // I am not recording difference in user list
                    // if needed in future, here is the place for finding difference in users (i.e. how many new or old users) then create EdgeInfo object
                    // Edge will be created even if Tweet weight or User weight or both is "zero"

                    bool null_flag_graphMatrix_1 = graphMatrix_1[row][col] == null ? true : false;
                    bool null_flag_graphMatrix_0 = graphMatrix_0[rowIndex][colIndex] == null ? true : false;
                    
                    if (null_flag_graphMatrix_1)
                    {
                        if (null_flag_graphMatrix_0)
                        {
                            tempEdge = null;
                        }
                        else
                        {
                            tempEdge = new EdgeInfo(
                                                    -graphMatrix_0[rowIndex][colIndex].TweetWeight,
                                                    -graphMatrix_0[rowIndex][colIndex].UserWeight
                                                    );
                        }
                    }
                    else
                    {
                        if (null_flag_graphMatrix_0)
                        {
                            tempEdge = new EdgeInfo(
                                                    graphMatrix_1[row][col].TweetWeight,
                                                    graphMatrix_1[row][col].UserWeight
                                                    );

                        }
                        else
                        {
                            tempEdge = new EdgeInfo(
                                                    graphMatrix_1[row][col].TweetWeight - graphMatrix_0[rowIndex][colIndex].TweetWeight,
                                                    graphMatrix_1[row][col].UserWeight - graphMatrix_0[rowIndex][colIndex].UserWeight
                                                    );
                        }
                    }
                    
                    differenceMatrix[row][col] = tempEdge;   
                }
                
            }

            return differenceMatrix;
        }

        private List<NodeInfo> DifferenceInWeightedNodeList(List<NodeInfo> list_0, List<NodeInfo> list_1)
        {
            // here in this function both lists would be having same number of nodes and same nodes

            List<NodeInfo> weightedCombinedList = new List<NodeInfo>();

            
            int index;

            // since now both list are sorted and nodes are in same sequence

            for(int i = 0; i < list_0.Count; i++)
            {
                weightedCombinedList.Add(new NodeInfo(list_1[i].NodeName, list_1[i].NodeWeight -= list_0[i].NodeWeight));
            }

            //foreach(NodeInfo n in list_0)
            //{
            //    index = IndexOfNode(list_1, n);
            //    list_1[index].NodeWeight -= n.NodeWeight;
            //}

            return weightedCombinedList;
        }


        private EdgeInfo[][] CreateJoinedAdjucencyMatrix(_Graph graph, List<NodeInfo> nodeList)
        {
            //creating rows in matrix
            //float[][] joinedAdjMatrix = _Util.Create2DArray(nodeList.Count,nodeList.Count);

            // following 2D array causes memory issue, I must rather use EdgeInfo [][], Or List<List<EdgeInfo>> and 
            // initialize array before executing following code.

            try
            {
                EdgeInfo[][] joinedEdgeMatrix = new EdgeInfo[nodeList.Count][];

                for (int temp = 0; temp < nodeList.Count; temp++)
                    joinedEdgeMatrix[temp] = new EdgeInfo[nodeList.Count];


                //EdgeInfo[][] joinedEdgeMatrix = new EdgeInfo[nodeList.Count][];

                //for(int i = 0; i < nodeList.Count; i++)
                //{
                //    joinedEdgeMatrix[i] = new EdgeInfo[nodeList.Count];
                //}

                Hashtable edgeList;
                int sourceNodeIndex, targetNodeIndex;

                //foreach (NodeInfo node in graph._NodeList)
                for (int index = 0; index < graph._NodeList.Count; index++)
                {
                    // row index in matrix
                    sourceNodeIndex = IndexOfNode(nodeList, graph._NodeList[index]);

                    edgeList = (Hashtable)graph.GetEdgeList(index);

                    //creating columns in matrix
                    //joinedAdjMatrix[currentRowIndex] = new float[nodeList.Count]; // assumption: it will be intitialed with default value 0

                    if (edgeList != null)
                    {
                        // edge list contains indexes of nodes that can be mapped on to _NodeList of _Graph
                        foreach (int nodeIndex in edgeList.Keys)
                        {
                            // column index in matrix
                            targetNodeIndex = IndexOfNode(nodeList, graph._NodeList[nodeIndex]);

                            //joinedAdjMatrix[sourceNodeIndex][targetNodeIndex] = Convert.ToSingle(edgeList[nodeIndex]);

                            // I am not deep copying here, so be careful what does call function do to it
                            //joinedEdgeMatrix[sourceNodeIndex][targetNodeIndex] = (EdgeInfo)edgeList[nodeIndex];
                            joinedEdgeMatrix[sourceNodeIndex][targetNodeIndex] = (EdgeInfo)edgeList[nodeIndex];
                        }

                    } // end of adjList != null condition


                } // end of graph.Nodes loop

                return joinedEdgeMatrix;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            //return joinedAdjMatrix;

        }



        #region "   Previous Methods with with float[][] AdjucencyMatrix, Currently NOT in use    "

        //private EdgeInfo[,] CreateJoinedAdjucencyMatrix(_Graph graph, List<NodeInfo> nodeList)
        //{
        //    //creating rows in matrix
        //    //float[][] joinedAdjMatrix = _Util.Create2DArray(nodeList.Count,nodeList.Count);

        //    // following 2D array causes memory issue, I must rather use EdgeInfo [][], Or List<List<EdgeInfo>> and 
        //    // initialize array before executing following code.

        //    try
        //    {
        //       EdgeInfo[,] joinedEdgeMatrix = new EdgeInfo[nodeList.Count, nodeList.Count];
        //        //List<List<EdgeInfo>> joinedEdgeMatrix = new List<List<EdgeInfo>>();



        //        //EdgeInfo[][] joinedEdgeMatrix = new EdgeInfo[nodeList.Count][];

        //        //for(int i = 0; i < nodeList.Count; i++)
        //        //{
        //        //    joinedEdgeMatrix[i] = new EdgeInfo[nodeList.Count];
        //        //}

        //        Hashtable edgeList;
        //        int sourceNodeIndex, targetNodeIndex;

        //        //foreach (NodeInfo node in graph._NodeList)
        //        for (int index = 0; index < graph._NodeList.Count; index++)
        //        {
        //            // row index in matrix
        //            sourceNodeIndex = IndexOfNode(nodeList, graph._NodeList[index]);

        //            edgeList = (Hashtable)graph.GetEdgeList(index);

        //            //creating columns in matrix
        //            //joinedAdjMatrix[currentRowIndex] = new float[nodeList.Count]; // assumption: it will be intitialed with default value 0

        //            if (edgeList != null)
        //            {
        //                // edge list contains indexes of nodes that can be mapped on to _NodeList of _Graph
        //                foreach (int nodeIndex in edgeList.Keys)
        //                {
        //                    // column index in matrix
        //                    targetNodeIndex = IndexOfNode(nodeList, graph._NodeList[nodeIndex]);

        //                    //joinedAdjMatrix[sourceNodeIndex][targetNodeIndex] = Convert.ToSingle(edgeList[nodeIndex]);

        //                    // I am not deep copying here, so be careful what does call function do to it
        //                    //joinedEdgeMatrix[sourceNodeIndex][targetNodeIndex] = (EdgeInfo)edgeList[nodeIndex];
        //                    joinedEdgeMatrix[sourceNodeIndex, targetNodeIndex] = (EdgeInfo)edgeList[nodeIndex];
        //                }

        //            } // end of adjList != null condition


        //        } // end of graph.Nodes loop

        //        return joinedEdgeMatrix;

        //    }
        //    catch (Exception ex)
        //    {
        //        int dummy = 0;
        //        throw ex;
        //    }

        //    //return joinedAdjMatrix;

        //}

        //private float[][] CreateJoinedAdjucencyMatrix(_Graph graph, List<NodeInfo> nodeList)
        //{
        //    //creating rows in matrix
        //    float[][] joinedAdjMatrix = _Util.Create2DArray(nodeList.Count, nodeList.Count);

        //    Hashtable edgeList;
        //    int sourceNodeIndex, targetNodeIndex;

        //    foreach (NodeInfo node in graph._NodeList)
        //    {
        //        // row index in matrix
        //        sourceNodeIndex = IndexOfNode(nodeList, node);

        //        edgeList = (Hashtable)graph.GetEdgeList(sourceNodeIndex);

        //        //creating columns in matrix
        //        //joinedAdjMatrix[currentRowIndex] = new float[nodeList.Count]; // assumption: it will be intitialed with default value 0

        //        if (edgeList != null)
        //        {
        //            // edge list contains indexes of nodes that can be mapped on to _NodeList of _Graph
        //            foreach (int nodeIndex in edgeList.Keys)
        //            {
        //                // column index in matrix
        //                targetNodeIndex = nodeIndex;

        //                joinedAdjMatrix[sourceNodeIndex][targetNodeIndex] = Convert.ToSingle(edgeList[nodeIndex]);

        //            }

        //        } // end of adjList != null condition

        //    } // end of graph.Nodes loop

        //    return joinedAdjMatrix;

        //}

        //private float[][] DifferenceMatrix(float[][] graphMatrix_0, List<NodeInfo> nodeList_0, float[][] graphMatrix_1, List<NodeInfo> nodeList_1)
        //{
        //    //both NodeLists have same number of nodes and same nodes but might be in difference order
        //    float[][] differenceMatrix = _Util.Create2DArray(nodeList_1.Count, nodeList_1.Count);

        //    int rowIndex, colIndex;

        //    for (int row = 0; row < differenceMatrix.Length; row++)
        //    {
        //        for (int col = 0; col < differenceMatrix[0].Length; col++)
        //        {
        //            //finding indexes in second matrix, because the order of nodes in both matrices are NOT identical
        //            rowIndex = IndexOfNode(nodeList_0, nodeList_1[row]);
        //            colIndex = IndexOfNode(nodeList_0, nodeList_1[col]);

        //            differenceMatrix[row][col] = graphMatrix_1[row][col] - graphMatrix_0[rowIndex][colIndex];
        //        }
        //    }

        //    return differenceMatrix;
        //}

        #endregion

        private int IndexOfNode(List<NodeInfo> list, NodeInfo node)
        {
            NodeInfo n;

            // convert this method into a Binary search, 
            // and make source the parameter "List<NodeInfo> list is in sorted order with respect to node name"
            //10-07-2017: List is now sorted, therefor using binary search here.
            int index = list.BinarySearch(node);

            return index;
            //for (int i = 0; i < list.Count; i++)
            //{
            //    n = list[i];

            //    if (n.NodeName.Equals(node.NodeName))
            //        return i;
            //}

            //return -1;
        }

        public void CalculateDegreeCentralityInDifferenceGraph()
        {
            lock (_Util.Locker)
            {
                _Util.totalIterations = _WindowsDifferences.Count;
                _Util.functionNameForProgressMsg = "CalculateDegreeCentralityInDifferenceGraph";
            }

            TimeSpan executionTime;
            DateTime processStart = DateTime.Now;

            _WindowsDifferences[0].CalculateDegreeCentrality(_config.Measure, _config.WeightCriteria, _WindowsDifferences[0], _config.WeightedEdgeFlag, _config.WeightedNodeFlag);

            executionTime = DateTime.Now.Subtract(processStart);
            _WindowsDifferences[0]._ExecutionTime += (executionTime.Days * 24 * 60 * 60 * 1000) + (executionTime.Hours * 60 * 60 * 1000) + (executionTime.Minutes * 60 * 1000) + executionTime.Milliseconds;

            for (int i = 1; i < _WindowsDifferences.Count; i++)
            {
                processStart = DateTime.Now;
                _WindowsDifferences[i].CalculateDegreeCentrality(_config.Measure, _config.WeightCriteria, _WindowsDifferences[i-1], _config.WeightedEdgeFlag, _config.WeightedNodeFlag);
                _WindowsDifferences[i]._ExecutionTime += (executionTime.Days * 24 * 60 * 60 * 1000) + (executionTime.Hours * 60 * 60 * 1000) + (executionTime.Minutes * 60 * 1000) + executionTime.Milliseconds;
                
                lock (_Util.Locker)
                {
                    _Util.completedIterations = i;
                    
                }

            }
        }

        public void CalculateWindowsDifferences()
        {
            _Progress p = _Progress.GetProgress;

            lock (_Util.Locker)
            {
                _Util.totalIterations = _SlidingWindowsGraphs.Count;
                _Util.functionNameForProgressMsg = "CalculateWindowsDifferences";
            }

            int i = 0;

            

            if (_SlidingWindowsGraphs.Count > 1)
            {

                for(i = 1; i < _SlidingWindowsGraphs.Count; i++)
                {
                    _WindowsDifferences.Add(FindSlidingWindowDifference(_SlidingWindowsGraphs[i - 1], _SlidingWindowsGraphs[i]));

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = i;
                    }
                }
                                
            }
            else
            {
                lock (_Util.Locker)
                {
                    p.Activity = 1;
                    p.Message = 2;
                }

            }

        }

        

        // I NEED TO MOVE FOLLOWING FUNCTIONS INTO UTILITY CLASS
        public bool CreateGraphVisualizationCSV(List<KeyValuePair<int,int>> DHG)
        {
            try
            {
                // Node List File
                //id label   timeset color
                //0   A               TRUE
                //1   B

                // Edge List File
                //Source Target  Type       id         label timeset weight
                // 0      1     Undirected  0                          1

                string nodeFileHeader = "id,label,timeset,ProbablityClass,Freq";
                string edgeFileHeader = "Source,Target,Type,id,label,timeset,weight";

                
                int maxCount = 0;
                List<string> tempList;


                lock (_Util.Locker)
                {
                    _Util.totalIterations = DHG.Count;
                    _Util.completedIterations = 0;
                    _Util.functionNameForProgressMsg = "CreateGraphVisualizationCSV";
                }

                string path = _Util.commonPath + "\\" + _Util.CreateFolderPath() + "\\DHGs";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                long count = 0;

                _Graph tempDHG;

                FileStream fileStream;
                StreamWriter streamWriter = null;

                string tempNodeLine = "";

                bool qualify = false;

                Hashtable edges;

                
                foreach (KeyValuePair<int, int> dhg in DHG)
                {

                    StringBuilder Nodeline = new StringBuilder();
                    StringBuilder Edgeline = new StringBuilder();
                    edges = new Hashtable();

                    fileStream = new FileStream(path + "\\" + dhg.Key.ToString() + "_" + dhg.Value.ToString() + "-NodeList.csv", FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                    streamWriter.WriteLine(nodeFileHeader);
                    streamWriter.Close();
                    fileStream = new FileStream(path + "\\" + dhg.Key.ToString() + "_" + dhg.Value.ToString() + "-EdgeList.csv", FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                    streamWriter.WriteLine(edgeFileHeader);
                    streamWriter.Close();

                    tempDHG = _WindowsDifferences[dhg.Key - 1];

                    List<NodeInfo> tempNodeList = tempDHG._NodeList;
                    NodeInfo tempNode;
                    Hashtable tempAdjacencyList = tempDHG._AdjucencyList;
                    
                    string probablityClass;
                    int edgeID = 0;
                    
                    qualify = false;
                    for ( int i = 0; i < tempNodeList.Count; i++)
                    {
                        tempNode = tempNodeList[i];
                        probablityClass = "";

                        //if (dhg.Value == 0)
                        //{
                        //    if (tempNode.NodeWeight > 1)
                        //        probablityClass = "TRUE";
                        //    else
                        //        probablityClass = "FALSE";
                        //}
                        //else if (tempNode.NodeWeight > 0)
                        //    probablityClass = "TRUE";
                        //else
                        //    probablityClass = "FALSE";

                        
                        if (tempNode.NodeWeight >= 1)
                            probablityClass = "TRUE";
                        else
                            probablityClass = "FALSE";
                        
                        if ( tempAdjacencyList.ContainsKey(i) && ((Hashtable)tempAdjacencyList[i]).Count < 25 && tempNode.NodeName.Length > 2) // if node has edges
                        {
                            qualify = true;
                            tempNodeLine = i.ToString() + "," + tempNode.NodeName + ",," + probablityClass + "," + tempNode.NodeWeight.ToString();

                            fileStream = new FileStream(path + "\\" + dhg.Key.ToString() + "_" + dhg.Value.ToString() + "-NodeList.csv", FileMode.Append, FileAccess.Write);
                            streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                            streamWriter.WriteLine(tempNodeLine);
                            streamWriter.Close();

                        }
                        else
                        {
                            int dummy = 0;
                        }

                        Hashtable tempEdgeList;
                        


                        
                        if (qualify) // if node has edges
                        {
                            tempEdgeList = (Hashtable)tempAdjacencyList[i];

                            fileStream = new FileStream(path + "\\" + dhg.Key.ToString() + "_" + dhg.Value.ToString() + "-EdgeList.csv", FileMode.Append, FileAccess.Write);
                            streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                            foreach (int targetNodeID in tempEdgeList.Keys)
                            {
                                // "Source,Target,Type,id,label,timeset,weight"
                                //Edgeline.AppendLine(sourceNodeID.ToString()+","+targetNodeID.ToString()+","+ "Undirected,"+edgeID.ToString()+",,,"+ ((EdgeInfo)(tempEdgeList[targetNodeID])).UserWeight.ToString());
                                if ( !(edges.ContainsKey(i.ToString() + "," + targetNodeID.ToString()) || edges.ContainsKey(targetNodeID.ToString() + "," + i.ToString())))
                                {
                                    edges.Add(i.ToString() + "," + targetNodeID.ToString(),0);
                                    edges.Add(targetNodeID.ToString() + "," + i.ToString(), 0);

                                    string temp = i.ToString() + "," + targetNodeID.ToString() + "," + "Undirected," + (edgeID++).ToString() + ",,," + ((EdgeInfo)(tempEdgeList[targetNodeID])).UserWeight.ToString();
                                    streamWriter.WriteLine(temp);

                                }

                            }

                            streamWriter.Close();

                        }

                    }

                    
                    //fileStream = new FileStream(path + "\\" + dhg.Key.ToString() + "_" + dhg.Value.ToString() + "-EdgeList.csv", FileMode.Create, FileAccess.Write);

                    //streamWriter.Write(edgeFileHeader + "\n" + Edgeline);

                    streamWriter.Close();


                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                } // end of loop DHG
                
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        
        public bool CreateUserInfoInEachSlidingWindowCSV(string fileName)
        {
            try
            {
                List<List<string>> allUserListInEacgSlidingWindows = new List<List<string>>();
                StringBuilder line = new StringBuilder();

                int maxCount = 0;
                List<string> tempList;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = _WindowsDifferences.Count;
                    _Util.functionNameForProgressMsg = "CreateUserInfoInEachSlidingWindowCSV (Creating TempList)";
                }

                long count = 0;
                foreach (_Graph g in _WindowsDifferences)
                {
                    tempList = g.CreateEachUsersTweetAndWordCountForCSV();
                    allUserListInEacgSlidingWindows.Add(tempList);

                    if (tempList.Count > maxCount)
                        maxCount = tempList.Count;

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                }

                count = 0;
                lock (_Util.Locker)
                {
                    _Util.totalIterations = maxCount;
                    _Util.functionNameForProgressMsg = "CreateUserInfoInEachSlidingWindowCSV (Writing)";
                }

                for (int i = 0; i < maxCount; i++)
                {
                    for (int j = 0; j < allUserListInEacgSlidingWindows.Count; j++)
                    {
                        if (i < allUserListInEacgSlidingWindows[j].Count)
                            line.Append(allUserListInEacgSlidingWindows[j][i]);
                        else
                            line.Append(",,,,");

                    }
                    line.AppendLine();

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                }

                string path = _Util.commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.Write(line);

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool CreateSlidingWindowsFeaturesCSV(string fileName)
        {

            // Need to change this, following code is the duplicate of function (Name: CreateCentralityScoreCSV, and Line# 967)
            // change the following code in favor of writing Sliding-windows features as in Degree_Centrality_Score.xls of FA_Caup
            float negFreqAgg = 0;
            float posFreqAgg = 0;

            try
            {
                List<string> stringList = new List<string>();

                StringBuilder slidingWindowFeatureString = new StringBuilder();
                slidingWindowFeatureString.AppendLine("Window No,S_Time,E_Time,Node Freq,Neg Prob, Pos Prob,Centrality,Node Count,Tweet Count,User Count, Execution Time");

                int maxCount = 0;
                List<string> tempList;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = _WindowsDifferences.Count;
                    _Util.functionNameForProgressMsg = "CreateSlidingWindowsFeaturesCSV";
                }

                int count = 0;

                float tempAggregatedNodesFre = 0;
                float tempAggregatedCentrality = 0;
                
                foreach (_Graph g in _WindowsDifferences)
                {
                    count++;   
                    foreach (KeyValuePair<int,float> pair in g._CenteralityScores)
                    {
                        tempAggregatedNodesFre += g._NodeList[pair.Key].NodeWeight;

                        // saperating -ve and +ve frequencies
                        if (g._NodeList[pair.Key].NodeWeight <= 0)
                            negFreqAgg += g._NodeList[pair.Key].NodeWeight;
                        else
                            posFreqAgg += g._NodeList[pair.Key].NodeWeight;


                        tempAggregatedCentrality += pair.Value;

                        
                    }

                    negFreqAgg = Math.Abs(negFreqAgg);

                    slidingWindowFeatureString.AppendLine(count.ToString() + "," + 
                                                      g._WindowStartTime.ToString() + "," + 
                                                      g._WindowEndTime.ToString() + "," +
                                                      tempAggregatedNodesFre.ToString() + "," +
                                                      (negFreqAgg / (negFreqAgg + posFreqAgg)).ToString() + "," +
                                                      (posFreqAgg / (negFreqAgg + posFreqAgg)).ToString() + "," +
                                                      tempAggregatedCentrality.ToString() + "," +
                                                      g._NodeList.Count.ToString() + "," +
                                                      g.TotalTweets.ToString() + "," +
                                                      g._UserList.Count.ToString() + "," +
                                                      g._ExecutionTime.ToString()
                                                      );

                    tempAggregatedCentrality = 0;
                    tempAggregatedNodesFre = 0;
                    negFreqAgg = 0;
                    posFreqAgg = 0;

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = count;
                    }

                } // end of main foreach loop (i.e. g in _WindowsDifferences

                count = 0;
                lock (_Util.Locker)
                {
                    _Util.completedIterations = _WindowsDifferences.Count;
                    _Util.functionNameForProgressMsg = "CreateCentralityScoreCSV (Writing)";
                }
                
                string path = _Util.commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.Write(slidingWindowFeatureString);

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }


            return true;
        }

        public bool CreateNetworkNodeFrequencyDistribution(string fileName)
        {
            try
            {
                List<List<string>> allNetworkNodeFrequency = new List<List<string>>();
                StringBuilder line = new StringBuilder();

                int maxCount = 0;
                List<string> tempList;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = _SlidingWindowsGraphs.Count;
                    _Util.functionNameForProgressMsg = "CreateNetworkNodeFrequencyDistribution";
                }

                long count = 0;

                foreach (_Graph g in _SlidingWindowsGraphs)
                {
                    // see if g.GetSortedCetralNodesForCSV has Quick sort implemented, if NOT then do it
                    tempList = new List<string>();

                    tempList.Add(g._WindowStartTime.ToString() + "," + g._WindowEndTime.ToString()+",,");
                    tempList.Add("Node Name, Frequency,,");

                    foreach (NodeInfo n in g._NodeList)
                    {
                        tempList.Add(n.NodeName + "," + n.NodeWeight.ToString()+",,");

                    }

                    allNetworkNodeFrequency.Add(tempList);

                    if (tempList.Count > maxCount)
                        maxCount = tempList.Count;

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }
                    
                }

                count = 0;
                lock (_Util.Locker)
                {
                    _Util.totalIterations = maxCount;
                    _Util.functionNameForProgressMsg = "CreateNetworkNodeFrequencyDistribution (Writing to file now)";
                }

                for (int i = 0; i < maxCount; i++)
                {
                    for (int j = 0; j < allNetworkNodeFrequency.Count; j++)
                    {
                        if (i < allNetworkNodeFrequency[j].Count)
                            line.Append(allNetworkNodeFrequency[j][i]);
                        else
                            line.Append(",,,");

                    }
                    line.AppendLine();

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                }

                string path = _Util.commonPath + "\\" + _Util.CreateFolderPath();

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);

                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.Write(line);

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool CreateCentralityScoreCSV(string fileName)
        {
            try
            {
                List<List<string>> allGraphsCentralityScore = new List<List<string>>();
                
                StringBuilder line = new StringBuilder();

                int maxCount = 0;
                List<string> tempList;

                lock (_Util.Locker)
                {
                    _Util.totalIterations = _WindowsDifferences.Count;
                    _Util.functionNameForProgressMsg = "CreateCentralityScoreCSV (Creating TempList)";
                }

                long count = 0;

                foreach (_Graph g in _WindowsDifferences)
                {
                    // see if g.GetSortedCetralNodesForCSV has Quick sort implemented, if NOT then do it
                    tempList = g.GetSortedCentralNodesForCSV();
                    allGraphsCentralityScore.Add(tempList);

                    if (tempList.Count > maxCount)
                        maxCount = tempList.Count;

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                }

                count = 0;
                lock (_Util.Locker)
                {
                    _Util.totalIterations = maxCount;
                    _Util.functionNameForProgressMsg = "CreateCentralityScoreCSV (Writing)";
                }

                for (int i = 0; i < maxCount; i++)
                {
                    for (int j = 0; j < allGraphsCentralityScore.Count; j++)
                    {
                        if (i < allGraphsCentralityScore[j].Count)
                            line.Append(allGraphsCentralityScore[j][i]);
                        else
                            line.Append(",,,,");
                        
                    }
                    line.AppendLine();

                    lock (_Util.Locker)
                    {
                        _Util.completedIterations = ++count;
                    }

                }

                string path = _Util.commonPath + "\\" + _Util.CreateFolderPath();
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileStream = new FileStream(path+"\\" + fileName, FileMode.Create, FileAccess.Write);
                
                var streamWriter = new StreamWriter(fileStream, Encoding.UTF8);

                streamWriter.Write(line);

                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
            
        }

    }
}
