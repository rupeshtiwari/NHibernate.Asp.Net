using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class ExamHistory : Entity
    {
        private ISet<DomainEvent> _entries;
        private int _totalEntry;
        private ExamHistoryId _historyId;
        private ExamSectionId _examSectionId;

        public virtual int TotalEntry
        {
            get { return _totalEntry; }
            protected internal set { _totalEntry = value; }
        }

        public virtual ExamHistoryId HistoryId
        {
            get { return _historyId; }
            protected internal set { _historyId = value; }
        }

        public virtual ExamSectionId ExamSectionId
        {
            get { return _examSectionId; }
            protected internal set { _examSectionId = value; }
        }

        public virtual ISet<DomainEvent> Entries
        {
            get { return _entries; }
            protected internal set { _entries = value; }
        }
        internal ExamHistory()
        {
            
        }
        public ExamHistory(ExamHistoryId historyId, ExamSectionId examSectionId)
        {
            _historyId = historyId;
            _examSectionId = examSectionId;
            _totalEntry = 0;
            _entries=new HashedSet<DomainEvent>();
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return ExamSectionId;
        }
    }
}
