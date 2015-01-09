using System.Collections.Generic;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using Iesi.Collections.Generic;
using RepositoryPattern.Entities;

namespace InHeritance
{
    public  class Entity
    {
        protected virtual int Id { get; set; }
    }

    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Id(Reveal.Member<Entity>("Id"));
            DiscriminateSubClassesOnColumn("EntityType");
            
        }
    }

    public class Segment:Entity
    {
        public virtual string SegmentName { get; set; }
    }

    public class SegmentMap : SubclassMap<Segment>
    {
        public SegmentMap()
        {
           Map(x => x.SegmentName);
        }
    }

    public class TestletSegment : Segment
    {
        private ISet<Item> _items;
        public virtual string TestletCounts { get; set; }
        public virtual TestletId TestletId { get; set; }

        public virtual ISet<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public TestletSegment()
        {
            _items = new HashedSet<Item>();
        }
    }

    public class TestletSegmentMap : SubclassMap<TestletSegment>
    {
        public TestletSegmentMap()
        {
            Join("Segment", x =>
            {
                x.KeyColumn("Id");
                x.Map(m => m.TestletCounts);
                x.Component(m => m.TestletId, d => d.Map(f => f.TestletGuid));
                x.HasMany(y => y.Items).Component(m =>
                {
                    m.Map(k => k.Name);
                    m.Map(k => k.Type);
                });
            });
        }
    }

    public class Item
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }

    public class ItemMap : ComponentMap<Item>
    {
        public ItemMap()
        {
            Map(x => x.Name);
            Map(x => x.Type);
        }
    }

}
