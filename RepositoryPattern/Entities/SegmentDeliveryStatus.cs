namespace RepositoryPattern.Entities
{
    public class SegmentDeliveryStatus  
    {
        #region Properties

        public virtual bool IsSubmitted { get; private set; }
        public virtual SegmentSubmittedReason SubmittedReason { get; private set; }
        public virtual bool IsLocked { get; private set; }
        public virtual int DeliveryCount { get; private set; }

        public bool IsInProgress
        {
            get { return !IsSubmitted; }
        }

        public bool IsCompletedSuccessfully
        {
            get
            {
                return (IsSubmitted
                        && SubmittedReason.Equals(SegmentSubmittedReason.CompletedSuccessfully));
            }
        }
        #endregion

        #region Constructors

        public SegmentDeliveryStatus()
        {
        }

        public SegmentDeliveryStatus(bool isSubmitted, SegmentSubmittedReason submittedReason, bool isLocked)
        {
            IsSubmitted = isSubmitted;
            SubmittedReason = submittedReason;
            IsLocked = isLocked;
            DeliveryCount = 0;
        }

        #endregion

        #region Object's overrides
 

        #endregion

        public bool IsSubmittedWith(SegmentSubmittedReason thisReason)
        {
            return SubmittedReason.Equals(thisReason);
        }

        public SegmentDeliveryStatus Locked()
        {
            return new SegmentDeliveryStatus(IsSubmitted, SubmittedReason, true);
        }

        public SegmentDeliveryStatus Returned()
        {
            return ResetDeliveryStatus();
        }

        public SegmentDeliveryStatus SubmitWith(SegmentSubmittedReason reason)
        {
           
            return new SegmentDeliveryStatus(true, reason, IsLocked);
        }

        public SegmentDeliveryStatus DeliveredNew()
        {
            return ResetDeliveryStatus();
        }

        public SegmentDeliveryStatus UndoTimeout()
        {
            return ResetDeliveryStatus();
        }

        public SegmentDeliveryStatus ResumedFromUnscheduledBreak()
        {
            return ResetDeliveryStatus();
        }

        public SegmentDeliveryStatus UndoAuthenticationError()
        {
            return ResetDeliveryStatus();
        }

        private static SegmentDeliveryStatus ResetDeliveryStatus()
        {
            return new SegmentDeliveryStatus(false, SegmentSubmittedReason.NotSet, false);
        }

    }
}