using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhgDataProcessor
{
    class ExtractionConfigration
    {
        public int ExpiryTime { get; set; }
        public Filter FilterationCriteria { get; set; }
        public CentralityMeasure Measure { get; set; }
        public EdgeWeightCriteria WeightCriteria { get; set; }
        public DuplicateTweetCriteria TweetMatchingCriteria { get; set; }
        public Hashtable filterWordList { get; set; }
        public string DataSetFilePath { get; set; }
        public bool UserMatchFlag { get; set; }
        public int minWordLength { get; set; }
        public bool WeightedEdgeFlag { get; set; }
        public bool IsDataCleaned { get; set; }
        public bool IsStemmingOn { get; set; }
        public bool IsDHGWriterOn { get; set; }
        public bool WeightedNodeFlag { get; set; }
        public TimeUnitExpiry ExpiryTimeUnit { get; set; }
        public bool IsAppRootPath { get; set; }



        private static ExtractionConfigration _config = null;

        public static ExtractionConfigration GetConfiguration
        {
            get
            {
                if (_config == null)
                    _config = new ExtractionConfigration();

                return _config;
            }
        }
        private ExtractionConfigration()
        {
            filterWordList = null;

        }
    }
}
