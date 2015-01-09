using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace InHeritance
{
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable();
            Id(Reveal.Member<Animal>("Id"));
            Map(x => x.Family);
        }
    }
}