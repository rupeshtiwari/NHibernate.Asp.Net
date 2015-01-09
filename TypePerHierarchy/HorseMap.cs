using FluentNHibernate.Mapping;

namespace InHeritance
{
    public class HorseMap : SubclassMap<Horse>
    {
        public HorseMap()
        {
            DiscriminatorValue(@"Horse");
            Map(x => x.Speed);
        }
    }
}