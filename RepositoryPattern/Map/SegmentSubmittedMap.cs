using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class SegmentSubmittedMap : SubclassMap<SegmentSubmitted>
    {
        public SegmentSubmittedMap()
        {
            Join("SegmentEvents", k =>
            {
                k.Component(m => m.ExamSectionId);
                k.Component(m => m.SegmentDeliveryStatus);
                k.Component(m => m.SegmentId);
                k.Map(m => m.SegmentType).CustomType<SegmentTypeString>();
            });
        }
    }
}