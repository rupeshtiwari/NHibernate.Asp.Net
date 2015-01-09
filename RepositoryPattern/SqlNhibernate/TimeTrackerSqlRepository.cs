using System;
using NHibernate;
using RepositoryPattern.Entities;

namespace RepositoryPattern.SqlNhibernate
{
    public class TimeTrackerSqlRepository :BaseSqlRepository<TimeTracker>
    {
        public TimeTrackerSqlRepository(ISession session) : base(session)
        {
        }

        public TimeTracker Get(TimeTrackerId timeTrackerId)
        {
            return Get(x => x.TimeTrackerId.TimeTrackerGuid == timeTrackerId.TimeTrackerGuid);
        }

        public void Save(TimeTracker timeTracker)
        {
            SaveOrUpdate(x => x.TimeTrackerId == timeTracker.TimeTrackerId, timeTracker);
        }

        public TimeTrackerId GetNextIdentity()
        {
            return new TimeTrackerId(Guid.NewGuid().ToString());
        }
    }
}