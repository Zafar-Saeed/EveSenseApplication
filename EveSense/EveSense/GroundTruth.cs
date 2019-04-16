using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveSense
{
    
    class GroundTruth
    {

        public GroundTruth()
        {
            TimeSlot = new Hashtable();

        }
        public Hashtable TimeSlot
        {
            get; set;
        }

        public void LoadGroundTruth(string[] groundTruthFiles)
        {
            try
            {
                foreach (string path in groundTruthFiles)
                {
                    this.AddSlidingWindow(path);
                }
            }
            catch (Exception ex)
            {
                 throw new Exception("Error Occured during loading ground truth files\n" + ex.ToString());
            }
        }

        public bool AddSlidingWindow(string filePath)
        {
            ActualTopics topics;
            try
            {
                if (filePath.Length > 0)
                {
                    string[] readLines = File.ReadAllText(filePath).Split(new char[] { '\n' });
                    topics = new ActualTopics();
                    topics.LoadMendatoryWords(readLines[0].Trim());
                    if (readLines.Length > 1)
                        topics.LoadOptionalWords(readLines[1].Trim());
                    else
                        topics.LoadOptionalWords("");

                    TimeSlot.Add(Path.GetFileName(filePath), topics);
                }
                return true;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
    }  
}
