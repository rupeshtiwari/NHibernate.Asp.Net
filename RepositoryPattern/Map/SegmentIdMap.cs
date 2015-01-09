using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class SegmentIdMap : ComponentMap<SegmentId>
    {
        public SegmentIdMap()
        {
            Map(x => x.SegmentGuid);
        }
    }
}