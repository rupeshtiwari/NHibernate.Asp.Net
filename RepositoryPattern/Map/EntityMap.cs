using FluentNHibernate;
using FluentNHibernate.Mapping;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Map
{
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            DiscriminateSubClassesOnColumn("EntityType");
            Id(Reveal.Member<Entity>("Id")).GeneratedBy.Native();
        }
    }
}