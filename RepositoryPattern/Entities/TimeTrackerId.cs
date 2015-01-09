using System;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class TimeTrackerId  
    {
        public string TimeTrackerGuid { get; private set; }
        public static readonly int MaximumLength = 50;

        internal TimeTrackerId()
        {
        }

        public override string ToString()
        {
            return TimeTrackerGuid;
        }

        public TimeTrackerId(string timeTrackerGuid)
        {
            

            TimeTrackerGuid = timeTrackerGuid;
        }

      
    }
}