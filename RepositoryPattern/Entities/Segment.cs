using System;
using System.Collections.Generic;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public abstract class Segment:Entity {
 
        public virtual SegmentId SegmentId { get; protected internal set; }
        public virtual ExamSectionId ExamSectionId { get; protected internal set; }
        public virtual string SegmentName { get; set; }
        public abstract SegmentType SegmentType { get; }
        public virtual SegmentDeliveryStatus DeliveryStatus { get; protected set; }
        internal Segment()
        {
        }
        protected Segment(SegmentId segmentId , ExamSectionId examSectionId)
        {
            SegmentId = segmentId;
            ExamSectionId = examSectionId;
            DeliveryStatus = new SegmentDeliveryStatus();
        }
        public virtual void Submit(SegmentSubmittedReason reason)
        {
            DeliveryStatus = DeliveryStatus.SubmitWith(reason);
        }
        protected override IEnumerable<object> GetIdentityComponents()
        {
            return new List<string>().ToArray();
        }

    }
}