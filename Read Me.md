	

/***********************************/
EveSense Event Detection Application
/***********************************/

	1- The source code is for the use of academic and research purposes only
	2- Demo Video is available at https://www.youtube.com/watch?v=YRMRc8tIupA
	3- Please report bugs and issues directly to zsaeed@cs.qau.edu.pk
	4- You need to have .Net framework 4.0 or later installed on the system
	5- There are two application projects

		5.1. DHG-Data-Processor
		5.2. EveSense


-----------------------
5.1- DHG-Data-Processor
-----------------------

- It's a background processing unit. It processes the dataset and extract all necessary features required to detect events and its related trending topics

- Dataset must be in .CSV (if not cleaned) with comma (,) seperated, or in .txt with tab seperated (if cleaned) with the following sequence of features:


CSV Format (Feature Set in Raw Dataset):

            //0  = User
            //1  = UserID
            //2  = UserTweets
            //3  = UserFavorites
            //4  = UserListed
            //5  = UserFollowers
            //6  = UserFriends
            //7  = UserSince
            //8  = UserSince(Year)
            //9  = UserLanguage
            //10 = UserLocation
            //11 = UserTimezone
            //12 = UserUTCOffset
            //13 = TimeOfTweet
            //14 = TweetLanguage
            //15 = TweetApp
            //16 = TweetLocation
            //17 = IsRetweet
            //18 = TweetID
            //19 = TweetURL
            //20 = Tweet
	    

Txt Format (Feature Set in Clean Dataset):

            //0 = TimeOfTweet
            //1  = UserID
            //2 = Tweet


- Load the dataset by clicking load button on the interface, and set all the configuration settings for the extraction and click process

- The extractor produces following files in the app root folder:
	
		1- Degree_Centrality_Scores.csv	
		2- Sliding_Windows_Features.csv
		3- UserInfoInEachSlidingWindow.csv
		4- UserTweetDistribution.csv
		5- WordDistribution.csv
		6- WordTweetUserDistribution.csv


------------------
5.2 EveSense
------------------

- Load all features files produced previously by DHG-Data-Processor, and click "Process"
- Explore self explainatory UI to optimize the results and visualization.
- The performance results are saved in the app root folder of EveSense



For any questions or requests, please contact any of the following co-authors of the paper: Saeed Z. OR Ayaz Abbasi R.


-----------------
For the citation:
-----------------

Saeed Z., Ayaz Abbasi R., Razzak I. (2020) EveSense: What Can You Sense from Twitter?. In: Jose J. et al. (eds) Advances in Information Retrieval. ECIR 2020. Lecture Notes in Computer Science, vol 12036. Springer, Cham

-----------------------------------------------------------------------------------
Dynamic Heartbeat Graph (DHG) approach, please read the following technical papers:
-----------------------------------------------------------------------------------

Saeed, Z., Abbasi, R. A., Razzak, M. I., Maqbool, O., Sadaf, A., and Xu, G. (2019). Enhanced Heartbeat Graph for emerging event detection on Twitter using time series networks, Expert Systems with Applications, 136:115-132.

Saeed, Z., Abbasi, R. A., Razzak, M. I., and Xu, G. (2019). Event detection in Twitter stream using weighted dynamic heartbeat graph approach, IEEE Computational Intelligence Magazine, 14(3):29-38.
