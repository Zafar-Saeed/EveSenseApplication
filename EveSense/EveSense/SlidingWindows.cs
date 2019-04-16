using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EveSense
{
    public class SingleWindow
    {
        public SingleWindow(string timeID, List<string> dhgIDs)
        {
            TimeSlotID = timeID;
            DHGsIDs = new List<string>(dhgIDs);
            CandidateTopics = new CandidateTopics();
        }
        public double threshold { get; set; }
        public string TimeSlotID { get; set; }
        public CandidateTopics CandidateTopics { get; set; }
        public List<string> DHGsIDs { get; set; }

    }

   public class SlidingWindows
    {
        public SlidingWindows()
        {
            ListOfWindows = new List<SingleWindow>();
        }

        public List<SingleWindow> ListOfWindows { get; set; }

        public void LoadSlidingWindow(string filePath)
        {
            try
            {
                string[] readLines = File.ReadAllText(filePath).Split(new char[] { '\n' });

                foreach (string line in readLines)
                {
                    string[] segments = line.Trim().Split(new char[] { ';' }, line.Length, StringSplitOptions.RemoveEmptyEntries);

                    string[] candidateDHGs = segments[1].Split(new char[] { ',' });

                    ListOfWindows.Add(new SingleWindow(segments[0], candidateDHGs.ToList<string>()));

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to load SlidingWindow file\n" + ex);
            }
            
        }

        public SingleWindow GetWindow(string timeSlotID)
        {
            foreach (SingleWindow sw in ListOfWindows)
            {
                if (sw.TimeSlotID.Equals(timeSlotID))
                {
                    return sw;
                }
            }

            return null;
        }

        public string ContainsCandidateDHG(string DHG_No)
        {
            try
            {
                foreach(SingleWindow sw in ListOfWindows)
                {
                    if (sw.DHGsIDs.Contains(DHG_No))
                    {
                        return "Y$"+sw.TimeSlotID;
                    }
                }

                return "N";
            }
            catch(Exception ex)
            {
                return "N";
            }
        }

        public void AddCandidateTopicsToSpecificWindow(string timeSlotID, CandidateTopics candTopic)
        {

            int index = ListOfWindows.FindIndex(w => w.TimeSlotID.Equals(timeSlotID));
            if (index >= 0)
                ListOfWindows[index].CandidateTopics = candTopic;
            else
                throw new Exception("Given Time Slot does not exist in the Sliding Windows");
        }
    }
    
}
