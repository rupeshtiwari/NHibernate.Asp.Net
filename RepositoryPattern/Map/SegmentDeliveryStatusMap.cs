using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class SegmentDeliveryStatusMap : ComponentMap<SegmentDeliveryStatus>
    {
        public SegmentDeliveryStatusMap()
        {
            Map(d => d.DeliveryCount);
            Map(d => d.IsLocked);
            Map(d => d.IsSubmitted);
            Map(d => d.SubmittedReason).CustomType<SegmentSubmittedReasonString>();
        }
    }
}