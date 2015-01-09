using System;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class IntroductionSegment : Segment
    {
        private bool _areTermsAccepted;

        public virtual bool AreTermsAccepted
        {
            get { return _areTermsAccepted; }
            protected internal set { _areTermsAccepted = value; }
        }

        public IntroductionSegment(SegmentId segmentId, ExamSectionId examSectionId)
            : base(segmentId, examSectionId)
        {
            _areTermsAccepted = true;
        }
        
        internal IntroductionSegment()
        {

        }

        public override SegmentType SegmentType
        {
            get { return SegmentType.Introduction; }
        }

        public virtual void AcceptTerms()
        {
          
            AreTermsAccepted = true;

        }

       
    }
}