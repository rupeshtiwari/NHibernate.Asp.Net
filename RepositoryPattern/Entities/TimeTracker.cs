using System;
using System.Collections.Generic;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class TimeTracker : Entity
    {
        private TimeTrackerId _timeTrackerId;
        private ExamSectionId _examSectionId;

        public virtual TimeTrackerId TimeTrackerId
        {
            get { return _timeTrackerId; }
            protected internal set { _timeTrackerId = value; }
        }

        public virtual ExamSectionId ExamSectionId
        {
            get { return _examSectionId; }
            protected internal set { _examSectionId = value; }
        }

        public virtual long TimeRemainingInSecondsToStartAcceleration { get; protected internal set; }
        public virtual long IntervalInSeconds { get; protected internal set; }

        internal TimeTracker()
        {
        }

        public TimeTracker(TimeTrackerId timeTrackerId, ExamSectionId examSectionId)
        {
            _timeTrackerId = timeTrackerId;
            _examSectionId = examSectionId;
        }

        #region Override Implementaions

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return TimeTrackerId;
        }

        #endregion

    }
}