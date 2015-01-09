using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class ExamSectionIdMap : ComponentMap<ExamSectionId>
    {
        public ExamSectionIdMap()
        {
            Map(x => x.ExamGuid);
        }
    }
}