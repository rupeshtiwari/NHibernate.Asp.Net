using FluentNHibernate.Mapping;
using NHibernate.Linq;
using NHibernate.Type;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public sealed class SegmentEventMap : SubclassMap<SegmentEvent>
    {
        public SegmentEventMap()
        {
            Component(m => m.ExamSectionId);
            Component(m => m.SegmentDeliveryStatus);
            Component(m => m.SegmentId);
            Map(m => m.SegmentType).CustomType<SegmentTypeString>();
        }
    }

    public class SegmentTypeString : EnumStringType<SegmentType>
    {

    }
}