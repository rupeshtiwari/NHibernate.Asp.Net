using FluentNHibernate.Mapping;

namespace InHeritance
{
    public class DogMap : SubclassMap<Dog>
    {
        public DogMap()
        {
            Component(x => x.DogId, m => m.Map(d => d.DogGuidId));
            DiscriminatorValue(@"Dog");
            Map(x => x.Breed);
        }
    }
}