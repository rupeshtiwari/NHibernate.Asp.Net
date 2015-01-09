using FluentNHibernate.Mapping;
using NHibernate.Type;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    
    public sealed class SegmentMap : SubclassMap<Segment>
    {
        public SegmentMap()
        {
            Map(x => x.SegmentName);
            Component(x => x.SegmentId);
            Component(x => x.ExamSectionId);
            Component(x => x.DeliveryStatus);
        }
    }

    public class SegmentSubmittedReasonString : EnumStringType<SegmentSubmittedReason>
    {
    }

   
}