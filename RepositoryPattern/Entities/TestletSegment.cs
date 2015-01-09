using System.Collections.Generic;

namespace RepositoryPattern.Entities
{
    public class TestletSegment : Segment
    {
        public virtual TestletId TestletId { get; protected internal set; }

        public virtual void AssignTestletContent(TestletId id)
        {
            TestletId = id;
        }


        internal TestletSegment()
        {
            
        }
        public TestletSegment(SegmentId id, ExamSectionId examSectionId)
            : base(id, examSectionId)
        {
        }
        
      
     
        public override SegmentType SegmentType
        {
            get { return Entities.SegmentType.Testlet; }
        }
    }
}