using System;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class SegmentSubmitted : SegmentEvent
    {

        internal SegmentSubmitted()
        {

        }

        public SegmentSubmitted(Segment segment)
            : base(segment)
        {

        }

        
    }
}