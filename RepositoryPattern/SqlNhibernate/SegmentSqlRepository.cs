using System;
using NHibernate;
using RepositoryPattern.Entities;
using RepositoryPattern.Entities.Interfaces;

namespace RepositoryPattern.SqlNhibernate
{
    public class SegmentSqlRepository : BaseSqlRepository<Segment>, ISegmentRepository
    {
        public SegmentSqlRepository(ISession session) : base(session)
        {
        }

        public Segment Get(SegmentId segmentId)
        {
            return Get(x => x.SegmentId.SegmentGuid == segmentId.SegmentGuid);
        }

        public SegmentId GetNextIdentity()
        {
            return new SegmentId(Guid.NewGuid().ToString());
        }

        public void Save(Segment segment)
        {
            SaveOrUpdate(s=>s.SegmentId.SegmentGuid==segment.SegmentId.SegmentGuid, segment);
        }
    }
}