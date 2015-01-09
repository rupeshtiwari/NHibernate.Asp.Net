using FluentNHibernate.Mapping;
using NHibernate.Linq;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class TestletSegmentMap : SubclassMap<TestletSegment>
    {
        public TestletSegmentMap()
        {
            Join("Segment", j =>
            {
                j.KeyColumn("Id");
                j.Component(m => m.TestletId, d => d.Map(f => f.TestletGuid));
            });
        }
    }
}