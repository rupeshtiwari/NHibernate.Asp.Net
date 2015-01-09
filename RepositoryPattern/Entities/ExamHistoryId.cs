using System;
using System.Collections.Generic;

namespace RepositoryPattern.Entities
{
    [Serializable]
    public class ExamHistoryId  
    {
        public virtual string ExamHistoryGuid { get; private set; }

        internal ExamHistoryId() { }

        public ExamHistoryId(string examHistoryGuid)
        {
            ExamHistoryGuid = examHistoryGuid;
        }
    }
}