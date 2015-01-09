using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class TimeTrackerMap : SubclassMap<TimeTracker>
    {
        public TimeTrackerMap()
        {
            Join("TimeTracker", k =>
            {
                k.Map(x => x.TimeRemainingInSecondsToStartAcceleration);
                k.Map(x => x.IntervalInSeconds);
                k.Component(x => x.TimeTrackerId, m => m.Map(d => d.TimeTrackerGuid));
                k.Component(x => x.ExamSectionId, m => m.Map(d => d.ExamGuid));
            });
        }
    }
}