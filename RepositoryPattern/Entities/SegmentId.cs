using System;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class SegmentId  
    {
        public virtual string SegmentGuid { get; protected internal set; }
        public static readonly int MaximumLength = 4000;

        internal SegmentId()
        { }

        public SegmentId(string segmentGuid)
        {
            SegmentGuid = segmentGuid;
        }
    }
}