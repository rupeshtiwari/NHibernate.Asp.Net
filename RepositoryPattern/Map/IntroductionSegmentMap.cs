using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class IntroductionSegmentMap : SubclassMap<IntroductionSegment>
    {
        public IntroductionSegmentMap()
        {
            Join("Segment", j =>
            {
                j.KeyColumn("Id");
                j.Map(m => m.AreTermsAccepted);
            });
        }
    }
}