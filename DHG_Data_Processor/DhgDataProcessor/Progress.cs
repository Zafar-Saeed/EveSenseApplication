using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    // singlton class for keep tracking of the progress and showing it on the screen using thread
    class _Progress
    {
        public int Activity { get; set; }
        public int Message { get; set; }

        private string[][] messages;
        private string[] activities;

        private static _Progress progress;

        private _Progress()
        {
            Activity = 0;
            Message = 0;

            activities = new string[]
            {
                "Initializing: ", // index 0
                "Detector: ", //  index 1
                "Filtration: ", // index 2
                "Bag of Words: ", // index 3
                "Cleansing Data: ", // index 4
                "Utility: ", // index 5
                "Completed: ", // index 6
                "Parsing: " // index 7

                

            };

            messages = new string[][]
            { 
                // 
                new string[]
                {
                    "Processing..." // index 0,0
                },

                // Detector Messages
                new string[]
                {
                    "Calculating Sliding Windows Differences...", // index 1,0
                    "Successfully calculated sliding windows differences...", // index 1,1
                    "There is only one sliding window graph, therefore cannot process...", // index 1,2
                    "Extracting graphs...", // index 1,3
                    "Calculating Degree Centralities of all sliding differences..." // index 1,4
                },

                // Filtration Messages
                new string[]
                {
                    "Adding tweet to clean dataset...", // index 2,0
                    "Removing keywords those qualitfy as stop words...", // index 2,1
                    "Removing Duplicate Tweets..." // index 2,2
                    
                },

                // Bag of Words Messages
                new string[]
                {
                    "Adding keywords to Bag of Words..." // index 3,0
                    
                },

                new string[]
                {
                    "Cleaning Tweets...", // index 4,0
                    "Reversing data set with respect to tweet date time", // index 4,1
                    "Writing cleaned data to the file.." // index 4,2
                    
                },

                // Utility
                new string[]
                {
                    "Reversing data order...", // index 5,0
                    "Writing clean dataset to file...", // index 5,1
                    "Writing word distribution to CSV file...", // index 5,2
                    "Writing data file for centrality score of all sliding differences...", // index 5,3
                    "Writing Removed (Duplicate) Tweets...", // index 5,4
                    "Writing UserInfo in each sliding window...", // index 5,5
                    "Writing User-Tweet distribution to CSV file...", // index 5,6
                    "Writing Word-Tweet-User distribution to CSV file...", // index 5,7
                    "Writing Sliding-Windows features (i.e. UserCount, TweetCount, NodeFreq, DegreeCentrality, Start and End Time)...", // index 5,8
                    "Writing DHG files for Visualization",  // index 5,9
                    "Writing term frequency distribution of each network"  // index 5,10

                    
                },
                new string[]
                {
                    "Completed..." // index 6,0
                },
                new string[]
                {
                    "Extracting dataset facts..." // index 7,0
                }

            };

        }

        public string GetMessage(int activityIndex, int messageIndex)
        {
            if (activityIndex > activities.Length - 1 || messageIndex > messages[activityIndex].Length - 1)
                return "Invalid Index for activity or message";
            return activities[activityIndex] +": " + messages[activityIndex][messageIndex];
        }

        public static _Progress GetProgress
        {
            get
            {
                if (progress == null)
                {
                    progress = new _Progress();
                    return progress;
                }
                else
                    return progress;
            }
        }
    }

}
