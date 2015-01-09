using System;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public abstract class SegmentEvent : DomainEvent
    {
        public virtual ExamSectionId ExamSectionId { get; set; }
        public virtual SegmentDeliveryStatus SegmentDeliveryStatus { get; set; }
        public virtual SegmentId SegmentId { get; set; }
        public virtual SegmentType SegmentType { get; set; }

        protected SegmentEvent()
        {

        }
        protected SegmentEvent(Segment segment)
        {
            ExamSectionId = segment.ExamSectionId;
            SegmentDeliveryStatus = segment.DeliveryStatus;
            SegmentId = segment.SegmentId;
            SegmentType = segment.SegmentType;
        }

        public bool IsOfSegmentType(SegmentType segmentType)
        {
            return SegmentType.Equals(segmentType);
        }

        public bool HasSegmentId(SegmentId segmentId)
        {
            return segmentId.Equals(SegmentId);
        }
    }
}