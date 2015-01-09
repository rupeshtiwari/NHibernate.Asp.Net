using System;
using NHibernate;
using RepositoryPattern.Entities;

namespace RepositoryPattern.SqlNhibernate
{
    public class ExamHistorySqlRepository : BaseSqlRepository<ExamHistory> 
    {
        public ExamHistorySqlRepository(ISession session)
            : base(session)
        {
        }

        public ExamHistory Get(ExamSectionId examSectionId)
        {
            return Get(x => x.ExamSectionId.ExamGuid == examSectionId.ExamGuid);
        }

        public ExamHistoryId GetNextIdentity()
        {
            return new ExamHistoryId(Guid.NewGuid().ToString());
        }

        public void Save(ExamHistory examHistory)
        {
            SaveOrUpdate(s => s.ExamSectionId.ExamGuid == examHistory.ExamSectionId.ExamGuid, examHistory);
        }
    }
}