using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    public enum CandidateSelection
    {
        HEARTBEAT = 0,
        FEATURES_BASED_UNION = 1,
        SELECT_ALL = 2
    };

    public class Config
    {
        public double AdjustmentParameter { get; set; }
        public int TopK { get; set; }
        public bool IsGF { get; set; }
        public bool IsTP { get; set; }
        public bool IsDC { get; set; }
        public string FileName { get; set; }
        public bool IsDTFRanking { get; set; }
        public bool IsDCRanking { get; set; }
        public bool IsRankingFused { get; set; }
        // add adjustment coefficients in case of linear combination of feature set and ranking machanism

        //0 => Heartbeat
        //1 => Feature-based Union
        //2 => Select All DHGs as candidate
        public CandidateSelection CandidateSelectionCriteria { get; set; }
        
    }
}
