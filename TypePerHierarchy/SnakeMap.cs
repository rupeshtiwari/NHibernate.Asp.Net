using FluentNHibernate.Mapping;

namespace InHeritance
{
    public class SnakeMap : SubclassMap<Snake>
    {
        public SnakeMap()
        {
            DiscriminatorValue(@"Snake");
            Map(x => x.Length);
        }
    }
}