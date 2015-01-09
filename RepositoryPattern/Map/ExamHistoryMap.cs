using System.Text;
using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class ExamHistoryMap : SubclassMap<ExamHistory>
    {
        public ExamHistoryMap()
        {
            Join("ExamHistory", k =>
            {
                k.KeyColumn("Id");

                HasMany(x => x.Entries).AsSet().Component(e =>
                {
                    e.Map(d => d.OccurredOn);
                    e.Map(d => d.Order);
                    Table("HistoryEntries");
                });

                k.Map(d => d.TotalEntry);
                k.Component(x => x.ExamSectionId, m => m.Map(d => d.ExamGuid));
                k.Component(x => x.HistoryId, m => m.Map(d => d.ExamHistoryGuid));
            });
        }
    }

    public class DomainEventMap : ComponentMap<DomainEvent>
    {

    }
}
